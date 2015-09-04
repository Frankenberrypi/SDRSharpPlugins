using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SDRSharp.Scanner
{
    public partial class DialogEntryInfo : Form
    {
        private MemoryEntry _memoryEntry;

        public DialogEntryInfo()
        {
            InitializeComponent();
            ValidateForm();
        }

        public DialogEntryInfo(MemoryEntry memoryEntry, List<string> groups)
        {
            _memoryEntry = memoryEntry;
            InitializeComponent();
            textBoxName.Text = memoryEntry.Name;
            comboGroupName.Text = memoryEntry.GroupName;
            frequencyNumericUpDown.Value = memoryEntry.Frequency;
            shiftNumericUpDown.Value = memoryEntry.Shift;
            lblMode.Text = memoryEntry.DetectorType.ToString();
            comboGroupName.Items.AddRange(groups.ToArray());
            nudFilterBandwidth.Value = memoryEntry.FilterBandwidth;
            favouriteCb.Checked = memoryEntry.IsFavourite;
            numericUpDownStayTunedLevel.Value = memoryEntry.StayTunedLevel;
            ValidateForm();
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void ValidateForm(){
            bool valid = textBoxName.Text != null && !"".Equals(textBoxName.Text.Trim())
                && comboGroupName.Text != null && !"".Equals(comboGroupName.Text.Trim())
                && frequencyNumericUpDown.Value != 0 && nudFilterBandwidth.Value!=0
                && numericUpDownStayTunedLevel.Value != 0;
            btnOk.Enabled = valid;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _memoryEntry.Name = textBoxName.Text.Trim();
            _memoryEntry.GroupName = comboGroupName.Text.Trim();
            _memoryEntry.Frequency = (long)frequencyNumericUpDown.Value;
            _memoryEntry.Shift = (long)shiftNumericUpDown.Value;
            _memoryEntry.FilterBandwidth = (long)nudFilterBandwidth.Value;
            _memoryEntry.IsFavourite = favouriteCb.Checked;
            _memoryEntry.StayTunedLevel = (int)numericUpDownStayTunedLevel.Value;
            DialogResult = DialogResult.OK;
        }

        private void numericUpDownStayTunedLevel_ValueChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}
