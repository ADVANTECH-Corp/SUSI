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
			this.button_WR = new System.Windows.Forms.Button();
			this.button_Probe = new System.Windows.Forms.Button();
			this.button_Read = new System.Windows.Forms.Button();
			this.button_Write = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_Result = new System.Windows.Forms.TextBox();
			this.textBox_Data = new System.Windows.Forms.TextBox();
			this.textBox_WLength = new System.Windows.Forms.TextBox();
			this.textBox_RLength = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_CMD = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_SlaveAddr = new System.Windows.Forms.TextBox();
			this.comboBox_DevList = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.radioButton_Freq400 = new System.Windows.Forms.RadioButton();
			this.textBox_Freq = new System.Windows.Forms.TextBox();
			this.button_SetFreq = new System.Windows.Forms.Button();
			this.button_GetFreq = new System.Windows.Forms.Button();
			this.radioButton_Freq0to100 = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox_SlaveAddress = new System.Windows.Forms.GroupBox();
			this.radioButton_Addr10bit = new System.Windows.Forms.RadioButton();
			this.radioButton_Addr7bit = new System.Windows.Forms.RadioButton();
			this.groupBox_CMD = new System.Windows.Forms.GroupBox();
			this.radioButton_CMDNone = new System.Windows.Forms.RadioButton();
			this.radioButton_CMDWord = new System.Windows.Forms.RadioButton();
			this.radioButton_CMDByte = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox_Freq = new System.Windows.Forms.GroupBox();
			this.groupBox_Protocol = new System.Windows.Forms.GroupBox();
			this.radioButton_ProtocalCombine = new System.Windows.Forms.RadioButton();
			this.radioButton_ProtocalTransfer = new System.Windows.Forms.RadioButton();
			this.groupBox_SlaveAddress.SuspendLayout();
			this.groupBox_CMD.SuspendLayout();
			this.groupBox_Freq.SuspendLayout();
			this.groupBox_Protocol.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_WR
			// 
			this.button_WR.Location = new System.Drawing.Point(14, 364);
			this.button_WR.Name = "button_WR";
			this.button_WR.Size = new System.Drawing.Size(99, 23);
			this.button_WR.TabIndex = 12;
			this.button_WR.Text = "WR Combined";
			this.button_WR.UseVisualStyleBackColor = true;
			this.button_WR.Click += new System.EventHandler(this.button_WR_Click);
			// 
			// button_Probe
			// 
			this.button_Probe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Probe.Location = new System.Drawing.Point(341, 364);
			this.button_Probe.Name = "button_Probe";
			this.button_Probe.Size = new System.Drawing.Size(75, 23);
			this.button_Probe.TabIndex = 12;
			this.button_Probe.Text = "Probe";
			this.button_Probe.UseVisualStyleBackColor = true;
			this.button_Probe.Click += new System.EventHandler(this.button_Probe_Click);
			// 
			// button_Read
			// 
			this.button_Read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Read.Location = new System.Drawing.Point(443, 364);
			this.button_Read.Name = "button_Read";
			this.button_Read.Size = new System.Drawing.Size(75, 23);
			this.button_Read.TabIndex = 12;
			this.button_Read.Text = "Read";
			this.button_Read.UseVisualStyleBackColor = true;
			this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
			// 
			// button_Write
			// 
			this.button_Write.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Write.Location = new System.Drawing.Point(524, 364);
			this.button_Write.Name = "button_Write";
			this.button_Write.Size = new System.Drawing.Size(75, 23);
			this.button_Write.TabIndex = 12;
			this.button_Write.Text = "Write";
			this.button_Write.UseVisualStyleBackColor = true;
			this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(364, 180);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(70, 12);
			this.label9.TabIndex = 9;
			this.label9.Text = "Write Length:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(364, 151);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 12);
			this.label7.TabIndex = 9;
			this.label7.Text = "Read Length:";
			// 
			// textBox_Result
			// 
			this.textBox_Result.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_Result.Location = new System.Drawing.Point(14, 301);
			this.textBox_Result.Multiline = true;
			this.textBox_Result.Name = "textBox_Result";
			this.textBox_Result.ReadOnly = true;
			this.textBox_Result.Size = new System.Drawing.Size(585, 57);
			this.textBox_Result.TabIndex = 11;
			this.textBox_Result.Text = "00";
			// 
			// textBox_Data
			// 
			this.textBox_Data.Font = new System.Drawing.Font("MingLiU", 9F);
			this.textBox_Data.Location = new System.Drawing.Point(14, 226);
			this.textBox_Data.Multiline = true;
			this.textBox_Data.Name = "textBox_Data";
			this.textBox_Data.Size = new System.Drawing.Size(585, 57);
			this.textBox_Data.TabIndex = 11;
			this.textBox_Data.Text = "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 \r\n00 01 02 03 04 05 06 07 08 09 0" +
				"A 0B 0C 0D 0E 0F";
			this.textBox_Data.TextChanged += new System.EventHandler(this.textBox_Data_TextChanged);
			this.textBox_Data.Leave += new System.EventHandler(this.textBox_Data_Leave);
			this.textBox_Data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Data_KeyPress);
			// 
			// textBox_WLength
			// 
			this.textBox_WLength.Location = new System.Drawing.Point(445, 177);
			this.textBox_WLength.MaxLength = 3;
			this.textBox_WLength.Name = "textBox_WLength";
			this.textBox_WLength.ReadOnly = true;
			this.textBox_WLength.Size = new System.Drawing.Size(57, 22);
			this.textBox_WLength.TabIndex = 11;
			this.textBox_WLength.Text = "1";
			// 
			// textBox_RLength
			// 
			this.textBox_RLength.Location = new System.Drawing.Point(445, 149);
			this.textBox_RLength.MaxLength = 3;
			this.textBox_RLength.Name = "textBox_RLength";
			this.textBox_RLength.Size = new System.Drawing.Size(57, 22);
			this.textBox_RLength.TabIndex = 11;
			this.textBox_RLength.Text = "0";
			this.textBox_RLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_RLength_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 286);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 12);
			this.label8.TabIndex = 9;
			this.label8.Text = "Result: (HEX)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 211);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 12);
			this.label6.TabIndex = 9;
			this.label6.Text = "Input Data: (HEX)";
			// 
			// textBox_CMD
			// 
			this.textBox_CMD.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_CMD.Location = new System.Drawing.Point(16, 21);
			this.textBox_CMD.MaxLength = 2;
			this.textBox_CMD.Name = "textBox_CMD";
			this.textBox_CMD.Size = new System.Drawing.Size(57, 22);
			this.textBox_CMD.TabIndex = 11;
			this.textBox_CMD.Text = "00";
			this.textBox_CMD.Leave += new System.EventHandler(this.textBox_CMD_Leave);
			this.textBox_CMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CMD_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(79, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "(HEX)";
			// 
			// textBox_SlaveAddr
			// 
			this.textBox_SlaveAddr.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_SlaveAddr.Location = new System.Drawing.Point(16, 21);
			this.textBox_SlaveAddr.MaxLength = 4;
			this.textBox_SlaveAddr.Name = "textBox_SlaveAddr";
			this.textBox_SlaveAddr.Size = new System.Drawing.Size(57, 22);
			this.textBox_SlaveAddr.TabIndex = 11;
			this.textBox_SlaveAddr.Text = "00";
			this.textBox_SlaveAddr.Leave += new System.EventHandler(this.textBox_SlaveAddr_Leave);
			this.textBox_SlaveAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SlaveAddr_KeyPress);
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
			this.comboBox_DevList.TabIndex = 17;
			this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_I2CList_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.label10.Location = new System.Drawing.Point(21, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(57, 15);
			this.label10.TabIndex = 16;
			this.label10.Text = "I2C Host:";
			// 
			// radioButton_Freq400
			// 
			this.radioButton_Freq400.AutoSize = true;
			this.radioButton_Freq400.Location = new System.Drawing.Point(95, 21);
			this.radioButton_Freq400.Name = "radioButton_Freq400";
			this.radioButton_Freq400.Size = new System.Drawing.Size(49, 16);
			this.radioButton_Freq400.TabIndex = 0;
			this.radioButton_Freq400.Text = "400K";
			this.radioButton_Freq400.UseVisualStyleBackColor = true;
			this.radioButton_Freq400.CheckedChanged += new System.EventHandler(this.radioButton_Freq400_CheckedChanged);
			// 
			// textBox_Freq
			// 
			this.textBox_Freq.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_Freq.Location = new System.Drawing.Point(13, 43);
			this.textBox_Freq.MaxLength = 6;
			this.textBox_Freq.Name = "textBox_Freq";
			this.textBox_Freq.Size = new System.Drawing.Size(56, 22);
			this.textBox_Freq.TabIndex = 11;
			this.textBox_Freq.Text = "0";
			this.textBox_Freq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Freq_KeyPress);
			// 
			// button_SetFreq
			// 
			this.button_SetFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_SetFreq.Location = new System.Drawing.Point(174, 41);
			this.button_SetFreq.Name = "button_SetFreq";
			this.button_SetFreq.Size = new System.Drawing.Size(57, 23);
			this.button_SetFreq.TabIndex = 12;
			this.button_SetFreq.Text = "Set";
			this.button_SetFreq.UseVisualStyleBackColor = true;
			this.button_SetFreq.Click += new System.EventHandler(this.button_SetFreq_Click);
			// 
			// button_GetFreq
			// 
			this.button_GetFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_GetFreq.Location = new System.Drawing.Point(237, 41);
			this.button_GetFreq.Name = "button_GetFreq";
			this.button_GetFreq.Size = new System.Drawing.Size(57, 23);
			this.button_GetFreq.TabIndex = 12;
			this.button_GetFreq.Text = "Get";
			this.button_GetFreq.UseVisualStyleBackColor = true;
			this.button_GetFreq.Click += new System.EventHandler(this.button_GetFreq_Click);
			// 
			// radioButton_Freq0to100
			// 
			this.radioButton_Freq0to100.AutoSize = true;
			this.radioButton_Freq0to100.Checked = true;
			this.radioButton_Freq0to100.Location = new System.Drawing.Point(13, 21);
			this.radioButton_Freq0to100.Name = "radioButton_Freq0to100";
			this.radioButton_Freq0to100.Size = new System.Drawing.Size(65, 16);
			this.radioButton_Freq0to100.TabIndex = 0;
			this.radioButton_Freq0to100.TabStop = true;
			this.radioButton_Freq0to100.Text = "0 - 100K";
			this.radioButton_Freq0to100.UseVisualStyleBackColor = true;
			this.radioButton_Freq0to100.CheckedChanged += new System.EventHandler(this.radioButton_Freq0to100_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(75, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "(KHz)";
			// 
			// groupBox_SlaveAddress
			// 
			this.groupBox_SlaveAddress.Controls.Add(this.radioButton_Addr10bit);
			this.groupBox_SlaveAddress.Controls.Add(this.radioButton_Addr7bit);
			this.groupBox_SlaveAddress.Controls.Add(this.textBox_SlaveAddr);
			this.groupBox_SlaveAddress.Controls.Add(this.label2);
			this.groupBox_SlaveAddress.Location = new System.Drawing.Point(14, 127);
			this.groupBox_SlaveAddress.Name = "groupBox_SlaveAddress";
			this.groupBox_SlaveAddress.Size = new System.Drawing.Size(136, 72);
			this.groupBox_SlaveAddress.TabIndex = 19;
			this.groupBox_SlaveAddress.TabStop = false;
			this.groupBox_SlaveAddress.Text = "Slave Address";
			// 
			// radioButton_Addr10bit
			// 
			this.radioButton_Addr10bit.AutoSize = true;
			this.radioButton_Addr10bit.Location = new System.Drawing.Point(67, 49);
			this.radioButton_Addr10bit.Name = "radioButton_Addr10bit";
			this.radioButton_Addr10bit.Size = new System.Drawing.Size(47, 16);
			this.radioButton_Addr10bit.TabIndex = 0;
			this.radioButton_Addr10bit.Text = "10bit";
			this.radioButton_Addr10bit.UseVisualStyleBackColor = true;
			this.radioButton_Addr10bit.CheckedChanged += new System.EventHandler(this.radioButton_Addr10bit_CheckedChanged);
			// 
			// radioButton_Addr7bit
			// 
			this.radioButton_Addr7bit.AutoSize = true;
			this.radioButton_Addr7bit.Location = new System.Drawing.Point(16, 49);
			this.radioButton_Addr7bit.Name = "radioButton_Addr7bit";
			this.radioButton_Addr7bit.Size = new System.Drawing.Size(41, 16);
			this.radioButton_Addr7bit.TabIndex = 0;
			this.radioButton_Addr7bit.Text = "7bit";
			this.radioButton_Addr7bit.UseVisualStyleBackColor = true;
			this.radioButton_Addr7bit.CheckedChanged += new System.EventHandler(this.radioButton_Addr7bit_CheckedChanged);
			// 
			// groupBox_CMD
			// 
			this.groupBox_CMD.Controls.Add(this.radioButton_CMDNone);
			this.groupBox_CMD.Controls.Add(this.radioButton_CMDWord);
			this.groupBox_CMD.Controls.Add(this.radioButton_CMDByte);
			this.groupBox_CMD.Controls.Add(this.textBox_CMD);
			this.groupBox_CMD.Controls.Add(this.label3);
			this.groupBox_CMD.Location = new System.Drawing.Point(156, 127);
			this.groupBox_CMD.Name = "groupBox_CMD";
			this.groupBox_CMD.Size = new System.Drawing.Size(189, 72);
			this.groupBox_CMD.TabIndex = 19;
			this.groupBox_CMD.TabStop = false;
			this.groupBox_CMD.Text = "Command";
			// 
			// radioButton_CMDNone
			// 
			this.radioButton_CMDNone.AutoSize = true;
			this.radioButton_CMDNone.Location = new System.Drawing.Point(123, 49);
			this.radioButton_CMDNone.Name = "radioButton_CMDNone";
			this.radioButton_CMDNone.Size = new System.Drawing.Size(48, 16);
			this.radioButton_CMDNone.TabIndex = 0;
			this.radioButton_CMDNone.Text = "None";
			this.radioButton_CMDNone.UseVisualStyleBackColor = true;
			this.radioButton_CMDNone.CheckedChanged += new System.EventHandler(this.radioButton_CMDNone_CheckedChanged);
			// 
			// radioButton_CMDWord
			// 
			this.radioButton_CMDWord.AutoSize = true;
			this.radioButton_CMDWord.Location = new System.Drawing.Point(67, 49);
			this.radioButton_CMDWord.Name = "radioButton_CMDWord";
			this.radioButton_CMDWord.Size = new System.Drawing.Size(50, 16);
			this.radioButton_CMDWord.TabIndex = 0;
			this.radioButton_CMDWord.Text = "Word";
			this.radioButton_CMDWord.UseVisualStyleBackColor = true;
			this.radioButton_CMDWord.CheckedChanged += new System.EventHandler(this.radioButton_CMDWord_CheckedChanged);
			// 
			// radioButton_CMDByte
			// 
			this.radioButton_CMDByte.AutoSize = true;
			this.radioButton_CMDByte.Location = new System.Drawing.Point(16, 49);
			this.radioButton_CMDByte.Name = "radioButton_CMDByte";
			this.radioButton_CMDByte.Size = new System.Drawing.Size(45, 16);
			this.radioButton_CMDByte.TabIndex = 0;
			this.radioButton_CMDByte.Text = "Byte";
			this.radioButton_CMDByte.UseVisualStyleBackColor = true;
			this.radioButton_CMDByte.CheckedChanged += new System.EventHandler(this.radioButton_CMDByte_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(78, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "(HEX)";
			// 
			// groupBox_Freq
			// 
			this.groupBox_Freq.Controls.Add(this.radioButton_Freq0to100);
			this.groupBox_Freq.Controls.Add(this.label4);
			this.groupBox_Freq.Controls.Add(this.textBox_Freq);
			this.groupBox_Freq.Controls.Add(this.radioButton_Freq400);
			this.groupBox_Freq.Controls.Add(this.button_SetFreq);
			this.groupBox_Freq.Controls.Add(this.button_GetFreq);
			this.groupBox_Freq.Location = new System.Drawing.Point(299, 48);
			this.groupBox_Freq.Name = "groupBox_Freq";
			this.groupBox_Freq.Size = new System.Drawing.Size(300, 73);
			this.groupBox_Freq.TabIndex = 19;
			this.groupBox_Freq.TabStop = false;
			this.groupBox_Freq.Text = "Frequency";
			// 
			// groupBox_Protocol
			// 
			this.groupBox_Protocol.Controls.Add(this.radioButton_ProtocalCombine);
			this.groupBox_Protocol.Controls.Add(this.radioButton_ProtocalTransfer);
			this.groupBox_Protocol.Location = new System.Drawing.Point(14, 48);
			this.groupBox_Protocol.Name = "groupBox_Protocol";
			this.groupBox_Protocol.Size = new System.Drawing.Size(278, 73);
			this.groupBox_Protocol.TabIndex = 19;
			this.groupBox_Protocol.TabStop = false;
			this.groupBox_Protocol.Text = "Protocol";
			// 
			// radioButton_ProtocalCombine
			// 
			this.radioButton_ProtocalCombine.AutoSize = true;
			this.radioButton_ProtocalCombine.Location = new System.Drawing.Point(16, 44);
			this.radioButton_ProtocalCombine.Name = "radioButton_ProtocalCombine";
			this.radioButton_ProtocalCombine.Size = new System.Drawing.Size(66, 16);
			this.radioButton_ProtocalCombine.TabIndex = 0;
			this.radioButton_ProtocalCombine.Text = "Combine";
			this.radioButton_ProtocalCombine.UseVisualStyleBackColor = true;
			this.radioButton_ProtocalCombine.CheckedChanged += new System.EventHandler(this.radioButton_ProtocalCombine_CheckedChanged);
			// 
			// radioButton_ProtocalTransfer
			// 
			this.radioButton_ProtocalTransfer.AutoSize = true;
			this.radioButton_ProtocalTransfer.Location = new System.Drawing.Point(16, 21);
			this.radioButton_ProtocalTransfer.Name = "radioButton_ProtocalTransfer";
			this.radioButton_ProtocalTransfer.Size = new System.Drawing.Size(62, 16);
			this.radioButton_ProtocalTransfer.TabIndex = 0;
			this.radioButton_ProtocalTransfer.Text = "Transfer";
			this.radioButton_ProtocalTransfer.UseVisualStyleBackColor = true;
			this.radioButton_ProtocalTransfer.CheckedChanged += new System.EventHandler(this.radioButton_ProtocalTransfer_CheckedChanged);
			// 
			// ctlMain
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.groupBox_Protocol);
			this.Controls.Add(this.groupBox_CMD);
			this.Controls.Add(this.groupBox_Freq);
			this.Controls.Add(this.button_WR);
			this.Controls.Add(this.groupBox_SlaveAddress);
			this.Controls.Add(this.button_Probe);
			this.Controls.Add(this.comboBox_DevList);
			this.Controls.Add(this.button_Read);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.button_Write);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_RLength);
			this.Controls.Add(this.textBox_Result);
			this.Controls.Add(this.textBox_WLength);
			this.Controls.Add(this.textBox_Data);
			this.MaximumSize = new System.Drawing.Size(630, 400);
			this.Name = "ctlMain";
			this.Size = new System.Drawing.Size(630, 400);
			this.Load += new System.EventHandler(this.PageI2C_Load);
			this.groupBox_SlaveAddress.ResumeLayout(false);
			this.groupBox_SlaveAddress.PerformLayout();
			this.groupBox_CMD.ResumeLayout(false);
			this.groupBox_CMD.PerformLayout();
			this.groupBox_Freq.ResumeLayout(false);
			this.groupBox_Freq.PerformLayout();
			this.groupBox_Protocol.ResumeLayout(false);
			this.groupBox_Protocol.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Probe;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.TextBox textBox_CMD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.TextBox textBox_WLength;
        private System.Windows.Forms.TextBox textBox_RLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_SlaveAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_WR;
        private System.Windows.Forms.GroupBox groupBox_SlaveAddress;
        private System.Windows.Forms.RadioButton radioButton_Addr10bit;
        private System.Windows.Forms.RadioButton radioButton_Addr7bit;
        private System.Windows.Forms.GroupBox groupBox_CMD;
        private System.Windows.Forms.RadioButton radioButton_CMDWord;
        private System.Windows.Forms.RadioButton radioButton_CMDByte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_Freq400;
        private System.Windows.Forms.TextBox textBox_Freq;
        private System.Windows.Forms.RadioButton radioButton_Freq0to100;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_SetFreq;
        private System.Windows.Forms.Button button_GetFreq;
        private System.Windows.Forms.GroupBox groupBox_Freq;
        private System.Windows.Forms.GroupBox groupBox_Protocol;
        private System.Windows.Forms.RadioButton radioButton_ProtocalCombine;
        private System.Windows.Forms.RadioButton radioButton_ProtocalTransfer;
        private System.Windows.Forms.RadioButton radioButton_CMDNone;

    }
}
