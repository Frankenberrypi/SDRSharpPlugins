using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDRSharp.LevelMeter
{
  

  public partial class LevelMeterTool : Form
  {
    public LevelMeterTool()
    {
      InitializeComponent();
    }

    public void OnLevelUpdate(string Mode, string Frequency, float Value, string Slevel)
    {
      aGauge1.Value = Value;
      aGauge1.GaugeLabels[0].Text = Mode;
      aGauge1.GaugeLabels[1].Text = Slevel;
      richTextBox1.Text = String.Format("     {0:F0} dBm", Value);
      this.Text = "LevelMeter @ " + Frequency;
    }

    private void LevelMeterTool_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      this.TopMost = checkBox1.Checked;
    }
  }
}
