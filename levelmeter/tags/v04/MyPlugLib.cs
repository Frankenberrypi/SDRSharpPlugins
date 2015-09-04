using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.MyPlugLibs
{
  class MyPlugLib
  {
    private ISharpControl _controlInterface;
    private float[] _fft_buffer;
    private const int POWERLEVEL_MIN = -140;

    public MyPlugLib(ISharpControl ControlInterface)
    {
      _controlInterface = ControlInterface;
      _fft_buffer = new float[_controlInterface.FFTResolution];
    }

    public void SetFftBuffer(ref float[] fft_buffer)
    {
      _fft_buffer = fft_buffer;
    }

    public int Fft_GetIndexTunedFreq()
    {

      long offset = 0;
      if (_controlInterface.FrequencyShiftEnabled)
      {
        offset = _controlInterface.FrequencyShift;
      }

      float FftLinieAbstandHz = (float)((float)_controlInterface.RFBandwidth / (float)_controlInterface.FFTResolution);
      float VfoDeltaToCenterFreq = _controlInterface.Frequency - _controlInterface.CenterFrequency - offset;
      float VfoFFtDeltaToCenterFreq = VfoDeltaToCenterFreq / FftLinieAbstandHz;
      float Index = (_controlInterface.FFTResolution / 2) + VfoFFtDeltaToCenterFreq;

      return (int)Math.Round(Index);

    }

    public float GetPowerTunedFreq()
    {
      return GetFftValue(Fft_GetIndexTunedFreq()); 
    }

    public float GetPowerTunedBandwith()
    {
      float delta = Fft_GetIndexTunedFreq();

      float FftLinieAbstandHz = (float)((float)_controlInterface.RFBandwidth / (float)_controlInterface.FFTResolution);

      int len = (int)(_controlInterface.FilterBandwidth / FftLinieAbstandHz);
      int start_index = Fft_GetIndexTunedFreq() - (len / 2);

      float avg = 0;
      for (int i = 0; i < len; i++)
      {
        avg += GetFftValue(start_index + i);
      }

      avg = avg / len;

      return avg;
    }

    public float GetPeakPowerTunedBandwith()
    {
      float delta = Fft_GetIndexTunedFreq();
      float FftLinieAbstandHz = (float)((float)_controlInterface.RFBandwidth / (float)_controlInterface.FFTResolution);
      int len = (int)(_controlInterface.FilterBandwidth / FftLinieAbstandHz);
      int start_index = Fft_GetIndexTunedFreq() - (len / 2);

      int offset = 0;

      float max = POWERLEVEL_MIN;
      for (int i = 0; i < len; i++)
      {
        if (GetFftValue(start_index + i) > max)
        {
          max = GetFftValue(start_index + i);
          offset = i;
        }

      }

      return max;
    }

    private float GetFftValue(int index)
    {
      float ret = POWERLEVEL_MIN;

      if (index > 0 && index < _fft_buffer.Length)
      {
        ret = _fft_buffer[index];
      }

      return ret;
    }
   

  }
}
