namespace SDRSharp.Scanner
{
    partial class ScannerPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNewEntry = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label17 = new System.Windows.Forms.Label();
            this.frequencyDataGridView = new System.Windows.Forms.DataGridView();
            this.comboGroups = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTriggerLevel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRxLevel = new System.Windows.Forms.TextBox();
            this.numericUpDownStayTunedThresholdTime = new System.Windows.Forms.NumericUpDown();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownScantime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAvgBwPower = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRecording = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoryEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStayTunedThresholdTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScantime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryEntryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainToolStrip.AutoSize = false;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewEntry,
            this.btnEdit,
            this.btnDelete});
            this.mainToolStrip.Location = new System.Drawing.Point(10, 315);
            this.mainToolStrip.MinimumSize = new System.Drawing.Size(205, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(205, 28);
            this.mainToolStrip.Stretch = true;
            this.mainToolStrip.TabIndex = 7;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEntry.Image")));
            this.btnNewEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(48, 25);
            this.btnNewEntry.Text = "New";
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 25);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 25);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 348);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Group:";
            // 
            // frequencyDataGridView
            // 
            this.frequencyDataGridView.AllowUserToAddRows = false;
            this.frequencyDataGridView.AllowUserToDeleteRows = false;
            this.frequencyDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frequencyDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.frequencyDataGridView.AutoGenerateColumns = false;
            this.frequencyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frequencyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn});
            this.frequencyDataGridView.DataSource = this.memoryEntryBindingSource;
            this.frequencyDataGridView.Location = new System.Drawing.Point(7, 394);
            this.frequencyDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyDataGridView.MultiSelect = false;
            this.frequencyDataGridView.Name = "frequencyDataGridView";
            this.frequencyDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.frequencyDataGridView.RowHeadersVisible = false;
            this.frequencyDataGridView.RowTemplate.Height = 24;
            this.frequencyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.frequencyDataGridView.ShowCellErrors = false;
            this.frequencyDataGridView.ShowCellToolTips = false;
            this.frequencyDataGridView.ShowEditingIcon = false;
            this.frequencyDataGridView.ShowRowErrors = false;
            this.frequencyDataGridView.Size = new System.Drawing.Size(208, 149);
            this.frequencyDataGridView.TabIndex = 6;
            this.frequencyDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.frequencyDataGridView_CellDoubleClick);
            this.frequencyDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.frequencyDataGridView_CellFormatting);
            this.frequencyDataGridView.SelectionChanged += new System.EventHandler(this.frequencyDataGridView_SelectionChanged);
            this.frequencyDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frequencyDataGridView_KeyDown);
            // 
            // comboGroups
            // 
            this.comboGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGroups.FormattingEnabled = true;
            this.comboGroups.Location = new System.Drawing.Point(50, 345);
            this.comboGroups.Margin = new System.Windows.Forms.Padding(2);
            this.comboGroups.Name = "comboGroups";
            this.comboGroups.Size = new System.Drawing.Size(157, 21);
            this.comboGroups.TabIndex = 4;
            this.comboGroups.SelectedIndexChanged += new System.EventHandler(this.comboGroups_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Timeout [s]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(150, 46);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.ReadOnly = true;
            this.textBoxTimeout.Size = new System.Drawing.Size(47, 20);
            this.textBoxTimeout.TabIndex = 37;
            this.textBoxTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "given Trigger Level [dB]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTriggerLevel
            // 
            this.textBoxTriggerLevel.Location = new System.Drawing.Point(150, 22);
            this.textBoxTriggerLevel.Name = "textBoxTriggerLevel";
            this.textBoxTriggerLevel.ReadOnly = true;
            this.textBoxTriggerLevel.Size = new System.Drawing.Size(47, 20);
            this.textBoxTriggerLevel.TabIndex = 35;
            this.textBoxTriggerLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "Peak Power [dB]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRxLevel
            // 
            this.textBoxRxLevel.Location = new System.Drawing.Point(150, 71);
            this.textBoxRxLevel.Name = "textBoxRxLevel";
            this.textBoxRxLevel.ReadOnly = true;
            this.textBoxRxLevel.Size = new System.Drawing.Size(47, 20);
            this.textBoxRxLevel.TabIndex = 33;
            this.textBoxRxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownStayTunedThresholdTime
            // 
            this.numericUpDownStayTunedThresholdTime.Location = new System.Drawing.Point(150, 93);
            this.numericUpDownStayTunedThresholdTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDownStayTunedThresholdTime.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownStayTunedThresholdTime.Name = "numericUpDownStayTunedThresholdTime";
            this.numericUpDownStayTunedThresholdTime.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownStayTunedThresholdTime.TabIndex = 31;
            this.numericUpDownStayTunedThresholdTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStayTunedThresholdTime.ValueChanged += new System.EventHandler(this.numericUpDownStayTunedThresholdTime_ValueChanged);
            this.numericUpDownStayTunedThresholdTime.Enter += new System.EventHandler(this.numericUpDownStayTunedThresholdTime_Enter);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Enabled = false;
            this.buttonStartStop.Location = new System.Drawing.Point(6, 26);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(200, 23);
            this.buttonStartStop.TabIndex = 32;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Thresh. Release Time [s]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownScantime
            // 
            this.numericUpDownScantime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownScantime.Location = new System.Drawing.Point(150, 70);
            this.numericUpDownScantime.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericUpDownScantime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownScantime.Name = "numericUpDownScantime";
            this.numericUpDownScantime.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownScantime.TabIndex = 28;
            this.numericUpDownScantime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownScantime.ValueChanged += new System.EventHandler(this.numericUpDownScantime_ValueChanged);
            this.numericUpDownScantime.Enter += new System.EventHandler(this.numericUpDownScantime_Enter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Scan Intervall [ms]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Peak Power",
            "Avg BW Power"});
            this.comboBoxMode.Location = new System.Drawing.Point(92, 20);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(103, 21);
            this.comboBoxMode.TabIndex = 42;
            this.comboBoxMode.Text = "Peak Power";
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 43;
            this.label6.Text = "Measuring Mode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 23);
            this.label7.TabIndex = 45;
            this.label7.Text = "Avg BW Power [dB]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxAvgBwPower
            // 
            this.textBoxAvgBwPower.Location = new System.Drawing.Point(150, 97);
            this.textBoxAvgBwPower.Name = "textBoxAvgBwPower";
            this.textBoxAvgBwPower.ReadOnly = true;
            this.textBoxAvgBwPower.Size = new System.Drawing.Size(47, 20);
            this.textBoxAvgBwPower.TabIndex = 44;
            this.textBoxAvgBwPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 23);
            this.label8.TabIndex = 47;
            this.label8.Text = "Recording";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxRecording
            // 
            this.comboBoxRecording.FormattingEnabled = true;
            this.comboBoxRecording.Items.AddRange(new object[] {
            "no",
            "yes"});
            this.comboBoxRecording.Location = new System.Drawing.Point(94, 45);
            this.comboBoxRecording.Name = "comboBoxRecording";
            this.comboBoxRecording.Size = new System.Drawing.Size(103, 21);
            this.comboBoxRecording.TabIndex = 48;
            this.comboBoxRecording.Text = "no";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxRecording);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDownScantime);
            this.groupBox1.Controls.Add(this.numericUpDownStayTunedThresholdTime);
            this.groupBox1.Controls.Add(this.comboBoxMode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(9, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 125);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxRxLevel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxAvgBwPower);
            this.groupBox2.Controls.Add(this.textBoxTriggerLevel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxTimeout);
            this.groupBox2.Location = new System.Drawing.Point(9, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 130);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monitor";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            this.frequencyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // memoryEntryBindingSource
            // 
            this.memoryEntryBindingSource.DataSource = typeof(SDRSharp.Scanner.MemoryEntry);
            // 
            // ScannerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboGroups);
            this.Controls.Add(this.frequencyDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScannerPanel";
            this.Size = new System.Drawing.Size(219, 550);
            this.DoubleClick += new System.EventHandler(this.ScannerPanel_DoubleClick);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStayTunedThresholdTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScantime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryEntryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton btnNewEntry;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView frequencyDataGridView;
        private System.Windows.Forms.ComboBox comboGroups;
        private System.Windows.Forms.BindingSource memoryEntryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTriggerLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRxLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownStayTunedThresholdTime;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownScantime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAvgBwPower;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxRecording;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
