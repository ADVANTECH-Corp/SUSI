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
        string[] infoVal = new string[] {
            "Spec version",
            "Boot up times",
            "Running time (hours)",
            "Microsoft Plug-and-Play ID",
            "Platform revision",
            "Last Shutdown Status",
            "Last Shutdown Event"
        };

        string[] infoStr = new string[] {
            "Board manufacturer",
            "Board name",
            "Board revision",
            "Board serial number",
            "BIOS revision",
            "Hardware revision",
            "Platform type",
			"Firmware name",
			"BIOS name"
        };

        const string GKEY_SUSI4 = "SUSI4GROUP";
        ListViewGroup susi4Group = new ListViewGroup(GKEY_SUSI4, "Susi4 Information");

        private bool _Available = false;
        public bool Available
        {
            get { return _Available; }
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
            _Available = true;
        }

        private void PageInfo_Load(object sender, EventArgs e)
        {
            listView.Groups.Add(susi4Group);
            GetInfoValue();
            GetInfoString();
			GetInfoCustomizeString();
            GetVersion();
        }

        private void GetInfoValue()
        {
            UInt32 Status;
            UInt32 Value = 0;
            string tmp_str;

            for (UInt32 i = 0; i < infoVal.Length; i++)
            {
                Status = SusiBoard.SusiBoardGetValue(i, ref Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    switch (i)
                    {
                        case SusiBoard.SUSI_ID_BOARD_PNPID_VAL:
                            tmp_str = UnCompressASCIIPNPID(Value);
                            break;

                        case SusiBoard.SUSI_ID_GET_SPEC_VERSION:
                        case SusiBoard.SUSI_ID_BOARD_PLATFORM_REV_VAL:
                            tmp_str = String.Format("{0},{1}", (Value >> 24) & 0xFF, (Value >> 16) & 0xFF);
                            break;

                        default:
                            tmp_str = Value.ToString();
                            break;
                    }
                    
                    ListViewItem lvItem = new ListViewItem(new string[] { infoVal[i], tmp_str }, susi4Group);
                    listView.Items.Add(lvItem);
                }
            }
        }

        private void GetInfoString()
        {
            UInt32 Status;
            UInt32 Length = 64;
            StringBuilder sb = new StringBuilder((int)Length);

            for (UInt32 i = 0; i < infoStr.Length; i++)
            {
                Length = (UInt32)sb.MaxCapacity;
                Status = SusiBoard.SusiBoardGetStringA(i, sb, ref Length);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { infoStr[i], sb.ToString() }, susi4Group);
                    listView.Items.Add(lvItem);
                }
            }
        }

		private void GetInfoCustomizeString()
		{
			UInt32 Status;
			UInt32 Length = 32;
			StringBuilder sb = new StringBuilder((int)Length);

			for (UInt32 i = SusiBoard.SUSI_ID_BOARD_OEM0_STR; i <= SusiBoard.SUSI_ID_BOARD_OEM2_STR; i++)
			{
				Length = (UInt32)sb.MaxCapacity;
				Status = SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_INFO(i), sb, ref Length);
				if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
					continue;

				string itemname = sb.ToString();

				Length = (UInt32)sb.MaxCapacity;
				Status = SusiBoard.SusiBoardGetStringA(i, sb, ref Length);
				if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
				{
					ListViewItem lvItem = new ListViewItem(new string[] { itemname, sb.ToString() }, susi4Group);
					listView.Items.Add(lvItem);
				}
			}
		}

        private void GetVersion()
        {
            UInt32 Status;
            UInt32 Value = 0;

            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_BOARD_DRIVER_VERSION_VAL, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                string tmpStr = String.Format("{0}.{1}.{2}", (Value >> 24), ((Value >> 16) & 0xFF), (Value & 0xFFFF));
                ListViewItem lvItem = new ListViewItem(new string[] { "Driver version", tmpStr }, susi4Group);
                listView.Items.Add(lvItem);
            }

            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_BOARD_LIB_VERSION_VAL, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                string tmpStr = String.Format("{0}.{1}.{2}", (Value >> 24), ((Value >> 16) & 0xFF), (Value & 0xFFFF));
                ListViewItem lvItem = new ListViewItem(new string[] { "Library version", tmpStr }, susi4Group);
                listView.Items.Add(lvItem);
            }

            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_BOARD_FIRMWARE_VERSION_VAL, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                string tmpStr = String.Format("{0}.{1}.{2}", (Value >> 24), ((Value >> 16) & 0xFF), (Value & 0xFFFF));
                ListViewItem lvItem = new ListViewItem(new string[] { "Firmware version", tmpStr }, susi4Group);
                listView.Items.Add(lvItem);
            }
            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_BOARD_DOCUMENT_VERSION_VAL, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                string tmpStr = String.Format("{0}.{1}.{2}", (Value & 0xFF), ((Value >> 8) & 0xFF),  ((Value >> 16) & 0xFF));
                ListViewItem lvItem = new ListViewItem(new string[] { "EC protocol version", tmpStr }, susi4Group);
                listView.Items.Add(lvItem);
            }
        }

        private string UnCompressASCIIPNPID(UInt32 pnpid)
        {
            ushort ascii_part = (ushort)((pnpid >> 12) & 0x0000FFFF);
            byte low_byte = (byte)(ascii_part & 0x00FF);
            byte high_byte = (byte)(ascii_part >> 8);

            byte first_char_pos = (byte)(low_byte >> 2);
            byte second_char_pos_high_part = (byte)(low_byte & 0x03);
            byte second_char_pos_low_part = (byte)(high_byte >> 5);
            byte second_char_pos = (byte)((second_char_pos_high_part << 3) | second_char_pos_low_part);
            byte third_char_pos = (byte)(high_byte & 0x1F);

            char c1 = Convert.ToChar(64 + first_char_pos);
            char c2 = Convert.ToChar(64 + second_char_pos);
            char c3 = Convert.ToChar(64 + third_char_pos);
            ushort vendor_specific_id = (ushort)(pnpid & 0x00000FFF);

            return String.Format("{0}{1}{2}, 0x{3:X}", c1, c2, c3, vendor_specific_id);
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			// Update data by double click the item
			UInt32 Status;
			UInt32 temp_U32 = 0;
			ListViewItem lvi = listView.FocusedItem;

			if (lvi.SubItems[0].Text == infoVal[2])		// Running time (hours)
			{
				Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_BOARD_RUNNING_TIME_METER_VAL, ref temp_U32);
				if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
				{
					//listView.BeginUpdate();
					lvi.SubItems[1].Text = temp_U32.ToString();
					//listView.EndUpdate();
					MessageBox.Show("Running time is updated.", "Confirm", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Running time update fail.", "Error", MessageBoxButtons.OK);
				}					
			}
		}
    }
}
