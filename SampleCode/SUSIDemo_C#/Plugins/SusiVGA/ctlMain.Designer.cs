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
            this.comboBox_DevList = new System.Windows.Forms.ComboBox();
            this.groupBox_Freq = new System.Windows.Forms.GroupBox();
            this.button_SetFreq = new System.Windows.Forms.Button();
            this.button_GetPol = new System.Windows.Forms.Button();
            this.button_GetFreq = new System.Windows.Forms.Button();
            this.radioButton_No = new System.Windows.Forms.RadioButton();
            this.textBox_Freq = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_Yes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
            this.button_GetBacklight = new System.Windows.Forms.Button();
            this.radioButton_Off = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_On = new System.Windows.Forms.RadioButton();
            this.trackBar_BL = new System.Windows.Forms.TrackBar();
            this.groupBox_Brightness = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_BLMax = new System.Windows.Forms.Label();
            this.label_BLMin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_BLValue = new System.Windows.Forms.Label();
            this.radioButton_ACPI = new System.Windows.Forms.RadioButton();
            this.radioButton_PWM = new System.Windows.Forms.RadioButton();
            this.button_GetBrightness = new System.Windows.Forms.Button();
            this.radioButton_WMI = new System.Windows.Forms.RadioButton();
            this.groupBox_Freq.SuspendLayout();
            this.groupBox_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BL)).BeginInit();
            this.groupBox_Brightness.SuspendLayout();
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
            this.comboBox_DevList.TabIndex = 9;
            this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_PanelList_SelectedIndexChanged);
            // 
            // groupBox_Freq
            // 
            this.groupBox_Freq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Freq.Controls.Add(this.button_SetFreq);
            this.groupBox_Freq.Controls.Add(this.button_GetPol);
            this.groupBox_Freq.Controls.Add(this.button_GetFreq);
            this.groupBox_Freq.Controls.Add(this.radioButton_No);
            this.groupBox_Freq.Controls.Add(this.textBox_Freq);
            this.groupBox_Freq.Controls.Add(this.label2);
            this.groupBox_Freq.Controls.Add(this.radioButton_Yes);
            this.groupBox_Freq.Controls.Add(this.label1);
            this.groupBox_Freq.Controls.Add(this.label4);
            this.groupBox_Freq.Location = new System.Drawing.Point(14, 48);
            this.groupBox_Freq.MaximumSize = new System.Drawing.Size(600, 120);
            this.groupBox_Freq.MinimumSize = new System.Drawing.Size(430, 0);
            this.groupBox_Freq.Name = "groupBox_Freq";
            this.groupBox_Freq.Size = new System.Drawing.Size(600, 84);
            this.groupBox_Freq.TabIndex = 8;
            this.groupBox_Freq.TabStop = false;
            this.groupBox_Freq.Text = "LVDS PWM Attribute";
            // 
            // button_SetFreq
            // 
            this.button_SetFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SetFreq.Location = new System.Drawing.Point(465, 23);
            this.button_SetFreq.Name = "button_SetFreq";
            this.button_SetFreq.Size = new System.Drawing.Size(57, 23);
            this.button_SetFreq.TabIndex = 3;
            this.button_SetFreq.Text = "Set";
            this.button_SetFreq.UseVisualStyleBackColor = true;
            this.button_SetFreq.Click += new System.EventHandler(this.button_SetFreq_Click);
            // 
            // button_GetPol
            // 
            this.button_GetPol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetPol.Location = new System.Drawing.Point(528, 52);
            this.button_GetPol.Name = "button_GetPol";
            this.button_GetPol.Size = new System.Drawing.Size(57, 23);
            this.button_GetPol.TabIndex = 3;
            this.button_GetPol.Text = "Get";
            this.button_GetPol.UseVisualStyleBackColor = true;
            this.button_GetPol.Click += new System.EventHandler(this.button_GetPol_Click);
            // 
            // button_GetFreq
            // 
            this.button_GetFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetFreq.Location = new System.Drawing.Point(528, 23);
            this.button_GetFreq.Name = "button_GetFreq";
            this.button_GetFreq.Size = new System.Drawing.Size(57, 23);
            this.button_GetFreq.TabIndex = 3;
            this.button_GetFreq.Text = "Get";
            this.button_GetFreq.UseVisualStyleBackColor = true;
            this.button_GetFreq.Click += new System.EventHandler(this.button_GetFreq_Click);
            // 
            // radioButton_No
            // 
            this.radioButton_No.AutoSize = true;
            this.radioButton_No.Checked = true;
            this.radioButton_No.Location = new System.Drawing.Point(164, 55);
            this.radioButton_No.Name = "radioButton_No";
            this.radioButton_No.Size = new System.Drawing.Size(37, 16);
            this.radioButton_No.TabIndex = 3;
            this.radioButton_No.TabStop = true;
            this.radioButton_No.Text = "&Native";
            this.radioButton_No.UseVisualStyleBackColor = true;
            this.radioButton_No.CheckedChanged += new System.EventHandler(this.radioButton_No_CheckedChanged);
            // 
            // textBox_Freq
            // 
            this.textBox_Freq.Location = new System.Drawing.Point(103, 25);
            this.textBox_Freq.MaxLength = 7;
            this.textBox_Freq.Name = "textBox_Freq";
            this.textBox_Freq.Size = new System.Drawing.Size(100, 22);
            this.textBox_Freq.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Polarity:";
            // 
            // radioButton_Yes
            // 
            this.radioButton_Yes.AutoSize = true;
            this.radioButton_Yes.Location = new System.Drawing.Point(103, 55);
            this.radioButton_Yes.Name = "radioButton_Yes";
            this.radioButton_Yes.Size = new System.Drawing.Size(40, 16);
            this.radioButton_Yes.TabIndex = 3;
            this.radioButton_Yes.Text = "&Invert";
            this.radioButton_Yes.UseVisualStyleBackColor = true;
            this.radioButton_Yes.CheckedChanged += new System.EventHandler(this.radioButton_Yes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Frequency:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(21, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Flat Panel:";
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Control.Controls.Add(this.button_GetBacklight);
            this.groupBox_Control.Controls.Add(this.radioButton_Off);
            this.groupBox_Control.Controls.Add(this.label3);
            this.groupBox_Control.Controls.Add(this.radioButton_On);
            this.groupBox_Control.Location = new System.Drawing.Point(14, 138);
            this.groupBox_Control.MaximumSize = new System.Drawing.Size(600, 120);
            this.groupBox_Control.MinimumSize = new System.Drawing.Size(430, 0);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Size = new System.Drawing.Size(600, 54);
            this.groupBox_Control.TabIndex = 8;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "LVDS Backlight Control";
            // 
            // button_GetBacklight
            // 
            this.button_GetBacklight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetBacklight.Location = new System.Drawing.Point(528, 21);
            this.button_GetBacklight.Name = "button_GetBacklight";
            this.button_GetBacklight.Size = new System.Drawing.Size(57, 23);
            this.button_GetBacklight.TabIndex = 3;
            this.button_GetBacklight.Text = "Get";
            this.button_GetBacklight.UseVisualStyleBackColor = true;
            this.button_GetBacklight.Click += new System.EventHandler(this.button_GetBacklight_Click);
            // 
            // radioButton_Off
            // 
            this.radioButton_Off.AutoSize = true;
            this.radioButton_Off.Location = new System.Drawing.Point(162, 25);
            this.radioButton_Off.Name = "radioButton_Off";
            this.radioButton_Off.Size = new System.Drawing.Size(39, 16);
            this.radioButton_Off.TabIndex = 3;
            this.radioButton_Off.Text = "O&ff";
            this.radioButton_Off.UseVisualStyleBackColor = true;
            this.radioButton_Off.CheckedChanged += new System.EventHandler(this.radioButton_Off_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Backlight:";
            // 
            // radioButton_On
            // 
            this.radioButton_On.AutoSize = true;
            this.radioButton_On.Checked = true;
            this.radioButton_On.Location = new System.Drawing.Point(103, 25);
            this.radioButton_On.Name = "radioButton_On";
            this.radioButton_On.Size = new System.Drawing.Size(37, 16);
            this.radioButton_On.TabIndex = 3;
            this.radioButton_On.TabStop = true;
            this.radioButton_On.Text = "&On";
            this.radioButton_On.UseVisualStyleBackColor = true;
            this.radioButton_On.CheckedChanged += new System.EventHandler(this.radioButton_On_CheckedChanged);
            // 
            // trackBar_BL
            // 
            this.trackBar_BL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_BL.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_BL.Location = new System.Drawing.Point(22, 47);
            this.trackBar_BL.Maximum = 100;
            this.trackBar_BL.Name = "trackBar_BL";
            this.trackBar_BL.Size = new System.Drawing.Size(447, 45);
            this.trackBar_BL.TabIndex = 10;
            this.trackBar_BL.TickFrequency = 10;
            this.trackBar_BL.Scroll += new System.EventHandler(this.trackBar_BL_Scroll);
            // 
            // groupBox_Brightness
            // 
            this.groupBox_Brightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Brightness.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Brightness.Controls.Add(this.radioButton_WMI);
            this.groupBox_Brightness.Controls.Add(this.label7);
            this.groupBox_Brightness.Controls.Add(this.label6);
            this.groupBox_Brightness.Controls.Add(this.label_BLMax);
            this.groupBox_Brightness.Controls.Add(this.label_BLMin);
            this.groupBox_Brightness.Controls.Add(this.label5);
            this.groupBox_Brightness.Controls.Add(this.label_BLValue);
            this.groupBox_Brightness.Controls.Add(this.radioButton_ACPI);
            this.groupBox_Brightness.Controls.Add(this.radioButton_PWM);
            this.groupBox_Brightness.Controls.Add(this.button_GetBrightness);
            this.groupBox_Brightness.Controls.Add(this.trackBar_BL);
            this.groupBox_Brightness.Location = new System.Drawing.Point(14, 198);
            this.groupBox_Brightness.MaximumSize = new System.Drawing.Size(600, 200);
            this.groupBox_Brightness.MinimumSize = new System.Drawing.Size(430, 0);
            this.groupBox_Brightness.Name = "groupBox_Brightness";
            this.groupBox_Brightness.Size = new System.Drawing.Size(600, 127);
            this.groupBox_Brightness.TabIndex = 8;
            this.groupBox_Brightness.TabStop = false;
            this.groupBox_Brightness.Text = "LVDS Backlight Brightness";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "0%";
            // 
            // label_BLMax
            // 
            this.label_BLMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_BLMax.AutoSize = true;
            this.label_BLMax.Location = new System.Drawing.Point(446, 80);
            this.label_BLMax.Name = "label_BLMax";
            this.label_BLMax.Size = new System.Drawing.Size(11, 12);
            this.label_BLMax.TabIndex = 1;
            this.label_BLMax.Text = "0";
            this.label_BLMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_BLMin
            // 
            this.label_BLMin.AutoSize = true;
            this.label_BLMin.Location = new System.Drawing.Point(31, 80);
            this.label_BLMin.Name = "label_BLMin";
            this.label_BLMin.Size = new System.Drawing.Size(11, 12);
            this.label_BLMin.TabIndex = 1;
            this.label_BLMin.Text = "0";
            this.label_BLMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Method:";
            // 
            // label_BLValue
            // 
            this.label_BLValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_BLValue.AutoSize = true;
            this.label_BLValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BLValue.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_BLValue.Location = new System.Drawing.Point(475, 59);
            this.label_BLValue.Name = "label_BLValue";
            this.label_BLValue.Size = new System.Drawing.Size(19, 19);
            this.label_BLValue.TabIndex = 12;
            this.label_BLValue.Text = "--";
            // 
            // radioButton_ACPI
            // 
            this.radioButton_ACPI.AutoSize = true;
            this.radioButton_ACPI.Location = new System.Drawing.Point(162, 21);
            this.radioButton_ACPI.Name = "radioButton_ACPI";
            this.radioButton_ACPI.Size = new System.Drawing.Size(49, 16);
            this.radioButton_ACPI.TabIndex = 3;
            this.radioButton_ACPI.Text = "&ACPI";
            this.radioButton_ACPI.UseVisualStyleBackColor = true;
            this.radioButton_ACPI.CheckedChanged += new System.EventHandler(this.radioButton_ACPI_CheckedChanged);
            // 
            // radioButton_PWM
            // 
            this.radioButton_PWM.AutoSize = true;
            this.radioButton_PWM.Checked = true;
            this.radioButton_PWM.Location = new System.Drawing.Point(103, 21);
            this.radioButton_PWM.Name = "radioButton_PWM";
            this.radioButton_PWM.Size = new System.Drawing.Size(50, 16);
            this.radioButton_PWM.TabIndex = 3;
            this.radioButton_PWM.TabStop = true;
            this.radioButton_PWM.Text = "&PWM";
            this.radioButton_PWM.UseVisualStyleBackColor = true;
            this.radioButton_PWM.CheckedChanged += new System.EventHandler(this.radioButton_PWM_CheckedChanged);
            // 
            // button_GetBrightness
            // 
            this.button_GetBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetBrightness.Location = new System.Drawing.Point(528, 69);
            this.button_GetBrightness.Name = "button_GetBrightness";
            this.button_GetBrightness.Size = new System.Drawing.Size(57, 23);
            this.button_GetBrightness.TabIndex = 11;
            this.button_GetBrightness.Text = "Get";
            this.button_GetBrightness.UseVisualStyleBackColor = true;
            this.button_GetBrightness.Click += new System.EventHandler(this.button_GetBrightness_Click);
            // 
            // radioButton_WMI
            // 
            this.radioButton_WMI.AutoSize = true;
            this.radioButton_WMI.Location = new System.Drawing.Point(227, 21);
            this.radioButton_WMI.Name = "radioButton_WMI";
            this.radioButton_WMI.Size = new System.Drawing.Size(48, 16);
            this.radioButton_WMI.TabIndex = 15;
            this.radioButton_WMI.Text = "&WMI";
            this.radioButton_WMI.UseVisualStyleBackColor = true;
            this.radioButton_WMI.CheckedChanged += new System.EventHandler(this.radioButton_WMI_CheckedChanged);
            // 
            // ctlMain
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBox_DevList);
            this.Controls.Add(this.groupBox_Brightness);
            this.Controls.Add(this.groupBox_Control);
            this.Controls.Add(this.groupBox_Freq);
            this.Controls.Add(this.label10);
            this.MinimumSize = new System.Drawing.Size(460, 0);
            this.Name = "ctlMain";
            this.Size = new System.Drawing.Size(630, 400);
            this.groupBox_Freq.ResumeLayout(false);
            this.groupBox_Freq.PerformLayout();
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BL)).EndInit();
            this.groupBox_Brightness.ResumeLayout(false);
            this.groupBox_Brightness.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.GroupBox groupBox_Freq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Freq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_No;
        private System.Windows.Forms.RadioButton radioButton_Yes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SetFreq;
        private System.Windows.Forms.Button button_GetFreq;
        private System.Windows.Forms.Button button_GetPol;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Button button_GetBacklight;
        private System.Windows.Forms.RadioButton radioButton_Off;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_On;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar_BL;
        private System.Windows.Forms.GroupBox groupBox_Brightness;
        private System.Windows.Forms.Button button_GetBrightness;
        private System.Windows.Forms.Label label_BLValue;
        private System.Windows.Forms.Label label_BLMin;
        private System.Windows.Forms.Label label_BLMax;
        private System.Windows.Forms.RadioButton radioButton_ACPI;
        private System.Windows.Forms.RadioButton radioButton_PWM;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton_WMI;
    }
}
