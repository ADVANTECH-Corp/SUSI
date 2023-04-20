using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
		public ctlMain()
		{
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

            InitializeComponent();
        }

		public bool Available
		{
			get
			{
				UInt32 status, tmp;
				status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_DEVICE_AVAILABLE, out tmp);
				return tmp > 0 ? true : false;
			}
		}

        private void Main_Load(object sender, EventArgs e)
        {
            UInt32 Value;

            Lib.SusiDeviceGetValue(Lib.SAB2000_ID_DEVICE_AVAILABLE, out Value);
            if (Value > 0)
            {
                // Add Pages
                PageHWM pHWM = new PageHWM();
                tabPage_HWM.Controls.Add(pHWM);
                pHWM.Dock = DockStyle.Fill;

                PageInfo pInfo = new PageInfo();
                tabPage_Info.Controls.Add(pInfo);
                pInfo.Dock = DockStyle.Fill;

                PageAlert pAlert = new PageAlert();
                tabPage_Alert.Controls.Add(pAlert);
                pAlert.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("NOT FOUND Device.");
                //this.Close();
            }
        }
    }
}