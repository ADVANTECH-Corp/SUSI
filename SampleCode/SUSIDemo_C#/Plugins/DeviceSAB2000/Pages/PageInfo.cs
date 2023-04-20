using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;


namespace Susi4.Plugin
{
    public partial class PageInfo : UserControl
    {
        public PageInfo()
        {
            InitializeComponent();
        }

        private void PageInfo_Load(object sender, EventArgs e)
        {
            InitializeInfo();
        }

        private void InitializeInfo()
        {
            UInt32 Status;
            UInt32 Value;

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_FW_VER, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_FWVer.Text = String.Format("{0}{1}.{2}", (char)(Value >> 16), (byte)(Value >> 8), (byte)Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_EC_TYPE, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_ChipType.Text = String.Format("{0}{1:X2}.{2}", (char)(Value >> 16), (byte)(Value >> 8), (byte)Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_KERNEL_VER, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_KernelVer.Text = String.Format("{0}{1}.{2}", (char)(Value >> 16), (byte)(Value >> 8), (byte)Value);
            }
        }
    }
}
