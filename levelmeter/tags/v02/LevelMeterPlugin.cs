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
            _controlInterface.PropertyChanged += new PropertyChangedEventHandler(PropertyChangedHandler);
            _levelmeterpanel = new LevelMeterPanel(_controlInterface); 
        }

        void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
          // Events
          switch (e.PropertyName)
          {
            case "StartRadio":
              if (_levelmeterpanel != null)
              {
                _levelmeterpanel.OnStartRadio();
              }
              break;

            case "StopRadio":
              if (_levelmeterpanel != null)
              {
                _levelmeterpanel.OnStopRadio();
              }
              break;

            default:
              break;
          }
        }
    }
}
