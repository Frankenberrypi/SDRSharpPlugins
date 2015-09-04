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
          this.label1 = new System.Windows.Forms.Label();
          this.textBoxRxLevel = new System.Windows.Forms.TextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.textBoxAvgBwPower = new System.Windows.Forms.TextBox();
          this.comboBoxMode = new System.Windows.Forms.ComboBox();
          this.label6 = new System.Windows.Forms.Label();
          this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
          this.label9 = new System.Windows.Forms.Label();
          this.textBoxPeakPowerBw = new System.Windows.Forms.TextBox();
          this.trackBar1 = new System.Windows.Forms.TrackBar();
          this.labelSpeed = new System.Windows.Forms.Label();
          this.richTextBox1 = new System.Windows.Forms.RichTextBox();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.aGauge1 = new System.Windows.Forms.AGauge();
          this.groupBoxMonitor.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.Location = new System.Drawing.Point(6, 15);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(120, 23);
          this.label1.TabIndex = 34;
          this.label1.Text = "Peak Power VFO [dB]";
          this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxRxLevel
          // 
          this.textBoxRxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxRxLevel.Location = new System.Drawing.Point(132, 17);
          this.textBoxRxLevel.Name = "textBoxRxLevel";
          this.textBoxRxLevel.ReadOnly = true;
          this.textBoxRxLevel.Size = new System.Drawing.Size(47, 20);
          this.textBoxRxLevel.TabIndex = 33;
          this.textBoxRxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // label7
          // 
          this.label7.Location = new System.Drawing.Point(6, 38);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(110, 23);
          this.label7.TabIndex = 45;
          this.label7.Text = "Avg Power BW  [dB]";
          this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxAvgBwPower
          // 
          this.textBoxAvgBwPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxAvgBwPower.Location = new System.Drawing.Point(132, 41);
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
          this.groupBoxMonitor.Controls.Add(this.label9);
          this.groupBoxMonitor.Controls.Add(this.textBoxPeakPowerBw);
          this.groupBoxMonitor.Controls.Add(this.textBoxRxLevel);
          this.groupBoxMonitor.Controls.Add(this.label7);
          this.groupBoxMonitor.Controls.Add(this.label1);
          this.groupBoxMonitor.Controls.Add(this.textBoxAvgBwPower);
          this.groupBoxMonitor.Location = new System.Drawing.Point(3, 288);
          this.groupBoxMonitor.Name = "groupBoxMonitor";
          this.groupBoxMonitor.Size = new System.Drawing.Size(202, 98);
          this.groupBoxMonitor.TabIndex = 50;
          this.groupBoxMonitor.TabStop = false;
          // 
          // label9
          // 
          this.label9.Location = new System.Drawing.Point(6, 62);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(117, 23);
          this.label9.TabIndex = 47;
          this.label9.Text = "Peak Power BW  [dB]";
          this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxPeakPowerBw
          // 
          this.textBoxPeakPowerBw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxPeakPowerBw.Location = new System.Drawing.Point(132, 65);
          this.textBoxPeakPowerBw.Name = "textBoxPeakPowerBw";
          this.textBoxPeakPowerBw.ReadOnly = true;
          this.textBoxPeakPowerBw.Size = new System.Drawing.Size(47, 20);
          this.textBoxPeakPowerBw.TabIndex = 46;
          this.textBoxPeakPowerBw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // trackBar1
          // 
          this.trackBar1.Location = new System.Drawing.Point(70, 41);
          this.trackBar1.Maximum = 300;
          this.trackBar1.Minimum = 1;
          this.trackBar1.Name = "trackBar1";
          this.trackBar1.Size = new System.Drawing.Size(126, 45);
          this.trackBar1.TabIndex = 55;
          this.trackBar1.TickFrequency = 50;
          this.trackBar1.Value = 1;
          this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
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
          // richTextBox1
          // 
          this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
          this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
          this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.richTextBox1.Location = new System.Drawing.Point(16, 167);
          this.richTextBox1.Name = "richTextBox1";
          this.richTextBox1.Size = new System.Drawing.Size(179, 37);
          this.richTextBox1.TabIndex = 53;
          this.richTextBox1.Text = "     0 dB";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.trackBar1);
          this.groupBox1.Controls.Add(this.labelSpeed);
          this.groupBox1.Controls.Add(this.comboBoxMode);
          this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Location = new System.Drawing.Point(3, 204);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(202, 87);
          this.groupBox1.TabIndex = 55;
          this.groupBox1.TabStop = false;
          // 
          // aGauge1
          // 
          this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
          this.aGauge1.BaseArcRadius = 80;
          this.aGauge1.BaseArcStart = 185;
          this.aGauge1.BaseArcSweep = 170;
          this.aGauge1.BaseArcWidth = 2;
          this.aGauge1.Center = new System.Drawing.Point(105, 130);
          aGaugeLabel1.Color = System.Drawing.SystemColors.WindowText;
          aGaugeLabel1.Name = "GaugeLabelMode";
          aGaugeLabel1.Position = new System.Drawing.Point(10, 10);
          aGaugeLabel1.Text = "Mode";
          this.aGauge1.GaugeLabels.Add(aGaugeLabel1);
          this.aGauge1.Location = new System.Drawing.Point(3, 18);
          this.aGauge1.MaxValue = 0F;
          this.aGauge1.MinValue = -130F;
          this.aGauge1.Name = "aGauge1";
          this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Blue;
          this.aGauge1.NeedleColor2 = System.Drawing.Color.Magenta;
          this.aGauge1.NeedleRadius = 85;
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
          this.aGauge1.TabIndex = 54;
          this.aGauge1.Text = "aGauge1";
          this.aGauge1.Value = -30F;
          // 
          // LevelMeterPanel
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.groupBoxMonitor);
          this.Controls.Add(this.richTextBox1);
          this.Controls.Add(this.aGauge1);
          this.Margin = new System.Windows.Forms.Padding(2);
          this.Name = "LevelMeterPanel";
          this.Size = new System.Drawing.Size(208, 392);
          this.groupBoxMonitor.ResumeLayout(false);
          this.groupBoxMonitor.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRxLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAvgBwPower;
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPeakPowerBw;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.AGauge aGauge1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
