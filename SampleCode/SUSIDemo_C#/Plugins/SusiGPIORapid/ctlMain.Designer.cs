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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gpioGridView = new System.Windows.Forms.DataGridView();
            this.gpioName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpioDir = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpioValue = new System.Windows.Forms.DataGridViewImageColumn();
            this.timer_statusupdating = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gpioGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gpioGridView
            // 
            this.gpioGridView.AllowUserToAddRows = false;
            this.gpioGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gpioGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gpioGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gpioGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gpioGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gpioGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gpioGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gpioGridView.ColumnHeadersHeight = 26;
            this.gpioGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gpioName,
            this.gpioDir,
            this.gpioValue});
            this.gpioGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gpioGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.gpioGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpioGridView.Location = new System.Drawing.Point(0, 0);
            this.gpioGridView.Name = "gpioGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gpioGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gpioGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpioGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gpioGridView.RowTemplate.Height = 52;
            this.gpioGridView.Size = new System.Drawing.Size(615, 400);
            this.gpioGridView.TabIndex = 0;
            this.gpioGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gpioGridView_CellClick);
            // 
            // gpioName
            // 
            this.gpioName.HeaderText = "Name";
            this.gpioName.Name = "gpioName";
            this.gpioName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gpioName.Width = 190;
            // 
            // gpioDir
            // 
            this.gpioDir.HeaderText = "Direction";
            this.gpioDir.Image = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;
            this.gpioDir.Name = "gpioDir";
            this.gpioDir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gpioDir.Width = 200;
            // 
            // gpioValue
            // 
            this.gpioValue.HeaderText = "Status";
            this.gpioValue.Image = global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48;
            this.gpioValue.Name = "gpioValue";
            this.gpioValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gpioValue.Width = 225;
            // 
            // timer_statusupdating
            // 
            this.timer_statusupdating.Interval = 1000;
            this.timer_statusupdating.Tick += new System.EventHandler(this.timer_statusupdating_Tick);
            // 
            // ctlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gpioGridView);
            //this.MinimumSize = new System.Drawing.Size(615, 400);
            this.Name = "ctlMain";
            this.Size = new System.Drawing.Size(615, 400);
            this.Load += new System.EventHandler(this.PageGPIORapid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpioGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridView gpioGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpioName0, gpioName1, gpioName2, gpioName3;
        private System.Windows.Forms.DataGridViewImageColumn gpioDir0, gpioDir1, gpioDir2, gpioDir3;
        private System.Windows.Forms.DataGridViewImageColumn gpioValue0, gpioValue1, gpioValue2, gpioValue3;
        private System.Windows.Forms.Timer timer_statusupdating;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpioName;
        private System.Windows.Forms.DataGridViewImageColumn gpioDir;
        private System.Windows.Forms.DataGridViewImageColumn gpioValue;
    }
}
