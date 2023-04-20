using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PageAlert : UserControl
    {
        struct AlertItem
        {
            public string Name;
            public UInt32 ID;

            public AlertItem(string name, UInt32 id)
            {
                Name = name;
                ID = id;
            }
        }

        Dictionary<int, AlertItem> AlertList = new Dictionary<int, AlertItem>();

        public PageAlert()
        {
            InitializeComponent();
        }

        private void PageAlert_Load(object sender, EventArgs e)
        {
            InitalizeAlert();
            GetLEDStatus();
            GetAlertCtrl();

            timer_Fresh.Enabled = true;
        }

        private void InitalizeAlert()
        {
            AlertList.Add(0, new AlertItem("CPU1", Lib.SAB2000_ID_HWM_TEMP_ALERT_VTIN1));
            comboBox_Src.Items.Add("CPU1");
            AlertList.Add(1, new AlertItem("CPU2", Lib.SAB2000_ID_HWM_TEMP_ALERT_VTIN2));
            comboBox_Src.Items.Add("CPU2");
            AlertList.Add(2, new AlertItem("Board Temperature 1", Lib.SAB2000_ID_HWM_TEMP_ALERT_BT1));
            comboBox_Src.Items.Add("Board Temperature 1");
            AlertList.Add(3, new AlertItem("Board Temperature 2", Lib.SAB2000_ID_HWM_TEMP_ALERT_BT2));
            comboBox_Src.Items.Add("Board Temperature 2");
            AlertList.Add(4, new AlertItem("Board Temperature 3", Lib.SAB2000_ID_HWM_TEMP_ALERT_BT3));
            comboBox_Src.Items.Add("Board Temperature 3");
            AlertList.Add(5, new AlertItem("Board Temperature 4", Lib.SAB2000_ID_HWM_TEMP_ALERT_BT4));
            comboBox_Src.Items.Add("Board Temperature 4");

            comboBox_Src.SelectedIndex = 0;
        }

        private string GetStatusStr(UInt32 Value)
        {
            switch (Value & 0x07)
            {
                case 0:
                    return "Dark";

                case 1:
                    return "Green";

                case 2:
                    return "Red";

                case 5:
                    return "Green Blink";

                case 6:
                    return "Red Blink";

                default:
                    return "Unknown";
            }
        }

        private void GetLEDStatus()
        {
            UInt32 Status;
            UInt32 Value;

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_LED_POWER, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_LED_PWR.Text = GetStatusStr(Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_LED_TEMP, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_LED_TEMP.Text = GetStatusStr(Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_LED_FAN, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_LED_FAN.Text = GetStatusStr(Value);
            }
        }


        private void GetAlertCtrl()
        {
            UInt32 Status;
            UInt32 Value;

            Status = Lib.SusiDeviceGetValue(Lib.SAB2000_ID_CTRL_ALERT, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                radioButton_AlertDis.Checked = (Value == 0);
            }
        }

        private void radioButton_AlertEn_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            Value = (radioButton_AlertDis.Checked) ? (UInt32)0 : (UInt32)1;

            Status = Lib.SusiDeviceSetValue(Lib.SAB2000_ID_CTRL_ALERT, Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
				System.Diagnostics.Debug.WriteLine(String.Format("SusiDeviceSetValue(SAB2000_ID_CTRL_ALERT) failed! (0x{0:X8})", Status));
            }
        }

        private void timer_Fresh_Tick(object sender, EventArgs e)
        {
            GetLEDStatus();
            GetAlertCtrl();
        }

        private void GetTempAlert()
        {
            UInt32 Status;
            UInt32 Value;
            UInt32 ID = AlertList[comboBox_Src.SelectedIndex].ID;

            Status = Lib.SusiDeviceGetValue(ID, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                textBox_Val.Text = Convert.ToString(SusiBoard.SusiDecodeCelcius(Value));
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {

            GetTempAlert();
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;
            UInt32 ID = AlertList[comboBox_Src.SelectedIndex].ID;

            try
            {
                Value = Convert.ToUInt32(textBox_Val.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Parameter!");
                return;
            }

            Status = Lib.SusiDeviceSetValue(ID, SusiBoard.SusiEncodeCelcius(Value));
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("SusiDeviceSetValue() failed! (0x{0:X8})", Status));
            }
        }

        private void comboBox_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTempAlert();
        }

    }
}
