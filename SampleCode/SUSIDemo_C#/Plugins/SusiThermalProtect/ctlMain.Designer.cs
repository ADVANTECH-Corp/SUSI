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
			this.groupBox_Control = new System.Windows.Forms.GroupBox();
			this.comboBox_Source = new System.Windows.Forms.ComboBox();
			this.button_Set = new System.Windows.Forms.Button();
			this.button_Get = new System.Windows.Forms.Button();
			this.comboBox_EventType = new System.Windows.Forms.ComboBox();
			this.textBox_StopT = new System.Windows.Forms.TextBox();
			this.textBox_TiggerT = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label_ClearRange = new System.Windows.Forms.Label();
			this.label_TriggerRange = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox_Control.SuspendLayout();
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
			this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_DevList_SelectedIndexChanged);
			// 
			// groupBox_Control
			// 
			this.groupBox_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_Control.Controls.Add(this.comboBox_Source);
			this.groupBox_Control.Controls.Add(this.button_Set);
			this.groupBox_Control.Controls.Add(this.button_Get);
			this.groupBox_Control.Controls.Add(this.comboBox_EventType);
			this.groupBox_Control.Controls.Add(this.textBox_StopT);
			this.groupBox_Control.Controls.Add(this.textBox_TiggerT);
			this.groupBox_Control.Controls.Add(this.label6);
			this.groupBox_Control.Controls.Add(this.label_ClearRange);
			this.groupBox_Control.Controls.Add(this.label_TriggerRange);
			this.groupBox_Control.Controls.Add(this.label4);
			this.groupBox_Control.Controls.Add(this.label5);
			this.groupBox_Control.Controls.Add(this.label3);
			this.groupBox_Control.Controls.Add(this.label2);
			this.groupBox_Control.Controls.Add(this.label1);
			this.groupBox_Control.Location = new System.Drawing.Point(14, 48);
			this.groupBox_Control.MaximumSize = new System.Drawing.Size(600, 250);
			this.groupBox_Control.MinimumSize = new System.Drawing.Size(525, 0);
			this.groupBox_Control.Name = "groupBox_Control";
			this.groupBox_Control.Size = new System.Drawing.Size(600, 142);
			this.groupBox_Control.TabIndex = 8;
			this.groupBox_Control.TabStop = false;
			this.groupBox_Control.Text = "Control";
			// 
			// comboBox_Source
			// 
			this.comboBox_Source.FormattingEnabled = true;
			this.comboBox_Source.Location = new System.Drawing.Point(135, 25);
			this.comboBox_Source.Name = "comboBox_Source";
			this.comboBox_Source.Size = new System.Drawing.Size(121, 20);
			this.comboBox_Source.TabIndex = 4;
			this.comboBox_Source.SelectedIndexChanged += new System.EventHandler(this.comboBox_Source_SelectedIndexChanged);
			// 
			// button_Set
			// 
			this.button_Set.Enabled = false;
			this.button_Set.Location = new System.Drawing.Point(429, 105);
			this.button_Set.Name = "button_Set";
			this.button_Set.Size = new System.Drawing.Size(75, 23);
			this.button_Set.TabIndex = 3;
			this.button_Set.Text = "Set";
			this.button_Set.UseVisualStyleBackColor = true;
			this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
			// 
			// button_Get
			// 
			this.button_Get.Location = new System.Drawing.Point(510, 105);
			this.button_Get.Name = "button_Get";
			this.button_Get.Size = new System.Drawing.Size(75, 23);
			this.button_Get.TabIndex = 3;
			this.button_Get.Text = "Get";
			this.button_Get.UseVisualStyleBackColor = true;
			this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
			// 
			// comboBox_EventType
			// 
			this.comboBox_EventType.FormattingEnabled = true;
			this.comboBox_EventType.Items.AddRange(new object[] {
            "Shutdowm",
            "Throttle",
            "Power OFF"});
			this.comboBox_EventType.Location = new System.Drawing.Point(136, 53);
			this.comboBox_EventType.Name = "comboBox_EventType";
			this.comboBox_EventType.Size = new System.Drawing.Size(120, 20);
			this.comboBox_EventType.TabIndex = 2;
			this.comboBox_EventType.SelectedIndexChanged += new System.EventHandler(this.comboBox_EventType_SelectedIndexChanged);
			// 
			// textBox_StopT
			// 
			this.textBox_StopT.Location = new System.Drawing.Point(136, 107);
			this.textBox_StopT.MaxLength = 3;
			this.textBox_StopT.Name = "textBox_StopT";
			this.textBox_StopT.Size = new System.Drawing.Size(59, 22);
			this.textBox_StopT.TabIndex = 1;
			this.textBox_StopT.Leave += new System.EventHandler(this.textBox_StopT_Leave);
            this.textBox_StopT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_In_KeyPress);
            // 
            // textBox_TiggerT
            // 
            this.textBox_TiggerT.Location = new System.Drawing.Point(136, 79);
			this.textBox_TiggerT.MaxLength = 3;
			this.textBox_TiggerT.Name = "textBox_TiggerT";
			this.textBox_TiggerT.Size = new System.Drawing.Size(59, 22);
			this.textBox_TiggerT.TabIndex = 1;
			this.textBox_TiggerT.Leave += new System.EventHandler(this.textBox_TiggerT_Leave);
			this.textBox_TiggerT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_In_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(201, 110);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 12);
			this.label6.TabIndex = 0;
			this.label6.Text = "Celsius";
			// 
			// label_ClearRange
			// 
			this.label_ClearRange.AutoSize = true;
			this.label_ClearRange.Location = new System.Drawing.Point(252, 110);
			this.label_ClearRange.Name = "label_ClearRange";
			this.label_ClearRange.Size = new System.Drawing.Size(83, 12);
			this.label_ClearRange.TabIndex = 0;
			this.label_ClearRange.Text = "(Range: 0 - 127)";
			// 
			// label_TriggerRange
			// 
			this.label_TriggerRange.AutoSize = true;
			this.label_TriggerRange.Location = new System.Drawing.Point(252, 82);
			this.label_TriggerRange.Name = "label_TriggerRange";
			this.label_TriggerRange.Size = new System.Drawing.Size(89, 12);
			this.label_TriggerRange.TabIndex = 0;
			this.label_TriggerRange.Text = "(Range: 70 - 127)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(201, 82);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "Celsius";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 110);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "Clear Temperature:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "Trigger Temperature:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "Event Type:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thermal Source:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.label16.Location = new System.Drawing.Point(21, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(119, 15);
			this.label16.TabIndex = 7;
			this.label16.Text = "Thermal Protection:";
			// 
			// ctlMain
			// 
			this.Controls.Add(this.comboBox_DevList);
			this.Controls.Add(this.groupBox_Control);
			this.Controls.Add(this.label16);
			this.MinimumSize = new System.Drawing.Size(630, 400);
			this.Name = "ctlMain";
			this.Size = new System.Drawing.Size(630, 400);
			this.groupBox_Control.ResumeLayout(false);
			this.groupBox_Control.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_EventType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TiggerT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_StopT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.ComboBox comboBox_Source;
        private System.Windows.Forms.Label label_ClearRange;
        private System.Windows.Forms.Label label_TriggerRange;
    }
}
