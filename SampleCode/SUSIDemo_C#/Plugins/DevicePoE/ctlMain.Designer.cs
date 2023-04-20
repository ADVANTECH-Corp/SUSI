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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.flpPoePorts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // flpPoePorts
            // 
            this.flpPoePorts.AutoScroll = true;
            this.flpPoePorts.AutoSize = true;
            this.flpPoePorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPoePorts.Location = new System.Drawing.Point(0, 0);
            this.flpPoePorts.Name = "flpPoePorts";
            this.flpPoePorts.Size = new System.Drawing.Size(630, 400);
            this.flpPoePorts.TabIndex = 0;
            // 
            // ctlMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flpPoePorts);
            this.MinimumSize = new System.Drawing.Size(630, 400);
            this.Name = "ctlMain";
            this.Size = new System.Drawing.Size(630, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion
   
	    private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FlowLayoutPanel flpPoePorts;
    }
}

