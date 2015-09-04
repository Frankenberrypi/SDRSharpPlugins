namespace SDRSharp.EasyScanner
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
          this.checkBoxWdog = new System.Windows.Forms.CheckBox();
          this.label10 = new System.Windows.Forms.Label();
          this.numericUpDownWdog = new System.Windows.Forms.NumericUpDown();
          this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
          this.label11 = new System.Windows.Forms.Label();
          this.textBoxWdog = new System.Windows.Forms.TextBox();
          this.label9 = new System.Windows.Forms.Label();
          this.textBoxPeakPowerBw = new System.Windows.Forms.TextBox();
          this.tabControl1 = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.memoryEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
          this.mainToolStrip.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.frequencyDataGridView)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStayTunedThresholdTime)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScantime)).BeginInit();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWdog)).BeginInit();
          this.groupBoxMonitor.SuspendLayout();
          this.tabControl1.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
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
          this.mainToolStrip.Location = new System.Drawing.Point(3, 3);
          this.mainToolStrip.MinimumSize = new System.Drawing.Size(180, 0);
          this.mainToolStrip.Name = "mainToolStrip";
          this.mainToolStrip.Size = new System.Drawing.Size(195, 28);
          this.mainToolStrip.Stretch = true;
          this.mainToolStrip.TabIndex = 7;
          this.mainToolStrip.Text = "toolStrip1";
          // 
          // btnNewEntry
          // 
          this.btnNewEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEntry.Image")));
          this.btnNewEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.btnNewEntry.Name = "btnNewEntry";
          this.btnNewEntry.Size = new System.Drawing.Size(51, 25);
          this.btnNewEntry.Text = "New";
          this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
          // 
          // btnEdit
          // 
          this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
          this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.btnEdit.Name = "btnEdit";
          this.btnEdit.Size = new System.Drawing.Size(47, 25);
          this.btnEdit.Text = "Edit";
          this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
          // 
          // btnDelete
          // 
          this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
          this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.btnDelete.Name = "btnDelete";
          this.btnDelete.Size = new System.Drawing.Size(60, 25);
          this.btnDelete.Text = "Delete";
          this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
          // 
          // label17
          // 
          this.label17.AutoSize = true;
          this.label17.Location = new System.Drawing.Point(18, 36);
          this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.label17.Name = "label17";
          this.label17.Size = new System.Drawing.Size(39, 13);
          this.label17.TabIndex = 5;
          this.label17.Text = "Group:";
          this.label17.Click += new System.EventHandler(this.label17_Click);
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
          this.frequencyDataGridView.Location = new System.Drawing.Point(1, 67);
          this.frequencyDataGridView.Margin = new System.Windows.Forms.Padding(2);
          this.frequencyDataGridView.MultiSelect = false;
          this.frequencyDataGridView.Name = "frequencyDataGridView";
          this.frequencyDataGridView.ReadOnly = true;
          this.frequencyDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
          this.frequencyDataGridView.RowHeadersVisible = false;
          this.frequencyDataGridView.RowTemplate.Height = 24;
          this.frequencyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.frequencyDataGridView.ShowCellErrors = false;
          this.frequencyDataGridView.ShowCellToolTips = false;
          this.frequencyDataGridView.ShowEditingIcon = false;
          this.frequencyDataGridView.ShowRowErrors = false;
          this.frequencyDataGridView.Size = new System.Drawing.Size(200, 273);
          this.frequencyDataGridView.TabIndex = 6;
          this.frequencyDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.frequencyDataGridView_CellContentClick);
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
          this.comboGroups.Location = new System.Drawing.Point(61, 33);
          this.comboGroups.Margin = new System.Windows.Forms.Padding(2);
          this.comboGroups.Name = "comboGroups";
          this.comboGroups.Size = new System.Drawing.Size(132, 21);
          this.comboGroups.TabIndex = 4;
          this.comboGroups.SelectedIndexChanged += new System.EventHandler(this.comboGroups_SelectedIndexChanged);
          // 
          // label4
          // 
          this.label4.Location = new System.Drawing.Point(6, 116);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(121, 23);
          this.label4.TabIndex = 38;
          this.label4.Text = "Release Timeout [s]";
          this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxTimeout
          // 
          this.textBoxTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxTimeout.Location = new System.Drawing.Point(133, 119);
          this.textBoxTimeout.Name = "textBoxTimeout";
          this.textBoxTimeout.ReadOnly = true;
          this.textBoxTimeout.Size = new System.Drawing.Size(47, 20);
          this.textBoxTimeout.TabIndex = 37;
          this.textBoxTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // label3
          // 
          this.label3.Location = new System.Drawing.Point(6, 19);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(121, 23);
          this.label3.TabIndex = 36;
          this.label3.Text = "Trigger Level [dB]";
          this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxTriggerLevel
          // 
          this.textBoxTriggerLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxTriggerLevel.Location = new System.Drawing.Point(133, 22);
          this.textBoxTriggerLevel.Name = "textBoxTriggerLevel";
          this.textBoxTriggerLevel.ReadOnly = true;
          this.textBoxTriggerLevel.Size = new System.Drawing.Size(47, 20);
          this.textBoxTriggerLevel.TabIndex = 35;
          this.textBoxTriggerLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // label1
          // 
          this.label1.Location = new System.Drawing.Point(6, 43);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(138, 23);
          this.label1.TabIndex = 34;
          this.label1.Text = "Peak Power [dB]";
          this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxRxLevel
          // 
          this.textBoxRxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxRxLevel.Location = new System.Drawing.Point(133, 46);
          this.textBoxRxLevel.Name = "textBoxRxLevel";
          this.textBoxRxLevel.ReadOnly = true;
          this.textBoxRxLevel.Size = new System.Drawing.Size(47, 20);
          this.textBoxRxLevel.TabIndex = 33;
          this.textBoxRxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // numericUpDownStayTunedThresholdTime
          // 
          this.numericUpDownStayTunedThresholdTime.Location = new System.Drawing.Point(133, 95);
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
          this.buttonStartStop.Location = new System.Drawing.Point(7, 31);
          this.buttonStartStop.Name = "buttonStartStop";
          this.buttonStartStop.Size = new System.Drawing.Size(193, 23);
          this.buttonStartStop.TabIndex = 32;
          this.buttonStartStop.Text = "Start";
          this.buttonStartStop.UseVisualStyleBackColor = true;
          this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
          // 
          // label2
          // 
          this.label2.Location = new System.Drawing.Point(6, 92);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(121, 23);
          this.label2.TabIndex = 30;
          this.label2.Text = "Release Timer [s]";
          this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // numericUpDownScantime
          // 
          this.numericUpDownScantime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
          this.numericUpDownScantime.Location = new System.Drawing.Point(133, 70);
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
            "Avg Power BW",
            "Peak Power BW"});
          this.comboBoxMode.Location = new System.Drawing.Point(77, 20);
          this.comboBoxMode.Name = "comboBoxMode";
          this.comboBoxMode.Size = new System.Drawing.Size(103, 21);
          this.comboBoxMode.TabIndex = 42;
          this.comboBoxMode.Text = "Peak Power BW";
          this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
          // 
          // label6
          // 
          this.label6.Location = new System.Drawing.Point(6, 20);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(65, 23);
          this.label6.TabIndex = 43;
          this.label6.Text = "Mode";
          this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // label7
          // 
          this.label7.Location = new System.Drawing.Point(6, 67);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(121, 23);
          this.label7.TabIndex = 45;
          this.label7.Text = "Avg Power BW  [dB]";
          this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxAvgBwPower
          // 
          this.textBoxAvgBwPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxAvgBwPower.Location = new System.Drawing.Point(133, 70);
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
          this.comboBoxRecording.Location = new System.Drawing.Point(77, 45);
          this.comboBoxRecording.Name = "comboBoxRecording";
          this.comboBoxRecording.Size = new System.Drawing.Size(103, 21);
          this.comboBoxRecording.TabIndex = 48;
          this.comboBoxRecording.Text = "no";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.checkBoxWdog);
          this.groupBox1.Controls.Add(this.label10);
          this.groupBox1.Controls.Add(this.numericUpDownWdog);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.comboBoxRecording);
          this.groupBox1.Controls.Add(this.label5);
          this.groupBox1.Controls.Add(this.label8);
          this.groupBox1.Controls.Add(this.numericUpDownScantime);
          this.groupBox1.Controls.Add(this.numericUpDownStayTunedThresholdTime);
          this.groupBox1.Controls.Add(this.comboBoxMode);
          this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Location = new System.Drawing.Point(6, 6);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(193, 150);
          this.groupBox1.TabIndex = 49;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Settings";
          // 
          // checkBoxWdog
          // 
          this.checkBoxWdog.AutoSize = true;
          this.checkBoxWdog.Location = new System.Drawing.Point(112, 122);
          this.checkBoxWdog.Name = "checkBoxWdog";
          this.checkBoxWdog.Size = new System.Drawing.Size(15, 14);
          this.checkBoxWdog.TabIndex = 51;
          this.checkBoxWdog.UseVisualStyleBackColor = true;
          this.checkBoxWdog.CheckedChanged += new System.EventHandler(this.checkBoxWdog_CheckedChanged);
          // 
          // label10
          // 
          this.label10.Location = new System.Drawing.Point(6, 117);
          this.label10.Name = "label10";
          this.label10.Size = new System.Drawing.Size(121, 23);
          this.label10.TabIndex = 49;
          this.label10.Text = "Watchdog Timer [s]";
          this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // numericUpDownWdog
          // 
          this.numericUpDownWdog.Enabled = false;
          this.numericUpDownWdog.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
          this.numericUpDownWdog.Location = new System.Drawing.Point(133, 120);
          this.numericUpDownWdog.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
          this.numericUpDownWdog.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
          this.numericUpDownWdog.Name = "numericUpDownWdog";
          this.numericUpDownWdog.Size = new System.Drawing.Size(47, 20);
          this.numericUpDownWdog.TabIndex = 50;
          this.numericUpDownWdog.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
          this.numericUpDownWdog.ValueChanged += new System.EventHandler(this.numericUpDownWdog_ValueChanged);
          // 
          // groupBoxMonitor
          // 
          this.groupBoxMonitor.Controls.Add(this.label11);
          this.groupBoxMonitor.Controls.Add(this.textBoxWdog);
          this.groupBoxMonitor.Controls.Add(this.label9);
          this.groupBoxMonitor.Controls.Add(this.textBoxPeakPowerBw);
          this.groupBoxMonitor.Controls.Add(this.label3);
          this.groupBoxMonitor.Controls.Add(this.textBoxRxLevel);
          this.groupBoxMonitor.Controls.Add(this.label7);
          this.groupBoxMonitor.Controls.Add(this.label1);
          this.groupBoxMonitor.Controls.Add(this.textBoxAvgBwPower);
          this.groupBoxMonitor.Controls.Add(this.textBoxTriggerLevel);
          this.groupBoxMonitor.Controls.Add(this.label4);
          this.groupBoxMonitor.Controls.Add(this.textBoxTimeout);
          this.groupBoxMonitor.Location = new System.Drawing.Point(6, 162);
          this.groupBoxMonitor.Name = "groupBoxMonitor";
          this.groupBoxMonitor.Size = new System.Drawing.Size(192, 172);
          this.groupBoxMonitor.TabIndex = 50;
          this.groupBoxMonitor.TabStop = false;
          this.groupBoxMonitor.Text = "Monitor";
          // 
          // label11
          // 
          this.label11.Location = new System.Drawing.Point(6, 141);
          this.label11.Name = "label11";
          this.label11.Size = new System.Drawing.Size(121, 23);
          this.label11.TabIndex = 49;
          this.label11.Text = "Watchdog Timeout [s]";
          this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxWdog
          // 
          this.textBoxWdog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxWdog.Location = new System.Drawing.Point(133, 144);
          this.textBoxWdog.Name = "textBoxWdog";
          this.textBoxWdog.ReadOnly = true;
          this.textBoxWdog.Size = new System.Drawing.Size(47, 20);
          this.textBoxWdog.TabIndex = 48;
          this.textBoxWdog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // label9
          // 
          this.label9.Location = new System.Drawing.Point(6, 91);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(121, 23);
          this.label9.TabIndex = 47;
          this.label9.Text = "Peak Power BW  [dB]";
          this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // textBoxPeakPowerBw
          // 
          this.textBoxPeakPowerBw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.textBoxPeakPowerBw.Location = new System.Drawing.Point(133, 94);
          this.textBoxPeakPowerBw.Name = "textBoxPeakPowerBw";
          this.textBoxPeakPowerBw.ReadOnly = true;
          this.textBoxPeakPowerBw.Size = new System.Drawing.Size(47, 20);
          this.textBoxPeakPowerBw.TabIndex = 46;
          this.textBoxPeakPowerBw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          // 
          // tabControl1
          // 
          this.tabControl1.Controls.Add(this.tabPage1);
          this.tabControl1.Controls.Add(this.tabPage2);
          this.tabControl1.Location = new System.Drawing.Point(5, 62);
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedIndex = 0;
          this.tabControl1.Size = new System.Drawing.Size(209, 371);
          this.tabControl1.TabIndex = 51;
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.groupBoxMonitor);
          this.tabPage1.Controls.Add(this.groupBox1);
          this.tabPage1.Location = new System.Drawing.Point(4, 22);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage1.Size = new System.Drawing.Size(201, 345);
          this.tabPage1.TabIndex = 0;
          this.tabPage1.Text = "Control";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // tabPage2
          // 
          this.tabPage2.Controls.Add(this.mainToolStrip);
          this.tabPage2.Controls.Add(this.frequencyDataGridView);
          this.tabPage2.Controls.Add(this.label17);
          this.tabPage2.Controls.Add(this.comboGroups);
          this.tabPage2.Location = new System.Drawing.Point(4, 22);
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage2.Size = new System.Drawing.Size(201, 345);
          this.tabPage2.TabIndex = 1;
          this.tabPage2.Text = "Frequency List";
          this.tabPage2.UseVisualStyleBackColor = true;
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
          this.memoryEntryBindingSource.DataSource = typeof(SDRSharp.EasyScanner.MemoryEntry);
          // 
          // ScannerPanel
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.buttonStartStop);
          this.Controls.Add(this.tabControl1);
          this.Margin = new System.Windows.Forms.Padding(2);
          this.Name = "ScannerPanel";
          this.Size = new System.Drawing.Size(217, 445);
          this.Load += new System.EventHandler(this.ScannerPanel_Load);
          this.DoubleClick += new System.EventHandler(this.ScannerPanel_DoubleClick);
          this.mainToolStrip.ResumeLayout(false);
          this.mainToolStrip.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.frequencyDataGridView)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStayTunedThresholdTime)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScantime)).EndInit();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWdog)).EndInit();
          this.groupBoxMonitor.ResumeLayout(false);
          this.groupBoxMonitor.PerformLayout();
          this.tabControl1.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.tabPage2.ResumeLayout(false);
          this.tabPage2.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.memoryEntryBindingSource)).EndInit();
          this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPeakPowerBw;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownWdog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxWdog;
        private System.Windows.Forms.CheckBox checkBoxWdog;
    }
}
