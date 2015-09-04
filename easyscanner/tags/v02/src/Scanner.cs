using System;
using System.Collections.Generic;
using System.Text;
using SDRSharp.Common;

namespace SDRSharp.EasyScanner
{
    public enum ScannerState
    {
        Scan,
        StayTuned
    };

  public delegate void ScanNextFrequency(int MemoryIndex);
  public delegate void ScanNextFrequencyTimeLeft(double ScanTime, double WdogTime, ScannerState State);
  public delegate void ScanStateChanged(ScannerState OldState,ScannerState NewState);
 
  class Scanner
  {

    public enum ScannerCompareMode
    {
        PeakPowerFrequency,
        AvgPowerBandwidth,
        PeakPowerBandwidth
    };

    private const int _SCAN_TIMER_INTERVALL = 50;
    private const int _SIMPLE_AVERAGE_SAMPLE_CNT = 4;
    private const int _SIMPLE_AVERAGE_MIN = -140;
    private int _scanTime = 5000;
    private int _scannerTimerTickCnt = 0;
    private int _scannerTimerTickCntLastFreqChange = 0;
    private int _scanIndex = 0;
    private float _scannerCompareRxLevel = _SIMPLE_AVERAGE_MIN;
    private int _scannerStayTunedCnt = 0;
    private int _tresholdReleaseTime = 0;
    private bool _scanDisable = false;
    private bool _wdogTimerEnable = false;
    private int _wdogTime = 5000;
    private int _wdogTimeTickCnt = 0;
    
    private ScannerState _scannerState = ScannerState.Scan;
    private ISharpControl _controlInterface;
    private List<MemoryEntry> _entries;
    private byte[] _fft_buffer;
    private ScannerCompareMode _mode = ScannerCompareMode.PeakPowerBandwidth;

    System.Timers.Timer _timerLevelInspect = new System.Timers.Timer();
    ScanNextFrequency _scanNextFrequencyCallBack;
    ScanNextFrequencyTimeLeft _scanNextFrequencyTimeLeftCallBack;
    ScanStateChanged _scanStateChangedCallback;

    Simova _smaTunedFrequecy;
    Simova _smaTunedBandwidth;
    Simova _smaTunedPeakPowerBandwidth;

    public Scanner(ISharpControl controlInterface, ScanNextFrequency Callback, ScanNextFrequencyTimeLeft CallbackTimeLeft)
	{
      _controlInterface = controlInterface;
      _scanNextFrequencyCallBack = Callback;
      _scanNextFrequencyTimeLeftCallBack = CallbackTimeLeft;
      _timerLevelInspect.Elapsed += new System.Timers.ElapsedEventHandler(_timerLevelInspect_Elapsed);
      _timerLevelInspect.Enabled = false;
      InitAverager();
      _fft_buffer = new byte[_controlInterface.FFTResolution];
      _timerLevelInspect.Interval = _SCAN_TIMER_INTERVALL;
    }

    #region public Methods

    public string GetPowerDebugString()
    {
        string s = "";
        s = "Frequency:" + _controlInterface.Frequency.ToString() +
            "   CenterFreq:" + _controlInterface.CenterFrequency.ToString() + Environment.NewLine +
            "   PwrFreq:" + PeakPowerCurrent.ToString("F0") +
            "   PwrFreqAvg:" + PeakPower.ToString("F0") + Environment.NewLine +
            "   PwrBW:" + PowerBanwidthAvgCurrent.ToString("F0") +
            "   PwrBWAvg" + PowerBanwidthAvg.ToString("F0");
        return s;
    }

    public void Start(List<MemoryEntry> entries)
    {
        _fft_buffer = new byte[_controlInterface.FFTResolution];
        _entries = entries;
        _scannerState = ScannerState.Scan;
        SetupFirstScan();
        _timerLevelInspect.Enabled = true;
    }

    public void Stop()
    {
        _timerLevelInspect.Enabled = false;
    }

    
    public void Resume()
    {
        if (_scannerState == ScannerState.StayTuned)
        {
            _scannerState = ScannerState.Scan;
        }
        ResumeScan();
        _timerLevelInspect.Enabled = true;
    }

    public void Pause()
    {
        _timerLevelInspect.Enabled = false;
    }

    #endregion

    #region public Properties

    public ScannerCompareMode Mode
    {
        get { return _mode; }
        set { _mode = value; }
    }

    public bool WdogTimerEnable
    {
      get { return _wdogTimerEnable; }
      set 
      {
        _wdogTimerEnable = value;
        _wdogTimeTickCnt = 0;
      }
    }

    public int WdogTime
    {
      get { return _wdogTime; }
      set 
      { 
        _wdogTime = value;
        _wdogTimeTickCnt = 0;
      }
    }

    

    public ScanStateChanged SetScanStateChangedCallback
    {
        set { _scanStateChangedCallback = value; }
    }

      
    public int ScanTime
    {
        get { return _scanTime; }
        set { _scanTime = value; }
    }

