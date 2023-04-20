namespace Susi4.Plugin
{
    partial class PoEPort
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
            this.groupBox_PoE1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Enable1 = new System.Windows.Forms.CheckBox();
            this.label_classValue1 = new System.Windows.Forms.Label();
            this.label_detectValue1 = new System.Windows.Forms.Label();
            this.label_currentValue1 = new System.Windows.Forms.Label();
            this.label_voltageValue1 = new System.Windows.Forms.Label();
            this.label_current1 = new System.Windows.Forms.Label();
            this.label_voltage1 = new System.Windows.Forms.Label();
            this.label_status1 = new System.Windows.Forms.Label();
            this.groupBox_PoE1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_PoE1
            // 
            this.groupBox_PoE1.AutoSize = true;
            this.groupBox_PoE1.Controls.Add(this.checkBox_Enable1);
            this.groupBox_PoE1.Controls.Add(this.label_classValue1);
            this.groupBox_PoE1.Controls.Add(this.label_detectValue1);
            this.groupBox_PoE1.Controls.Add(this.label_currentValue1);
            this.groupBox_PoE1.Controls.Add(this.label_voltageValue1);
            this.groupBox_PoE1.Controls.Add(this.label_current1);
            this.groupBox_PoE1.Controls.Add(this.label_voltage1);
            this.groupBox_PoE1.Controls.Add(this.label_status1);
            this.groupBox_PoE1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_PoE1.Location = new System.Drawing.Point(0, 0);
            this.groupBox_PoE1.Name = "groupBox_PoE1";
            this.groupBox_PoE1.Size = new System.Drawing.Size(150, 141);
            this.groupBox_PoE1.TabIndex = 1;
            this.groupBox_PoE1.TabStop = false;
            this.groupBox_PoE1.Text = "PoE";
            // 
            // checkBox_Enable1
            // 
            this.checkBox_Enable1.Location = new System.Drawing.Point(7, 13);
            this.checkBox_Enable1.Name = "checkBox_Enable1";
            this.checkBox_Enable1.Size = new System.Drawing.Size(56, 16);
            this.checkBox_Enable1.TabIndex = 13;
            this.checkBox_Enable1.Text = "Enable";
            this.checkBox_Enable1.UseVisualStyleBackColor = true;
            this.checkBox_Enable1.CheckedChanged += new System.EventHandler(this.checkBox_Enable1_CheckedChanged);
            // 
            // label_classValue1
            // 
            this.label_classValue1.AutoSize = true;
            this.label_classValue1.Location = new System.Drawing.Point(7, 35);
            this.label_classValue1.Name = "label_classValue1";
            this.label_classValue1.Size = new System.Drawing.Size(8, 12);
            this.label_classValue1.TabIndex = 11;
            this.label_classValue1.Text = ".";
            // 
            // label_detectValue1
            // 
            this.label_detectValue1.AutoSize = true;
            this.label_detectValue1.Location = new System.Drawing.Point(50, 56);
            this.label_detectValue1.Name = "label_detectValue1";
            this.label_detectValue1.Size = new System.Drawing.Size(8, 12);
            this.label_detectValue1.TabIndex = 10;
            this.label_detectValue1.Text = ".";
            // 
            // label_currentValue1
            // 
            this.label_currentValue1.AutoSize = true;
            this.label_currentValue1.Location = new System.Drawing.Point(50, 98);
            this.label_currentValue1.Name = "label_currentValue1";
            this.label_currentValue1.Size = new System.Drawing.Size(8, 12);
            this.label_currentValue1.TabIndex = 8;
            this.label_currentValue1.Text = ".";
            // 
            // label_voltageValue1
            // 
            this.label_voltageValue1.AutoSize = true;
            this.label_voltageValue1.Location = new System.Drawing.Point(50, 77);
            this.label_voltageValue1.Name = "label_voltageValue1";
            this.label_voltageValue1.Size = new System.Drawing.Size(8, 12);
            this.label_voltageValue1.TabIndex = 5;
            this.label_voltageValue1.Text = ".";
            // 
            // label_current1
            // 
            this.label_current1.AutoSize = true;
            this.label_current1.Location = new System.Drawing.Point(7, 98);
            this.label_current1.Name = "label_current1";
            this.label_current1.Size = new System.Drawing.Size(47, 12);
            this.label_current1.TabIndex = 5;
            this.label_current1.Text = "Current :";
            // 
            // label_voltage1
            // 
            this.label_voltage1.AutoSize = true;
            this.label_voltage1.Location = new System.Drawing.Point(7, 77);
            this.label_voltage1.Name = "label_voltage1";
            this.label_voltage1.Size = new System.Drawing.Size(47, 12);
            this.label_voltage1.TabIndex = 7;
            this.label_voltage1.Text = "Voltage :";
            // 
            // label_status1
            // 
            this.label_status1.AutoSize = true;
            this.label_status1.Location = new System.Drawing.Point(7, 56);
            this.label_status1.Name = "label_status1";
            this.label_status1.Size = new System.Drawing.Size(38, 12);
            this.label_status1.TabIndex = 5;
            this.label_status1.Text = "Status :";
            // 
            // PoEPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_PoE1);
            this.Name = "PoEPort";
            this.Size = new System.Drawing.Size(150, 141);
            this.groupBox_PoE1.ResumeLayout(false);
            this.groupBox_PoE1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_PoE1;
        private System.Windows.Forms.CheckBox checkBox_Enable1;
        private System.Windows.Forms.Label label_classValue1;
        private System.Windows.Forms.Label label_detectValue1;
        private System.Windows.Forms.Label label_currentValue1;
        private System.Windows.Forms.Label label_voltageValue1;
        private System.Windows.Forms.Label label_current1;
        private System.Windows.Forms.Label label_voltage1;
        private System.Windows.Forms.Label label_status1;
    }
}
