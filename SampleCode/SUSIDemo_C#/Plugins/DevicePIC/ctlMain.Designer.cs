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
        this.tabPage_Status = new System.Windows.Forms.TabPage();
        this.tabPage_Setup = new System.Windows.Forms.TabPage();
        this.tabPage_Realtime_status = new System.Windows.Forms.TabPage();
        this.tabControl.SuspendLayout();
        this.SuspendLayout();
        // 
        // tabControl
        // 
        this.tabControl.Controls.Add(this.tabPage_Status);
        this.tabControl.Controls.Add(this.tabPage_Setup);
        this.tabControl.Controls.Add(this.tabPage_Realtime_status);
        this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl.Font = new System.Drawing.Font("Arial", 9F);
        this.tabControl.Location = new System.Drawing.Point(0, 0);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new System.Drawing.Size(630, 400);
        this.tabControl.TabIndex = 1;
        // 
        // tabPage_Status
        // 
        this.tabPage_Status.Location = new System.Drawing.Point(4, 24);
        this.tabPage_Status.Name = "tabPage_Status";
        this.tabPage_Status.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_Status.Size = new System.Drawing.Size(622, 372);
        this.tabPage_Status.TabIndex = 0;
        this.tabPage_Status.Text = "Property";
        this.tabPage_Status.UseVisualStyleBackColor = true;
        // 
        // tabPage_Setup
        // 
        this.tabPage_Setup.Location = new System.Drawing.Point(4, 24);
        this.tabPage_Setup.Name = "tabPage_Setup";
        this.tabPage_Setup.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_Setup.Size = new System.Drawing.Size(622, 372);
        this.tabPage_Setup.TabIndex = 1;
        this.tabPage_Setup.Text = "Settings";
        this.tabPage_Setup.UseVisualStyleBackColor = true;
        // 
        // tabPage_Realtime_status
        // 
        this.tabPage_Realtime_status.Location = new System.Drawing.Point(4, 24);
        this.tabPage_Realtime_status.Name = "tabPage_Realtime_status";
        this.tabPage_Realtime_status.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_Realtime_status.Size = new System.Drawing.Size(622, 372);
        this.tabPage_Realtime_status.TabIndex = 2;
        this.tabPage_Realtime_status.Text = "Real-time status";
        this.tabPage_Realtime_status.UseVisualStyleBackColor = true;
        // 
        // ctlMain
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        this.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.tabControl);
        this.Font = new System.Drawing.Font("Arial", 9F);
        this.MinimumSize = new System.Drawing.Size(630, 400);
        this.Name = "ctlMain";
        this.Size = new System.Drawing.Size(630, 400);
        this.Load += new System.EventHandler(this.Main_Load);
        this.tabControl.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPage_Status;
    private System.Windows.Forms.TabPage tabPage_Setup;
    private System.Windows.Forms.TabPage tabPage_Realtime_status;


  }
}

