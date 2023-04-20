using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
	public partial class ctlMain : UserControl
	{
        private bool _available =  false;

		public ctlMain()
		{
            UInt32 status, tmp;
			try
			{
				UInt32 Status = SusiLib.SusiLibInitialize();
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS && Status != SusiStatus.SUSI_STATUS_INITIALIZED)
                    return;
			}
			catch
			{
				return;
			}
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_INFO_AVAILABLE, out tmp);
            _available = tmp > 0 ? true : false;
			InitializeComponent();
		}

		public bool Available
		{
			get
			{
                return _available;
			}
		}

		private void Main_Load(object sender, EventArgs e)
		{
            UInt32 Value;

            //MessageBox.Show("Main_Load");
            Lib.SusiDeviceGetValue(Lib.PIC_ID_BOARD_ID, out Value);
            if (Value > 0)
            {
                // Add Pages
                PageStatus pStatus = new PageStatus();
                tabPage_Status.Controls.Add(pStatus);
                pStatus.Dock = DockStyle.Fill;
                PageSetup pSetup = new PageSetup();
                tabPage_Setup.Controls.Add(pSetup);
                pSetup.Dock = DockStyle.Fill;
                PageRealTimeStatus pRealtimestatus = new PageRealTimeStatus();
                tabPage_Realtime_status.Controls.Add(pRealtimestatus);
                pRealtimestatus.Dock = DockStyle.Fill;

            }
            else
            {
                MessageBox.Show("NOT FOUND Device.");
                //this.Close();
            }
			
		}
	}
}
