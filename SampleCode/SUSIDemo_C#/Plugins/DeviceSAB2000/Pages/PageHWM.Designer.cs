namespace Susi4.Plugin
{
    partial class PageHWM
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader_Item = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Value = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Unit = new System.Windows.Forms.ColumnHeader();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
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
            this.columnHeader_Unit});
            this.listView.Location = new System.Drawing.Point(0, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(641, 403);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Item
            // 
            this.columnHeader_Item.Text = "Item Name";
            this.columnHeader_Item.Width = 208;
            // 
            // columnHeader_Value
            // 
            this.columnHeader_Value.Text = "Value";
            this.columnHeader_Value.Width = 192;
            // 
            // columnHeader_Unit
            // 
            this.columnHeader_Unit.Text = "Unit";
            this.columnHeader_Unit.Width = 99;
            // 
            // timer_refresh
            // 
            this.timer_refresh.Interval = 1000;
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // PageHWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "PageHWM";
            this.Size = new System.Drawing.Size(641, 418);
            this.Load += new System.EventHandler(this.PageInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader_Item;
        private System.Windows.Forms.ColumnHeader columnHeader_Value;
        private System.Windows.Forms.ColumnHeader columnHeader_Unit;
        private System.Windows.Forms.Timer timer_refresh;
    }
}
