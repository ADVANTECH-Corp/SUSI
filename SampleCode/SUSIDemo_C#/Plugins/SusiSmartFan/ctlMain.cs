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
        class ThermalInfo
        {
            public UInt32 TempID;
            public UInt32 Type;
        }

        class DeviceInfo
        {
            public UInt32 ID;
            public SusiFan.SusiFanControl Config;
            public UInt32 ControlSupportFlags;
            public UInt32 AutoSupportFlags;
            public List<ThermalInfo> ThermalList = new List<ThermalInfo>();

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_HWM_FANCONTROL(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;

        public bool Available
        {
            get { return (DevList.Count > 0); }
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
            InitializeSmartFan();
        }

        private void PageSmartFan_Load(object sender, EventArgs e)
        {
            radioButton_OpPWM.Checked = true;
        }

        private void InitializeSmartFan()
        {
            UInt32 Status;

            for (UInt32 i = 0; i < SusiBoard.SUSI_ID_HWM_FAN_MAX; i++)
            {
                DeviceInfo info = new DeviceInfo(SusiBoard.SUSI_ID_HWM_FAN_CPU + i);

                // Get configuration
                Status = SusiFan.SusiFanControlGetConfig(info.ID, out info.Config);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    continue;
                }

                // Get supported item
                SusiFan.SusiFanControlGetCaps(info.ID, SusiFan.SUSI_ID_FC_CONTROL_SUPPORT_FLAGS, out info.ControlSupportFlags);
                SusiFan.SusiFanControlGetCaps(info.ID, SusiFan.SUSI_ID_FC_AUTO_SUPPORT_FLAGS, out info.AutoSupportFlags);

                // Get supported temperature
                for (UInt32 j = 0; j < SusiBoard.SUSI_ID_HWM_TEMP_MAX; j++)
                {
                    ThermalInfo zi = new ThermalInfo();
                    Status = SusiFan.SusiFanControlGetCaps(info.ID, (SusiBoard.SUSI_ID_HWM_TEMP_CPU + j), out zi.Type);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        zi.TempID = (SusiBoard.SUSI_ID_HWM_TEMP_CPU + j);
                        info.ThermalList.Add(zi);
                    }
                }

                DevList.Add(info);
                comboBox_DevList.Items.Add(info.Name);
            }

            if (DevList.Count > 0)
            {
                comboBox_DevList.SelectedIndex = 0;
            }
        }

        private void GetSpeed()
        {
            UInt32 Value = 0;
            UInt32 Status = SusiBoard.SusiBoardGetValue(Dev.ID, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Speed.Text = Value.ToString();
                timer_Info.Enabled = true;
            }
            else
            {
                label_Speed.Text = "N/A";
                timer_Info.Enabled = false;
            }
        }

        private void GetConfig()
        {
            UInt32 Status;

            Status = SusiFan.SusiFanControlGetConfig(Dev.ID, out Dev.Config);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiFanControlGetConfig failed. (0x{0:X8})", Status));
                return;
            }

            switch (Dev.Config.Mode)
            {
                case SusiFan.SUSI_FAN_CTRL_MODE_FULL:
                    radioButton_ModeFull.Checked = true;
                    break;

                case SusiFan.SUSI_FAN_CTRL_MODE_OFF:
                    radioButton_ModeOFF.Checked = true;
                    break;

                case SusiFan.SUSI_FAN_CTRL_MODE_AUTO:
                    radioButton_ModeAuto.Checked = true;
                    break;

                case SusiFan.SUSI_FAN_CTRL_MODE_MANUAL:
                default:
                    radioButton_ModeManual.Checked = true;
                    break;
            }

            textBox_PWM.Text = Dev.Config.PWM.ToString();

            FillType(Dev.Config.AutoControl.TmlSource);

            textBox_TempLowStop.Text = Math.Floor(SusiBoard.SusiDecodeCelcius(Dev.Config.AutoControl.LowStopLimit)).ToString();
            textBox_TempLowLimit.Text = Math.Floor(SusiBoard.SusiDecodeCelcius(Dev.Config.AutoControl.LowLimit)).ToString();
            textBox_TempHighLimit.Text = Math.Floor(SusiBoard.SusiDecodeCelcius(Dev.Config.AutoControl.HighLimit)).ToString();

            if (Dev.Config.AutoControl.OpMode == SusiFan.SUSI_FAN_AUTO_CTRL_OPMODE_PWM)
                radioButton_OpPWM.Checked = true;
            else
                radioButton_OpRPM.Checked = true;
            textBox_MaxRPM.Text = Dev.Config.AutoControl.MaxRPM.ToString();
            textBox_MinRPM.Text = Dev.Config.AutoControl.MinRPM.ToString();
            textBox_MaxPWM.Text = Dev.Config.AutoControl.MaxPWM.ToString();
            textBox_MinPWM.Text = Dev.Config.AutoControl.MinPWM.ToString();

            radioButton_ModeAuto.Enabled = ((Dev.ControlSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_MODE) != 0);
            radioButton_ModeOFF.Enabled = ((Dev.ControlSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_OFF_MODE) != 0);
            radioButton_ModeFull.Enabled = ((Dev.ControlSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_FULL_MODE) != 0);
            radioButton_ModeManual.Enabled = ((Dev.ControlSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_MANUAL_MODE) != 0);

            radioButton_OpPWM.Enabled = ((Dev.AutoSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_PWM) != 0);
            radioButton_OpRPM.Enabled = ((Dev.AutoSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_RPM) != 0);

            textBox_TempLowStop.Enabled = ((Dev.AutoSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_LOW_STOP) != 0);
            textBox_TempLowLimit.Enabled = ((Dev.AutoSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_LOW_LIMIT) != 0);
            textBox_TempHighLimit.Enabled = ((Dev.AutoSupportFlags & SusiFan.SUSI_FC_FLAG_SUPPORT_AUTO_HIGH_LIMIT) != 0);
        }

        private void FillType(UInt32 Type)
        {
            if ((Type & 0x000FF000) == SusiBoard.SUSI_ID_HWM_TEMP_CPU)  // Check ID
            {
                for (int i = 0; i < Dev.ThermalList.Count; i++)
                {
                    if (Dev.ThermalList[i].TempID == Type)
                    {
                        comboBox_Source.SelectedIndex = i;
                        return;
                    }
                }
            }
            comboBox_Source.SelectedIndex = -1;
            comboBox_Source.Text = "";
        }

        private string GetThermalName(UInt32 ID)
        {
            UInt32 Length = 32;
            StringBuilder sb = new StringBuilder((int)Length);
            if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_HWM(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                return sb.ToString();
            }

            return "";
        }

        private void RefreshThermalList()
        {
            int index;
            comboBox_Source.Items.Clear();

            for (int i = 0; i < Dev.ThermalList.Count; i++)
            {
                index = (int)(Dev.ThermalList[i].TempID & 0xFF);
                comboBox_Source.Items.Add(GetThermalName(Dev.ThermalList[i].TempID));
            }

            comboBox_Source.Enabled = (comboBox_Source.Items.Count > 0);
        }

        private void comboBox_FanCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];
            RefreshThermalList();
            GetConfig();
            GetSpeed();
        }

        private void radioButton_ModeFull_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_Control.Enabled = !radioButton_ModeFull.Checked;
        }

        private void radioButton_ModeOFF_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_Control.Enabled = !radioButton_ModeOFF.Checked;
        }

        private void radioButton_AutoManual_CheckedChanged(object sender, EventArgs e)
        {
            textBox_PWM.Enabled = radioButton_ModeManual.Checked;
            groupBox_Auto.Enabled = radioButton_ModeAuto.Checked && radioButton_ModeAuto.Enabled;
        }

        private void radioButton_OpRPM_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MaxPWM.Enabled = radioButton_OpPWM.Checked;
            textBox_MinPWM.Enabled = radioButton_OpPWM.Checked;
        }

        private void radioButton_OpPWM_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MaxRPM.Enabled = radioButton_OpRPM.Checked;
            textBox_MinRPM.Enabled = radioButton_OpRPM.Checked;
        }

        private void timer_Info_Tick(object sender, EventArgs e)
        {
            GetSpeed();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            GetConfig();
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            if (radioButton_ModeFull.Checked)
                Dev.Config.Mode = SusiFan.SUSI_FAN_CTRL_MODE_FULL;
            else if (radioButton_ModeOFF.Checked)
                Dev.Config.Mode = SusiFan.SUSI_FAN_CTRL_MODE_OFF;
            else if (radioButton_ModeAuto.Checked)
            {
                if (comboBox_Source.SelectedIndex == -1)
                {
                    MessageBox.Show("Make sure all the setting is valid!");
                    return;
                }

                Dev.Config.Mode = SusiFan.SUSI_FAN_CTRL_MODE_AUTO;

                Dev.Config.AutoControl.TmlSource = Dev.ThermalList[comboBox_Source.SelectedIndex].TempID;

                Dev.Config.AutoControl.LowStopLimit = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_TempLowStop.Text));
                Dev.Config.AutoControl.LowLimit = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_TempLowLimit.Text));
                Dev.Config.AutoControl.HighLimit = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_TempHighLimit.Text));

                if (radioButton_OpPWM.Checked)
                    Dev.Config.AutoControl.OpMode = SusiFan.SUSI_FAN_AUTO_CTRL_OPMODE_PWM;
                else
                    Dev.Config.AutoControl.OpMode = SusiFan.SUSI_FAN_AUTO_CTRL_OPMODE_RPM;

                Dev.Config.AutoControl.MaxRPM = Convert.ToUInt32(textBox_MaxRPM.Text);
                Dev.Config.AutoControl.MinRPM = Convert.ToUInt32(textBox_MinRPM.Text);
                Dev.Config.AutoControl.MaxPWM = Convert.ToUInt32(textBox_MaxPWM.Text);
                Dev.Config.AutoControl.MinPWM = Convert.ToUInt32(textBox_MinPWM.Text);
            }
            else
                Dev.Config.Mode = SusiFan.SUSI_FAN_CTRL_MODE_MANUAL;

            Dev.Config.PWM = Convert.ToUInt32(textBox_PWM.Text);

            UInt32 Status = SusiFan.SusiFanControlSetConfig(Dev.ID, ref Dev.Config);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiFanControlSetConfig failed. (0x{0:X8})", Status));
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb == null) return;

            if (tb.Text.Length == 0)
                tb.Text = "0";
        }
    }
}
