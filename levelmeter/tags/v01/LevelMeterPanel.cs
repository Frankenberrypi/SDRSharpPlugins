using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.LevelMeter
{
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
      private  int _MEASURE_TIMER_INTERVALL = 20;
      private  int _SIMPLE_AVERAGE_SAMPLE_CNT = 10;
      private  int _SIMPLE_AVERAGE_MIN = -130;
       
        public LevelMeterPanel(ISharpControl control)
        {
            InitializeComponent();            

            _controlInterface = control;

            _fft_buffer = new byte[_controlInterface.FFTResolution];

           _smaTunedFrequecy = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
           _smaTunedBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
           _smaTunedPeakPowerBandwidth  = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);

           trackBar1.Value = 50;

            UpdateTimer = new Timer();
            UpdateTimer.Interval = _UPDATE_TIMER_INTERVALL;
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            

            MeasureTimer = new Timer();
            MeasureTimer.Interval = _MEASURE_TIMER_INTERVALL;
            MeasureTimer.Tick += new EventHandler(MeasureTimer_Tick);

            MeasureTimer.Start();
            UpdateTimer.Start();
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

        void UpdateTimer_Tick(object sender, EventArgs e)
        {  
            if (_mode == 0)
            {
              SetGauge(_smaTunedFrequecy);
              richTextBox1.Text = String.Format("     {0:F0} dB", aGauge1.Value);
              aGauge1.GaugeLabels[0].Text = "Peak Power VFO";
            }
            else if (_mode == 1)
            {
              SetGauge(_smaTunedBandwidth);
              richTextBox1.Text = String.Format("     {0:F0} dB", _smaTunedBandwidth.Average);
              aGauge1.GaugeLabels[0].Text = "Average Power Bandwidth";
            }
            else if (_mode == 2)
            {
              SetGauge(_smaTunedPeakPowerBandwidth);
              richTextBox1.Text = String.Format("     {0:F0} dB", _smaTunedPeakPowerBandwidth.Average);
              aGauge1.GaugeLabels[0].Text = "Peak Power Bandwidth";
            }

            textBoxRxLevel.Text = String.Format("{0:F0}", _smaTunedFrequecy.Average);
            textBoxAvgBwPower.Text = String.Format("{0:F0}", _smaTunedBandwidth.Average);
            textBoxPeakPowerBw.Text = String.Format("{0:F0}", _smaTunedPeakPowerBandwidth.Average);
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
          Result = (int)((_controlInterface.Frequency - _controlInterface.CenterFrequency) / (GetSamplerate() / _controlInterface.FFTResolution));
          return Result;
        }

        private float GetPowerTunedBandwith()
        {
          float delta = Fft_GetCenterOffsetIndex();

          int len = _controlInterface.FilterBandwidth / ((int)GetSamplerate() / _controlInterface.FFTResolution);
          int start_index = _controlInterface.FFTResolution / 2 + (int)delta - len / 2;

          if (start_index < 0)
            return -130;

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
          float val = -130;

          if (index < 0)
            return -130;

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

       

    }
}

