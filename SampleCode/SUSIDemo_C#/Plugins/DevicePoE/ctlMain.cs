using System;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        const UInt32 PortNumberMAX = 8;
        private bool _available = false;

        public ctlMain()
        {
            UInt32 status, tmp;

            try
            {
                status = SusiLib.SusiLibInitialize();

                if (status != SusiStatus.SUSI_STATUS_SUCCESS &&
                    status != SusiStatus.SUSI_STATUS_INITIALIZED)
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            status = Lib.SusiDeviceGetValue(Lib.POE_ID_INFO_AVAILABLE, out tmp);
            _available = tmp > 0 ? true : false;

            InitializeComponent();

            timer.Stop();
            for (UInt32 i = 0; i < PortNumberMAX; i++)
            {
                status = Lib.SusiDeviceGetValue(Lib.POE_ID_CAP_BASE + i, out tmp);
                if (tmp > 0 && status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    flpPoePorts.Controls.Add(new PoEPort(i));
                }
                else
                {
                    break;
                }
            }
            timer.Start();
        }

        public bool Available
        {
            get
            {
                return _available;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (PoEPort port in flpPoePorts.Controls)
            {
                port.update();
            }
        }
    }
}
