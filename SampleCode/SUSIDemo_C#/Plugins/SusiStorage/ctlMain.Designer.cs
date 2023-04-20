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
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label_MaxLen = new System.Windows.Forms.Label();
			this.label_Status = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label_TotalSize = new System.Windows.Forms.Label();
			this.label_BlockSize = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_Access = new System.Windows.Forms.GroupBox();
			this.textBox_Result = new System.Windows.Forms.TextBox();
			this.textBox_Data = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button_Write = new System.Windows.Forms.Button();
			this.button_Read = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_WLen = new System.Windows.Forms.TextBox();
			this.textBox_RLen = new System.Windows.Forms.TextBox();
			this.textBox_Offset = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox_WriteProtection = new System.Windows.Forms.GroupBox();
			this.button_Unlock = new System.Windows.Forms.Button();
			this.button_GetStatus = new System.Windows.Forms.Button();
			this.button_Lock = new System.Windows.Forms.Button();
			this.textBox_Password = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox_Access.SuspendLayout();
			this.groupBox_WriteProtection.SuspendLayout();
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
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(20, 48);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(135, 12);
			this.label13.TabIndex = 1;
			this.label13.Text = "Password Maximun Length:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(20, 27);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(114, 12);
			this.label11.TabIndex = 1;
			this.label11.Text = "Write Protection Status:";
			// 
			// label_MaxLen
			// 
			this.label_MaxLen.AutoSize = true;
			this.label_MaxLen.Location = new System.Drawing.Point(180, 48);
			this.label_MaxLen.Name = "label_MaxLen";
			this.label_MaxLen.Size = new System.Drawing.Size(13, 12);
			this.label_MaxLen.TabIndex = 1;
			this.label_MaxLen.Text = "--";
			// 
			// label_Status
			// 
			this.label_Status.AutoSize = true;
			this.label_Status.Location = new System.Drawing.Point(170, 27);
			this.label_Status.Name = "label_Status";
			this.label_Status.Size = new System.Drawing.Size(13, 12);
			this.label_Status.TabIndex = 1;
			this.label_Status.Text = "--";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "Total size (Byte):";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 12);
			this.label6.TabIndex = 1;
			this.label6.Text = "Block size (Byte):";
			// 
			// label_TotalSize
			// 
			this.label_TotalSize.AutoSize = true;
			this.label_TotalSize.Location = new System.Drawing.Point(123, 28);
			this.label_TotalSize.Name = "label_TotalSize";
			this.label_TotalSize.Size = new System.Drawing.Size(11, 12);
			this.label_TotalSize.TabIndex = 1;
			this.label_TotalSize.Text = "0";
			// 
			// label_BlockSize
			// 
			this.label_BlockSize.AutoSize = true;
			this.label_BlockSize.Location = new System.Drawing.Point(123, 49);
			this.label_BlockSize.Name = "label_BlockSize";
			this.label_BlockSize.Size = new System.Drawing.Size(11, 12);
			this.label_BlockSize.TabIndex = 1;
			this.label_BlockSize.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(21, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "iManager Storage:";
			// 
			// groupBox_Access
			// 
			this.groupBox_Access.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_Access.Controls.Add(this.textBox_Result);
			this.groupBox_Access.Controls.Add(this.textBox_Data);
			this.groupBox_Access.Controls.Add(this.label8);
			this.groupBox_Access.Controls.Add(this.label4);
			this.groupBox_Access.Controls.Add(this.button_Write);
			this.groupBox_Access.Controls.Add(this.button_Read);
			this.groupBox_Access.Controls.Add(this.label7);
			this.groupBox_Access.Controls.Add(this.label6);
			this.groupBox_Access.Controls.Add(this.textBox_WLen);
			this.groupBox_Access.Controls.Add(this.label_TotalSize);
			this.groupBox_Access.Controls.Add(this.textBox_RLen);
			this.groupBox_Access.Controls.Add(this.label_BlockSize);
			this.groupBox_Access.Controls.Add(this.textBox_Offset);
			this.groupBox_Access.Controls.Add(this.label5);
			this.groupBox_Access.Controls.Add(this.label3);
			this.groupBox_Access.Controls.Add(this.label9);
			this.groupBox_Access.Controls.Add(this.label2);
			this.groupBox_Access.Location = new System.Drawing.Point(14, 48);
			this.groupBox_Access.MaximumSize = new System.Drawing.Size(600, 250);
			this.groupBox_Access.MinimumSize = new System.Drawing.Size(525, 0);
			this.groupBox_Access.Name = "groupBox_Access";
			this.groupBox_Access.Size = new System.Drawing.Size(600, 215);
			this.groupBox_Access.TabIndex = 8;
			this.groupBox_Access.TabStop = false;
			this.groupBox_Access.Text = "Access";
			// 
			// textBox_Result
			// 
			this.textBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Result.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_Result.Location = new System.Drawing.Point(115, 144);
			this.textBox_Result.Multiline = true;
			this.textBox_Result.Name = "textBox_Result";
			this.textBox_Result.ReadOnly = true;
			this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Result.Size = new System.Drawing.Size(385, 57);
			this.textBox_Result.TabIndex = 14;
			this.textBox_Result.Text = "00";
			// 
			// textBox_Data
			// 
			this.textBox_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Data.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBox_Data.Location = new System.Drawing.Point(115, 81);
			this.textBox_Data.Multiline = true;
			this.textBox_Data.Name = "textBox_Data";
			this.textBox_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Data.Size = new System.Drawing.Size(385, 57);
			this.textBox_Data.TabIndex = 15;
			this.textBox_Data.Text = "00";
			this.textBox_Data.TextChanged += new System.EventHandler(this.textBox_Data_TextChanged);
			this.textBox_Data.Leave += new System.EventHandler(this.textBox_Data_Leave);
			this.textBox_Data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Data_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(20, 147);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 12);
			this.label8.TabIndex = 12;
			this.label8.Text = "Result: (HEX)";
			// 
			// button_Write
			// 
			this.button_Write.Location = new System.Drawing.Point(510, 81);
			this.button_Write.Name = "button_Write";
			this.button_Write.Size = new System.Drawing.Size(75, 23);
			this.button_Write.TabIndex = 3;
			this.button_Write.Text = "Write";
			this.button_Write.UseVisualStyleBackColor = true;
			this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
			// 
			// button_Read
			// 
			this.button_Read.Location = new System.Drawing.Point(510, 144);
			this.button_Read.Name = "button_Read";
			this.button_Read.Size = new System.Drawing.Size(75, 23);
			this.button_Read.TabIndex = 3;
			this.button_Read.Text = "Read";
			this.button_Read.UseVisualStyleBackColor = true;
			this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 12);
			this.label7.TabIndex = 13;
			this.label7.Text = "Data: (HEX)";
			// 
			// textBox_WLen
			// 
			this.textBox_WLen.Location = new System.Drawing.Point(437, 53);
			this.textBox_WLen.MaxLength = 4;
			this.textBox_WLen.Name = "textBox_WLen";
			this.textBox_WLen.ReadOnly = true;
			this.textBox_WLen.Size = new System.Drawing.Size(63, 22);
			this.textBox_WLen.TabIndex = 2;
			this.textBox_WLen.Text = "1";
			// 
			// textBox_RLen
			// 
			this.textBox_RLen.Location = new System.Drawing.Point(437, 25);
			this.textBox_RLen.MaxLength = 4;
			this.textBox_RLen.Name = "textBox_RLen";
			this.textBox_RLen.Size = new System.Drawing.Size(63, 22);
			this.textBox_RLen.TabIndex = 2;
			this.textBox_RLen.Text = "1";
			this.textBox_RLen.Leave += new System.EventHandler(this.textBox_RLen_Leave);
			this.textBox_RLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_RLen_KeyPress);
			// 
			// textBox_Offset
			// 
			this.textBox_Offset.Location = new System.Drawing.Point(233, 25);
			this.textBox_Offset.MaxLength = 2;
			this.textBox_Offset.Name = "textBox_Offset";
			this.textBox_Offset.Size = new System.Drawing.Size(40, 22);
			this.textBox_Offset.TabIndex = 2;
			this.textBox_Offset.Text = "00";
			this.textBox_Offset.Leave += new System.EventHandler(this.textBox_Offset_Leave);
			this.textBox_Offset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Offset_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(352, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 12);
			this.label5.TabIndex = 1;
			this.label5.Text = "Write Length:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(352, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 12);
			this.label3.TabIndex = 1;
			this.label3.Text = "Read Length:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(279, 28);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 12);
			this.label9.TabIndex = 1;
			this.label9.Text = "(HEX)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(182, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "Offset:";
			// 
			// groupBox_WriteProtection
			// 
			this.groupBox_WriteProtection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_WriteProtection.Controls.Add(this.label13);
			this.groupBox_WriteProtection.Controls.Add(this.label11);
			this.groupBox_WriteProtection.Controls.Add(this.button_Unlock);
			this.groupBox_WriteProtection.Controls.Add(this.button_GetStatus);
			this.groupBox_WriteProtection.Controls.Add(this.button_Lock);
			this.groupBox_WriteProtection.Controls.Add(this.label_MaxLen);
			this.groupBox_WriteProtection.Controls.Add(this.textBox_Password);
			this.groupBox_WriteProtection.Controls.Add(this.label15);
			this.groupBox_WriteProtection.Controls.Add(this.label_Status);
			this.groupBox_WriteProtection.Location = new System.Drawing.Point(14, 269);
			this.groupBox_WriteProtection.MaximumSize = new System.Drawing.Size(600, 250);
			this.groupBox_WriteProtection.MinimumSize = new System.Drawing.Size(525, 0);
			this.groupBox_WriteProtection.Name = "groupBox_WriteProtection";
			this.groupBox_WriteProtection.Size = new System.Drawing.Size(600, 118);
			this.groupBox_WriteProtection.TabIndex = 8;
			this.groupBox_WriteProtection.TabStop = false;
			this.groupBox_WriteProtection.Text = "Write Protection";
			// 
			// button_Unlock
			// 
			this.button_Unlock.Location = new System.Drawing.Point(510, 82);
			this.button_Unlock.Name = "button_Unlock";
			this.button_Unlock.Size = new System.Drawing.Size(75, 23);
			this.button_Unlock.TabIndex = 3;
			this.button_Unlock.Text = "Unlock";
			this.button_Unlock.UseVisualStyleBackColor = true;
			this.button_Unlock.Click += new System.EventHandler(this.button_Unlock_Click);
			// 
			// button_GetStatus
			// 
			this.button_GetStatus.Location = new System.Drawing.Point(510, 22);
			this.button_GetStatus.Name = "button_GetStatus";
			this.button_GetStatus.Size = new System.Drawing.Size(75, 23);
			this.button_GetStatus.TabIndex = 3;
			this.button_GetStatus.Text = "Get Status";
			this.button_GetStatus.UseVisualStyleBackColor = true;
			this.button_GetStatus.Click += new System.EventHandler(this.button_GetStatus_Click);
			// 
			// button_Lock
			// 
			this.button_Lock.Location = new System.Drawing.Point(429, 82);
			this.button_Lock.Name = "button_Lock";
			this.button_Lock.Size = new System.Drawing.Size(75, 23);
			this.button_Lock.TabIndex = 3;
			this.button_Lock.Text = "Lock";
			this.button_Lock.UseVisualStyleBackColor = true;
			this.button_Lock.Click += new System.EventHandler(this.button_Lock_Click);
			// 
			// textBox_Password
			// 
			this.textBox_Password.Location = new System.Drawing.Point(22, 84);
			this.textBox_Password.MaxLength = 8;
			this.textBox_Password.Name = "textBox_Password";
			this.textBox_Password.Size = new System.Drawing.Size(218, 22);
			this.textBox_Password.TabIndex = 2;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(20, 69);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(51, 12);
			this.label15.TabIndex = 1;
			this.label15.Text = "Password:";
			// 
			// ctlMain
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.comboBox_DevList);
			this.Controls.Add(this.groupBox_WriteProtection);
			this.Controls.Add(this.groupBox_Access);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(630, 400);
			this.Name = "ctlMain";
			this.Size = new System.Drawing.Size(630, 400);
			this.groupBox_Access.ResumeLayout(false);
			this.groupBox_Access.PerformLayout();
			this.groupBox_WriteProtection.ResumeLayout(false);
			this.groupBox_WriteProtection.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_TotalSize;
        private System.Windows.Forms.Label label_BlockSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_Access;
        private System.Windows.Forms.TextBox textBox_Offset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_RLen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_WLen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox_WriteProtection;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_Unlock;
        private System.Windows.Forms.Button button_Lock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_MaxLen;
        private System.Windows.Forms.Button button_GetStatus;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.Button button_Read;
    }
}
