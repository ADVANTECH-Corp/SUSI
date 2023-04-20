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
            this.listView = new DoubleBufferListView();
            this.columnHeader_Item = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Value = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_MinValue = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_MaxValue = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Unit = new System.Windows.Forms.ColumnHeader();
            this.timer_monitoring = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Item,
            this.columnHeader_Value,
            this.columnHeader_MinValue,
            this.columnHeader_MaxValue,
            this.columnHeader_Unit});
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(624, 383);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // columnHeader_Item
            // 
            this.columnHeader_Item.Text = "Item Name";
            this.columnHeader_Item.Width = 140;
            // 
            // columnHeader_Value
            // 
            this.columnHeader_Value.Text = "Value";
            this.columnHeader_Value.Width = 90;
            // 
            // columnHeader_MinValue
            // 
            this.columnHeader_MinValue.Text = "Minimum Value";
            this.columnHeader_MinValue.Width = 124;
            // 
            // columnHeader_MaxValue
            // 
            this.columnHeader_MaxValue.Text = "Maximum Value";
            this.columnHeader_MaxValue.Width = 115;
            // 
            // columnHeader_Unit
            // 
            this.columnHeader_Unit.Text = "Unit";
            this.columnHeader_Unit.Width = 57;
            // 
            // timer_monitoring
            // 
            this.timer_monitoring.Interval = 1000;
            this.timer_monitoring.Tick += new System.EventHandler(this.timer_monitoring_Tick);
            // 
            // PageHWM
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listView);
            this.Name = "PageHWM";
            this.Size = new System.Drawing.Size(630, 400);
            this.Load += new System.EventHandler(this.PageHWM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader_Item;
        private System.Windows.Forms.ColumnHeader columnHeader_Value;
        private System.Windows.Forms.ColumnHeader columnHeader_Unit;
        private System.Windows.Forms.ColumnHeader columnHeader_MaxValue;
        private System.Windows.Forms.ColumnHeader columnHeader_MinValue;
        private System.Windows.Forms.Timer timer_monitoring;
    }
}