    public bool IsRxLevelValid
    {
      get 
      {
          if (_scannerCompareRxLevel == _SIMPLE_AVERAGE_MIN)
          return false;
        else
          return true;
      }
    }

    public ScannerState State
    {
        get { return _scannerState; }
        set { _scannerState = value; }
    }
   
    public int ThresholdReleaseTime
    {
      get { return _tresholdReleaseTime; }
      set { _tresholdReleaseTime = value; }
    }
      
    public float PeakPower
    {
        get { return _smaTunedFrequecy.Average; }
    }
    public float PeakPowerBw
    {
      get { return _smaTunedPeakPowerBandwidth.Average; }
    }
    

     public bool ScanDisable
    {
        get { return _scanDisable; }
        set { _scanDisable = value; }
    }

    public float PowerBanwidthAvg
    {
        get { return _smaTunedBandwidth.Average; }
    }

    public float PeakPowerCurrent
    {
        get { return _smaTunedFrequecy.Current; }
    }

    public float PeakPowerBwCurrent
    {
      get { return _smaTunedPeakPowerBandwidth.Current; }
    }
    

    public float PowerBanwidthAvgCurrent
    {
        get { return _smaTunedBandwidth.Current; }
    }

    public bool IsStayTunedStable
    {
      get 
      {
        if (_scannerStayTunedCnt == 0)
          return true;
        else
          return false; 
      }
    }
    
    #endregion

    #region private Methods

    #region FFT / Power
   
    private float Fft_ReScaleMagnitude(float Value)
    {
        float Result = 0;
        float Scale = byte.MaxValue / (float)130;
        Result = Value / Scale - 130;
        return Result;
    }

    private int GetSamplerate()
    {
        return _controlInterface.RFBandwidth;
    }

    private int Fft_GetCenterOffsetIndex()
    {
        int Result = 0;
        Result = (int)((_controlInterface.Frequency - _controlInterface.CenterFrequency) / (GetSamplerate() / _controlInterface.FFTResolution));
        return Result;
    }

    private void PowerDetection()
    {
        if (!_controlInterface.IsPlaying)
            return;

        _controlInterface.GetSpectrumSnapshot(_fft_buffer);

        _smaTunedFrequecy.Add(GetPowerTunedFreq());
        _smaTunedBandwidth.Add(GetPowerTunedBandwith());
        _smaTunedPeakPowerBandwidth.Add(GetPeakPowerTunedBandwith());

        if (_mode == ScannerCompareMode.PeakPowerFrequency)
        {
            _scannerCompareRxLevel = _smaTunedFrequecy.IsValid ? _smaTunedFrequecy.Average : _SIMPLE_AVERAGE_MIN;
        }
        else if (_mode == ScannerCompareMode.AvgPowerBandwidth)
        {
            _scannerCompareRxLevel = _smaTunedBandwidth.IsValid ? _smaTunedBandwidth.Average : _SIMPLE_AVERAGE_MIN;
        }
        else if (_mode == ScannerCompareMode.PeakPowerBandwidth)
        {
          _scannerCompareRxLevel = _smaTunedBandwidth.IsValid ? _smaTunedPeakPowerBandwidth.Average : _SIMPLE_AVERAGE_MIN;
        }
      
    }

    private float GetPowerTunedBandwith()
    {
        float delta = Fft_GetCenterOffsetIndex();

        int len = _controlInterface.FilterBandwidth / ((int)GetSamplerate() / _controlInterface.FFTResolution);
        int start_index = _controlInterface.FFTResolution / 2 + (int)delta - len / 2;

        float avg = 0;
        for (int i = 0; i < len; i++)
        {
            if ((start_index + i) < _fft_buffer.Length)
            {
                avg += _fft_buffer[start_index + i];
            }
        }

        avg = avg / len;

        avg = Fft_ReScaleMagnitude(avg);

        return avg;
    }

    private float GetPeakPowerTunedBandwith()
    {
      float delta = Fft_GetCenterOffsetIndex();

      int len = _controlInterface.FilterBandwidth / ((int)GetSamplerate() / _controlInterface.FFTResolution);
      int start_index = _controlInterface.FFTResolution / 2 + (int)delta - len / 2;

      int offset = 0;

      float max = -130;
      for (int i = 0; i < len; i++)
      {
        if ((start_index + i) < _fft_buffer.Length)
        {
          if (_fft_buffer[start_index + i] > max)
          {
            max = _fft_buffer[start_index + i];
            offset = i;
          }
        }
      }

      max = Fft_ReScaleMagnitude(max);

      return max;
    }

    private float GetPowerTunedFreq()
    {
        int delta = Fft_GetCenterOffsetIndex();
        int index = _controlInterface.FFTResolution / 2 + delta;
        float val = -130;
        if (index < _fft_buffer.Length)
        {
            val = Fft_ReScaleMagnitude(_fft_buffer[index]);
        }
        return val;
    }

