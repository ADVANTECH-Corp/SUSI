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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_HWM = new System.Windows.Forms.TabPage();
            this.tabPage_Alert = new System.Windows.Forms.TabPage();
            this.tabPage_Info = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_HWM);
            this.tabControl.Controls.Add(this.tabPage_Alert);
            this.tabControl.Controls.Add(this.tabPage_Info);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(544, 425);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_HWM
            // 
            this.tabPage_HWM.Location = new System.Drawing.Point(4, 21);
            this.tabPage_HWM.Name = "tabPage_HWM";
            this.tabPage_HWM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_HWM.Size = new System.Drawing.Size(536, 400);
            this.tabPage_HWM.TabIndex = 0;
            this.tabPage_HWM.Text = "HWM";
            this.tabPage_HWM.UseVisualStyleBackColor = true;
            // 
            // tabPage_Alert
            // 
            this.tabPage_Alert.Location = new System.Drawing.Point(4, 21);
            this.tabPage_Alert.Name = "tabPage_Alert";
            this.tabPage_Alert.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Alert.Size = new System.Drawing.Size(762, 392);
            this.tabPage_Alert.TabIndex = 1;
            this.tabPage_Alert.Text = "Alert";
            this.tabPage_Alert.UseVisualStyleBackColor = true;
            // 
            // tabPage_Info
            // 
            this.tabPage_Info.Location = new System.Drawing.Point(4, 21);
            this.tabPage_Info.Name = "tabPage_Info";
            this.tabPage_Info.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Info.Size = new System.Drawing.Size(762, 392);
            this.tabPage_Info.TabIndex = 2;
            this.tabPage_Info.Text = "Information";
            this.tabPage_Info.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 425);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.Text = "Susi Device";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_HWM;
        private System.Windows.Forms.TabPage tabPage_Alert;
        private System.Windows.Forms.TabPage tabPage_Info;
    }
}

