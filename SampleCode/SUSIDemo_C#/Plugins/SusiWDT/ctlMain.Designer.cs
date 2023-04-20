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
			this.groupBox_Control = new System.Windows.Forms.GroupBox();
			this.comboBox_Type = new System.Windows.Forms.ComboBox();
			this.button_Start = new System.Windows.Forms.Button();
			this.textBox_Event = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.button_Trigger = new System.Windows.Forms.Button();
			this.textBox_Delay = new System.Windows.Forms.TextBox();
			this.button_Stop = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_Reset = new System.Windows.Forms.TextBox();
			this.label_EventType = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_Info = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label_MinUnit = new System.Windows.Forms.Label();
			this.label_MinResetTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label_MinDelayTime = new System.Windows.Forms.Label();
			this.label_MaxResetTime = new System.Windows.Forms.Label();
			this.label_MinEventTime = new System.Windows.Forms.Label();
			this.label_MaxDelayTime = new System.Windows.Forms.Label();
			this.label_MaxEventTime = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.comboBox_DevList = new System.Windows.Forms.ComboBox();
			this.groupBox_Control.SuspendLayout();
			this.groupBox_Info.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_Control
			// 
			this.groupBox_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_Control.Controls.Add(this.comboBox_Type);
			this.groupBox_Control.Controls.Add(this.button_Start);
			this.groupBox_Control.Controls.Add(this.textBox_Event);
			this.groupBox_Control.Controls.Add(this.label2);
			this.groupBox_Control.Controls.Add(this.label11);
			this.groupBox_Control.Controls.Add(this.label12);
			this.groupBox_Control.Controls.Add(this.button_Trigger);
			this.groupBox_Control.Controls.Add(this.textBox_Delay);
			this.groupBox_Control.Controls.Add(this.button_Stop);
			this.groupBox_Control.Controls.Add(this.label10);
			this.groupBox_Control.Controls.Add(this.label3);
			this.groupBox_Control.Controls.Add(this.textBox_Reset);
			this.groupBox_Control.Controls.Add(this.label_EventType);
			this.groupBox_Control.Controls.Add(this.label1);
			this.groupBox_Control.Location = new System.Drawing.Point(14, 176);
			this.groupBox_Control.MaximumSize = new System.Drawing.Size(600, 150);
			this.groupBox_Control.MinimumSize = new System.Drawing.Size(525, 0);
			this.groupBox_Control.Name = "groupBox_Control";
			this.groupBox_Control.Size = new System.Drawing.Size(600, 142);
			this.groupBox_Control.TabIndex = 5;
			this.groupBox_Control.TabStop = false;
			this.groupBox_Control.Text = "Control";
			// 
			// comboBox_Type
			// 
			this.comboBox_Type.FormattingEnabled = true;
			this.comboBox_Type.Location = new System.Drawing.Point(135, 81);
			this.comboBox_Type.Name = "comboBox_Type";
			this.comboBox_Type.Size = new System.Drawing.Size(116, 20);
			this.comboBox_Type.TabIndex = 3;
			this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
			// 
			// button_Start
			// 
			this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Start.Location = new System.Drawing.Point(348, 107);
			this.button_Start.Name = "button_Start";
			this.button_Start.Size = new System.Drawing.Size(75, 23);
			this.button_Start.TabIndex = 2;
			this.button_Start.Text = "Start";
			this.button_Start.UseVisualStyleBackColor = true;
			this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
			// 
			// textBox_Event
			// 
			this.textBox_Event.Location = new System.Drawing.Point(135, 109);
			this.textBox_Event.Name = "textBox_Event";
			this.textBox_Event.Size = new System.Drawing.Size(92, 22);
			this.textBox_Event.TabIndex = 0;
			this.textBox_Event.Text = "0";
			this.textBox_Event.Leave += new System.EventHandler(this.textBox_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "Event time:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(233, 112);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(18, 12);
			this.label11.TabIndex = 1;
			this.label11.Text = "ms";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(233, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(18, 12);
			this.label12.TabIndex = 1;
			this.label12.Text = "ms";
			// 
			// button_Trigger
			// 
			this.button_Trigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Trigger.Location = new System.Drawing.Point(429, 107);
			this.button_Trigger.Name = "button_Trigger";
			this.button_Trigger.Size = new System.Drawing.Size(75, 23);
			this.button_Trigger.TabIndex = 2;
			this.button_Trigger.Text = "Trigger";
			this.button_Trigger.UseVisualStyleBackColor = true;
			this.button_Trigger.Click += new System.EventHandler(this.button_Trigger_Click);
			// 
			// textBox_Delay
			// 
			this.textBox_Delay.Location = new System.Drawing.Point(135, 25);
			this.textBox_Delay.Name = "textBox_Delay";
			this.textBox_Delay.Size = new System.Drawing.Size(92, 22);
			this.textBox_Delay.TabIndex = 0;
			this.textBox_Delay.Text = "0";
			this.textBox_Delay.Leave += new System.EventHandler(this.textBox_Leave);
			// 
			// button_Stop
			// 
			this.button_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Stop.Location = new System.Drawing.Point(510, 107);
			this.button_Stop.Name = "button_Stop";
			this.button_Stop.Size = new System.Drawing.Size(75, 23);
			this.button_Stop.TabIndex = 2;
			this.button_Stop.Text = "Stop";
			this.button_Stop.UseVisualStyleBackColor = true;
			this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(233, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(18, 12);
			this.label10.TabIndex = 1;
			this.label10.Text = "ms";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 12);
			this.label3.TabIndex = 1;
			this.label3.Text = "Reset time:";
			// 
			// textBox_Reset
			// 
			this.textBox_Reset.Location = new System.Drawing.Point(135, 53);
			this.textBox_Reset.Name = "textBox_Reset";
			this.textBox_Reset.Size = new System.Drawing.Size(92, 22);
			this.textBox_Reset.TabIndex = 0;
			this.textBox_Reset.Text = "0";
			this.textBox_Reset.Leave += new System.EventHandler(this.textBox_Leave);
			// 
			// label_EventType
			// 
			this.label_EventType.AutoSize = true;
			this.label_EventType.Location = new System.Drawing.Point(20, 84);
			this.label_EventType.Name = "label_EventType";
			this.label_EventType.Size = new System.Drawing.Size(62, 12);
			this.label_EventType.TabIndex = 1;
			this.label_EventType.Text = "Event Type:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Delay time:";
			// 
			// groupBox_Info
			// 
			this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_Info.Controls.Add(this.label8);
			this.groupBox_Info.Controls.Add(this.label15);
			this.groupBox_Info.Controls.Add(this.label4);
			this.groupBox_Info.Controls.Add(this.label6);
			this.groupBox_Info.Controls.Add(this.label14);
			this.groupBox_Info.Controls.Add(this.label13);
			this.groupBox_Info.Controls.Add(this.label_MinUnit);
			this.groupBox_Info.Controls.Add(this.label_MinResetTime);
			this.groupBox_Info.Controls.Add(this.label7);
			this.groupBox_Info.Controls.Add(this.label_MinDelayTime);
			this.groupBox_Info.Controls.Add(this.label_MaxResetTime);
			this.groupBox_Info.Controls.Add(this.label_MinEventTime);
			this.groupBox_Info.Controls.Add(this.label_MaxDelayTime);
			this.groupBox_Info.Controls.Add(this.label_MaxEventTime);
			this.groupBox_Info.Location = new System.Drawing.Point(14, 48);
			this.groupBox_Info.MaximumSize = new System.Drawing.Size(600, 120);
			this.groupBox_Info.MinimumSize = new System.Drawing.Size(525, 0);
			this.groupBox_Info.Name = "groupBox_Info";
			this.groupBox_Info.Size = new System.Drawing.Size(600, 120);
			this.groupBox_Info.TabIndex = 4;
			this.groupBox_Info.TabStop = false;
			this.groupBox_Info.Text = "Information";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(318, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 12);
			this.label8.TabIndex = 1;
			this.label8.Text = "Minimum delay time:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(318, 49);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(105, 12);
			this.label15.TabIndex = 1;
			this.label15.Text = "Minimum event time:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "Maximum delay time:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 12);
			this.label6.TabIndex = 1;
			this.label6.Text = "Maximum event time:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(20, 91);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(75, 12);
			this.label14.TabIndex = 1;
			this.label14.Text = "Minimum unit:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(318, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(101, 12);
			this.label13.TabIndex = 1;
			this.label13.Text = "Minimum reset time:";
			// 
			// label_MinUnit
			// 
			this.label_MinUnit.AutoSize = true;
			this.label_MinUnit.Location = new System.Drawing.Point(143, 91);
			this.label_MinUnit.Name = "label_MinUnit";
			this.label_MinUnit.Size = new System.Drawing.Size(11, 12);
			this.label_MinUnit.TabIndex = 1;
			this.label_MinUnit.Text = "0";
			// 
			// label_MinResetTime
			// 
			this.label_MinResetTime.AutoSize = true;
			this.label_MinResetTime.Location = new System.Drawing.Point(438, 70);
			this.label_MinResetTime.Name = "label_MinResetTime";
			this.label_MinResetTime.Size = new System.Drawing.Size(11, 12);
			this.label_MinResetTime.TabIndex = 1;
			this.label_MinResetTime.Text = "0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 12);
			this.label7.TabIndex = 1;
			this.label7.Text = "Maximum reset time:";
			// 
			// label_MinDelayTime
			// 
			this.label_MinDelayTime.AutoSize = true;
			this.label_MinDelayTime.Location = new System.Drawing.Point(438, 28);
			this.label_MinDelayTime.Name = "label_MinDelayTime";
			this.label_MinDelayTime.Size = new System.Drawing.Size(11, 12);
			this.label_MinDelayTime.TabIndex = 1;
			this.label_MinDelayTime.Text = "0";
			// 
			// label_MaxResetTime
			// 
			this.label_MaxResetTime.AutoSize = true;
			this.label_MaxResetTime.Location = new System.Drawing.Point(143, 70);
			this.label_MaxResetTime.Name = "label_MaxResetTime";
			this.label_MaxResetTime.Size = new System.Drawing.Size(11, 12);
			this.label_MaxResetTime.TabIndex = 1;
			this.label_MaxResetTime.Text = "0";
			// 
			// label_MinEventTime
			// 
			this.label_MinEventTime.AutoSize = true;
			this.label_MinEventTime.Location = new System.Drawing.Point(438, 49);
			this.label_MinEventTime.Name = "label_MinEventTime";
			this.label_MinEventTime.Size = new System.Drawing.Size(11, 12);
			this.label_MinEventTime.TabIndex = 1;
			this.label_MinEventTime.Text = "0";
			// 
			// label_MaxDelayTime
			// 
			this.label_MaxDelayTime.AutoSize = true;
			this.label_MaxDelayTime.Location = new System.Drawing.Point(143, 28);
			this.label_MaxDelayTime.Name = "label_MaxDelayTime";
			this.label_MaxDelayTime.Size = new System.Drawing.Size(11, 12);
			this.label_MaxDelayTime.TabIndex = 1;
			this.label_MaxDelayTime.Text = "0";
			// 
			// label_MaxEventTime
			// 
			this.label_MaxEventTime.AutoSize = true;
			this.label_MaxEventTime.Location = new System.Drawing.Point(143, 49);
			this.label_MaxEventTime.Name = "label_MaxEventTime";
			this.label_MaxEventTime.Size = new System.Drawing.Size(11, 12);
			this.label_MaxEventTime.TabIndex = 1;
			this.label_MaxEventTime.Text = "0";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.label16.Location = new System.Drawing.Point(21, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(101, 15);
			this.label16.TabIndex = 1;
			this.label16.Text = "Watchdog timer:";
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
			this.comboBox_DevList.TabIndex = 6;
			this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_WDogList_SelectedIndexChanged);
			// 
			// ctlMain
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.comboBox_DevList);
			this.Controls.Add(this.groupBox_Control);
			this.Controls.Add(this.groupBox_Info);
			this.Controls.Add(this.label16);
			this.MinimumSize = new System.Drawing.Size(460, 285);
			this.Name = "ctlMain";
			this.Size = new System.Drawing.Size(630, 400);
			this.groupBox_Control.ResumeLayout(false);
			this.groupBox_Control.PerformLayout();
			this.groupBox_Info.ResumeLayout(false);
			this.groupBox_Info.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Trigger;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Delay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Event;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Reset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_MaxResetTime;
        private System.Windows.Forms.Label label_MaxDelayTime;
        private System.Windows.Forms.Label label_MaxEventTime;
        private System.Windows.Forms.Label label_EventType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_MinUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_MinResetTime;
        private System.Windows.Forms.Label label_MinDelayTime;
        private System.Windows.Forms.Label label_MinEventTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_DevList;
    }
}
