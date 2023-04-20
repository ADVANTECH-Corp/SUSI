using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PageHWM : UserControl
    {
        class ItemContent
        {
            public UInt32 ID;
            public UInt32 Value;
            public ListViewItem LVI;
        }

        const UInt32 KELVINS_OFFSET = 2731;

        string[] tempStr = new string[] {
            "CPU1",                 // 0
            "CPU2",                 // 1
            "M/B",                  // 2
            "Board Temperature 1",  // 3
            "Board Temperature 2",  // 4
            "Board Temperature 3",  // 5
            "Board Temperature 4",  // 6
        };

        string[] fanStr = new string[] {
            "FAN0",                 // 0
            "FAN1",                 // 1
            "FAN2",                 // 2
            "OnBoard FAN1",         // 3
            "OnBoard FAN2",         // 4
            "OnBoard FAN3",         // 5
            "OnBoard FAN4",         // 6
            "OnBoard FAN5",         // 7
            "OnBoard FAN6",         // 8
            "OnBoard FAN7",         // 9
        };

        List<ItemContent> tempList = new List<ItemContent>();
        List<ItemContent> fanList = new List<ItemContent>();

        public PageHWM()
        {
            InitializeComponent();
        }

        private void PageInfo_Load(object sender, EventArgs e)
        {
            InitializeTemp();
            InitializeFan();

            timer_refresh.Enabled = true;
        }

        private void InitializeTemp()
        {
            UInt32 Status;
            string tmp_str;

            ListViewGroup lvGroup = new ListViewGroup("Temperature");
            listView.Groups.Add(lvGroup);

            for (UInt32 i = 3; i < tempStr.Length; i++) //start from borad temp
            {
                ItemContent ic = new ItemContent();
                ic.ID = Lib.SAB2000_ID_HWM_TEMP_BASE + i;

                Status = Lib.SusiDeviceGetValue(ic.ID, out ic.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    tmp_str = Convert.ToString((ic.Value - KELVINS_OFFSET) / 10);
                    ic.LVI = new ListViewItem(new string[] { tempStr[i], tmp_str, "Celsius" }, lvGroup);
                    listView.Items.Add(ic.LVI);

                    tempList.Add(ic);
                }
            }
        }

        private void RefreshTemp()
        {
            UInt32 Status;

            foreach (ItemContent ic in tempList)
            {
                Status = Lib.SusiDeviceGetValue(ic.ID, out ic.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    ic.LVI.SubItems[1].Text = Convert.ToString(SusiBoard.SusiDecodeCelcius(ic.Value));
                }
            }
        }

        private void InitializeFan()
        {
            UInt32 Status;

            ListViewGroup lvGroup = new ListViewGroup("Fan");
            listView.Groups.Add(lvGroup);

            for (UInt32 i = 3; i < fanStr.Length; i++) // start form board fan
            {
                ItemContent ic = new ItemContent();
                ic.ID = Lib.SAB2000_ID_HWM_FAN_BASE + i;

                Status = Lib.SusiDeviceGetValue(ic.ID, out ic.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    ic.LVI = new ListViewItem(new string[] { fanStr[i], ic.Value.ToString(), "RPM" }, lvGroup);
                    listView.Items.Add(ic.LVI);

                    fanList.Add(ic);
                }
            }
        }

        private void RefreshFan()
        {
            UInt32 Status;

            foreach (ItemContent ic in fanList)
            {
                Status = Lib.SusiDeviceGetValue(ic.ID, out ic.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    ic.LVI.SubItems[1].Text = ic.Value.ToString();
                }
            }
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            RefreshTemp();
            RefreshFan();
        }
    }
}
