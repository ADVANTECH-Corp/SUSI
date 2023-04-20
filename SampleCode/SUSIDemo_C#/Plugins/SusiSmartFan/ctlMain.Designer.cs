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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_DevList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Mode = new System.Windows.Forms.GroupBox();
            this.radioButton_ModeAuto = new System.Windows.Forms.RadioButton();
            this.radioButton_ModeOFF = new System.Windows.Forms.RadioButton();
            this.radioButton_ModeFull = new System.Windows.Forms.RadioButton();
            this.radioButton_ModeManual = new System.Windows.Forms.RadioButton();
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
            this.groupBox_Auto = new System.Windows.Forms.GroupBox();
            this.comboBox_Source = new System.Windows.Forms.ComboBox();
            this.radioButton_OpRPM = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_MaxPWM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_MinPWM = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_TempLowStop = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_MaxRPM = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_TempLowLimit = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_MinRPM = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_TempHighLimit = new System.Windows.Forms.TextBox();
            this.radioButton_OpPWM = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PWM = new System.Windows.Forms.TextBox();
            this.button_Get = new System.Windows.Forms.Button();
            this.button_Set = new System.Windows.Forms.Button();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.timer_Info = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Mode.SuspendLayout();
            this.groupBox_Control.SuspendLayout();
            this.groupBox_Auto.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_DevList
            // 
            this.comboBox_DevList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_DevList.FormattingEnabled = true;
            this.comboBox_DevList.Location = new System.Drawing.Point(149, 13);
            this.comboBox_DevList.MaximumSize = new System.Drawing.Size(450, 0);
            this.comboBox_DevList.MinimumSize = new System.Drawing.Size(300, 0);
            this.comboBox_DevList.Name = "comboBox_DevList";
            this.comboBox_DevList.Size = new System.Drawing.Size(450, 20);
            this.comboBox_DevList.TabIndex = 8;
            this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_FanCList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fan controller:";
            // 
            // groupBox_Mode
            // 
            this.groupBox_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeAuto);
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeOFF);
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeFull);
            this.groupBox_Mode.Controls.Add(this.radioButton_ModeManual);
            this.groupBox_Mode.Location = new System.Drawing.Point(14, 50);
            this.groupBox_Mode.MaximumSize = new System.Drawing.Size(600, 250);
            this.groupBox_Mode.Name = "groupBox_Mode";
            this.groupBox_Mode.Size = new System.Drawing.Size(321, 51);
            this.groupBox_Mode.TabIndex = 9;
            this.groupBox_Mode.TabStop = false;
            this.groupBox_Mode.Text = "Mode";
            // 
            // radioButton_ModeAuto
            // 
            this.radioButton_ModeAuto.AutoSize = true;
            this.radioButton_ModeAuto.Location = new System.Drawing.Point(253, 21);
            this.radioButton_ModeAuto.Name = "radioButton_ModeAuto";
            this.radioButton_ModeAuto.Size = new System.Drawing.Size(46, 16);
            this.radioButton_ModeAuto.TabIndex = 0;
            this.radioButton_ModeAuto.TabStop = true;
            this.radioButton_ModeAuto.Text = "Auto";
            this.radioButton_ModeAuto.UseVisualStyleBackColor = true;
            this.radioButton_ModeAuto.CheckedChanged += new System.EventHandler(this.radioButton_AutoManual_CheckedChanged);
            // 
            // radioButton_ModeOFF
            // 
            this.radioButton_ModeOFF.AutoSize = true;
            this.radioButton_ModeOFF.Location = new System.Drawing.Point(90, 21);
            this.radioButton_ModeOFF.Name = "radioButton_ModeOFF";
            this.radioButton_ModeOFF.Size = new System.Drawing.Size(43, 16);
            this.radioButton_ModeOFF.TabIndex = 0;
            this.radioButton_ModeOFF.TabStop = true;
            this.radioButton_ModeOFF.Text = "OFF";
            this.radioButton_ModeOFF.UseVisualStyleBackColor = true;
            this.radioButton_ModeOFF.CheckedChanged += new System.EventHandler(this.radioButton_ModeOFF_CheckedChanged);
            // 
            // radioButton_ModeFull
            // 
            this.radioButton_ModeFull.AutoSize = true;
            this.radioButton_ModeFull.Location = new System.Drawing.Point(18, 21);
            this.radioButton_ModeFull.Name = "radioButton_ModeFull";
            this.radioButton_ModeFull.Size = new System.Drawing.Size(41, 16);
            this.radioButton_ModeFull.TabIndex = 0;
            this.radioButton_ModeFull.TabStop = true;
            this.radioButton_ModeFull.Text = "Full";
            this.radioButton_ModeFull.UseVisualStyleBackColor = true;
            this.radioButton_ModeFull.CheckedChanged += new System.EventHandler(this.radioButton_ModeFull_CheckedChanged);
            // 
            // radioButton_ModeManual
            // 
            this.radioButton_ModeManual.AutoSize = true;
            this.radioButton_ModeManual.Location = new System.Drawing.Point(164, 21);
            this.radioButton_ModeManual.Name = "radioButton_ModeManual";
            this.radioButton_ModeManual.Size = new System.Drawing.Size(58, 16);
            this.radioButton_ModeManual.TabIndex = 0;
            this.radioButton_ModeManual.TabStop = true;
            this.radioButton_ModeManual.Text = "Manual";
            this.radioButton_ModeManual.UseVisualStyleBackColor = true;
            this.radioButton_ModeManual.CheckedChanged += new System.EventHandler(this.radioButton_AutoManual_CheckedChanged);
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Control.Controls.Add(this.groupBox_Auto);
            this.groupBox_Control.Controls.Add(this.label3);
            this.groupBox_Control.Controls.Add(this.label2);
            this.groupBox_Control.Controls.Add(this.textBox_PWM);
            this.groupBox_Control.Location = new System.Drawing.Point(14, 107);
            this.groupBox_Control.MaximumSize = new System.Drawing.Size(600, 250);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Size = new System.Drawing.Size(600, 227);
            this.groupBox_Control.TabIndex = 9;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // groupBox_Auto
            // 
            this.groupBox_Auto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Auto.Controls.Add(this.comboBox_Source);
            this.groupBox_Auto.Controls.Add(this.radioButton_OpRPM);
            this.groupBox_Auto.Controls.Add(this.label14);
            this.groupBox_Auto.Controls.Add(this.label21);
            this.groupBox_Auto.Controls.Add(this.textBox_MaxPWM);
            this.groupBox_Auto.Controls.Add(this.label13);
            this.groupBox_Auto.Controls.Add(this.textBox_MinPWM);
            this.groupBox_Auto.Controls.Add(this.label12);
            this.groupBox_Auto.Controls.Add(this.textBox_TempLowStop);
            this.groupBox_Auto.Controls.Add(this.label18);
            this.groupBox_Auto.Controls.Add(this.textBox_MaxRPM);
            this.groupBox_Auto.Controls.Add(this.label17);
            this.groupBox_Auto.Controls.Add(this.textBox_TempLowLimit);
            this.groupBox_Auto.Controls.Add(this.label16);
            this.groupBox_Auto.Controls.Add(this.textBox_MinRPM);
            this.groupBox_Auto.Controls.Add(this.label15);
            this.groupBox_Auto.Controls.Add(this.textBox_TempHighLimit);
            this.groupBox_Auto.Controls.Add(this.radioButton_OpPWM);
            this.groupBox_Auto.Controls.Add(this.label4);
            this.groupBox_Auto.Controls.Add(this.label5);
            this.groupBox_Auto.Controls.Add(this.label8);
            this.groupBox_Auto.Controls.Add(this.label9);
            this.groupBox_Auto.Controls.Add(this.label11);
            this.groupBox_Auto.Controls.Add(this.label6);
            this.groupBox_Auto.Controls.Add(this.label7);
            this.groupBox_Auto.Controls.Add(this.label10);
            this.groupBox_Auto.Location = new System.Drawing.Point(18, 52);
            this.groupBox_Auto.MaximumSize = new System.Drawing.Size(600, 250);
            this.groupBox_Auto.Name = "groupBox_Auto";
            this.groupBox_Auto.Size = new System.Drawing.Size(567, 161);
            this.groupBox_Auto.TabIndex = 9;
            this.groupBox_Auto.TabStop = false;
            this.groupBox_Auto.Text = "Auto";
            // 
            // comboBox_Source
            // 
            this.comboBox_Source.FormattingEnabled = true;
            this.comboBox_Source.Location = new System.Drawing.Point(117, 19);
            this.comboBox_Source.Name = "comboBox_Source";
            this.comboBox_Source.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Source.TabIndex = 3;
            // 
            // radioButton_OpRPM
            // 
            this.radioButton_OpRPM.AutoSize = true;
            this.radioButton_OpRPM.Location = new System.Drawing.Point(472, 20);
            this.radioButton_OpRPM.Name = "radioButton_OpRPM";
            this.radioButton_OpRPM.Size = new System.Drawing.Size(47, 16);
            this.radioButton_OpRPM.TabIndex = 0;
            this.radioButton_OpRPM.TabStop = true;
            this.radioButton_OpRPM.Text = "RPM";
            this.radioButton_OpRPM.UseVisualStyleBackColor = true;
            this.radioButton_OpRPM.CheckedChanged += new System.EventHandler(this.radioButton_OpRPM_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(187, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "Celsius";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 12);
            this.label21.TabIndex = 1;
            this.label21.Text = "Thermal Source:";
            // 
            // textBox_MaxPWM
            // 
            this.textBox_MaxPWM.Location = new System.Drawing.Point(416, 43);
            this.textBox_MaxPWM.MaxLength = 3;
            this.textBox_MaxPWM.Name = "textBox_MaxPWM";
            this.textBox_MaxPWM.Size = new System.Drawing.Size(64, 22);
            this.textBox_MaxPWM.TabIndex = 0;
            this.textBox_MaxPWM.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_MaxPWM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(187, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "Celsius";
            // 
            // textBox_MinPWM
            // 
            this.textBox_MinPWM.Location = new System.Drawing.Point(416, 71);
            this.textBox_MinPWM.MaxLength = 3;
            this.textBox_MinPWM.Name = "textBox_MinPWM";
            this.textBox_MinPWM.Size = new System.Drawing.Size(64, 22);
            this.textBox_MinPWM.TabIndex = 0;
            this.textBox_MinPWM.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_MinPWM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "Celsius";
            // 
            // textBox_TempLowStop
            // 
            this.textBox_TempLowStop.Location = new System.Drawing.Point(117, 71);
            this.textBox_TempLowStop.MaxLength = 3;
            this.textBox_TempLowStop.Name = "textBox_TempLowStop";
            this.textBox_TempLowStop.Size = new System.Drawing.Size(64, 22);
            this.textBox_TempLowStop.TabIndex = 0;
            this.textBox_TempLowStop.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_TempLowStop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(486, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "RPM";
            // 
            // textBox_MaxRPM
            // 
            this.textBox_MaxRPM.Enabled = false;
            this.textBox_MaxRPM.Location = new System.Drawing.Point(416, 99);
            this.textBox_MaxRPM.MaxLength = 5;
            this.textBox_MaxRPM.Name = "textBox_MaxRPM";
            this.textBox_MaxRPM.Size = new System.Drawing.Size(64, 22);
            this.textBox_MaxRPM.TabIndex = 0;
            this.textBox_MaxRPM.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_MaxRPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(486, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "RPM";
            // 
            // textBox_TempLowLimit
            // 
            this.textBox_TempLowLimit.Location = new System.Drawing.Point(117, 99);
            this.textBox_TempLowLimit.MaxLength = 3;
            this.textBox_TempLowLimit.Name = "textBox_TempLowLimit";
            this.textBox_TempLowLimit.Size = new System.Drawing.Size(64, 22);
            this.textBox_TempLowLimit.TabIndex = 0;
            this.textBox_TempLowLimit.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_TempLowLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(486, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "%";
            // 
            // textBox_MinRPM
            // 
            this.textBox_MinRPM.Enabled = false;
            this.textBox_MinRPM.Location = new System.Drawing.Point(416, 127);
            this.textBox_MinRPM.MaxLength = 5;
            this.textBox_MinRPM.Name = "textBox_MinRPM";
            this.textBox_MinRPM.Size = new System.Drawing.Size(64, 22);
            this.textBox_MinRPM.TabIndex = 0;
            this.textBox_MinRPM.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_MinRPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(486, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "%";
            // 
            // textBox_TempHighLimit
            // 
            this.textBox_TempHighLimit.Location = new System.Drawing.Point(117, 127);
            this.textBox_TempHighLimit.MaxLength = 3;
            this.textBox_TempHighLimit.Name = "textBox_TempHighLimit";
            this.textBox_TempHighLimit.Size = new System.Drawing.Size(64, 22);
            this.textBox_TempHighLimit.TabIndex = 0;
            this.textBox_TempHighLimit.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_TempHighLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // radioButton_OpPWM
            // 
            this.radioButton_OpPWM.AutoSize = true;
            this.radioButton_OpPWM.Location = new System.Drawing.Point(416, 20);
            this.radioButton_OpPWM.Name = "radioButton_OpPWM";
            this.radioButton_OpPWM.Size = new System.Drawing.Size(50, 16);
            this.radioButton_OpPWM.TabIndex = 0;
            this.radioButton_OpPWM.TabStop = true;
            this.radioButton_OpPWM.Text = "PWM";
            this.radioButton_OpPWM.UseVisualStyleBackColor = true;
            this.radioButton_OpPWM.CheckedChanged += new System.EventHandler(this.radioButton_OpPWM_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Op Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Maximum PWM:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Minimum RPM:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Low Stop:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "High Limit:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Minimum PWM:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Maximum RPM:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Low Limit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PWM:";
            // 
            // textBox_PWM
            // 
            this.textBox_PWM.Location = new System.Drawing.Point(135, 24);
            this.textBox_PWM.MaxLength = 3;
            this.textBox_PWM.Name = "textBox_PWM";
            this.textBox_PWM.Size = new System.Drawing.Size(64, 22);
            this.textBox_PWM.TabIndex = 0;
            this.textBox_PWM.Leave += new System.EventHandler(this.textBox_Leave);
            this.textBox_PWM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(524, 340);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(75, 23);
            this.button_Get.TabIndex = 10;
            this.button_Get.Text = "Get";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(443, 340);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(75, 23);
            this.button_Set.TabIndex = 10;
            this.button_Set.Text = "Set";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Info.Controls.Add(this.label20);
            this.groupBox_Info.Controls.Add(this.label23);
            this.groupBox_Info.Controls.Add(this.label_Speed);
            this.groupBox_Info.Location = new System.Drawing.Point(341, 50);
            this.groupBox_Info.MaximumSize = new System.Drawing.Size(600, 250);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(273, 51);
            this.groupBox_Info.TabIndex = 9;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Information";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "Speed:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(142, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 1;
            this.label23.Text = "RPM";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Location = new System.Drawing.Point(73, 23);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(21, 12);
            this.label_Speed.TabIndex = 1;
            this.label_Speed.Text = "----";
            // 
            // timer_Info
            // 
            this.timer_Info.Interval = 1000;
            this.timer_Info.Tick += new System.EventHandler(this.timer_Info_Tick);
            // 
            // PageSmartFan
            // 
            this.Controls.Add(this.button_Set);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.groupBox_Control);
            this.Controls.Add(this.groupBox_Info);
            this.Controls.Add(this.groupBox_Mode);
            this.Controls.Add(this.comboBox_DevList);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(630, 400);
            this.Name = "PageSmartFan";
            this.Size = new System.Drawing.Size(630, 400);
            this.Load += new System.EventHandler(this.PageSmartFan_Load);
            this.groupBox_Mode.ResumeLayout(false);
            this.groupBox_Mode.PerformLayout();
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.groupBox_Auto.ResumeLayout(false);
            this.groupBox_Auto.PerformLayout();
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_Mode;
        private System.Windows.Forms.RadioButton radioButton_ModeOFF;
        private System.Windows.Forms.RadioButton radioButton_ModeFull;
        private System.Windows.Forms.RadioButton radioButton_ModeManual;
        private System.Windows.Forms.RadioButton radioButton_ModeAuto;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PWM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_OpRPM;
        private System.Windows.Forms.RadioButton radioButton_OpPWM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_MaxPWM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_MinRPM;
        private System.Windows.Forms.TextBox textBox_MaxRPM;
        private System.Windows.Forms.TextBox textBox_MinPWM;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_TempHighLimit;
        private System.Windows.Forms.TextBox textBox_TempLowLimit;
        private System.Windows.Forms.TextBox textBox_TempLowStop;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox_Auto;
        private System.Windows.Forms.Timer timer_Info;
        private System.Windows.Forms.ComboBox comboBox_Source;
        private System.Windows.Forms.Label label21;
    }
}
