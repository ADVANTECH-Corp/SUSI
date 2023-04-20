using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using Susi4.Libraries;
//using System.Diagnostics;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        class DeviceInfo
        {
            public UInt32 ID;

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
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_SMB(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;
        
        const UInt32 SMB_PROTOCAL_QUICK = 0;
        const UInt32 SMB_PROTOCAL_BYTE = 1;
        const UInt32 SMB_PROTOCAL_BYTEDATA = 2;
        const UInt32 SMB_PROTOCAL_WORDDATA = 3;
        const UInt32 SMB_PROTOCAL_BLOCK = 4;
        const UInt32 SMB_PROTOCAL_I2CBLOCK = 5;

        private string PreviousData = "00";
        private byte[] baData = new byte[1] { 0 };

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
            InitializeSMB();
        }

        private void PageSMB_Load(object sender, EventArgs e)
        {
            comboBox_Protocal.SelectedIndex = 0;
        }

        private void InitializeSMB()
        {
            UInt32 Status;
            UInt32 Value = 0;

            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_SMBUS_SUPPORTED, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                for (UInt32 i = 0; i < SusiSMB.SUSI_SMBUS_MAX_DEVICE; i++)
                {
                    if ((Value & (1 << (int)i)) > 0)
                    {
                        DeviceInfo info = new DeviceInfo(i);
                        DevList.Add(info);
                        comboBox_DevList.Items.Add(info.Name);
                    }
                }
            }

            if (DevList.Count > 0)
            {
                comboBox_DevList.SelectedIndex = 0;
            }
        }

        private void comboBox_SMBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];
        }

        private void comboBox_Protocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((UInt32)comboBox_Protocal.SelectedIndex)
            {
                case SMB_PROTOCAL_QUICK:
                    textBox_CMD.Enabled = false;
                    textBox_RLength.Enabled = false;
                    textBox_Data.Enabled = false;
                    break;

                case SMB_PROTOCAL_BYTE:
                    textBox_CMD.Enabled = false;
                    textBox_RLength.Enabled = false;
                    textBox_Data.Enabled = true;
                    break;
                
                case SMB_PROTOCAL_BYTEDATA:
                case SMB_PROTOCAL_WORDDATA:
                    textBox_CMD.Enabled = true;
                    textBox_RLength.Enabled = false;
                    textBox_Data.Enabled = true;
                    break;

                case SMB_PROTOCAL_BLOCK:
                case SMB_PROTOCAL_I2CBLOCK:
                    textBox_CMD.Enabled = true;
                    textBox_RLength.Enabled = true;
                    textBox_Data.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void button_Probe_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            StringBuilder sbOutput = new StringBuilder();

			textBox_Result.Text = "Probe process...";
			textBox_Result.Update();

			textBox_Result.Clear();
            sbOutput.Append("Slave address of existed devices:\r\n");

            for (int i = 0x06; i < 0xF0; i += 2)
            {
                Status = SusiSMB.SusiSMBWriteQuick(Dev.ID, (byte)i);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    sbOutput.Append(String.Format("{0:X2} ", i));
                }
            }

            textBox_Result.Text = sbOutput.ToString();
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            byte addr = 0;
            byte cmd = 0;
            UInt32 length = 0;

            StringBuilder sb;
            byte Data_u8;
            byte[] DataBlock;

            textBox_Result.Clear();

            try
            {
                addr = Convert.ToByte(textBox_SlaveAddr.Text, 16);
                cmd = Convert.ToByte(textBox_CMD.Text, 16);
                length = Convert.ToUInt32(textBox_RLength.Text);
            }
            catch
            {
            	MessageBox.Show("Wrong parameter, please check format of inputs.");
                return;
            }

            switch ((UInt32)comboBox_Protocal.SelectedIndex)
            {
                case SMB_PROTOCAL_QUICK:
                    Status = SusiSMB.SusiSMBReadQuick(Dev.ID, addr);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Read Quick failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_BYTE:
                    Status = SusiSMB.SusiSMBReceiveByte(Dev.ID, addr, out Data_u8);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Receice byte failed. (0x{0:X8})", Status);
                    else
                        textBox_Result.Text = Data_u8.ToString("X2");
                    break;

                case SMB_PROTOCAL_BYTEDATA:
                     Status = SusiSMB.SusiSMBReadByte(Dev.ID, addr, cmd, out Data_u8);
                     if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                         textBox_Result.Text = string.Format("Read byte data failed. (0x{0:X8})", Status);
                     else
                        textBox_Result.Text = Data_u8.ToString("X2");
                    break;

                case SMB_PROTOCAL_WORDDATA:
                    UInt16 Data_u16;
                    Status = SusiSMB.SusiSMBReadWord(Dev.ID, addr, cmd, out Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    else
                        textBox_Result.Text = String.Format("{0:X2} {1:X2}", (byte)Data_u16, (byte)(Data_u16 >> 8));
                    break;

                case SMB_PROTOCAL_BLOCK:
                    DataBlock = new byte[length];
                    Status = SusiSMB.SusiSMBReadBlock(Dev.ID, addr, cmd, DataBlock, ref length);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS && Status != SusiStatus.SUSI_STATUS_MORE_DATA)
                    {
                        textBox_Result.Text = string.Format("Read block data failed. (0x{0:X8})", Status);
                    }
                    else
                    {
                        if (Status == SusiStatus.SUSI_STATUS_MORE_DATA)
                        {
                            MessageBox.Show(String.Format("Read block need more length, target size is {0}.", length));
                        }

                        textBox_RLength.Text = length.ToString();

                        if (length > DataBlock.Length)
                            length = (UInt32)DataBlock.Length;

                        sb = new StringBuilder();
                        for (int i = 0; i < length; i++)
                        {
                            sb.Append(string.Format("{0:X2} ", DataBlock[i]));
                        }
                        textBox_Result.Text = sb.ToString();

                    }
                    break;

                case SMB_PROTOCAL_I2CBLOCK:
                    DataBlock = new byte[length];
                    Status = SusiSMB.SusiSMBI2CReadBlock(Dev.ID, addr, cmd, DataBlock, length);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Read I2C block data failed. (0x{0:X8})", Status);
                    else
                    {
                        sb = new StringBuilder();
                        for (int i = 0; i < length; i++)
                        {
                            sb.Append(string.Format("{0:X2} ", DataBlock[i]));
                        }
                        textBox_Result.Text = sb.ToString();
                    }
                    break;

                default:
                    break;
            }
        }

        private void button_Write_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            byte addr = 0;
            byte cmd = 0;
            UInt32 length = 0;

            textBox_Result.Clear();

            try
            {
                addr = Convert.ToByte(textBox_SlaveAddr.Text, 16);
                cmd = Convert.ToByte(textBox_CMD.Text, 16);
                length = Convert.ToUInt32(textBox_WLength.Text);
            }
            catch
            {
                MessageBox.Show("Wrong parameter, please check format of inputs.");
                return;
            }

            switch ((UInt32)comboBox_Protocal.SelectedIndex)
            {
                case SMB_PROTOCAL_QUICK:
                    Status = SusiSMB.SusiSMBWriteQuick(Dev.ID, addr);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Write Quick failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_BYTE:
                    if (baData.Length == 0)
                    {
                        textBox_Result.Text = "Please fill a byte data into InputData field.";
                        break;
                    }
                    Status = SusiSMB.SusiSMBSendByte(Dev.ID, addr, baData[0]);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Send byte failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_BYTEDATA:
                    if (baData.Length == 0)
                    {
                        textBox_Result.Text = "Please fill a byte data into InputData field.";
                        break;
                    }
                    Status = SusiSMB.SusiSMBWriteByte(Dev.ID, addr, cmd, baData[0]);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Write byte data failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_WORDDATA:
                    if (baData.Length < 2)
                    {
                        textBox_Result.Text = "Please fill a word data into InputData field.";
                        break;
                    }
                    UInt16 Data_u16 =  (UInt16)(baData[0] + (baData[1] << 8));
                    Status = SusiSMB.SusiSMBWriteWord(Dev.ID, addr, cmd, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Write word data failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_BLOCK:
                    if (baData.Length == 0)
                    {
                        textBox_Result.Text = "Please fill data into InputData field.";
                        break;
                    }
                    Status = SusiSMB.SusiSMBWriteBlock(Dev.ID, addr, cmd, baData, length);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Write block data failed. (0x{0:X8})", Status);
                    break;

                case SMB_PROTOCAL_I2CBLOCK:
                    if (baData.Length == 0)
                    {
                        textBox_Result.Text = "Please fill data into InputData field.";
                        break;
                    }
                    Status = SusiSMB.SusiSMBI2CWriteBlock(Dev.ID, addr, cmd, baData, length);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Result.Text = string.Format("Write I2C block data failed. (0x{0:X8})", Status);
                    break;

                default:
                    break;
            }
        }

        #region TextKeyPress
        private void textBox_Hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Common.IsHex(e.KeyChar))
                return;
            e.Handled = true;
        }

        private void textBox_Hex_Leave(object sender, EventArgs e)
        {
            TextBox currnet = sender as TextBox;
            try
            {
                UInt32 Value = Convert.ToUInt32(currnet.Text, 16);
                currnet.Text = Value.ToString("X2");
            }
            catch
            {
                currnet.Text = "00";
            }
        }

        private void textBox_RLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void textBox_RLength_Leave(object sender, EventArgs e)
        {
            UInt32 Value;

            if (UInt32.TryParse(textBox_RLength.Text, out Value) == false)
                textBox_RLength.Text = "0";
        }

        private void textBox_Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Common.IsHex(e.KeyChar))
            {
                return;
            }
            
            e.Handled = true;
        }

        private void textBox_Data_Leave(object sender, EventArgs e)
        {
            baData = Common.StringToByteArray(textBox_Data.Text);
            textBox_Data.Text = Common.ByteArrayToHexString(baData);
        }

        private void textBox_Data_TextChanged(object sender, EventArgs e)
        {
            int prevSelection = textBox_Data.SelectionStart;
            byte[] baData = new byte[0];

            try
            {
                if (textBox_Data.Text.Length == 0)
                {
                    textBox_WLength.Text = "0";
                }
                else
                {
                    baData = Common.StringToByteArray(textBox_Data.Text);
                    if (baData.Length == 0)
                    {
                        textBox_Data.Text = PreviousData;
                        textBox_Data.SelectionStart = prevSelection;
                        return;
                    }
                }

                textBox_WLength.Text = baData.Length.ToString();
            }
            catch
            {
                textBox_Data.Text = PreviousData;
                textBox_Data.SelectionStart = prevSelection;
                return;
            }

            PreviousData = textBox_Data.Text;
        }
        #endregion
    }
}
