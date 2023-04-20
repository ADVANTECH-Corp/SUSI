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
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Protocal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SlaveAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_CMD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
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
            this.comboBox_DevList.TabIndex = 8;
            this.comboBox_DevList.SelectedIndexChanged += new System.EventHandler(this.comboBox_SMBList_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(21, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "SMBus Host:";
            // 
            // comboBox_Protocal
            // 
            this.comboBox_Protocal.FormattingEnabled = true;
            this.comboBox_Protocal.Items.AddRange(new object[] {
            "Quick",
            "Byte",
            "Byte Data",
            "Word Data",
            "Block",
            "I2C Block"});
            this.comboBox_Protocal.Location = new System.Drawing.Point(104, 25);
            this.comboBox_Protocal.Name = "comboBox_Protocal";
            this.comboBox_Protocal.Size = new System.Drawing.Size(116, 20);
            this.comboBox_Protocal.TabIndex = 10;
            this.comboBox_Protocal.SelectedIndexChanged += new System.EventHandler(this.comboBox_Protocal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Protocal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Slave Address:";
            // 
            // textBox_SlaveAddr
            // 
            this.textBox_SlaveAddr.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_SlaveAddr.Location = new System.Drawing.Point(104, 51);
            this.textBox_SlaveAddr.MaxLength = 2;
            this.textBox_SlaveAddr.Name = "textBox_SlaveAddr";
            this.textBox_SlaveAddr.Size = new System.Drawing.Size(57, 22);
            this.textBox_SlaveAddr.TabIndex = 11;
            this.textBox_SlaveAddr.Text = "00";
            this.textBox_SlaveAddr.Leave += new System.EventHandler(this.textBox_Hex_Leave);
            this.textBox_SlaveAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Hex_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Command:";
            // 
            // textBox_CMD
            // 
            this.textBox_CMD.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_CMD.Location = new System.Drawing.Point(104, 79);
            this.textBox_CMD.MaxLength = 2;
            this.textBox_CMD.Name = "textBox_CMD";
            this.textBox_CMD.Size = new System.Drawing.Size(57, 22);
            this.textBox_CMD.TabIndex = 11;
            this.textBox_CMD.Text = "00";
            this.textBox_CMD.Leave += new System.EventHandler(this.textBox_Hex_Leave);
            this.textBox_CMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Hex_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "(HEX)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "(HEX)";
            // 
            // button_Probe
            // 
            this.button_Probe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Probe.Location = new System.Drawing.Point(346, 269);
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
            this.button_Read.Location = new System.Drawing.Point(427, 269);
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
            this.button_Write.Location = new System.Drawing.Point(510, 269);
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
            this.label9.Location = new System.Drawing.Point(254, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "Write Length:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Read Length:";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Result.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Result.Location = new System.Drawing.Point(17, 206);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ReadOnly = true;
            this.textBox_Result.Size = new System.Drawing.Size(568, 57);
            this.textBox_Result.TabIndex = 11;
            this.textBox_Result.Text = "00";
            // 
            // textBox_Data
            // 
            this.textBox_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Data.Font = new System.Drawing.Font("MingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Data.Location = new System.Drawing.Point(17, 131);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(568, 57);
            this.textBox_Data.TabIndex = 11;
            this.textBox_Data.Text = "00";
            this.textBox_Data.TextChanged += new System.EventHandler(this.textBox_Data_TextChanged);
            this.textBox_Data.Leave += new System.EventHandler(this.textBox_Data_Leave);
            this.textBox_Data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Data_KeyPress);
            // 
            // textBox_WLength
            // 
            this.textBox_WLength.Location = new System.Drawing.Point(338, 79);
            this.textBox_WLength.MaxLength = 2;
            this.textBox_WLength.Name = "textBox_WLength";
            this.textBox_WLength.ReadOnly = true;
            this.textBox_WLength.Size = new System.Drawing.Size(57, 22);
            this.textBox_WLength.TabIndex = 11;
            this.textBox_WLength.Text = "1";
            this.textBox_WLength.Leave += new System.EventHandler(this.textBox_RLength_Leave);
            this.textBox_WLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_RLength_KeyPress);
            // 
            // textBox_RLength
            // 
            this.textBox_RLength.Location = new System.Drawing.Point(338, 51);
            this.textBox_RLength.MaxLength = 2;
            this.textBox_RLength.Name = "textBox_RLength";
            this.textBox_RLength.Size = new System.Drawing.Size(57, 22);
            this.textBox_RLength.TabIndex = 11;
            this.textBox_RLength.Text = "0";
            this.textBox_RLength.Leave += new System.EventHandler(this.textBox_RLength_Leave);
            this.textBox_RLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_RLength_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Result: (HEX)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Input Data: (HEX)";
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Control.Controls.Add(this.button_Probe);
            this.groupBox_Control.Controls.Add(this.button_Read);
            this.groupBox_Control.Controls.Add(this.button_Write);
            this.groupBox_Control.Controls.Add(this.label1);
            this.groupBox_Control.Controls.Add(this.textBox_CMD);
            this.groupBox_Control.Controls.Add(this.label9);
            this.groupBox_Control.Controls.Add(this.label7);
            this.groupBox_Control.Controls.Add(this.textBox_Result);
            this.groupBox_Control.Controls.Add(this.textBox_Data);
            this.groupBox_Control.Controls.Add(this.textBox_WLength);
            this.groupBox_Control.Controls.Add(this.textBox_RLength);
            this.groupBox_Control.Controls.Add(this.label2);
            this.groupBox_Control.Controls.Add(this.textBox_SlaveAddr);
            this.groupBox_Control.Controls.Add(this.label8);
            this.groupBox_Control.Controls.Add(this.label6);
            this.groupBox_Control.Controls.Add(this.label3);
            this.groupBox_Control.Controls.Add(this.comboBox_Protocal);
            this.groupBox_Control.Controls.Add(this.label4);
            this.groupBox_Control.Controls.Add(this.label5);
            this.groupBox_Control.Location = new System.Drawing.Point(14, 48);
            this.groupBox_Control.MaximumSize = new System.Drawing.Size(600, 360);
            this.groupBox_Control.MinimumSize = new System.Drawing.Size(430, 0);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Size = new System.Drawing.Size(600, 302);
            this.groupBox_Control.TabIndex = 12;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // PageSMB
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox_Control);
            this.Controls.Add(this.comboBox_DevList);
            this.Controls.Add(this.label10);
            this.Name = "PageSMB";
            this.Size = new System.Drawing.Size(630, 400);
            this.Load += new System.EventHandler(this.PageSMB_Load);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_DevList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_Protocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_SlaveAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_CMD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_RLength;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Probe;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_WLength;
        private System.Windows.Forms.GroupBox groupBox_Control;
    }
}
