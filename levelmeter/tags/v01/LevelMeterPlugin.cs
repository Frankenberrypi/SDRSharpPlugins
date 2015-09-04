using System;
using System.Windows.Forms;

using SDRSharp.Common;


namespace SDRSharp.LevelMeter
{
    public class LevelMeterPlugin : ISharpPlugin
    {
        private const string _displayName = "LevelMeter";
        private ISharpControl _controlInterface;
        private LevelMeterPanel _frequencyManagerPanel;

        public bool HasGui
        {
            get { return true; }
        }

        public UserControl GuiControl
        {
            get { return _frequencyManagerPanel; }
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
            _frequencyManagerPanel = new LevelMeterPanel(_controlInterface); 
        }
    }
}