    #endregion

    private void InitAverager()
    {
        _scannerCompareRxLevel =-_SIMPLE_AVERAGE_MIN;
        _smaTunedFrequecy = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
        _smaTunedBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
      _smaTunedPeakPowerBandwidth  = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
    }

    private void SetupFirstScan()
    {
        _scannerTimerTickCnt = 0;
        _scannerTimerTickCntLastFreqChange = 0;
        _scannerStayTunedCnt = 0;
        _wdogTimeTickCnt = 0;
        _scannerCompareRxLevel = _SIMPLE_AVERAGE_MIN;

        DoReTuning(_entries[0]);
        _scanIndex = 0;
        if (_entries.Count > 1)
        {
            _scanIndex++;
        }
    }

    private void ResumeScan()
    {
        _scanStateChangedCallback(_scannerState, ScannerState.Scan);
        _scannerState = ScannerState.Scan;
        _scannerTimerTickCnt = 0;
        _scannerTimerTickCntLastFreqChange = 0;
        _scannerStayTunedCnt = 0;
        _wdogTimeTickCnt = 0;
        DoReTuning(_entries[_scanIndex]);
    }

    private void DoReTuning(MemoryEntry Entry)
    {
        InitAverager();

       _controlInterface.FrequencyShiftEnabled = false;

        if (Entry.Shift != 0)
        {
            Entry.Frequency += Entry.Shift;
        }
        _controlInterface.DetectorType = Entry.DetectorType;
        _controlInterface.FilterBandwidth = (int)Entry.FilterBandwidth;
        _controlInterface.Frequency = Entry.Frequency;
        UpdateTimeLeft(_scanTime,_wdogTime);
    }

   
    private void UpdateTimeLeft(int ScanTime, int WdogTime)
    {
      if (_scanNextFrequencyTimeLeftCallBack != null)
      {
        if (ScanTime == 0)
        {
          ScanTime = _scanTime;
        }
        _scanNextFrequencyTimeLeftCallBack(ScanTime,WdogTime, _scannerState);
      }
    }

    

    private void _timerLevelInspect_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {

      if (!_controlInterface.IsPlaying)
      {
        Stop();
      }

      _timerLevelInspect.Enabled = false;
      _scannerTimerTickCnt++;

      PowerDetection();

      //##########################################
      if (_scannerState == ScannerState.Scan)
      //##########################################
      {
        if (_scannerTimerTickCnt * _SCAN_TIMER_INTERVALL % 200 == 0)
        {
          UpdateTimeLeft(
                _scanTime - (_scannerTimerTickCnt - _scannerTimerTickCntLastFreqChange) * _SCAN_TIMER_INTERVALL,
                _wdogTime - _wdogTimeTickCnt * _SCAN_TIMER_INTERVALL
                
                );
        }

        if (_scannerCompareRxLevel >= _entries[_scanIndex].StayTunedLevel)
        {
            _scanStateChangedCallback(_scannerState, ScannerState.StayTuned);
            _scannerState = ScannerState.StayTuned;
        }
        else if (_scannerTimerTickCnt * _SCAN_TIMER_INTERVALL % _scanTime == 0 && !_scanDisable)
        {
          _scannerTimerTickCntLastFreqChange = _scannerTimerTickCnt;
         
          _scanNextFrequencyCallBack(_scanIndex);

          DoReTuning(_entries[_scanIndex]);

          _scanIndex++;

          if (_scanIndex > _entries.Count - 1)
          {
            _scanIndex = 0;
          }

        }
      }
      
      //##########################################
      else if (_scannerState == ScannerState.StayTuned)
      //##########################################
      {
        _wdogTimeTickCnt++;

        if (_scannerCompareRxLevel < _entries[_scanIndex].StayTunedLevel)
        {
          _scannerStayTunedCnt++;
        }
        else
        {
          _scannerStayTunedCnt = 0;
        }

        if (_scannerStayTunedCnt * _SCAN_TIMER_INTERVALL % 200 == 0)
        {
          UpdateTimeLeft(
                          _tresholdReleaseTime - (_scannerStayTunedCnt * _SCAN_TIMER_INTERVALL),
                          _wdogTime - (_wdogTimeTickCnt * _SCAN_TIMER_INTERVALL)                          
                          );
        }

        if (_scannerStayTunedCnt * _SCAN_TIMER_INTERVALL >= _tresholdReleaseTime && !_scanDisable)
        {
          ResumeScan();
        }
        else if (_wdogTimeTickCnt * _SCAN_TIMER_INTERVALL >= _wdogTime && _wdogTimerEnable)
        {
          ResumeScan();
        }
      }
      _timerLevelInspect.Enabled = true;
    }

    
    #endregion

  }
}
