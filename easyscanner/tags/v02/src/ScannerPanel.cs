using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.EasyScanner
{
    public delegate void RadioInfo(object sender, MemoryInfoEventArgs e);

    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("EasyScanner Panel")]
    public partial class ScannerPanel : UserControl
    {
        private Scanner _scanner;

        private readonly SortableBindingList<MemoryEntry> _displayedEntries = new SortableBindingList<MemoryEntry>();
        private readonly List<MemoryEntry> _entries;
        private readonly SettingsPersister _settingsPersister;
        private readonly List<string> _groups = new List<string>();
        private const string AllGroups = "[All Groups]";
        private const string FavouriteGroup = "[Favourites]";
        private const string DisableStringTextBox = "---";


        private ISharpControl _controlInterface;

        void SetupDebugSession(string ScanListName)
        {
            for (int i=0; i < comboGroups.Items.Count; i++)
            {
                if (comboGroups.Items[i].Equals(ScanListName))
                {
                    comboGroups.SelectedIndex = i;
                }
            }
        }

        public ScannerPanel(ISharpControl control)
        {
            InitializeComponent();


            _controlInterface = control;

            if (LicenseManager.UsageMode==LicenseUsageMode.Runtime)
            {
                _settingsPersister = new SettingsPersister();
                _entries = _settingsPersister.ReadStoredFrequencies();
                _groups = GetGroupsFromEntries();
                ProcessGroups(null);
            }

          

            /*
            foreach (DataGridViewColumn column in frequencyDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }*/

            _scanner = new Scanner(_controlInterface, ScanNextFrequencyCallback, ScanNextFrequencyTimeLeftCallback);
            _scanner.SetScanStateChangedCallback = ScanStateChanged;
            _controlInterface.PropertyChanged += PropertyChangedEventHandler;

            memoryEntryBindingSource.DataSource = _displayedEntries;

           

#if(DEBUG)
            SetupDebugSession("BOS");
#endif
        }

        public String SelectedGroup
        {
            get { return (string)comboGroups.SelectedItem; }
            set
            {
                if (value!=null && comboGroups.Items.IndexOf(value) != -1)
                {
                    comboGroups.SelectedIndex = comboGroups.Items.IndexOf(value);
                }
            }
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            Bookmark();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (memoryEntryBindingSource.Current != null)
                DoEdit((MemoryEntry)memoryEntryBindingSource.Current, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var entry = (MemoryEntry) memoryEntryBindingSource.Current;
            if (entry != null && MessageBox.Show("Are you sure that you want to delete '"
              + entry.Name + "'?", "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _entries.Remove(entry);
                _settingsPersister.PersistStoredFrequencies(_entries);                
                _displayedEntries.Remove(entry);
            }
        }

        private void DoEdit(MemoryEntry memoryEntry, bool isNew)
        {
            var dialog = new DialogEntryInfo(memoryEntry, _groups);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (isNew)
                {
                    _entries.Add(memoryEntry);
                    _entries.Sort((e1, e2) => e1.Frequency.CompareTo(e2.Frequency));
                }
                _settingsPersister.PersistStoredFrequencies(_entries);
                if (!_groups.Contains(memoryEntry.GroupName))
                {
                    _groups.Add(memoryEntry.GroupName);
                    ProcessGroups(memoryEntry.GroupName);
                }
                else
                {
                    if ((string)comboGroups.SelectedItem == AllGroups || (string)comboGroups.SelectedItem == memoryEntry.GroupName ||
                        ((string)comboGroups.SelectedItem == FavouriteGroup && memoryEntry.IsFavourite))
                    {
                        if (isNew)
                            _displayedEntries.Add(memoryEntry);                            
                    }
                    else
                        comboGroups.SelectedItem = memoryEntry.GroupName;
                }
            }
        }

        private List<String> GetGroupsFromEntries()
        {
            var groups = new List<string>();
            foreach (MemoryEntry entry in _entries)
            {
                if (!groups.Contains(entry.GroupName))
                    groups.Add(entry.GroupName);
            }
            return groups;
        }

        private void frequencyDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (frequencyDataGridView.Columns[e.ColumnIndex].DataPropertyName == "Frequency" && e.Value != null)
            {
                var frequency = (long)e.Value;
                e.Value = GetFrequencyDisplay(frequency);
                e.FormattingApplied = true;
            }
        }

        private void frequencyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Navigate();
        }

        private void ProcessGroups(String selectedGroupName)
        {
            _groups.Sort();
            comboGroups.Items.Clear();
            comboGroups.Items.Add(AllGroups);
            comboGroups.Items.Add(FavouriteGroup);
            comboGroups.Items.AddRange(_groups.ToArray());
            if (selectedGroupName != null)
                comboGroups.SelectedItem = selectedGroupName;
            else
                comboGroups.SelectedIndex = 0;
        }

        private void comboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            memoryEntryBindingSource.Clear();
            _displayedEntries.Clear();
            if (comboGroups.SelectedIndex != -1)
            {
                var selectedGroup = (string) comboGroups.SelectedItem;
                
                foreach (MemoryEntry entry in _entries)
                {
                    if (selectedGroup == AllGroups || entry.GroupName == selectedGroup || (selectedGroup == FavouriteGroup && entry.IsFavourite ))
                    {
                        _displayedEntries.Add(entry);
                    }
                }
            }
        }

        private void frequencyDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = frequencyDataGridView.SelectedRows.Count > 0;
            btnEdit.Enabled = frequencyDataGridView.SelectedRows.Count > 0;
        }

        public void Bookmark()
        {
            
            //if (_controlInterface.Frequency == 0) return;
            if (!_controlInterface.IsPlaying) return;

            var memoryEntry = new MemoryEntry();

            memoryEntry.DetectorType = _controlInterface.DetectorType;
            memoryEntry.Frequency = _controlInterface.Frequency;
            memoryEntry.FilterBandwidth = _controlInterface.FilterBandwidth;
            memoryEntry.Shift = _controlInterface.FrequencyShiftEnabled ? _controlInterface.FrequencyShift : 0;
            memoryEntry.StayTunedLevel = -30;
            
            memoryEntry.GroupName = "Misc";
            if (_controlInterface.DetectorType == DetectorType.WFM)
            {
                var stationName = _controlInterface.RdsProgramService.Trim();
                memoryEntry.Name = string.Empty;
                if (!string.IsNullOrEmpty(stationName))
                {
                    memoryEntry.Name = stationName;
                }
                else
                {
                    memoryEntry.Name = GetFrequencyDisplay(_controlInterface.Frequency) + " " + memoryEntry.DetectorType;
                }
            }
            else
            {
                memoryEntry.Name = GetFrequencyDisplay(_controlInterface.Frequency) + " " + memoryEntry.DetectorType;
            }
            memoryEntry.IsFavourite = true;
            DoEdit(memoryEntry, true);
        }

        public void Navigate()
        {
            if (!_controlInterface.IsPlaying) return;

            var rowIndex = frequencyDataGridView.SelectedCells.Count > 0 ? frequencyDataGridView.SelectedCells[0].RowIndex : -1;
            if (rowIndex != -1)
            {
                try
                {
                    var memoryEntry = (MemoryEntry) memoryEntryBindingSource.List[rowIndex];


                    _controlInterface.FrequencyShiftEnabled = memoryEntry.Shift != 0;
                    if (_controlInterface.FrequencyShiftEnabled)
                    {
                        _controlInterface.FrequencyShift = memoryEntry.Shift;
                    }
                    _controlInterface.DetectorType = memoryEntry.DetectorType;
                    _controlInterface.FilterBandwidth = (int) memoryEntry.FilterBandwidth;
                    _controlInterface.Frequency = memoryEntry.Frequency;
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string GetFrequencyDisplay(long frequency)
        {
            string result;
            var absFrequency = Math.Abs(frequency);
            if (absFrequency == 0)
            {
                result = "DC";
            }
            else if (absFrequency > 1500000000)
            {
                result = string.Format("{0:#,0.000 000} GHz", frequency / 1000000000.0);
            }
            else if (absFrequency > 30000000)
            {
                result = string.Format("{0:0,0.000#} MHz", frequency / 1000000.0);
            }
            else if (absFrequency > 1000)
            {
                result = string.Format("{0:#,#.###} kHz", frequency / 1000.0);
            }
            else
            {
                result = frequency.ToString();
            }
            return result;
        }

        private void frequencyDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate();
                e.Handled = true;
            }
        }

        //####################################################################
        // Scanner Extension to Freq-Manager
        //####################################################################

        #region Scanner Extension to Freq-Manager

        List<MemoryEntry> GetScanEntries()
        {
            List<MemoryEntry> ScanEntries = new List<MemoryEntry>();

            foreach (MemoryEntry m in _displayedEntries)
            {
                ScanEntries.Add(m);
            }
            return ScanEntries;
        }

        void InitGui()
        {
            textBoxTriggerLevel.Text = "";
            textBoxTimeout.Text = "";
            textBoxRxLevel.Text = "";
            textBoxAvgBwPower.Text = "";
            textBoxPeakPowerBw.Text = "";
            textBoxWdog.Text = "";
            groupBoxMonitor.Text = "Monitor";
            comboGroups.Enabled = true;
        }
        void Start()
        {
            List<MemoryEntry> ScanEntries = GetScanEntries();

            if (ScanEntries.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("Add at least two entries to the scan list!");
                return;
            }

            comboGroups.Enabled = false;
            buttonStartStop.Text = "Stop";
            mainToolStrip.Enabled = false;
            ScanNextFrequencyCallback(0);
            _scanner.ScanTime = (int)numericUpDownScantime.Value;
            _scanner.ThresholdReleaseTime = (int)numericUpDownStayTunedThresholdTime.Value*1000;
            _scanner.Start(GetScanEntries());

            SetWdogTime();
        }

        void SetWdogTime()
        {
          if (checkBoxWdog.Checked)
          {
            _scanner.WdogTimerEnable = true;
            _scanner.WdogTime = (int)numericUpDownWdog.Value * 1000;
          }
        }

        void Stop()
        {
            buttonStartStop.Text = "Start";
            textBoxRxLevel.Text = "";
            mainToolStrip.Enabled = true;
            WaverecorderStop();
            _scanner.Stop();
            InitGui();
        }


        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text.Equals("Start"))
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void numericUpDownScantime_ValueChanged(object sender, EventArgs e)
        {
            _scanner.ScanTime = (int)numericUpDownScantime.Value;
        }

        private void numericUpDownStayTunedThresholdTime_ValueChanged(object sender, EventArgs e)
        {
            _scanner.ThresholdReleaseTime = (int)numericUpDownStayTunedThresholdTime.Value * 1000;

            if (numericUpDownWdog.Value <= (numericUpDownStayTunedThresholdTime.Value +  10))
            {
              numericUpDownWdog.Value += numericUpDownWdog.Increment;
              SetWdogTime();
            }
        }

        private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "StopRadio":
                    Stop();
                    buttonStartStop.Enabled = false;
                    break;
                case "StartRadio":
                    buttonStartStop.Enabled = true;
                    break;
                case "FFTResolution":
                    _scanner.Stop();
                    _scanner.Start(GetScanEntries());
                    break;
                case "AudioGain":
                case "FilterAudio":
                case "Frequency":
                case "CenterFrequency":
                case "FilterBandwidth":
                case "FilterOrder":
                case "FilterType":
                case "CorrectIq":
                case "FrequencyShiftEnabled":
                case "FrequencyShift":
                case "DetectorType":
                case "FmStereo":
                case "CWShift":
                case "SquelchThreshold":
                case "SquelchEnabled":
                case "SnapToGrid":
                case "StepSize":
                case "UseAgc":
                case "UseHang":
                case "AgcDecay":
                case "AgcThreshold":
                case "AgcSlope":
                case "SwapIq":
                case "SAttack":
                case "SDecay":
                case "WAttack":
                case "WDecay":
                case "MarkPeaks":
                case "UseTimeMarkers":
                

                    break;

                default:
                    break;
            }

        }

        void ScanStateChanged(ScannerState OldState, ScannerState NewState)
        {
            if (NewState == ScannerState.StayTuned)
            {
                if (comboBoxRecording.Text.ToLower().Equals("yes"))
                {
                    WaverecorderStart();
                }
            }
            else if (NewState == ScannerState.Scan)
            {
                WaverecorderStop();
            }
        }

        void ScanNextFrequencyTimeLeftCallback(double ScanTime, double WdogTime, ScannerState State)
        {

          ScanTime = ScanTime / 1000;
          WdogTime = WdogTime / 1000;

            try
            {
                if (_scanner.IsRxLevelValid)
                {
                  textBoxRxLevel.Text = String.Format("{0:F0}", _scanner.PeakPower);
                  textBoxAvgBwPower.Text = String.Format("{0:F0}", _scanner.PowerBanwidthAvg);
                  textBoxPeakPowerBw.Text = String.Format("{0:F0}", _scanner.PeakPowerBw);
                }
                else
                {
                    textBoxRxLevel.Text = "";
                }

                if (_scanner.State == ScannerState.StayTuned)
                {
                    frequencyDataGridView.DefaultCellStyle.SelectionBackColor = Color.Green;
                    if (_scanner.IsStayTunedStable)
                      textBoxTimeout.Text = DisableStringTextBox;
                    else
                      textBoxTimeout.Text = String.Format("{0:0.0}", ScanTime);

                    if (_scanner.WdogTimerEnable)
                      textBoxWdog.Text = String.Format("{0:0.0}", WdogTime);
                    else
                      textBoxWdog.Text = DisableStringTextBox;

                }
                else
                {
                    frequencyDataGridView.DefaultCellStyle.SelectionBackColor = Color.Blue;
                    textBoxTimeout.Text = String.Format("{0:0.0}", ScanTime);
                    textBoxWdog.Text = DisableStringTextBox;
                  
                }
            }
            catch (Exception)
            {

            }
        }

        void ScanNextFrequencyCallback(int MemoryIndex)
        {
            int i = 0;

            foreach (DataGridViewRow row in frequencyDataGridView.Rows)
            {
                if (i++ == MemoryIndex)
                {
                    frequencyDataGridView.Rows[MemoryIndex].Selected = true;
                    textBoxTriggerLevel.Text = _displayedEntries[MemoryIndex].StayTunedLevel.ToString();
                    groupBoxMonitor.Text = _displayedEntries[MemoryIndex].Name;

                   //if (MemoryIndex > 2)// && MemoryIndex % 4 == 0)
                    {
                        frequencyDataGridView.FirstDisplayedScrollingRowIndex = MemoryIndex ;
                        frequencyDataGridView.Update();
                    }
                }
            }

            frequencyDataGridView.Refresh();
        }

        #endregion

        
        private void numericUpDownScantime_ValueChangedaw(object sender, EventArgs e)
        {
            _scanner.ScanTime = (int)numericUpDownScantime.Value;
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scanner.Mode = (Scanner.ScannerCompareMode)comboBoxMode.SelectedIndex;
        }

        private void numericUpDownScantime_Enter(object sender, EventArgs e)
        {
            frequencyDataGridView.Focus();
        }

        private void numericUpDownStayTunedThresholdTime_Enter(object sender, EventArgs e)
        {
            frequencyDataGridView.Focus();
        }

        void WaverecorderStart()
        {
            Control c = GetWaveRecorderButton();
            if(c != null)
            {
                if (((Button)c).Text.Equals("Record"))
                {
                    ((Button)c).PerformClick();
                }
            }
        }

        void WaverecorderStop()
        {
            Control c = GetWaveRecorderButton();
            if(c != null)
            {
             if( ((Button)c).Text.Equals("Stop"))
             {
                ((Button)c).PerformClick();
             }
            }
        }
        private void ProcessAllControls(Control rootControl, string name, ref Control res)
        {
            foreach (Control childControl in rootControl.Controls)
            {
                ProcessAllControls(childControl, name,ref res);
                if (childControl.Name == name)
                {
                  res = childControl;
                }
            }
        }
        Control GetWaveRecorderButton()
        {
            Control res=null;
            Control p = null;
        
            ProcessAllControls(this.Parent.Parent, "RecordingPanel", ref p);
            if (p != null)
            {
               ProcessAllControls(p, "recBtn", ref res);
            }

            return res;
        }
        private void ScannerPanel_DoubleClick(object sender, EventArgs e)
        {

#if(DEBUG)
            _scanner.ScanDisable = !_scanner.ScanDisable;
            if (_scanner.ScanDisable)
                textBoxTimeout.BackColor = Color.Red;
            else
                textBoxTimeout.BackColor = Color.Green;
#endif
        }

        private void frequencyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ScannerPanel_Load(object sender, EventArgs e)
        {
          if (GetWaveRecorderButton() == null)
          {
            comboBoxRecording.Enabled = false;
          }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownWdog_ValueChanged(object sender, EventArgs e)
        {
          if (numericUpDownWdog.Value <= (numericUpDownStayTunedThresholdTime.Value + 10))
          {
            numericUpDownWdog.Value += numericUpDownWdog.Increment;
          }
          SetWdogTime();
        }

        private void checkBoxWdog_CheckedChanged(object sender, EventArgs e)
        {
          numericUpDownWdog.Enabled = checkBoxWdog.Checked;
          _scanner.WdogTimerEnable = checkBoxWdog.Checked;

           SetWdogTime();
        }
       
    }
}

