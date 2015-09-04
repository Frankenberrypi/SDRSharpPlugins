using System;
using System.Windows.Forms;

using SDRSharp.Common;


namespace SDRSharp.EasyScanner
{
    public class EasyScannerPlugin: ISharpPlugin
    {
        private const string _displayName = "EasyScanner";
        private ISharpControl _controlInterface;
        private ScannerPanel _frequencyManagerPanel;

        

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
            _frequencyManagerPanel = new ScannerPanel(_controlInterface); 
        }
    }
}
