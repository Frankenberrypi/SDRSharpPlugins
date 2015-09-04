namespace SDRSharp.LevelMeter
{
  partial class LevelMeterTool
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.AGaugeLabel aGaugeLabel1 = new System.Windows.Forms.AGaugeLabel();
      System.Windows.Forms.AGaugeLabel aGaugeLabel2 = new System.Windows.Forms.AGaugeLabel();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.aGauge1 = new System.Windows.Forms.AGauge();
      this.SuspendLayout();
      // 
      // richTextBox1
      // 
      this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
      this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBox1.Location = new System.Drawing.Point(0, 146);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.Size = new System.Drawing.Size(213, 37);
      this.richTextBox1.TabIndex = 56;
      this.richTextBox1.Text = "     0 dB";
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(4, 189);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(59, 17);
      this.checkBox1.TabIndex = 57;
      this.checkBox1.Text = "OnTop";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // aGauge1
      // 
      this.aGauge1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
      this.aGauge1.BaseArcRadius = 80;
      this.aGauge1.BaseArcStart = 185;
      this.aGauge1.BaseArcSweep = 170;
      this.aGauge1.BaseArcWidth = 2;
      this.aGauge1.Center = new System.Drawing.Point(105, 130);
      aGaugeLabel1.Color = System.Drawing.SystemColors.WindowText;
      aGaugeLabel1.Name = "GaugeLabelMode";
      aGaugeLabel1.Position = new System.Drawing.Point(5, 10);
      aGaugeLabel1.Text = "Mode";
      aGaugeLabel2.Color = System.Drawing.SystemColors.WindowText;
      aGaugeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      aGaugeLabel2.Name = "GaugeLabelSLevel";
      aGaugeLabel2.Position = new System.Drawing.Point(140, 5);
      aGaugeLabel2.Text = "S0";
      this.aGauge1.GaugeLabels.Add(aGaugeLabel1);
      this.aGauge1.GaugeLabels.Add(aGaugeLabel2);
      this.aGauge1.Location = new System.Drawing.Point(4, 2);
      this.aGauge1.MaxValue = 0F;
      this.aGauge1.MinValue = -130F;
      this.aGauge1.Name = "aGauge1";
      this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Blue;
      this.aGauge1.NeedleColor2 = System.Drawing.Color.HotPink;
      this.aGauge1.NeedleRadius = 80;
      this.aGauge1.NeedleType = System.Windows.Forms.NeedleType.Advance;
      this.aGauge1.NeedleWidth = 2;
      this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
      this.aGauge1.ScaleLinesInterInnerRadius = 73;
      this.aGauge1.ScaleLinesInterOuterRadius = 80;
      this.aGauge1.ScaleLinesInterWidth = 1;
      this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
      this.aGauge1.ScaleLinesMajorInnerRadius = 70;
      this.aGauge1.ScaleLinesMajorOuterRadius = 80;
      this.aGauge1.ScaleLinesMajorStepValue = 10F;
      this.aGauge1.ScaleLinesMajorWidth = 2;
      this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
      this.aGauge1.ScaleLinesMinorInnerRadius = 75;
      this.aGauge1.ScaleLinesMinorOuterRadius = 80;
      this.aGauge1.ScaleLinesMinorTicks = 1;
      this.aGauge1.ScaleLinesMinorWidth = 1;
      this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Black;
      this.aGauge1.ScaleNumbersFormat = null;
      this.aGauge1.ScaleNumbersRadius = 95;
      this.aGauge1.ScaleNumbersRotation = 0;
      this.aGauge1.ScaleNumbersStartScaleLine = 0;
      this.aGauge1.ScaleNumbersStepScaleLines = 1;
      this.aGauge1.Size = new System.Drawing.Size(205, 180);
      this.aGauge1.TabIndex = 58;
      this.aGauge1.Text = "aGauge1";
      this.aGauge1.Value = -30F;
      // 
      // LevelMeterTool
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(212, 209);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.aGauge1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "LevelMeterTool";
      this.ShowInTaskbar = false;
      this.Text = "LevelMeter";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelMeterTool_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.AGauge aGauge1;
  }
}