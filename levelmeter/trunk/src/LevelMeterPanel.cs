using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using SDRSharp.Radio;
using SDRSharp.Common;
using SDRSharp.MyPlugLibs;

namespace SDRSharp.LevelMeter
{

  public delegate void OnLevelUpdate(string Mode, string Frequency, float Value, string Unit,string Slevel);
    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("LevelMeter Panel")]
    public partial class LevelMeterPanel : UserControl
    {
        private ISharpControl _controlInterface;
        private System.Windows.Forms.Timer  _updateTimer;
        private Simova _smaTunedFrequecy;
        private Simova _smaTunedBandwidth;
        private Simova _smaTunedPeakPowerBandwidth;
        private bool _enable = false;
        private float[] _fft_buffer;
        private const int POWERLEVEL_MIN = -140;
        private int _mode = 0;         /* 0=Peak Power 1=Avg Power BW  2=Peak Power BW   */
        private  int _UPDATE_TIMER_INTERVALL = 200;
        private  int _MEASURE_TIMER_INTERVALL = 50;
        private  int _SIMPLE_AVERAGE_SAMPLE_CNT = 5;
        private int _SIMPLE_AVERAGE_MIN = POWERLEVEL_MIN;
        private LevelMeterTool _toolWin;
        private OnLevelUpdate _onLevelUpdateCallback = null;
        private Options _options;
        private MyPlugLib MyLib;
        Thread GetPowerThreadWorker;
       
        public LevelMeterPanel(ISharpControl control)
        {
          InitializeComponent();
            
          _controlInterface = control;

          InitToolWindow();

          LoadOptions();

          _fft_buffer = new float[_controlInterface.FFTResolution];

          MyLib = new MyPlugLib(_controlInterface);
          MyLib.SetFftBuffer(ref _fft_buffer);
          
					_smaTunedFrequecy = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
          _smaTunedBandwidth = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);
          _smaTunedPeakPowerBandwidth  = new Simova(_SIMPLE_AVERAGE_SAMPLE_CNT, _SIMPLE_AVERAGE_MIN);

          UpdateTimerInit();

          GuiInit();
        }

        #region Getter

        public bool IsEnabled
        {
            get { return _enable; }
        }

        #endregion

        #region Options

        void SaveOptions()
        {
          _options.Mode = comboBoxMode.SelectedIndex;
          _options.ShowPopupOnStartup = cbShowPopup.Checked;
          _options.IsEnabled = checkBoxEnable.Checked;
          _options.Save();
        }

        void LoadOptions()
        {
          _options = new Options(Environment.CurrentDirectory);

          labelPowerVfo.Text   = "Peak Power VFO " + "[" + _options.Unit + "]";
          labelAvgPowerBw.Text = "Avg Power BW "   + "[" + _options.Unit + "]";
          labelPeakPwerBw.Text = "Peak Power BW  " + "[" + _options.Unit + "]";

          comboBoxMode.SelectedIndex = _options.Mode;
          cbShowPopup.Checked = _options.ShowPopupOnStartup;
          checkBoxEnable.Checked = _options.IsEnabled;

          aGauge1.MinValue = _options.GaugeLevelMin;
          aGauge1.MaxValue = _options.GaugeLevelMax;

          _enable = _options.IsEnabled;

          _toolWin.SetMinMax(_options.GaugeLevelMin,_options.GaugeLevelMax);

        }
        #endregion

        #region Tool Window

        void InitToolWindow()
        {
          _toolWin = new LevelMeterTool();
          _toolWin.Show();
          _toolWin.Visible = false;
          OnLevelUpdateEvent = new OnLevelUpdate(_toolWin.OnLevelUpdate);
        }

        public OnLevelUpdate OnLevelUpdateEvent
        {
          set { _onLevelUpdateCallback = value; }
        }

        #endregion

        #region Gauge
        void SetGauge(Simova s)
        {
          if (aGauge1.Value > s.Average || aGauge1.Value < s.Average)
          {
            float diff = s.Average - aGauge1.Value;

            if (Math.Abs(diff) < 2)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.001 * tbSmoothing.Value;
            }
            else if (Math.Abs(diff) < 5)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.005 * tbSmoothing.Value;
            }
            else if (Math.Abs(diff) < 10)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.01 * tbSmoothing.Value;
            }
            else if (Math.Abs(diff) < 50)
            {
              aGauge1.Value += Math.Sign(diff) * (float)0.05 * tbSmoothing.Value;
            }
            else
            {
              aGauge1.Value += diff;
            }
          }
        }

        #endregion

        #region S Level
        public string GetSLevel(float Frequency, float Level)
        {
          int Slevel = 0;
          int Diff = 0;
          int HfOffset = 0;

          if (!_options.SMeterEnable)
          {
            return "";
          }

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
        #endregion
      
        #region Timer

        void UpdateTimerInit()
        {
					_updateTimer = new System.Windows.Forms.Timer();
          _updateTimer.Interval = _UPDATE_TIMER_INTERVALL;
          _updateTimer.Tick += new EventHandler(UpdateTimer_Tick);
        }

				void GetPowerThreadFunc(object parameter)
				{
					while (true)
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

						_controlInterface.GetSpectrumSnapshot(_fft_buffer, POWERLEVEL_MIN, 0);

						_smaTunedFrequecy.Add(MyLib.GetPowerTunedFreq());
						_smaTunedBandwidth.Add(MyLib.GetPowerTunedBandwith());
						_smaTunedPeakPowerBandwidth.Add(MyLib.GetPeakPowerTunedBandwith());

						Thread.Sleep(_MEASURE_TIMER_INTERVALL);
					}
				}

        void UpdateTimer_Tick(object sender, EventArgs e)
        {
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
            
            richTextBox1.Text = String.Format("{0,10:F0} {1}", aGauge1.Value, _options.Unit);
            textBoxRxLevel.Text = String.Format("{0:F0}", _smaTunedFrequecy.Average);
            textBoxAvgBwPower.Text = String.Format("{0:F0}", _smaTunedBandwidth.Average);
            textBoxPeakPowerBw.Text = String.Format("{0:F0}", _smaTunedPeakPowerBandwidth.Average);

            string Slevel = "";
            Slevel = GetSLevel(_controlInterface.Frequency, aGauge1.Value);
            aGauge1.GaugeLabels[1].Text = Slevel;

            if (_onLevelUpdateCallback != null)
            {
              string f = String.Format("{0:0,0}", _controlInterface.Frequency) + "Hz";
              _onLevelUpdateCallback(aGauge1.GaugeLabels[0].Text, f, aGauge1.Value, _options.Unit,Slevel);
            }
        }
        #endregion
                          
        #region Start/Stop/init

        private void StartMeasureThread()
        {
					if (GetPowerThreadWorker == null)
					{
						GetPowerThreadWorker = new Thread(GetPowerThreadFunc);
						GetPowerThreadWorker.Name = "LevelmeterGetPower";
						GetPowerThreadWorker.Start();
					}
        }

        private void StoptMeasureThread()
        {
					if (GetPowerThreadWorker != null)
					{
						GetPowerThreadWorker.Abort();
						GetPowerThreadWorker = null;
					}
        }
        public void OnStartRadio()
        {
          StartMeasureThread();

          _updateTimer.Start();
        }

        public void OnStopRadio()
        {
          GuiInit();
        }

        public void OnFFTResChange()
        {
          StoptMeasureThread();
          _updateTimer.Stop();
          _fft_buffer = new float[_controlInterface.FFTResolution];
          MyLib.SetFftBuffer(ref _fft_buffer);
          StartMeasureThread();
          _updateTimer.Start();
        }

        void GuiInit()
        {
          StoptMeasureThread();
           _updateTimer.Stop();
          aGauge1.Value = aGauge1.MinValue;
          richTextBox1.Text = String.Format("{0,10:F0} {1}", _SIMPLE_AVERAGE_MIN,_options.Unit);
          textBoxRxLevel.Text = "";
          textBoxAvgBwPower.Text = "";
          textBoxPeakPowerBw.Text = "";

          string Slevel = GetSLevel(_controlInterface.Frequency, _SIMPLE_AVERAGE_MIN);
          aGauge1.GaugeLabels[1].Text = Slevel;

          if (_onLevelUpdateCallback != null)
          {
            string f = String.Format("{0:0,0}", _controlInterface.Frequency) + "Hz";
            _onLevelUpdateCallback(aGauge1.GaugeLabels[0].Text, f, aGauge1.Value, _options.Unit,Slevel);
          }
        }
        #endregion

        #region Events
        private void checkBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            _enable = checkBoxEnable.Checked;

               if(_enable && _controlInterface.IsPlaying)
               {
                   OnStartRadio();
               }

               if (!_enable)
               {
                   OnStopRadio();
               }
                
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          _toolWin.Visible = cbShowPopup.Checked;
        }
       
        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
          _mode = comboBoxMode.SelectedIndex;
          _options.Mode = _mode;
        }

        #endregion

       
    }
}

