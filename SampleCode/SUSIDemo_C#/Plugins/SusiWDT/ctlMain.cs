using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using System.Runtime.InteropServices;
//using System.Diagnostics;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        class DeviceInfo
        {
            public UInt32 ID;
			public UInt32 SupportEventFlags;
            public UInt32 MaxDelay;
            public UInt32 MinDelay;
            public UInt32 MaxReset;
            public UInt32 MinReset;
            public UInt32 MaxEvent;
            public UInt32 MinEvent;
			public UInt32 Unit;

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
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_WDT(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        static SusiWDog.SUSI_WDT_INT_CALLBACK fn_callback;

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
            InitializeWDog();
        }

        private void InitializeWDog()
        {
            UInt32 Status;

            for (UInt32 i = 0; i < SusiWDog.SUSI_ID_WATCHDOG_MAX; i++)
            {
                DeviceInfo info = new DeviceInfo(i);

				Status = SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_SUPPORT_FLAGS, out info.SupportEventFlags);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    continue;
                }

                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_DELAY_MAXIMUM, out info.MaxDelay);
                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_DELAY_MINIMUM, out info.MinDelay);
                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_RESET_MAXIMUM, out info.MaxReset);
                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_RESET_MINIMUM, out info.MinReset);
                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_EVENT_MAXIMUM, out info.MaxEvent);
                SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_EVENT_MINIMUM, out info.MinEvent);
				SusiWDog.SusiWDogGetCaps(i, SusiWDog.SUSI_ID_WDT_UNIT_MINIMUM, out info.Unit);

                DevList.Add(info);
                comboBox_DevList.Items.Add(info.Name);
            }

            if (DevList.Count > 0)
            {
                comboBox_DevList.SelectedIndex = 0;
            }
        }

        private void IntCallback(IntPtr context)
        {
            MessageBox.Show("Get IRQ Event!");
        }

        private void comboBox_WDogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];

            label_MaxDelayTime.Text = String.Format("{0} ms", Dev.MaxDelay);
            label_MaxEventTime.Text = String.Format("{0} ms", Dev.MaxEvent);
            label_MaxResetTime.Text = String.Format("{0} ms", Dev.MaxReset);
            label_MinDelayTime.Text = String.Format("{0} ms", Dev.MinDelay);
            label_MinEventTime.Text = String.Format("{0} ms", Dev.MinEvent);
            label_MinResetTime.Text = String.Format("{0} ms", Dev.MinReset);
            label_MinUnit.Text = String.Format("{0} ms", Dev.Unit);

			comboBox_Type.Items.Clear();
			comboBox_Type.Items.Add("None");
			if (Dev.SupportEventFlags != 0)
			{
				if ((Dev.SupportEventFlags & SusiWDog.SUSI_WDT_FLAG_SUPPORT_IRQ) != 0)
					comboBox_Type.Items.Add("IRQ");

				if ((Dev.SupportEventFlags & SusiWDog.SUSI_WDT_FLAG_SUPPORT_SCI) != 0)
					comboBox_Type.Items.Add("SCI");

				if ((Dev.SupportEventFlags & SusiWDog.SUSI_WDT_FLAG_SUPPORT_PWRBTN) != 0)
					comboBox_Type.Items.Add("Power Button");

                if ((Dev.SupportEventFlags & SusiWDog.SUSI_WDT_FLAG_SUPPORT_PIN) != 0)
                    comboBox_Type.Items.Add("PIN");

                comboBox_Type.Enabled = true;
			}
			else
			{
				comboBox_Type.Enabled = false;
			}

			comboBox_Type.SelectedIndex = 0;
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Type.SelectedIndex == 0)
            {
                textBox_Event.Enabled = false;
            }
            else
            {
                textBox_Event.Enabled = true;
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 m_DelayTime = 0;
            UInt32 m_EventTime = 0;
            UInt32 m_ResetTime = 0;
			UInt32 m_EventType = SusiWDog.SUSI_WDT_EVENT_TYPE_NONE;

            try
            {
                m_DelayTime = Convert.ToUInt32(textBox_Delay.Text);
                m_EventTime = Convert.ToUInt32(textBox_Event.Text);
                m_ResetTime = Convert.ToUInt32(textBox_Reset.Text);
            }
            catch
            {
                MessageBox.Show("Please check all input data, those should be numeric.");
                return;
            }

			if (comboBox_Type.Text == "IRQ")
			{
				m_EventType = SusiWDog.SUSI_WDT_EVENT_TYPE_IRQ;
			}
			else if (comboBox_Type.Text == "SCI")
			{
				m_EventType = SusiWDog.SUSI_WDT_EVENT_TYPE_SCI;
			}
			else if (comboBox_Type.Text == "Power Button")
			{
				m_EventType = SusiWDog.SUSI_WDT_EVENT_TYPE_PWRBTN;
			}
            else if (comboBox_Type.Text == "PIN")
            {
                m_EventType = SusiWDog.SUSI_WDT_EVENT_TYPE_PIN;
            }

            if (m_EventType == SusiWDog.SUSI_WDT_EVENT_TYPE_IRQ && m_EventTime > 0)
            {
                fn_callback = new SusiWDog.SUSI_WDT_INT_CALLBACK(IntCallback);
                IntPtr ptr = Marshal.GetFunctionPointerForDelegate(fn_callback);
                SusiWDog.SusiWDogSetCallBack(Dev.ID, ptr, IntPtr.Zero);
            }

			Status = SusiWDog.SusiWDogStart(Dev.ID, m_DelayTime, m_EventTime, m_ResetTime, m_EventType);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiWDogStart failed. (0x{0:X8})", Status));
            }
        }

        private void button_Trigger_Click(object sender, EventArgs e)
        {
            UInt32 Status = SusiWDog.SusiWDogTrigger(Dev.ID);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiWDogStart failed. (0x{0:X8})", Status));
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            UInt32 Status = SusiWDog.SusiWDogStop(Dev.ID);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiWDogStop failed. (0x{0:X8})", Status));

            // Clear Event
            SusiWDog.SusiWDogSetCallBack(Dev.ID, IntPtr.Zero, IntPtr.Zero);
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
