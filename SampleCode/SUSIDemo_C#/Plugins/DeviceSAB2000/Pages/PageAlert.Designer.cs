namespace Susi4.Plugin
{
    partial class PageAlert
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Val = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Src = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_Ctrl = new System.Windows.Forms.GroupBox();
            this.button_Get = new System.Windows.Forms.Button();
            this.button_Set = new System.Windows.Forms.Button();
            this.groupBox_Status = new System.Windows.Forms.GroupBox();
            this.label_LED_TEMP = new System.Windows.Forms.Label();
            this.label_CaseOpen = new System.Windows.Forms.Label();
            this.label_LED_FAN = new System.Windows.Forms.Label();
            this.label_LED_PWR = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_Fresh = new System.Windows.Forms.Timer(this.components);
            this.radioButton_AlertEn = new System.Windows.Forms.RadioButton();
            this.radioButton_AlertDis = new System.Windows.Forms.RadioButton();
            this.groupBox_Ctrl.SuspendLayout();
            this.groupBox_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Value:";
            // 
            // textBox_Val
            // 
            this.textBox_Val.Location = new System.Drawing.Point(60, 47);
            this.textBox_Val.Name = "textBox_Val";
            this.textBox_Val.Size = new System.Drawing.Size(53, 22);
            this.textBox_Val.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Celsius)";
            // 
            // comboBox_Src
            // 
            this.comboBox_Src.FormattingEnabled = true;
            this.comboBox_Src.Location = new System.Drawing.Point(60, 21);
            this.comboBox_Src.Name = "comboBox_Src";
            this.comboBox_Src.Size = new System.Drawing.Size(141, 20);
            this.comboBox_Src.TabIndex = 3;
            this.comboBox_Src.SelectedIndexChanged += new System.EventHandler(this.comboBox_Src_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Source:";
            // 
            // groupBox_Ctrl
            // 
            this.groupBox_Ctrl.Controls.Add(this.button_Get);
            this.groupBox_Ctrl.Controls.Add(this.button_Set);
            this.groupBox_Ctrl.Controls.Add(this.comboBox_Src);
            this.groupBox_Ctrl.Controls.Add(this.label3);
            this.groupBox_Ctrl.Controls.Add(this.label1);
            this.groupBox_Ctrl.Controls.Add(this.textBox_Val);
            this.groupBox_Ctrl.Controls.Add(this.label2);
            this.groupBox_Ctrl.Location = new System.Drawing.Point(19, 49);
            this.groupBox_Ctrl.Name = "groupBox_Ctrl";
            this.groupBox_Ctrl.Size = new System.Drawing.Size(220, 117);
            this.groupBox_Ctrl.TabIndex = 5;
            this.groupBox_Ctrl.TabStop = false;
            this.groupBox_Ctrl.Text = "Thermal Alert Control";
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(152, 82);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(49, 23);
            this.button_Get.TabIndex = 5;
            this.button_Get.Text = "Get";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(97, 82);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(49, 23);
            this.button_Set.TabIndex = 5;
            this.button_Set.Text = "Set";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // groupBox_Status
            // 
            this.groupBox_Status.Controls.Add(this.label_LED_TEMP);
            this.groupBox_Status.Controls.Add(this.label_CaseOpen);
            this.groupBox_Status.Controls.Add(this.label_LED_FAN);
            this.groupBox_Status.Controls.Add(this.label_LED_PWR);
            this.groupBox_Status.Controls.Add(this.label8);
            this.groupBox_Status.Controls.Add(this.label6);
            this.groupBox_Status.Controls.Add(this.label4);
            this.groupBox_Status.Location = new System.Drawing.Point(20, 172);
            this.groupBox_Status.Name = "groupBox_Status";
            this.groupBox_Status.Size = new System.Drawing.Size(219, 117);
            this.groupBox_Status.TabIndex = 6;
            this.groupBox_Status.TabStop = false;
            this.groupBox_Status.Text = "Status";
            // 
            // label_LED_TEMP
            // 
            this.label_LED_TEMP.AutoSize = true;
            this.label_LED_TEMP.Location = new System.Drawing.Point(89, 45);
            this.label_LED_TEMP.Name = "label_LED_TEMP";
            this.label_LED_TEMP.Size = new System.Drawing.Size(13, 12);
            this.label_LED_TEMP.TabIndex = 0;
            this.label_LED_TEMP.Text = "--";
            // 
            // label_CaseOpen
            // 
            this.label_CaseOpen.Location = new System.Drawing.Point(0, 0);
            this.label_CaseOpen.Name = "label_CaseOpen";
            this.label_CaseOpen.Size = new System.Drawing.Size(100, 23);
            this.label_CaseOpen.TabIndex = 1;
            // 
            // label_LED_FAN
            // 
            this.label_LED_FAN.AutoSize = true;
            this.label_LED_FAN.Location = new System.Drawing.Point(89, 66);
            this.label_LED_FAN.Name = "label_LED_FAN";
            this.label_LED_FAN.Size = new System.Drawing.Size(13, 12);
            this.label_LED_FAN.TabIndex = 0;
            this.label_LED_FAN.Text = "--";
            // 
            // label_LED_PWR
            // 
            this.label_LED_PWR.AutoSize = true;
            this.label_LED_PWR.Location = new System.Drawing.Point(89, 24);
            this.label_LED_PWR.Name = "label_LED_PWR";
            this.label_LED_PWR.Size = new System.Drawing.Size(13, 12);
            this.label_LED_PWR.TabIndex = 0;
            this.label_LED_PWR.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Temp. LED:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fan LED:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Power LED:";
            // 
            // timer_Fresh
            // 
            this.timer_Fresh.Interval = 1000;
            this.timer_Fresh.Tick += new System.EventHandler(this.timer_Fresh_Tick);
            // 
            // radioButton_AlertEn
            // 
            this.radioButton_AlertEn.AutoSize = true;
            this.radioButton_AlertEn.Checked = true;
            this.radioButton_AlertEn.Location = new System.Drawing.Point(35, 18);
            this.radioButton_AlertEn.Name = "radioButton_AlertEn";
            this.radioButton_AlertEn.Size = new System.Drawing.Size(81, 16);
            this.radioButton_AlertEn.TabIndex = 7;
            this.radioButton_AlertEn.TabStop = true;
            this.radioButton_AlertEn.Text = "Alert Enable";
            this.radioButton_AlertEn.UseVisualStyleBackColor = true;
            this.radioButton_AlertEn.CheckedChanged += new System.EventHandler(this.radioButton_AlertEn_CheckedChanged);
            // 
            // radioButton_AlertDis
            // 
            this.radioButton_AlertDis.AutoSize = true;
            this.radioButton_AlertDis.Location = new System.Drawing.Point(137, 18);
            this.radioButton_AlertDis.Name = "radioButton_AlertDis";
            this.radioButton_AlertDis.Size = new System.Drawing.Size(83, 16);
            this.radioButton_AlertDis.TabIndex = 7;
            this.radioButton_AlertDis.TabStop = true;
            this.radioButton_AlertDis.Text = "Alert Disable";
            this.radioButton_AlertDis.UseVisualStyleBackColor = true;
            // 
            // PageAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton_AlertDis);
            this.Controls.Add(this.radioButton_AlertEn);
            this.Controls.Add(this.groupBox_Status);
            this.Controls.Add(this.groupBox_Ctrl);
            this.Name = "PageAlert";
            this.Size = new System.Drawing.Size(604, 363);
            this.Load += new System.EventHandler(this.PageAlert_Load);
            this.groupBox_Ctrl.ResumeLayout(false);
            this.groupBox_Ctrl.PerformLayout();
            this.groupBox_Status.ResumeLayout(false);
            this.groupBox_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Val;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Src;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_Ctrl;
        private System.Windows.Forms.GroupBox groupBox_Status;
        private System.Windows.Forms.Label label_LED_PWR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_LED_FAN;
        private System.Windows.Forms.Label label_LED_TEMP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer_Fresh;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.RadioButton radioButton_AlertEn;
        private System.Windows.Forms.RadioButton radioButton_AlertDis;
        private System.Windows.Forms.Label label_CaseOpen;
    }
}
