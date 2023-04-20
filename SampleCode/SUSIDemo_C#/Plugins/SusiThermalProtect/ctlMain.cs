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
            public UInt32 ID;
            public UInt32 Source;
        }

        class DeviceInfo
        {
            public UInt32 ID;
            public SusiThermalProtection.SusiThermalProtect Config;
            public UInt32 SupportFlags;
            public UInt32 TriggerMaximum;   // 0.1 Kelvins
            public UInt32 TriggerMinimum;
            public UInt32 ClearMaximum;
            public UInt32 ClearMinimum;
            public List<ThermalInfo> SourceList = new List<ThermalInfo>();

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
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_TML(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;

        const UInt32 SRC_ID_BASE = 0x00020000;

        const string EVENT_NONE = "None";
        const string EVENT_SHUTDOWN = "Shutdown";
        const string EVENT_THROTTLE = "Throttle";
        const string EVENT_POWEROFF = "Power off";

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
            InitializeThermal();
        }

        private void InitializeThermal()
        {
            UInt32 Status;

            for (UInt32 i = 0; i < SusiThermalProtection.SUSI_ID_THERMAL_MAX; i++)
            {
                DeviceInfo info = new DeviceInfo(i);

                Status = SusiThermalProtection.SusiThermalProtectionGetConfig(info.ID, out info.Config);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    continue;
                }

                SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, SusiThermalProtection.SUSI_ID_TP_EVENT_SUPPORT_FLAGS, out info.SupportFlags);
                SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, SusiThermalProtection.SUSI_ID_TP_EVENT_TRIGGER_MAXIMUM, out info.TriggerMaximum);
                SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, SusiThermalProtection.SUSI_ID_TP_EVENT_TRIGGER_MINIMUM, out info.TriggerMinimum);
                SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, SusiThermalProtection.SUSI_ID_TP_EVENT_CLEAR_MAXIMUM, out info.ClearMaximum);
                SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, SusiThermalProtection.SUSI_ID_TP_EVENT_CLEAR_MINIMUM, out info.ClearMinimum);

                for (UInt32 j = 0; j < SusiBoard.SUSI_ID_HWM_TEMP_MAX; j++)
                {
                    ThermalInfo ti = new ThermalInfo();
                    Status = SusiThermalProtection.SusiThermalProtectionGetCaps(info.ID, (SusiBoard.SUSI_ID_HWM_TEMP_CPU + j), out ti.Source);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        ti.ID = (SusiBoard.SUSI_ID_HWM_TEMP_CPU + j);
                        info.SourceList.Add(ti);
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

        private void RefreshSourceList()
        {
            int index;
            comboBox_Source.Items.Clear();

            for (int i = 0; i < Dev.SourceList.Count; i++)
            {
                index = (int)(Dev.SourceList[i].ID & 0xFF);
                comboBox_Source.Items.Add(GetThermalName(Dev.SourceList[i].ID));
            }
        }

        private void FillSource(UInt32 src)
        {
            if ((src & 0x000FF000) == SRC_ID_BASE)  // Check ID
            {
                for (int i = 0; i < Dev.SourceList.Count; i++)
                {
                    if (Dev.SourceList[i].ID == src)
                    {
                        comboBox_Source.SelectedIndex = i;
                        return;
                    }
                }
            }
            
            comboBox_Source.SelectedIndex = -1;
            comboBox_Source.Text = "";
        }

        private void GetConfig()
        {
            UInt32 Status;

            Status = SusiThermalProtection.SusiThermalProtectionGetConfig(Dev.ID, out Dev.Config);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiThermalProtectionGetConfig() failed. ({0:X8})", Status));
            }
            else
            {
                FillSource(Dev.Config.SourceId);
                textBox_TiggerT.Text = SusiBoard.SusiDecodeCelcius(Dev.Config.SendEventTemperature).ToString();
                textBox_StopT.Text = SusiBoard.SusiDecodeCelcius(Dev.Config.ClearEventTemperature).ToString();
                SelectEventType();
                SetRange();
            }
        }

        private UInt32 GetEventType()
        {
            switch (comboBox_EventType.Text)
            {
                case EVENT_SHUTDOWN:
                    return SusiThermalProtection.SUSI_THERMAL_EVENT_SHUTDOWN;

                case EVENT_THROTTLE:
                    return SusiThermalProtection.SUSI_THERMAL_EVENT_THROTTLE;

                case EVENT_POWEROFF:
                    return SusiThermalProtection.SUSI_THERMAL_EVENT_POWEROFF;
            }

            return SusiThermalProtection.SUSI_THERMAL_EVENT_NONE;
        }

        private void SelectEventType()
        {
            comboBox_EventType.Items.Clear();

            comboBox_EventType.Items.Add(EVENT_NONE);
            if (Dev.Config.EventType == SusiThermalProtection.SUSI_THERMAL_EVENT_NONE)
            {
                comboBox_EventType.SelectedIndex = comboBox_EventType.Items.Count - 1;
            }

            if ((Dev.SupportFlags & SusiThermalProtection.SUSI_THERMAL_FLAG_SUPPORT_SHUTDOWN) > 0)
            {
                comboBox_EventType.Items.Add(EVENT_SHUTDOWN);
                if (Dev.Config.EventType == SusiThermalProtection.SUSI_THERMAL_EVENT_SHUTDOWN)
                {
                    comboBox_EventType.SelectedIndex = comboBox_EventType.Items.Count - 1;
                }
            }

            if ((Dev.SupportFlags & SusiThermalProtection.SUSI_THERMAL_FLAG_SUPPORT_THROTTLE) > 0)
            {
                comboBox_EventType.Items.Add(EVENT_THROTTLE);
                if (Dev.Config.EventType == SusiThermalProtection.SUSI_THERMAL_EVENT_THROTTLE)
                {
                    comboBox_EventType.SelectedIndex = comboBox_EventType.Items.Count - 1;
                }
            }

            if ((Dev.SupportFlags & SusiThermalProtection.SUSI_THERMAL_FLAG_SUPPORT_POWEROFF) > 0)
            {
                comboBox_EventType.Items.Add(EVENT_POWEROFF);
                if (Dev.Config.EventType == SusiThermalProtection.SUSI_THERMAL_EVENT_POWEROFF)
                {
                    comboBox_EventType.SelectedIndex = comboBox_EventType.Items.Count - 1;
                }
            }
        }

        private void SetRange()
        {
            label_TriggerRange.Text = String.Format("(Range: {0} - {1})", SusiBoard.SusiDecodeCelcius(Dev.TriggerMinimum), SusiBoard.SusiDecodeCelcius(Dev.TriggerMaximum));
            label_ClearRange.Text = String.Format("(Range: {0} - {1})", SusiBoard.SusiDecodeCelcius(Dev.ClearMinimum), SusiBoard.SusiDecodeCelcius(Dev.ClearMaximum));
        }

        private void comboBox_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Set.Enabled = (comboBox_Source.SelectedIndex > -1);
        }

        private void comboBox_DevList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];
            RefreshSourceList();
            GetConfig();
        }

        private void comboBox_EventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool en = (comboBox_EventType.Text == EVENT_NONE);

            textBox_StopT.Enabled = !en;
            textBox_TiggerT.Enabled = !en;
        }

        private void textBox_In_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void textBox_In_Leave(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;
            UInt32 Value;

            if (UInt32.TryParse(current.Text, out Value) == false)
                current.Text = "0";
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            UInt32 Status;

            if (comboBox_Source.SelectedIndex == -1)
            {
                MessageBox.Show("Make sure all the setting is valid!");
                return;
            }

            Dev.Config.ClearEventTemperature = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_StopT.Text));
            Dev.Config.SendEventTemperature = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_TiggerT.Text));
            Dev.Config.SourceId = Dev.SourceList[comboBox_Source.SelectedIndex].ID;
            Dev.Config.EventType = GetEventType();

            Status = SusiThermalProtection.SusiThermalProtectionSetConfig(Dev.ID, ref Dev.Config);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiThermalProtectionSetConfig() failed. ({0:X8})", Status));
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            GetConfig();
        }

        private void textBox_TiggerT_Leave(object sender, EventArgs e)
        {
            if (textBox_TiggerT.Text.Length == 0)
                textBox_TiggerT.Text = "0";

            UInt32 Value = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_TiggerT.Text));

            if (Value > Dev.TriggerMaximum)
                textBox_TiggerT.Text = SusiBoard.SusiDecodeCelcius(Dev.TriggerMaximum).ToString();
            else if (Value < Dev.TriggerMinimum)
                textBox_TiggerT.Text = SusiBoard.SusiDecodeCelcius(Dev.TriggerMinimum).ToString();
        }

        private void textBox_StopT_Leave(object sender, EventArgs e)
        {
            if (textBox_StopT.Text.Length == 0)
                textBox_StopT.Text = "0";

            UInt32 Value = SusiBoard.SusiEncodeCelcius(Convert.ToUInt32(textBox_StopT.Text));

            if (Value > Dev.ClearMaximum)
                textBox_StopT.Text = SusiBoard.SusiDecodeCelcius(Dev.ClearMaximum).ToString();
            else if (Value < Dev.ClearMinimum)
                textBox_StopT.Text = SusiBoard.SusiDecodeCelcius(Dev.ClearMinimum).ToString();
        }
    }
}
