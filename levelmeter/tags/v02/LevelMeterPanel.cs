using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.LevelMeter
{

  public delegate void OnLevelUpdate(string Mode, string Frequency, float Value, string Slevel);
    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("Gauge Panel")]
    public partial class LevelMeterPanel : UserControl
    {
               
        private ISharpControl _controlInterface;
        private Timer UpdateTimer;
        private Timer MeasureTimer;
        Simova _smaTunedFrequecy;
        Simova _smaTunedBandwidth;
        Simova _smaTunedPeakPowerBandwidth;
        private byte[] _fft_buffer;
        int _mode = 0;         /* 0=Peak Power 1=Avg Power BW  2=Peak Power BW   */

      private  int _UPDATE_TIMER_INTERVALL = 100;
      private  int _MEASURE_TIMER_INTERVALL = 50;
      private  int _SIMPLE_AVERAGE_SAMPLE_CNT = 5;
      private  int _SIMPLE_AVERAGE_MIN = -130;
      private LevelMeterTool ToolWin;
      private OnLevelUpdate _onLevelUpdateCallback = null;
       
        public LevelMeterPanel(ISharpControl control)
        {
            InitializeComponent();
            
            _controlInterface = control;

            ToolWin = new LevelMeterTool();
            ToolWin = new LevelMeterTool();
            ToolWin.Show();
            ToolWin.Visible = false;
            OnLevelUpdateEvent = new OnLevelUpdate(ToolWin.OnLevelUpdate);

            _fft_buffer = new byte[_controlInterface.FFTResolution];

           _smaTunedFrequecy = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
           _smaTunedBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
           _smaTunedPeakPowerBandwidth  = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);

           trackBar1.Value = 100;

                      
            UpdateTimer = new Timer();
            UpdateTimer.Interval = _UPDATE_TIMER_INTERVALL;
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            

            MeasureTimer = new Timer();
            MeasureTimer.Interval = _MEASURE_TIMER_INTERVALL;
            MeasureTimer.Tick += new EventHandler(MeasureTimer_Tick);

            Init();
        }

        void MeasureTimer_Tick(object sender, EventArgs e)
        {
          if (!_controlInterface.IsPlaying)
          {
            if (_smaTunedFrequecy.IsValid)
            {
              _smaTunedFrequecy = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
              _smaTunedBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
              _smaTunedPeakPowerBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
            }
            return;
          }

          _controlInterface.GetSpectrumSnapshot(_fft_buffer);

          _smaTunedFrequecy.Add(GetPowerTunedFreq());
          _smaTunedBandwidth.Add(GetPowerTunedBandwith());
          _smaTunedPeakPowerBandwidth.Add(GetPeakPowerTunedBandwith());
        }

        void SetGauge(Simova s)
        {
          if (aGauge1.Value > s.Average || aGauge1.Value < s.Average)
          {
            float diff = s.Average - aGauge1.Value;

            if ( Math.Abs(diff) < 2 )
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.001 * trackBar1.Value;
            }
            else if (Math.Abs(diff) < 5)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.005 * trackBar1.Value;
            }
            else if (Math.Abs(diff) < 10)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.01 * trackBar1.Value;
            }
            else if (Math.Abs(diff) < 50)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.05 * trackBar1.Value;
            }
            //else if(Math.Abs(diff) > trackBar1.Value * 0.1)
            //{
             // aGauge1.Value += trackBar1.Value * Math.Sign(diff) * (float)0.1;
            //}
            else
            {
               aGauge1.Value += diff;
            }
          }
        }
        public string GetSLevel(float Frequency, float Level)
        {
          int Slevel = 0;
          int Diff = 0;
          int HfOffset = 0;

          if (Frequency > 30000000)
          {
            HfOffset = 20;
          }

          if (Level < -121 - HfOffset)
          {
            Slevel = 0;
          }
          else if (Level < -115 - HfOffset)
          {
            Slevel = 1;
          }
          else if (Level < -109 - HfOffset)
          {
            Slevel = 2;
          }
          else if (Level < -103 - HfOffset)
          {
            Slevel = 3;
          }
          else if (Level < -97 - HfOffset)
          {
            Slevel = 4;
          }
          else if (Level < -91 - HfOffset)
          {
            Slevel = 5;
          }
          else if (Level < -85 - HfOffset)
          {
            Slevel = 6;
          }
          else if (Level < -79 - HfOffset)
          {
            Slevel = 7;
          }
          else if (Level < -73 - HfOffset)
          {
            Slevel = 8;
          }
          else if (Level < -63 - HfOffset)
          {
            Slevel = 9;
          }
          else
          {
            Slevel = 9;
            Diff = Math.Abs((int)Level + 73 - HfOffset);
            Diff = (Diff % 3) * 3;
          }

          string s = "S" + Slevel.ToString();

          if (Diff != 0)
          {
            s = s + "+" + Diff.ToString();
          }

          return s;
        }

        public OnLevelUpdate OnLevelUpdateEvent
        {
          set { _onLevelUpdateCallback = value; }
        }
        void UpdateTimer_Tick(object sender, EventArgs e)
        {
            string Slevel = "";
            if (_mode == 0)
            {
              SetGauge(_smaTunedFrequecy);
              aGauge1.GaugeLabels[0].Text = "Peak Power VFO";
            }
            else if (_mode == 1)
            {
              SetGauge(_smaTunedBandwidth);
              aGauge1.GaugeLabels[0].Text = "Average Power Bandwidth";
            }
            else if (_mode == 2)
            {
              SetGauge(_smaTunedPeakPowerBandwidth);
              aGauge1.GaugeLabels[0].Text = "Peak Power Bandwidth";
            }

            Slevel = GetSLevel(_controlInterface.Frequency, aGauge1.Value);
            richTextBox1.Text = String.Format("    {0:F0} dBm", aGauge1.Value);
            textBoxRxLevel.Text = String.Format("{0:F0}", _smaTunedFrequecy.Average);
            textBoxAvgBwPower.Text = String.Format("{0:F0}", _smaTunedBandwidth.Average);
            textBoxPeakPowerBw.Text = String.Format("{0:F0}", _smaTunedPeakPowerBandwidth.Average);

            aGauge1.GaugeLabels[1].Text = Slevel;

            if (_onLevelUpdateCallback != null)
            {
              string f = String.Format("{0:0,0}", _controlInterface.Frequency) + "Hz";
              _onLevelUpdateCallback(aGauge1.GaugeLabels[0].Text, f, aGauge1.Value, Slevel);
            }
        }


        private float GetPeakPowerTunedBandwith()
        {
          float delta = Fft_GetCenterOffsetIndex();

          int len = _controlInterface.FilterBandwidth / ((int)GetSamplerate() / _controlInterface.FFTResolution);
          int start_index = _controlInterface.FFTResolution / 2 + (int)delta - len / 2;
          
          int offset = 0;

          float max = _SIMPLE_AVERAGE_MIN;
          for (int i = 0; i < len; i++)
          {
            if (start_index < 0)
              return -130;
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

        private int Fft_GetCenterOffsetIndex()
        {
          int Result = 0;
          long offset = 0;
          if (_controlInterface.FrequencyShiftEnabled)
          {
            offset = _controlInterface.FrequencyShift;
          }
          Result = (int)((_controlInterface.Frequency - _controlInterface.CenterFrequency - offset) / (GetSamplerate() / _controlInterface.FFTResolution));
          return Result;
        }

        private float GetPowerTunedBandwith()
        {
          float delta = Fft_GetCenterOffsetIndex();

          int len = _controlInterface.FilterBandwidth / ((int)GetSamplerate() / _controlInterface.FFTResolution);
          int start_index = _controlInterface.FFTResolution / 2 + (int)delta - len / 2;

          if (start_index < 0)
            return _SIMPLE_AVERAGE_MIN;

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
        private int GetSamplerate()
        {
          return _controlInterface.RFBandwidth;
        }
        private float Fft_ReScaleMagnitude(float Value)
        {
          float Result = 0;
          float Scale = byte.MaxValue / (float)130;
          Result = Value / Scale - 130;
          return Result;
        }
     private float GetPowerTunedFreq()
      {
          int delta = Fft_GetCenterOffsetIndex();
          int index = _controlInterface.FFTResolution / 2 + delta;
          float val = _SIMPLE_AVERAGE_MIN;

          if (index < 0)
            return _SIMPLE_AVERAGE_MIN;

          if (index < _fft_buffer.Length)
          {
              val = Fft_ReScaleMagnitude(_fft_buffer[index]);
          }
          return val;
      }
      
        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
          _mode = comboBoxMode.SelectedIndex;
        }

   
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
//          labelSpeed.Text = trackBar1.Value.ToString();
        }


        public void OnStartRadio()
        {
          MeasureTimer.Start();
          UpdateTimer.Start();
        }

        public void OnStopRadio()
        {
          Init();
        }
        void Init()
        {
          MeasureTimer.Stop();
          UpdateTimer.Stop();
          aGauge1.Value = _SIMPLE_AVERAGE_MIN;
          richTextBox1.Text = String.Format("    {0:F0} dBm", _SIMPLE_AVERAGE_MIN);
          textBoxRxLevel.Text = "";
          textBoxAvgBwPower.Text = "";
          textBoxPeakPowerBw.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          ToolWin.Visible = checkBox1.Checked;
        }
    }
}

