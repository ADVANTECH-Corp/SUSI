namespace Susi4.Plugin
{
    partial class ctlMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CheckBox_Enable = new System.Windows.Forms.CheckBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolStripLabel_Status = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel_Result = new System.Windows.Forms.ToolStripLabel();
            this.TextBox_Xoffset = new System.Windows.Forms.TextBox();
            this.TextBox_Yoffset = new System.Windows.Forms.TextBox();
            this.TextBox_Zoffset = new System.Windows.Forms.TextBox();
            this.ComboBox_GRange = new System.Windows.Forms.ComboBox();
            this.CheckBox_LowPower = new System.Windows.Forms.CheckBox();
            this.ComboBox_Rate = new System.Windows.Forms.ComboBox();
            this.CheckBox_Sleep = new System.Windows.Forms.CheckBox();
            this.Timer_ReadData = new System.Windows.Forms.Timer(this.components);
            this.TextBox_Xout = new System.Windows.Forms.TextBox();
            this.TextBox_Yout = new System.Windows.Forms.TextBox();
            this.TextBox_Zout = new System.Windows.Forms.TextBox();
            this.Button_SetOffset = new System.Windows.Forms.Button();
            this.Button_ResetOffset = new System.Windows.Forms.Button();
            this.Button_Calibration = new System.Windows.Forms.Button();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.ComboBox_Wakeup = new System.Windows.Forms.ComboBox();
            this.label_DrawMax = new System.Windows.Forms.Label();
            this.label_DrawCenter = new System.Windows.Forms.Label();
            this.label_DrawMin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.LineChartCtrl_Data = new LineChartCtrl.LineChartCtrl();
            this.ToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBox_Enable
            // 
            this.CheckBox_Enable.AutoSize = true;
            this.CheckBox_Enable.Location = new System.Drawing.Point(15, 21);
            this.CheckBox_Enable.Name = "CheckBox_Enable";
            this.CheckBox_Enable.Size = new System.Drawing.Size(56, 16);
            this.CheckBox_Enable.TabIndex = 0;
            this.CheckBox_Enable.Text = "Enable";
            this.CheckBox_Enable.UseVisualStyleBackColor = true;
            this.CheckBox_Enable.CheckedChanged += new System.EventHandler(this.CheckBox_Enable_CheckedChanged);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_Status,
            this.toolStripSeparator1,
            this.ToolStripLabel_Result});
            this.ToolStrip.Location = new System.Drawing.Point(0, 482);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(580, 25);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip";
            // 
            // ToolStripLabel_Status
            // 
            this.ToolStripLabel_Status.AutoSize = false;
            this.ToolStripLabel_Status.Name = "ToolStripLabel_Status";
            this.ToolStripLabel_Status.Size = new System.Drawing.Size(120, 22);
            this.ToolStripLabel_Status.Text = "Status";
            this.ToolStripLabel_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLabel_Result
            // 
            this.ToolStripLabel_Result.Name = "ToolStripLabel_Result";
            this.ToolStripLabel_Result.Size = new System.Drawing.Size(42, 22);
            this.ToolStripLabel_Result.Text = "Result";
            // 
            // TextBox_Xoffset
            // 
            this.TextBox_Xoffset.BackColor = System.Drawing.Color.Black;
            this.TextBox_Xoffset.Location = new System.Drawing.Point(11, 21);
            this.TextBox_Xoffset.Name = "TextBox_Xoffset";
            this.TextBox_Xoffset.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Xoffset.TabIndex = 2;
            this.TextBox_Xoffset.TextChanged += new System.EventHandler(this.TextBox_Xoffset_TextChanged);
            this.TextBox_Xoffset.Leave += new System.EventHandler(this.TextBox_Xoffset_Leave);
            // 
            // TextBox_Yoffset
            // 
            this.TextBox_Yoffset.BackColor = System.Drawing.Color.Black;
            this.TextBox_Yoffset.Location = new System.Drawing.Point(11, 50);
            this.TextBox_Yoffset.Name = "TextBox_Yoffset";
            this.TextBox_Yoffset.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Yoffset.TabIndex = 3;
            this.TextBox_Yoffset.TextChanged += new System.EventHandler(this.TextBox_Yoffset_TextChanged);
            this.TextBox_Yoffset.Leave += new System.EventHandler(this.TextBox_Yoffset_Leave);
            // 
            // TextBox_Zoffset
            // 
            this.TextBox_Zoffset.BackColor = System.Drawing.Color.Black;
            this.TextBox_Zoffset.Location = new System.Drawing.Point(11, 77);
            this.TextBox_Zoffset.Name = "TextBox_Zoffset";
            this.TextBox_Zoffset.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Zoffset.TabIndex = 4;
            this.TextBox_Zoffset.TextChanged += new System.EventHandler(this.TextBox_Zoffset_TextChanged);
            this.TextBox_Zoffset.Leave += new System.EventHandler(this.TextBox_Zoffset_Leave);
            // 
            // ComboBox_GRange
            // 
            this.ComboBox_GRange.FormattingEnabled = true;
            this.ComboBox_GRange.Location = new System.Drawing.Point(126, 27);
            this.ComboBox_GRange.Name = "ComboBox_GRange";
            this.ComboBox_GRange.Size = new System.Drawing.Size(78, 20);
            this.ComboBox_GRange.TabIndex = 5;
            this.ComboBox_GRange.SelectedIndexChanged += new System.EventHandler(this.ComboBox_GRange_SelectedIndexChanged);
            this.ComboBox_GRange.TextChanged += new System.EventHandler(this.ComboBox_GRange_TextChanged);
            // 
            // CheckBox_LowPower
            // 
            this.CheckBox_LowPower.AutoSize = true;
            this.CheckBox_LowPower.Location = new System.Drawing.Point(202, 21);
            this.CheckBox_LowPower.Name = "CheckBox_LowPower";
            this.CheckBox_LowPower.Size = new System.Drawing.Size(77, 16);
            this.CheckBox_LowPower.TabIndex = 6;
            this.CheckBox_LowPower.Text = "Low Power";
            this.CheckBox_LowPower.UseVisualStyleBackColor = true;
            this.CheckBox_LowPower.CheckedChanged += new System.EventHandler(this.CheckBox_LowPower_CheckedChanged);
            // 
            // ComboBox_Rate
            // 
            this.ComboBox_Rate.Enabled = false;
            this.ComboBox_Rate.FormattingEnabled = true;
            this.ComboBox_Rate.Location = new System.Drawing.Point(33, 45);
            this.ComboBox_Rate.Name = "ComboBox_Rate";
            this.ComboBox_Rate.Size = new System.Drawing.Size(86, 20);
            this.ComboBox_Rate.TabIndex = 7;
            this.ComboBox_Rate.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Rate_SelectedIndexChanged);
            this.ComboBox_Rate.TextChanged += new System.EventHandler(this.ComboBox_Rate_TextChanged);
            // 
            // CheckBox_Sleep
            // 
            this.CheckBox_Sleep.AutoSize = true;
            this.CheckBox_Sleep.Location = new System.Drawing.Point(414, 21);
            this.CheckBox_Sleep.Name = "CheckBox_Sleep";
            this.CheckBox_Sleep.Size = new System.Drawing.Size(49, 16);
            this.CheckBox_Sleep.TabIndex = 8;
            this.CheckBox_Sleep.Text = "Sleep";
            this.CheckBox_Sleep.UseVisualStyleBackColor = true;
            this.CheckBox_Sleep.CheckedChanged += new System.EventHandler(this.CheckBox_Sleep_CheckedChanged);
            // 
            // Timer_ReadData
            // 
            this.Timer_ReadData.Tick += new System.EventHandler(this.Timer_ReadData_Tick);
            // 
            // TextBox_Xout
            // 
            this.TextBox_Xout.BackColor = System.Drawing.Color.Black;
            this.TextBox_Xout.Location = new System.Drawing.Point(10, 21);
            this.TextBox_Xout.Name = "TextBox_Xout";
            this.TextBox_Xout.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Xout.TabIndex = 9;
            // 
            // TextBox_Yout
            // 
            this.TextBox_Yout.BackColor = System.Drawing.Color.Black;
            this.TextBox_Yout.Location = new System.Drawing.Point(10, 49);
            this.TextBox_Yout.Name = "TextBox_Yout";
            this.TextBox_Yout.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Yout.TabIndex = 10;
            // 
            // TextBox_Zout
            // 
            this.TextBox_Zout.BackColor = System.Drawing.Color.Black;
            this.TextBox_Zout.Location = new System.Drawing.Point(10, 77);
            this.TextBox_Zout.Name = "TextBox_Zout";
            this.TextBox_Zout.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Zout.TabIndex = 11;
            // 
            // Button_SetOffset
            // 
            this.Button_SetOffset.Location = new System.Drawing.Point(11, 105);
            this.Button_SetOffset.Name = "Button_SetOffset";
            this.Button_SetOffset.Size = new System.Drawing.Size(55, 23);
            this.Button_SetOffset.TabIndex = 12;
            this.Button_SetOffset.Text = "Set";
            this.Button_SetOffset.UseVisualStyleBackColor = true;
            this.Button_SetOffset.Click += new System.EventHandler(this.Button_SetOffset_Click);
            // 
            // Button_ResetOffset
            // 
            this.Button_ResetOffset.Location = new System.Drawing.Point(74, 105);
            this.Button_ResetOffset.Name = "Button_ResetOffset";
            this.Button_ResetOffset.Size = new System.Drawing.Size(55, 23);
            this.Button_ResetOffset.TabIndex = 13;
            this.Button_ResetOffset.Text = "Reset";
            this.Button_ResetOffset.UseVisualStyleBackColor = true;
            this.Button_ResetOffset.Click += new System.EventHandler(this.Button_ResetOffset_Click);
            // 
            // Button_Calibration
            // 
            this.Button_Calibration.Location = new System.Drawing.Point(139, 105);
            this.Button_Calibration.Name = "Button_Calibration";
            this.Button_Calibration.Size = new System.Drawing.Size(95, 23);
            this.Button_Calibration.TabIndex = 14;
            this.Button_Calibration.Text = "Calibration";
            this.Button_Calibration.UseVisualStyleBackColor = true;
            this.Button_Calibration.Click += new System.EventHandler(this.Button_Calibration_Click);
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Location = new System.Drawing.Point(119, 459);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(103, 23);
            this.Button_Refresh.TabIndex = 15;
            this.Button_Refresh.Text = "Refresh All";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // ComboBox_Wakeup
            // 
            this.ComboBox_Wakeup.Enabled = false;
            this.ComboBox_Wakeup.FormattingEnabled = true;
            this.ComboBox_Wakeup.Location = new System.Drawing.Point(33, 96);
            this.ComboBox_Wakeup.Name = "ComboBox_Wakeup";
            this.ComboBox_Wakeup.Size = new System.Drawing.Size(86, 20);
            this.ComboBox_Wakeup.TabIndex = 16;
            this.ComboBox_Wakeup.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Wakeup_SelectedIndexChanged);
            this.ComboBox_Wakeup.TextChanged += new System.EventHandler(this.ComboBox_Wakeup_TextChanged);
            // 
            // label_DrawMax
            // 
            this.label_DrawMax.Location = new System.Drawing.Point(22, 62);
            this.label_DrawMax.Name = "label_DrawMax";
            this.label_DrawMax.Size = new System.Drawing.Size(24, 12);
            this.label_DrawMax.TabIndex = 18;
            this.label_DrawMax.Text = "1";
            this.label_DrawMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_DrawCenter
            // 
            this.label_DrawCenter.Location = new System.Drawing.Point(22, 110);
            this.label_DrawCenter.Name = "label_DrawCenter";
            this.label_DrawCenter.Size = new System.Drawing.Size(24, 12);
            this.label_DrawCenter.TabIndex = 19;
            this.label_DrawCenter.Text = "0";
            this.label_DrawCenter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_DrawMin
            // 
            this.label_DrawMin.Location = new System.Drawing.Point(6, 158);
            this.label_DrawMin.Name = "label_DrawMin";
            this.label_DrawMin.Size = new System.Drawing.Size(39, 20);
            this.label_DrawMin.TabIndex = 20;
            this.label_DrawMin.Text = "-1";
            this.label_DrawMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CheckBox_Enable);
            this.groupBox1.Controls.Add(this.CheckBox_LowPower);
            this.groupBox1.Controls.Add(this.CheckBox_Sleep);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 107);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Unchecked: normal mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Checked: sleep mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Unchecked:  normal operation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Checked:  reduced power operation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Unchecked:  standby mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Checked:  measurement mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TextBox_Xout);
            this.groupBox2.Controls.Add(this.TextBox_Yout);
            this.groupBox2.Controls.Add(this.TextBox_Zout);
            this.groupBox2.Location = new System.Drawing.Point(204, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 139);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TextBox_Xoffset);
            this.groupBox3.Controls.Add(this.TextBox_Yoffset);
            this.groupBox3.Controls.Add(this.TextBox_Zoffset);
            this.groupBox3.Controls.Add(this.Button_SetOffset);
            this.groupBox3.Controls.Add(this.Button_ResetOffset);
            this.groupBox3.Controls.Add(this.Button_Calibration);
            this.groupBox3.Location = new System.Drawing.Point(340, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 139);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offset";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.ComboBox_GRange);
            this.groupBox4.Controls.Add(this.label_DrawMax);
            this.groupBox4.Controls.Add(this.label_DrawCenter);
            this.groupBox4.Controls.Add(this.label_DrawMin);
            this.groupBox4.Controls.Add(this.LineChartCtrl_Data);
            this.groupBox4.Location = new System.Drawing.Point(15, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(565, 181);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Measure";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "g-Range:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Z:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Rate in Normal Mode:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "Rate in Sleep Mode:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.ComboBox_Rate);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.ComboBox_Wakeup);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(15, 126);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(151, 139);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output Data Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(125, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "Hz";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(125, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "Hz";
            // 
            // Button_Reset
            // 
            this.Button_Reset.Location = new System.Drawing.Point(15, 459);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(96, 23);
            this.Button_Reset.TabIndex = 33;
            this.Button_Reset.Text = "Reset All";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // LineChartCtrl_Data
            // 
            this.LineChartCtrl_Data.BackColor = System.Drawing.Color.White;
            this.LineChartCtrl_Data.Font = new System.Drawing.Font("Verdana", 9F);
            this.LineChartCtrl_Data.GridHeight = 10;
            this.LineChartCtrl_Data.GridWidth = 10;
            this.LineChartCtrl_Data.Lin11Color = System.Drawing.Color.LimeGreen;
            this.LineChartCtrl_Data.Lin12Color = System.Drawing.Color.Pink;
            this.LineChartCtrl_Data.Lin13Color = System.Drawing.Color.Yellow;
            this.LineChartCtrl_Data.Location = new System.Drawing.Point(59, 62);
            this.LineChartCtrl_Data.Name = "LineChartCtrl_Data";
            this.LineChartCtrl_Data.Size = new System.Drawing.Size(465, 108);
            this.LineChartCtrl_Data.TabIndex = 21;
            this.LineChartCtrl_Data.ThreadLine = 0F;
            this.LineChartCtrl_Data.ValueMaximum = 100F;
            this.LineChartCtrl_Data.ValueMinimum = 0F;
            // 
            // ctlMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Button_Refresh);
            this.Controls.Add(this.ToolStrip);
            this.Name = "ctlMain";
            this.Size = new System.Drawing.Size(530, 365);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBox_Enable;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripLabel ToolStripLabel_Status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel ToolStripLabel_Result;
        private System.Windows.Forms.TextBox TextBox_Xoffset;
        private System.Windows.Forms.TextBox TextBox_Yoffset;
        private System.Windows.Forms.TextBox TextBox_Zoffset;
        private System.Windows.Forms.ComboBox ComboBox_GRange;
        private System.Windows.Forms.CheckBox CheckBox_LowPower;
        private System.Windows.Forms.ComboBox ComboBox_Rate;
        private System.Windows.Forms.CheckBox CheckBox_Sleep;
        private System.Windows.Forms.Timer Timer_ReadData;
        private System.Windows.Forms.TextBox TextBox_Xout;
        private System.Windows.Forms.TextBox TextBox_Yout;
        private System.Windows.Forms.TextBox TextBox_Zout;
        private System.Windows.Forms.Button Button_SetOffset;
        private System.Windows.Forms.Button Button_ResetOffset;
        private System.Windows.Forms.Button Button_Calibration;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.ComboBox ComboBox_Wakeup;
        private System.Windows.Forms.Label label_DrawMax;
        private System.Windows.Forms.Label label_DrawCenter;
        private System.Windows.Forms.Label label_DrawMin;
        private LineChartCtrl.LineChartCtrl LineChartCtrl_Data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;

    }
}