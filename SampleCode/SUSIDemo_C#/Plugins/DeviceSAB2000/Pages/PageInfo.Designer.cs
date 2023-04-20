namespace Susi4.Plugin
{
    partial class PageInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_FWVer = new System.Windows.Forms.Label();
            this.label_KernelVer = new System.Windows.Forms.Label();
            this.label_ChipType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firmware Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kernel Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chip Type:";
            // 
            // label_FWVer
            // 
            this.label_FWVer.AutoSize = true;
            this.label_FWVer.Location = new System.Drawing.Point(116, 16);
            this.label_FWVer.Name = "label_FWVer";
            this.label_FWVer.Size = new System.Drawing.Size(13, 12);
            this.label_FWVer.TabIndex = 0;
            this.label_FWVer.Text = "--";
            // 
            // label_KernelVer
            // 
            this.label_KernelVer.AutoSize = true;
            this.label_KernelVer.Location = new System.Drawing.Point(116, 37);
            this.label_KernelVer.Name = "label_KernelVer";
            this.label_KernelVer.Size = new System.Drawing.Size(13, 12);
            this.label_KernelVer.TabIndex = 0;
            this.label_KernelVer.Text = "--";
            // 
            // label_ChipType
            // 
            this.label_ChipType.AutoSize = true;
            this.label_ChipType.Location = new System.Drawing.Point(116, 58);
            this.label_ChipType.Name = "label_ChipType";
            this.label_ChipType.Size = new System.Drawing.Size(13, 12);
            this.label_ChipType.TabIndex = 0;
            this.label_ChipType.Text = "--";
            // 
            // PageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_ChipType);
            this.Controls.Add(this.label_KernelVer);
            this.Controls.Add(this.label_FWVer);
            this.Controls.Add(this.label1);
            this.Name = "PageInfo";
            this.Size = new System.Drawing.Size(572, 409);
            this.Load += new System.EventHandler(this.PageInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_FWVer;
        private System.Windows.Forms.Label label_KernelVer;
        private System.Windows.Forms.Label label_ChipType;
    }
}
