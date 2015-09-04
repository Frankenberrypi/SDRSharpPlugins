namespace SDRSharp.LevelMeter
{
    partial class LevelMeterPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
          SaveOptions();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.Windows.Forms.AGaugeLabel aGaugeLabel1 = new System.Windows.Forms.AGaugeLabel();
      System.Windows.Forms.AGaugeLabel aGaugeLabel2 = new System.Windows.Forms.AGaugeLabel();
      this.labelPowerVfo = new System.Windows.Forms.Label();
      this.textBoxRxLevel = new System.Windows.Forms.TextBox();
      this.labelAvgPowerBw = new System.Windows.Forms.Label();
      this.textBoxAvgBwPower = new System.Windows.Forms.TextBox();
      this.comboBoxMode = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
      this.labelPeakPwerBw = new System.Windows.Forms.Label();
      this.textBoxPeakPowerBw = new System.Windows.Forms.TextBox();
      this.cbShowPopup = new System.Windows.Forms.CheckBox();
      this.tbSmoothing = new System.Windows.Forms.TrackBar();
      this.labelSpeed = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBoxEnable = new System.Windows.Forms.CheckBox();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.aGauge1 = new System.Windows.Forms.AGauge();
      this.groupBoxMonitor.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbSmoothing)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelPowerVfo
      // 
      this.labelPowerVfo.Location = new System.Drawing.Point(6, 15);
      this.labelPowerVfo.Name = "labelPowerVfo";
      this.labelPowerVfo.Size = new System.Drawing.Size(132, 23);
      this.labelPowerVfo.TabIndex = 34;
      this.labelPowerVfo.Text = "Peak Power VFO ";
      this.labelPowerVfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxRxLevel
      // 
      this.textBoxRxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBoxRxLevel.Location = new System.Drawing.Point(144, 17);
      this.textBoxRxLevel.Name = "textBoxRxLevel";
      this.textBoxRxLevel.ReadOnly = true;
      this.textBoxRxLevel.Size = new System.Drawing.Size(47, 20);
      this.textBoxRxLevel.TabIndex = 33;
      this.textBoxRxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // labelAvgPowerBw
      // 
      this.labelAvgPowerBw.Location = new System.Drawing.Point(6, 38);
      this.labelAvgPowerBw.Name = "labelAvgPowerBw";
      this.labelAvgPowerBw.Size = new System.Drawing.Size(132, 23);
      this.labelAvgPowerBw.TabIndex = 45;
      this.labelAvgPowerBw.Text = "Avg Power BW ";
      this.labelAvgPowerBw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxAvgBwPower
      // 
      this.textBoxAvgBwPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBoxAvgBwPower.Location = new System.Drawing.Point(144, 41);
      this.textBoxAvgBwPower.Name = "textBoxAvgBwPower";
      this.textBoxAvgBwPower.ReadOnly = true;
      this.textBoxAvgBwPower.Size = new System.Drawing.Size(47, 20);
      this.textBoxAvgBwPower.TabIndex = 44;
      this.textBoxAvgBwPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // comboBoxMode
      // 
      this.comboBoxMode.FormattingEnabled = true;
      this.comboBoxMode.Items.AddRange(new object[] {
            "Peak Power VFO",
            "Avg Power BW",
            "Peak Power BW"});
      this.comboBoxMode.Location = new System.Drawing.Point(60, 19);
      this.comboBoxMode.Name = "comboBoxMode";
      this.comboBoxMode.Size = new System.Drawing.Size(129, 21);
      this.comboBoxMode.TabIndex = 42;
      this.comboBoxMode.Text = "Peak Power VFO";
      this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(10, 18);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(54, 23);
      this.label6.TabIndex = 43;
      this.label6.Text = "Mode";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // groupBoxMonitor
      // 
      this.groupBoxMonitor.Controls.Add(this.labelPeakPwerBw);
      this.groupBoxMonitor.Controls.Add(this.textBoxPeakPowerBw);
      this.groupBoxMonitor.Controls.Add(this.textBoxRxLevel);
      this.groupBoxMonitor.Controls.Add(this.labelAvgPowerBw);
      this.groupBoxMonitor.Controls.Add(this.labelPowerVfo);
      this.groupBoxMonitor.Controls.Add(this.textBoxAvgBwPower);
      this.groupBoxMonitor.Location = new System.Drawing.Point(3, 311);
      this.groupBoxMonitor.Name = "groupBoxMonitor";
      this.groupBoxMonitor.Size = new System.Drawing.Size(202, 93);
      this.groupBoxMonitor.TabIndex = 50;
      this.groupBoxMonitor.TabStop = false;
      // 
      // labelPeakPwerBw
      // 
      this.labelPeakPwerBw.Location = new System.Drawing.Point(6, 62);
      this.labelPeakPwerBw.Name = "labelPeakPwerBw";
      this.labelPeakPwerBw.Size = new System.Drawing.Size(132, 23);
      this.labelPeakPwerBw.TabIndex = 47;
      this.labelPeakPwerBw.Text = "Peak Power BW  ";
      this.labelPeakPwerBw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxPeakPowerBw
      // 
      this.textBoxPeakPowerBw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBoxPeakPowerBw.Location = new System.Drawing.Point(144, 65);
      this.textBoxPeakPowerBw.Name = "textBoxPeakPowerBw";
      this.textBoxPeakPowerBw.ReadOnly = true;
      this.textBoxPeakPowerBw.Size = new System.Drawing.Size(47, 20);
      this.textBoxPeakPowerBw.TabIndex = 46;
      this.textBoxPeakPowerBw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // cbShowPopup
      // 
      this.cbShowPopup.AutoSize = true;
      this.cbShowPopup.Location = new System.Drawing.Point(13, 96);
      this.cbShowPopup.Name = "cbShowPopup";
      this.cbShowPopup.Size = new System.Drawing.Size(123, 17);
      this.cbShowPopup.TabIndex = 48;
      this.cbShowPopup.Text = "show popup window";
      this.cbShowPopup.UseVisualStyleBackColor = true;
      this.cbShowPopup.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // tbSmoothing
      // 
      this.tbSmoothing.Location = new System.Drawing.Point(70, 41);
      this.tbSmoothing.Maximum = 300;
      this.tbSmoothing.Minimum = 1;
      this.tbSmoothing.Name = "tbSmoothing";
      this.tbSmoothing.Size = new System.Drawing.Size(126, 45);
      this.tbSmoothing.TabIndex = 55;
      this.tbSmoothing.TickFrequency = 50;
      this.tbSmoothing.Value = 100;
      // 
      // labelSpeed
      // 
      this.labelSpeed.AutoSize = true;
      this.labelSpeed.Location = new System.Drawing.Point(8, 46);
      this.labelSpeed.Name = "labelSpeed";
      this.labelSpeed.Size = new System.Drawing.Size(57, 13);
      this.labelSpeed.TabIndex = 56;
      this.labelSpeed.Text = "Smoothing";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.checkBoxEnable);
      this.groupBox1.Controls.Add(this.cbShowPopup);
      this.groupBox1.Controls.Add(this.tbSmoothing);
      this.groupBox1.Controls.Add(this.labelSpeed);
      this.groupBox1.Controls.Add(this.comboBoxMode);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Location = new System.Drawing.Point(3, 188);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(202, 126);
      this.groupBox1.TabIndex = 55;
      this.groupBox1.TabStop = false;
      // 
      // checkBoxEnable
      // 
      this.checkBoxEnable.AutoSize = true;
      this.checkBoxEnable.Location = new System.Drawing.Point(13, 73);
      this.checkBoxEnable.Name = "checkBoxEnable";
      this.checkBoxEnable.Size = new System.Drawing.Size(58, 17);
      this.checkBoxEnable.TabIndex = 57;
      this.checkBoxEnable.Text = "enable";
      this.checkBoxEnable.UseVisualStyleBackColor = true;
      this.checkBoxEnable.CheckedChanged += new System.EventHandler(this.checkBoxEnable_CheckedChanged);
      // 
      // richTextBox1
      // 
      this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
      this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBox1.Location = new System.Drawing.Point(3, 150);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.Size = new System.Drawing.Size(202, 37);
      this.richTextBox1.TabIndex = 60;
      this.richTextBox1.Text = "     0 dB";
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
      this.aGauge1.Location = new System.Drawing.Point(3, 6);
      this.aGauge1.MaxValue = 0F;
      this.aGauge1.MinValue = -140F;
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
      this.aGauge1.ScaleNumbersRadius = 93;
      this.aGauge1.ScaleNumbersRotation = 0;
      this.aGauge1.ScaleNumbersStartScaleLine = 0;
      this.aGauge1.ScaleNumbersStepScaleLines = 1;
      this.aGauge1.Size = new System.Drawing.Size(205, 180);
      this.aGauge1.TabIndex = 59;
      this.aGauge1.Text = "aGauge1";
      this.aGauge1.Value = -30F;
      // 
      // LevelMeterPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.aGauge1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBoxMonitor);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "LevelMeterPanel";
      this.Size = new System.Drawing.Size(212, 436);
      this.groupBoxMonitor.ResumeLayout(false);
      this.groupBoxMonitor.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbSmoothing)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPowerVfo;
        private System.Windows.Forms.TextBox textBoxRxLevel;
        private System.Windows.Forms.Label labelAvgPowerBw;
        private System.Windows.Forms.TextBox textBoxAvgBwPower;
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.Label labelPeakPwerBw;
        private System.Windows.Forms.TextBox textBoxPeakPowerBw;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbSmoothing;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.AGauge aGauge1;
        private System.Windows.Forms.CheckBox cbShowPopup;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxEnable;
    }
}
