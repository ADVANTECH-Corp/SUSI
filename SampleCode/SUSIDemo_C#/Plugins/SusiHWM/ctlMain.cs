using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
//using System.Diagnostics;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        Dictionary<ListViewItem, ItemContent> lvItems = new Dictionary<ListViewItem, ItemContent>();

        class ItemContent
        {
            public UInt32 ID;
            public float Value;
            public float MaximumValue;
            public float MinimumValue;
            public string Unit;

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            public ItemContent(UInt32 Id)
            {
                this.ID = Id;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_HWM(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        const string UNIT_CURRENT_STR = "A";
        const string UNIT_VOLTAGE_STR = "V";
        const string UNIT_TEMP_STR = "Celsius";
        const string UNIT_FAN_STR = "RPM";
        const string UNIT_CASEOPEN_STR = "Status";

        const UInt32 KELVINS_OFFSET = 2731;

        const string CASEOPEN_STATUS_NORMAL = "Normal";
        const string CASEOPEN_STATUS_OPENED = "Been Opened";

        public bool Available
        {
            get { return (lvItems.Count > 0); }
        }

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

            listView.BeginUpdate();
            InitializeItems(UNIT_VOLTAGE_STR, "Voltage", SusiBoard.SUSI_ID_HWM_VOLTAGE_VCORE, SusiBoard.SUSI_ID_HWM_VOLTAGE_MAX);
            InitializeItems(UNIT_CURRENT_STR, "Current", SusiBoard.SUSI_ID_HWM_CURRENT_OEM0, SusiBoard.SUSI_ID_HWM_CURRENT_MAX);
            InitializeItems(UNIT_TEMP_STR, "Temperature", SusiBoard.SUSI_ID_HWM_TEMP_CPU, SusiBoard.SUSI_ID_HWM_TEMP_MAX);
            InitializeItems(UNIT_FAN_STR, "Fan", SusiBoard.SUSI_ID_HWM_FAN_CPU, SusiBoard.SUSI_ID_HWM_FAN_MAX);
            InitializeItems(UNIT_CASEOPEN_STR, "Case Open (Double click item to clear)", SusiBoard.SUSI_ID_HWM_CASEOPEN_OEM0, SusiBoard.SUSI_ID_HWM_CASEOPEN_MAX);
            listView.EndUpdate();
        }

        private void PageHWM_Load(object sender, EventArgs e)
        {
            timer_monitoring.Enabled = true;
        }

        private void InitializeItems(string unit, string groupname, UInt32 IDBase, UInt32 Count)
        {
            UInt32 Status;
            UInt32 temp_U32 = 0;

            ListViewGroup lvGroup = new ListViewGroup(groupname);
            listView.Groups.Add(lvGroup);

            for (int i = 0; i < Count; i++)
            {
                ItemContent ic = new ItemContent((UInt32)(i + IDBase));
                ic.Unit = unit;

                Status = SusiBoard.SusiBoardGetValue(ic.ID, ref temp_U32);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    ListViewItem lvItem;

                    if (unit == UNIT_CASEOPEN_STR)
                    {
                        string COS = (temp_U32 == 0) ? CASEOPEN_STATUS_NORMAL : CASEOPEN_STATUS_OPENED;
                        ic.Value = temp_U32;
                        lvItem = new ListViewItem(new string[] { ic.Name, COS, "", "", unit }, lvGroup);
                    }
                    else if (ConvertUnit(temp_U32, ic, true))
                    {
                        lvItem = new ListViewItem(new string[] { ic.Name, ic.Value.ToString(), ic.MinimumValue.ToString(), ic.MaximumValue.ToString(), unit }, lvGroup);

                    }
                    else
                        continue;

                    listView.Items.Add(lvItem);
                    lvItems.Add(lvItem, ic);
                }
            }
        }

        private bool ConvertUnit(UInt32 orgValue, ItemContent BoardItem, bool init)
        {
            switch (BoardItem.Unit)
            {
                case UNIT_VOLTAGE_STR:
                    BoardItem.Value = (Int32)orgValue / 1000f;
                    break;

                case UNIT_TEMP_STR:
                    BoardItem.Value = SusiBoard.SusiDecodeCelcius(orgValue);
                    break;

                case UNIT_FAN_STR:
                    BoardItem.Value = (float)orgValue;
                    break;

                case UNIT_CURRENT_STR:
                    BoardItem.Value = (UInt32)orgValue / 1000f;
                    break;

                default:
                    return false;
            }

            if (init)
            {
                BoardItem.MaximumValue = BoardItem.Value;
                BoardItem.MinimumValue = BoardItem.Value;
            }
            else
            {
                if (BoardItem.Value > BoardItem.MaximumValue)
                    BoardItem.MaximumValue = BoardItem.Value;
                else if (BoardItem.Value < BoardItem.MinimumValue)
                    BoardItem.MinimumValue = BoardItem.Value;
            }

            return true;
        }

        private void RefreshItems()
        {
            UInt32 Status;
            UInt32 temp_U32 = 0;

            listView.BeginUpdate();
            foreach (ListViewItem lvi in listView.Items)
            {
                ItemContent ic = lvItems[lvi];
                Status = SusiBoard.SusiBoardGetValue(ic.ID, ref temp_U32);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    if (ic.Unit == UNIT_CASEOPEN_STR)
                    {
                        ic.Value = temp_U32;
                        lvi.SubItems[1].Text = (temp_U32 == 0) ? CASEOPEN_STATUS_NORMAL : CASEOPEN_STATUS_OPENED;
                    }
                    else if (ConvertUnit(temp_U32, lvItems[lvi], false))
                    {
                        lvi.SubItems[1].Text = ic.Value.ToString();
                        lvi.SubItems[2].Text = ic.MinimumValue.ToString();
                        lvi.SubItems[3].Text = ic.MaximumValue.ToString();
                    }
                }
            }
            listView.EndUpdate();
        }

        private void timer_monitoring_Tick(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ItemContent ic = lvItems[listView.FocusedItem];

            if (ic.Unit == UNIT_CASEOPEN_STR && ic.Value == 1)
            {
                string msg = String.Format("Do you want to clear case open status? ({0})", listView.FocusedItem.Text);
                if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UInt32 temp_U32 = SusiBoard.CASEOPEN_CLEAR_CMD;
                    UInt32 Status = SusiBoard.SusiBoardGetValue(ic.ID, ref temp_U32);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        // Error
                    }
                }
            }
        }
    }

    class DoubleBufferListView : ListView
    {
        public DoubleBufferListView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
