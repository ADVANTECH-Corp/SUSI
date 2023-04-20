using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using System.Runtime.InteropServices;
using System.Threading;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        class DeviceInfo
        {
            public UInt32 ID;
            public UInt32 SupportInput;
            public UInt32 SupportOutput;
            public UInt32 SupportInterrupt;

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;
                SupportInput = 0;
                SupportOutput = 0;
            }
        }

        class DevPinInfo
        {
            public UInt32 ID;

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            override public string ToString()
            {
                return String.Format("{0} ({1})", ID, Name);
            }

            public DevPinInfo(UInt32 DeviceID)
            {
                ID = DeviceID;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_GPIO(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        const int MAX_BANK_NUM = 4;

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;
        List<DevPinInfo> DevPinList = new List<DevPinInfo>();
        DevPinInfo DevPin = null;

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
            InitializeGPIO();
            InitializePins();
        }

        private void PageGPIO_Load(object sender, EventArgs e)
        {
            radioButton_SinglePin.Checked = true;
        }

        private void InitializeGPIO()
        {
            UInt32 Status;

            for (int i = 0; i < MAX_BANK_NUM; i++)
            {
                DeviceInfo info = new DeviceInfo(SusiGPIO.SUSI_ID_GPIO_BANK((UInt32)i));

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_INPUT_SUPPORT, out info.SupportInput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_OUTPUT_SUPPORT, out info.SupportOutput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                DevList.Add(info);
                comboBox_BankNum.Items.Add(i.ToString());

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_INT_SUPPORT, out info.SupportInterrupt);
            }

            if (DevList.Count > 0)
            {
                comboBox_BankNum.SelectedIndex = 0;
            }
        }

        private void InitializePins()
        {
            StringBuilder sb = new StringBuilder(32);
            UInt32 mask;

            for (int i = 0; i < DevList.Count; i++)
            {
                // 32 pins per bank
                for (int j = 0; j < 32; j++)
                {
                    mask = (UInt32)(1 << j);
                    if ((DevList[i].SupportInput & mask) > 0 || (DevList[i].SupportOutput & mask) > 0)
                    {
                        DevPinInfo pinInfo = new DevPinInfo((UInt32)((i << 5) + j));
                        DevPinList.Add(pinInfo);

                        comboBox_PinNum.Items.Add(pinInfo.ToString());
                    }
                }
            }

            if (DevList.Count > 0)
            {
                comboBox_PinNum.SelectedIndex = 0;
            }
        }

        private void ShowSupportedInfo()
        {
            if (radioButton_SinglePin.Checked)
            {
                if ((DevList[(int)(DevPin.ID >> 5)].SupportInput & (UInt32)(1 << (int)(DevPin.ID & 0x1F))) > 0)
                    label_Inputs.Text = "1";
                else
                    label_Inputs.Text = "0";

                if ((DevList[(int)(DevPin.ID >> 5)].SupportOutput & (UInt32)(1 << (int)(DevPin.ID & 0x1F))) > 0)
                    label_Outputs.Text = "1";
                else
                    label_Outputs.Text = "0";

                if ((DevList[(int)(DevPin.ID >> 5)].SupportInterrupt & (UInt32)(1 << (int)(DevPin.ID & 0x1F))) > 0)
                {
                    label_interrupt.Text = "1";
                    txtEdge3.Enabled = true;
                    txtMask3.Enabled = true;
                }
                else
                {
                    label_interrupt.Text = "0";
                    txtMask3.Enabled = false;
                    txtEdge3.Enabled = false;
                }
            }
            else
            {
                label_Inputs.Text = Convert.ToString(Dev.SupportInput, 2).PadLeft(32, '0');
                label_Outputs.Text = Convert.ToString(Dev.SupportOutput, 2).PadLeft(32, '0');
                label_interrupt.Text = Convert.ToString(Dev.SupportInterrupt, 2).PadLeft(32, '0');
            }
            panel1.Visible = Dev.SupportInterrupt != 0;
            label_interrupt.Visible = panel1.Visible;
            label11.Visible = panel1.Visible;
        }

        private void InputLimitProtect()
        {
            UInt32 mask = (Dev.SupportInput | Dev.SupportOutput) & 0xff;
            bool isZero = (mask == 0);
            textBox_Mask0.Enabled = !isZero;
            textBox_Mask0.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir0.Enabled = !isZero;
            textBox_Level0.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 8) & 0xff;
            isZero = (mask == 0);
            textBox_Mask1.Enabled = !isZero;
            textBox_Mask1.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir1.Enabled = !isZero;
            textBox_Level1.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 16) & 0xff;
            isZero = (mask == 0);
            textBox_Mask2.Enabled = !isZero;
            textBox_Mask2.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir2.Enabled = !isZero;
            textBox_Level2.Enabled = !isZero;

            mask = ((Dev.SupportInput | Dev.SupportOutput) >> 24) & 0xff;
            isZero = (mask == 0);
            textBox_Mask3.Enabled = !isZero;
            textBox_Mask3.Text = Convert.ToString(mask, 2).PadLeft(8, '0');
            textBox_Dir3.Enabled = !isZero;
            textBox_Level3.Enabled = !isZero;

            mask = (Dev.SupportInterrupt) & 0xff;
            isZero = (mask == 0);
            txtMask0.Enabled = !isZero;
            txtEdge0.Enabled = !isZero;

            mask = (Dev.SupportInterrupt >> 8) & 0xff;
            isZero = (mask == 0);
            txtMask1.Enabled = !isZero;
            txtEdge1.Enabled = !isZero;

            mask = (Dev.SupportInterrupt >> 16) & 0xff;
            isZero = (mask == 0);
            txtMask2.Enabled = !isZero;
            txtEdge2.Enabled = !isZero;

            mask = (Dev.SupportInterrupt >> 24) & 0xff;
            isZero = (mask == 0);
            txtMask3.Enabled = !isZero;
            txtEdge3.Enabled = !isZero;
            //txtTrigger3.Enabled = !isZero;

        }

        private void radioButton_SinglePin_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_PinNum.Enabled = radioButton_SinglePin.Checked;
            bool bChecked = radioButton_SinglePin.Checked;

            textBox_Level3.MaxLength = bChecked ? 1 : 8;
            textBox_Dir3.MaxLength = bChecked ? 1 : 8;
            txtMask3.MaxLength = bChecked ? 1 : 8;
            txtEdge3.MaxLength = bChecked ? 1 : 8;
            txtTrigger3.MaxLength = bChecked ? 1 : 8;
            textBox_Level3.Text = bChecked ? "0" : "00000000";
            textBox_Dir3.Text = bChecked ? "0" : "00000000";
            textBox_Mask3.Text = bChecked ? "1" : "00000000";
            txtEdge3.Text = bChecked ? "0" : "00000000";
            txtTrigger3.Text = bChecked ? "0" : "00000000";
            txtMask3.Text = bChecked ? "0" : "00000000";
            textBox_Mask3.ReadOnly = bChecked ? true : false;

            ShowSupportedInfo();
        }

        private void radioButton_MultiPin_CheckedChanged(object sender, EventArgs e)
        {
            bool isMulti = radioButton_MultiPin.Checked;

            textBox_Level2.Visible = isMulti;
            textBox_Level1.Visible = isMulti;
            textBox_Level0.Visible = isMulti;

            textBox_Mask2.Visible = isMulti;
            textBox_Mask1.Visible = isMulti;
            textBox_Mask0.Visible = isMulti;

            textBox_Dir2.Visible = isMulti;
            textBox_Dir1.Visible = isMulti;
            textBox_Dir0.Visible = isMulti;

            comboBox_BankNum.Enabled = isMulti;

            label_Bit0.Visible = isMulti;
            label_Bit8.Visible = isMulti;
            label_Bit16.Visible = isMulti;
            label_Bit24.Visible = isMulti;
            label_Bit31.Visible = isMulti;

            txtMask0.Visible = isMulti;
            txtMask1.Visible = isMulti;
            txtMask2.Visible = isMulti;
            txtEdge0.Visible = isMulti;
            txtEdge1.Visible = isMulti;
            txtEdge2.Visible = isMulti;
            txtTrigger0.Visible = isMulti;
            txtTrigger1.Visible = isMulti;
            txtTrigger2.Visible = isMulti;

            if (radioButton_MultiPin.Checked)
                InputLimitProtect();
            else
            {
                textBox_Level3.Enabled = true;
                textBox_Mask3.Enabled = true;
                textBox_Dir3.Enabled = true;
            }
        }

        private void comboBox_BankNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_BankNum.SelectedIndex];
            ShowSupportedInfo();
            InputLimitProtect();
        }

        private void comboBox_PinNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevPin = DevPinList[comboBox_PinNum.SelectedIndex];
            ShowSupportedInfo();
        }

        private void textBox_Bin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || e.KeyChar == '0' || e.KeyChar == '1')
                return;

            e.Handled = true;
        }

        private void textBox_Bin_Leave(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;

            if (radioButton_SinglePin.Checked)
            {
                if (current.Text.Length < 1)
                    current.Text = "0";
            }
            else
            {
                UInt32 bin = 0;

                if (current.Text.Length > 0)
                {
                    bin = Convert.ToUInt32(current.Text, 2);
                }

                current.Text = Convert.ToString(bin, 2).PadLeft(8, '0');
            }
        }

        private UInt32 GetID()
        {
            if (radioButton_SinglePin.Checked)
                return DevPin.ID;
            else
                return Dev.ID;
        }

        private UInt32 GetMask()
        {
            if (radioButton_SinglePin.Checked)
                return 1;
            else
            {
                UInt32 mask = Convert.ToUInt32(textBox_Mask0.Text, 2);
                mask += Convert.ToUInt32(textBox_Mask1.Text, 2) << 8;
                mask += Convert.ToUInt32(textBox_Mask2.Text, 2) << 16;
                mask += Convert.ToUInt32(textBox_Mask3.Text, 2) << 24;
                return mask;
            }
        }

        private void button_GetLevel_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiGPIO.SusiGPIOGetLevel(GetID(), GetMask(), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (radioButton_SinglePin.Checked)
                {
                    textBox_Level3.Text = Value.ToString();
                }
                else
                {
                    textBox_Level3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Level0.Text = Convert.ToString(Value & 0xFF, 2).PadLeft(8, '0');
                }
            }
            else
                MessageBox.Show(String.Format("SusiGPIOGetLevel() failed. (0x{0:X8})", Status));
        }

        private void button_SetLevel_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = Convert.ToUInt32(textBox_Level3.Text, 2);

            if (radioButton_MultiPin.Checked)
            {
                Value <<= 24;
                Value += Convert.ToUInt32(textBox_Level2.Text, 2) << 16;
                Value += Convert.ToUInt32(textBox_Level1.Text, 2) << 8;
                Value += Convert.ToUInt32(textBox_Level0.Text, 2);
            }

            Status = SusiGPIO.SusiGPIOSetLevel(GetID(), GetMask(), Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiGPIOSetLevel() failed. (0x{0:X8})", Status));
        }

        private void button_GetDir_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiGPIO.SusiGPIOGetDirection(GetID(), GetMask(), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (radioButton_SinglePin.Checked)
                {
                    textBox_Dir3.Text = Value.ToString();
                }
                else
                {
                    textBox_Dir3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                    textBox_Dir0.Text = Convert.ToString(Value & 0xFF, 2).PadLeft(8, '0');
                }
            }
            else
                MessageBox.Show(String.Format("SusiGPIOGetDirection() failed. (0x{0:X8})", Status));
        }

        private void button_SetDir_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = Convert.ToUInt32(textBox_Dir3.Text, 2);

            if (radioButton_MultiPin.Checked)
            {
                Value <<= 24;
                Value += Convert.ToUInt32(textBox_Dir2.Text, 2) << 16;
                Value += Convert.ToUInt32(textBox_Dir1.Text, 2) << 8;
                Value += Convert.ToUInt32(textBox_Dir0.Text, 2);
            }

            Status = SusiGPIO.SusiGPIOSetDirection(GetID(), GetMask(), Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiGPIOSetDirection() failed. (0x{0:X8})", Status));
        }

        private void btnIntPinSet_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Enable = 0;

            if (radioButton_MultiPin.Checked)
            {
                Enable  = Convert.ToUInt32(txtMask3.Text, 2) << 24;
                Enable += Convert.ToUInt32(txtMask2.Text, 2) << 16;
                Enable += Convert.ToUInt32(txtMask1.Text, 2) <<  8;
                Enable += Convert.ToUInt32(txtMask0.Text, 2) <<  0;
            } else
                Enable += Convert.ToUInt32(txtMask3.Text, 2) ;
       
            Status = SusiGPIO.SusiGPIOIntSetPin(GetID(), GetMask(), Enable);

            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiGPIOIntSetPin() failed. (0x{0:X8})", Status));
        }

        private void btnIntEdgeSet_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value  = 0; 

            if (radioButton_MultiPin.Checked)
            {
                Value  = Convert.ToUInt32(txtEdge3.Text, 2) << 24;
                Value += Convert.ToUInt32(txtEdge2.Text, 2) << 16;
                Value += Convert.ToUInt32(txtEdge1.Text, 2) <<  8;
                Value += Convert.ToUInt32(txtEdge0.Text, 2) <<  0;
            }
            else
                Value += Convert.ToUInt32(txtEdge3.Text, 2) << 0;

            Status = SusiGPIO.SusiGPIOIntSetEdge(GetID(), GetMask(), Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("btnIntEdgeSet_Click() failed. (0x{0:X8})", Status));
        }

        static private void OnCallback(IntPtr pPin)
        {
            current.IntCallback(pPin);
        }

        private void IntCallback(IntPtr pPin)
        {
            if (radioButton_MultiPin.Checked)
            {
                int nPin = pPin.ToInt32();
                int nPort = nPin / 8;
                int nBit = nPin % 8;

                if (nPin < 0 && nPin > 16)
                    return;

                System.Windows.Forms.TextBox txt = nPort == 1 ? txtTrigger1 : txtTrigger0;
                if (txt.Text.Length < 8)
                    return;

                char[] str = txt.Text.ToCharArray();
                char c = str[7 - nBit] ;

                c = c == '9' ? '0' : ++c;
                str[7 - nBit] = c;
                txt.ForeColor = System.Drawing.Color.Red;
//                txt.Enabled = true;
                txt.Text = new string(str);
//                txt.Enabled = true;
            }

            else if (GetID() == pPin.ToInt32())
            {
              txtTrigger3.ForeColor = System.Drawing.Color.Red;
//                txtTrigger3.Enabled = true;
                int n = Int32.Parse(txtTrigger3.Text) ;
                n = n >= 9 ? 0 : n + 1;
                txtTrigger3.Text = n.ToString();
            }
        }

        static private  SusiWDog.SUSI_WDT_INT_CALLBACK fn_callback = new SusiWDog.SUSI_WDT_INT_CALLBACK (OnCallback);
        private IntPtr pfn_callback = Marshal.GetFunctionPointerForDelegate (fn_callback);
        public static ctlMain current;

        private void btnIntStart_Click(object sender, EventArgs e)
        {
            UInt32 Status = 0;
            UInt32 Enable = Enable = GetMask(); 

            current = this;

            if (SusiStatus.SUSI_STATUS_SUCCESS != (Status = SusiGPIO.SusiGPIOIntRegister(pfn_callback) ) )
                MessageBox.Show(String.Format("btnIntStart_Click() failed. (0x{0:X8})", Status));
        }

        private void btnIntStop_Click(object sender, EventArgs e)
        {
            UInt32 Status = 0;
            if (SusiStatus.SUSI_STATUS_SUCCESS != (Status = SusiGPIO.SusiGPIOIntUnRegister() ) )
                MessageBox.Show(String.Format("btnIntStop_Click() failed. (0x{0:X8})", Status));
        }

        private void btnIntPinGet_Click(object sender, EventArgs e)
        {
            UInt32 Value;
            UInt32 Status = SusiGPIO.SusiGPIOIntGetPin(GetID(), GetMask(), out Value);

            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("btnIntPinGet_Click() failed. (0x{0:X8})", Status));

            else if (radioButton_MultiPin.Checked)
            {
                txtMask0.Text = Convert.ToString((Value) & 0xFF, 2).PadLeft(8, '0');
                txtMask1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                txtMask2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                txtMask3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');
            }
            else
                txtMask3.Text = Value == 0 ? "0" : "1";
        }

        private void btnIntEdgeGet_Click(object sender, EventArgs e)
        {
            UInt32 Value;
            UInt32 Status = SusiGPIO.SusiGPIOIntGetEdge(GetID(), GetMask(), out Value);

            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("btnIntEdgeGet_Click() failed. (0x{0:X8})", Status));

            else if (radioButton_MultiPin.Checked)
            { 
                txtEdge0.Text = Convert.ToString(Value & 0xFF, 2).PadLeft(8, '0');
                txtEdge1.Text = Convert.ToString((Value >> 8) & 0xFF, 2).PadLeft(8, '0');
                txtEdge2.Text = Convert.ToString((Value >> 16) & 0xFF, 2).PadLeft(8, '0');
                txtEdge3.Text = Convert.ToString((Value >> 24) & 0xFF, 2).PadLeft(8, '0');

}
            else
                txtEdge3.Text = Value == 0 ? "0" : "1";
		}        
    }
}
  
