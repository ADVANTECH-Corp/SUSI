using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using System.Diagnostics;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        class DeviceInfo
        {
            public UInt32 ID;
            public UInt32 MaxValue;
            public UInt32 MinValue;
            public bool SupportACPI;
            public bool SupportWMI;
            public bool SupportPWM
            {
                get { return (MaxValue > 0); }
            }

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;
                SupportACPI = false;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_VGA_BACKLIGHT(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
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
            InitializeVGA();
        }

        private void InitializeVGA()
        {
            UInt32 Status;
            UInt32 Value;
            byte[] bLevels;
            for (UInt32 i = 0; i < SusiVga.SUSI_ID_BACKLIGHT_MAX; i++)
            {
                DeviceInfo info = new DeviceInfo(i);

                Status = SusiVga.SusiVgaGetCaps(i, SusiVga.SUSI_ID_VGA_BRIGHTNESS_MAXIMUM, out info.MaxValue);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    SusiVga.SusiVgaGetCaps(i, SusiVga.SUSI_ID_VGA_BRIGHTNESS_MINIMUM, out info.MinValue);
                }
                else
                {
                    info.MaxValue = 0;
                    info.MinValue = 0;
                }

                Status = SusiVga.SusiVgaGetBacklightLevel(i, out Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    info.SupportACPI = true;
                }
                else
                {
                    if (info.MaxValue == 0)
                    {
                        Status = SusiVga.SusiVgaGetBacklightEnable(i, out Value);
                        if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                               continue;
                    }
                }

                bLevels = GetBrightnessLevels();

                if (bLevels.Length != 0)
                    info.SupportWMI = true;
                else
                    info.SupportWMI = false;

                DevList.Add(info);
                comboBox_DevList.Items.Add(info.Name);
            }

            if (DevList.Count > 0)
            {
                comboBox_DevList.SelectedIndex = 0;
            }
        }

        private void comboBox_PanelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];

            GetFrequency();
            GetPolarity();
            GetBacklightEn();

            groupBox_Brightness.Enabled = (Dev.SupportACPI || Dev.SupportPWM || Dev.SupportWMI);
            radioButton_ACPI.Enabled = Dev.SupportACPI;
            radioButton_PWM.Enabled = Dev.SupportPWM;
            radioButton_WMI.Enabled = Dev.SupportWMI;
            if (!radioButton_PWM.Enabled)
            {
                if (radioButton_ACPI.Enabled)
                    radioButton_ACPI.Checked = true;
            }
            else
            {
                if (!radioButton_ACPI.Enabled)
                    radioButton_PWM.Checked = true;
            }
            GetBrightness();
        }

        #region Frequency
        private void GetFrequency()
        {
            UInt32 Status;
            UInt32 Value;
            bool en = false;

            Status = SusiVga.SusiVgaGetFrequency(Dev.ID, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                textBox_Freq.Text = Value.ToString();
                en = true;
            }

            textBox_Freq.Enabled = en;
            button_GetFreq.Enabled = en;
            button_SetFreq.Enabled = en;
        }

        private void button_GetFreq_Click(object sender, EventArgs e)
        {
            GetFrequency();
        }

        private void button_SetFreq_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            try
            {
                Value = Convert.ToUInt32(textBox_Freq.Text);
            }
            catch
            {
                MessageBox.Show("Invalid value format, please confirm.");
                return;
            }

            Status = SusiVga.SusiVgaSetFrequency(Dev.ID, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                Debug.WriteLine(String.Format("SusiVgaSetPolarity failed. 0x{0:X8}", Status));
            }
        }
        #endregion

        #region Polarity
        private void GetPolarity()
        {
            UInt32 Status;
            UInt32 Value;
            bool en = false;

            Status = SusiVga.SusiVgaGetPolarity(Dev.ID, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (Value == SusiVga.SUSI_BACKLIGHT_POLARITY_OFF)
                    radioButton_No.Checked = true;
                else
                    radioButton_Yes.Checked = true;

                en = true;
            }

            radioButton_Yes.Enabled = en;
            radioButton_No.Enabled = en;
            button_GetPol.Enabled = en;
        }

        private void button_GetPol_Click(object sender, EventArgs e)
        {
            GetPolarity();
        }

        private void radioButton_Yes_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;

            if (radioButton_Yes.Checked)
            {
                Status = SusiVga.SusiVgaSetPolarity(Dev.ID, SusiVga.SUSI_BACKLIGHT_POLARITY_ON);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    Debug.WriteLine(String.Format("SusiVgaSetPolarity failed. 0x{0:X8}", Status));
                }
            }
        }

        private void radioButton_No_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;

            if (radioButton_No.Checked)
            {
                Status = SusiVga.SusiVgaSetPolarity(Dev.ID, SusiVga.SUSI_BACKLIGHT_POLARITY_OFF);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    Debug.WriteLine(String.Format("SusiVgaSetPolarity failed. 0x{0:X8}", Status));
                }
            }
        }
        #endregion

        #region Backlight
        private void GetBacklightEn()
        {
            UInt32 Status;
            UInt32 Value;
            bool en = false;

            Status = SusiVga.SusiVgaGetBacklightEnable(Dev.ID, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (Value == SusiVga.SUSI_BACKLIGHT_SET_OFF)
                    radioButton_Off.Checked = true;
                else
                    radioButton_On.Checked = true;

                en = true;
            }

            groupBox_Control.Enabled = en;
        }

        private void button_GetBacklight_Click(object sender, EventArgs e)
        {
            GetBacklightEn();
        }

        private void radioButton_Off_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;

            if (radioButton_Off.Checked)
            {
                Status = SusiVga.SusiVgaSetBacklightEnable(Dev.ID, SusiVga.SUSI_BACKLIGHT_SET_OFF);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    Debug.WriteLine(String.Format("SusiVgaSetBacklightEnable failed. 0x{0:X8}", Status));
                }
            }
        }

        private void radioButton_On_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;

            if (radioButton_On.Checked)
            {
                Status = SusiVga.SusiVgaSetBacklightEnable(Dev.ID, SusiVga.SUSI_BACKLIGHT_SET_ON);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    Debug.WriteLine(String.Format("SusiVgaSetBacklightEnable failed. 0x{0:X8}", Status));
                }
            }
        }
        #endregion

        #region Brightness
        static byte[] GetBrightnessLevels()
        {
            byte[] BrightnessLevels = new byte[0];
            System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");
            System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightness");
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);

            try
            {
                System.Management.ManagementObjectCollection moc = mos.Get();
                foreach (System.Management.ManagementObject o in moc)
                {
                    BrightnessLevels = (byte[])o.GetPropertyValue("Level");
                    break;
                }
                moc.Dispose();
                mos.Dispose();
            }
            catch (Exception)
            {
                //MessageBox.Show("Not support this brightness control");
            }
            return BrightnessLevels;
        }
        static UInt32 GetWMIBrightness()
        {
            byte curBrightness = 0;
            System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");
            System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightness");
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);
            System.Management.ManagementObjectCollection moc = mos.Get();

            foreach (System.Management.ManagementObject o in moc)
            {
                curBrightness = (byte)o.GetPropertyValue("CurrentBrightness");
                break;
            }
            moc.Dispose();
            mos.Dispose();
            return (UInt32)curBrightness;
        }
        static void SetBrightness(byte targetBrightness)
        {
            System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");
            System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightnessMethods");
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);
            System.Management.ManagementObjectCollection moc = mos.Get();

            foreach (System.Management.ManagementObject o in moc)
            {
                o.InvokeMethod("WmiSetBrightness", new Object[] { UInt32.MaxValue, targetBrightness });
                break;
            }
            moc.Dispose();
            mos.Dispose();
        }
        private void GetBrightness()
        {
            UInt32 Status;
            UInt32 Value;

            // Avoid value over range
            trackBar_BL.Minimum = -1;
            trackBar_BL.Maximum = 0xFFFF;

            if (radioButton_PWM.Checked)
            {
                Status = SusiVga.SusiVgaGetBacklightBrightness(Dev.ID, out Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    trackBar_BL.Value = (int)Value;
                    label_BLValue.Text = Value.ToString();
                }

                trackBar_BL.Minimum = (int)Dev.MinValue;
                trackBar_BL.Maximum = (int)Dev.MaxValue;
                label_BLMax.Text = Dev.MaxValue.ToString();
                label_BLMin.Text = Dev.MinValue.ToString();
            }
            else if (radioButton_ACPI.Checked)
            {
                Status = SusiVga.SusiVgaGetBacklightLevel(Dev.ID, out Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    trackBar_BL.Value = (int)Value;
                    label_BLValue.Text = Value.ToString();
                }

                trackBar_BL.Minimum = 0;
                trackBar_BL.Maximum = 9;
                label_BLMax.Text = SusiVga.SUSI_BACKLIGHT_LEVEL_MAXIMUM.ToString();
                label_BLMin.Text = SusiVga.SUSI_BACKLIGHT_LEVEL_MINIMUM.ToString();
            }
            else
            {
                Value = GetWMIBrightness();
                if (Value >= 0 && Value <= 100)
                {
                    trackBar_BL.Value = (int)Value;
                    label_BLValue.Text = Value.ToString();
                }

                trackBar_BL.Minimum = 0;
                trackBar_BL.Maximum = 100;
                label_BLMax.Text = trackBar_BL.Maximum.ToString();
                label_BLMin.Text = trackBar_BL.Minimum.ToString();
            }
        }

        private void radioButton_PWM_CheckedChanged(object sender, EventArgs e)
        {
            GetBrightness();
        }

        private void radioButton_ACPI_CheckedChanged(object sender, EventArgs e)
        {
            GetBrightness();
        }
        private void radioButton_WMI_CheckedChanged(object sender, EventArgs e)
        {
            GetBrightness();
        }
        private void trackBar_BL_Scroll(object sender, EventArgs e)
        {
            UInt32 Status;

            if (radioButton_PWM.Checked)
            {
                Status = SusiVga.SusiVgaSetBacklightBrightness(Dev.ID, (UInt32)trackBar_BL.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    label_BLValue.Text = trackBar_BL.Value.ToString();
                }
            }
            else if (radioButton_ACPI.Checked)
            {
                Status = SusiVga.SusiVgaSetBacklightLevel(Dev.ID, (UInt32)trackBar_BL.Value);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    label_BLValue.Text = trackBar_BL.Value.ToString();
                }
            }
            else
            {
                SetBrightness(Convert.ToByte((UInt32)trackBar_BL.Value));
                label_BLValue.Text = trackBar_BL.Value.ToString();
            }
        }

        private void button_GetBrightness_Click(object sender, EventArgs e)
        {
            GetBrightness();
        }
        #endregion
    }
}
