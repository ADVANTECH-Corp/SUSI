using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using Susi4.Libraries;

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
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_I2C(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        DeviceInfo Dev = null;

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
            InitializeI2C();
        }

        private void PageI2C_Load(object sender, EventArgs e)
        {
            radioButton_ProtocalTransfer.Checked = true;
            radioButton_Addr7bit.Checked = true;
            radioButton_CMDByte.Checked = true;

            textBox_Data.Text = PreviousData;
        }

        private void InitializeI2C()
        {
            UInt32 Status;
            UInt32 Value = 0;

            Status = SusiBoard.SusiBoardGetValue(SusiBoard.SUSI_ID_I2C_SUPPORTED, ref Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                for (UInt32 i = 0; i < SusiI2C.SUSI_I2C_MAX_DEVICE; i++)
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

        #region Protocal
        private void radioButton_ProtocalCombine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ProtocalCombine.Checked)
            {
                radioButton_CMDByte.Checked = true;
                radioButton_Addr7bit.Checked = true;
            }
        }

        private void radioButton_ProtocalTransfer_CheckedChanged(object sender, EventArgs e)
        {
            bool en = radioButton_ProtocalTransfer.Checked;

            radioButton_Addr10bit.Enabled = en;
            radioButton_Addr7bit.Enabled = en;
            groupBox_CMD.Enabled = en;

            button_Read.Enabled = en;
            button_Write.Enabled = en;
            button_WR.Enabled = !en;
        }
        #endregion

        #region Frequency
        private void GetFrequency()
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiI2C.SusiI2CGetFrequency(Dev.ID, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (Value > 100)
                    radioButton_Freq400.Checked = true;
                else
                    radioButton_Freq0to100.Checked = true;

                textBox_Freq.Text = Value.ToString();
                groupBox_Freq.Enabled = true;
            }
            else
            {
                groupBox_Freq.Enabled = false;
            }
        }

        private void button_GetFreq_Click(object sender, EventArgs e)
        {
            GetFrequency();
        }

        private void button_SetFreq_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = Convert.ToUInt32(textBox_Freq.Text);

            Status = SusiI2C.SusiI2CSetFrequency(Dev.ID, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("SusiI2CSetFrequency() failed. (0x{0:X8})", Status));
            }
        }

        private void radioButton_Freq400_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Freq400.Checked)
            {
                textBox_Freq.Text = "400";
                textBox_Freq.ReadOnly = true;
            }
        }

        private void radioButton_Freq0to100_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Freq0to100.Checked)
            {
                textBox_Freq.ReadOnly = false;
                if (textBox_Freq.Text == "400")
                {
                    textBox_Freq.Text = "100";
                }
            }
        }

        private void textBox_Freq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;
            e.Handled = true;
        }
        #endregion

        #region Address
        private void radioButton_Addr7bit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Addr7bit.Checked)
            {
                textBox_SlaveAddr.MaxLength = 2;
                NormalizeAddress();
            }
        }

        private void radioButton_Addr10bit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Addr10bit.Checked)
            {
                textBox_SlaveAddr.MaxLength = 4;
                NormalizeAddress();
            }
        }

        private void NormalizeAddress()
        {
            if (radioButton_Addr7bit.Checked)
            {
                if (textBox_SlaveAddr.Text.Length > 2)
                    textBox_SlaveAddr.Text = textBox_SlaveAddr.Text.Substring(textBox_SlaveAddr.Text.Length - textBox_SlaveAddr.MaxLength);
                else if (textBox_SlaveAddr.Text.Length == 0)
                    textBox_SlaveAddr.Text = "00";
                else
                {
                    UInt32 tmp_u32 = Convert.ToUInt32(textBox_SlaveAddr.Text, 16);
                    textBox_SlaveAddr.Text = tmp_u32.ToString("X2");
                }
            }
            else
            {
                if (textBox_SlaveAddr.Text.Length == 0)
                    textBox_SlaveAddr.Text = "0000";
                else
                {
                    UInt32 tmp_u32 = Convert.ToUInt32(textBox_SlaveAddr.Text, 16);
                    textBox_SlaveAddr.Text = tmp_u32.ToString("X4");
                }
            }
        }

        private void textBox_SlaveAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Common.IsHex(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;
            e.Handled = true;
        }

        private void textBox_SlaveAddr_Leave(object sender, EventArgs e)
        {
            NormalizeAddress();
        }
        #endregion

        #region Command
        private void radioButton_CMDByte_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CMDByte.Checked)
            {
                textBox_CMD.MaxLength = 2;
                NormalizeCMD();
            }
        }

        private void radioButton_CMDWord_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CMDWord.Checked)
            {
                textBox_CMD.MaxLength = 4;
                NormalizeCMD();
            }
        }

        private void radioButton_CMDNone_CheckedChanged(object sender, EventArgs e)
        {
            textBox_CMD.Enabled = !radioButton_CMDNone.Checked;
        }

        private void textBox_CMD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Common.IsHex(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;
            e.Handled = true;
        }

        private void NormalizeCMD()
        {
            if (radioButton_CMDByte.Checked)
            {
                if (textBox_CMD.Text.Length > 2)
                    textBox_CMD.Text = textBox_CMD.Text.Substring(textBox_CMD.Text.Length - textBox_CMD.MaxLength);
                else if (textBox_CMD.Text.Length == 0)
                    textBox_CMD.Text = "00";
                else
                {
                    UInt32 tmp_u32 = Convert.ToUInt32(textBox_CMD.Text, 16);
                    textBox_CMD.Text = tmp_u32.ToString("X2");
                }
            }
            else
            {
                if (textBox_CMD.Text.Length == 0)
                    textBox_CMD.Text = "0000";
                else
                {
                    UInt32 tmp_u32 = Convert.ToUInt32(textBox_CMD.Text, 16);
                    textBox_CMD.Text = tmp_u32.ToString("X4");
                }
            }
        }

        private void textBox_CMD_Leave(object sender, EventArgs e)
        {
            NormalizeCMD();
        }
        #endregion

        #region Input data
        private void textBox_Data_Leave(object sender, EventArgs e)
        {
            baData = Common.StringToByteArray(textBox_Data.Text);
            textBox_Data.Text = Common.ByteArrayToHexString(baData);
        }

        private void textBox_Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Char.IsSeparator(e.KeyChar) || Common.IsHex(e.KeyChar))
                return;

            e.Handled = true;
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

        private void comboBox_I2CList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];
            GetFrequency();
        }

        private void textBox_RLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;
            e.Handled = true;
        }

        private void ShowResult(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(string.Format("{0:X2} ", data[i]));
            }
            textBox_Result.Text = sb.ToString().TrimEnd();
        }

        private void button_WR_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 addr = 0;
            UInt32 cmd = 0;
            UInt32 length = 0;
            UInt32 rlength = 0;

            textBox_Result.Clear();

            try
            {
                addr = Convert.ToUInt32(textBox_SlaveAddr.Text, 16);
                cmd = Convert.ToUInt32(textBox_CMD.Text, 16);
                length = Convert.ToUInt32(textBox_WLength.Text);
                rlength = Convert.ToUInt32(textBox_RLength.Text);
            }
            catch
            {
                MessageBox.Show("Wrong parameter, please check format of inputs.");
                return;
            }

            byte[] rData = new byte[rlength];
            if (rlength == 0)
                rData = null;

            Status = SusiI2C.SusiI2CWriteReadCombine(Dev.ID, (byte)addr, baData, length, rData, rlength);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                textBox_Result.Text = String.Format("Write read combine failed. (0x{0:X8})", Status);
            }
            else
            {
                ShowResult(rData);
            }
        }

        private void button_Probe_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            StringBuilder sbOutput = new StringBuilder();

			textBox_Result.Text = "Probe process...";            
			textBox_Result.Update();

			textBox_Result.Clear();

            if (radioButton_Addr10bit.Checked)
            {
                sbOutput.Append(String.Format("Slave address (10-bit) of existed devices:\r\n"));

                for (UInt32 i = 0; i < 0x400; i++)
                {
                    Status = SusiI2C.SusiI2CProbeDevice(Dev.ID, SusiI2C.SUSI_I2C_ENC_10BIT_ADDR(i));
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        sbOutput.Append(String.Format("{0:X4} ", i));
                    }
                }
            }
            else
            {
                sbOutput.Append(String.Format("Slave address (7-bit) of existed devices:\r\n"));
                for (UInt32 i = 0x03; i < 0x78; i++)
                {
                    Status = SusiI2C.SusiI2CProbeDevice(Dev.ID, SusiI2C.SUSI_I2C_ENC_7BIT_ADDR(i));
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        sbOutput.Append(String.Format("{0:X2} ", SusiI2C.SUSI_I2C_ENC_7BIT_ADDR(i)));
                    }
                }
            }

            textBox_Result.Text = sbOutput.ToString().TrimEnd();
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 addr = 0;
            UInt32 cmd = 0;
            UInt32 length = 0;

            textBox_Result.Clear();

            try
            {
                addr = Convert.ToUInt32(textBox_SlaveAddr.Text, 16);
                cmd = Convert.ToUInt32(textBox_CMD.Text, 16);
                length = Convert.ToUInt32(textBox_RLength.Text);
            }
            catch
            {
                MessageBox.Show("Wrong parameter, please check format of inputs.");
                return;
            }

            if (radioButton_Addr10bit.Checked)
            {
                addr = SusiI2C.SUSI_I2C_ENC_10BIT_ADDR(addr);
            }

            if (radioButton_CMDWord.Checked)
            {
                cmd = SusiI2C.SUSI_I2C_ENC_EXT_CMD(cmd);
            }
            else if (radioButton_CMDNone.Checked)
            {
                cmd = SusiI2C.SUSI_I2C_ENC_NO_CMD(cmd);
            }

            byte[] rData = new byte[length];
            Status = SusiI2C.SusiI2CReadTransfer(Dev.ID, addr, cmd, rData, length);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ShowResult(rData);
            }
            else
            {
                textBox_Result.Text = String.Format("Read transfer failed. (0x{0:X8})", Status);
            }
        }

        private void button_Write_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 addr = 0;
            UInt32 cmd = 0;
            UInt32 length = 0;

            textBox_Result.Clear();

            try
            {
                addr = Convert.ToUInt32(textBox_SlaveAddr.Text, 16);
                cmd = Convert.ToUInt32(textBox_CMD.Text, 16);
                length = Convert.ToUInt32(textBox_WLength.Text);
            }
            catch
            {
                MessageBox.Show("Wrong parameter, please check format of inputs.");
                return;
            }

            if (radioButton_Addr10bit.Checked)
            {
                addr = SusiI2C.SUSI_I2C_ENC_10BIT_ADDR(addr);
            }

            if (radioButton_CMDWord.Checked)
            {
                cmd = SusiI2C.SUSI_I2C_ENC_EXT_CMD(cmd);
            }
            else if (radioButton_CMDNone.Checked)
            {
                cmd = SusiI2C.SUSI_I2C_ENC_NO_CMD(cmd);
            }

            Status = SusiI2C.SusiI2CWriteTransfer(Dev.ID, addr, cmd, baData, length);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                textBox_Result.Text = String.Format("Write transfer failed. (0x{0:X8})", Status);
            }
        }
    }
}
