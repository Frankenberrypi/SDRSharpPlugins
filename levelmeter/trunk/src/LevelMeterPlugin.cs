using System;
using System.Windows.Forms;
using System.ComponentModel;
using SDRSharp.Common;


namespace SDRSharp.LevelMeter
{
    public class LevelMeterPlugin : ISharpPlugin
    {
        private const string _displayName = "LevelMeter";
        private ISharpControl _controlInterface;
        private LevelMeterPanel _levelmeterpanel;

        public bool HasGui
        {
            get { return true; }
        }

        public UserControl GuiControl
        {
          get { return _levelmeterpanel; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public void Close()
        {
        }

        public void Initialize(ISharpControl control)
        {
             _controlInterface = control;
            _levelmeterpanel = new LevelMeterPanel(_controlInterface);
            _controlInterface.PropertyChanged += new PropertyChangedEventHandler(PropertyChangedHandler);
        }

        void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (_levelmeterpanel.IsEnabled == false)
            {
                return;
            }
          // Events
          switch (e.PropertyName)
          {
            case "StartRadio":
                _levelmeterpanel.OnStartRadio();
              break;

            case "StopRadio":
                _levelmeterpanel.OnStopRadio();
              break;
            case "FFTResolution":
              _levelmeterpanel.OnFFTResChange();
              break;

            default:
              break;
          }
        }
    }
}
