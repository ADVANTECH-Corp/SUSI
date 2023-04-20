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
            public UInt32 TotalSize;
            public UInt32 BlockSize;
            public UInt32 MaxKeySize;

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;
                BlockSize = 0;
                MaxKeySize = 0;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_STORAGE(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
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
            InitializeStorage();
        }

        private void InitializeStorage()
        {
            UInt32 Status;

            for (UInt32 i = 0; i < SusiStorage.SUSI_ID_STORAGE_MAX; i++)
            {
                DeviceInfo info = new DeviceInfo(i);

                Status = SusiStorage.SusiStorageGetCaps(info.ID, SusiStorage.SUSI_ID_STORAGE_TOTAL_SIZE, out info.TotalSize);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                Status = SusiStorage.SusiStorageGetCaps(info.ID, SusiStorage.SUSI_ID_STORAGE_BLOCK_SIZE, out info.BlockSize);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    info.BlockSize = 0;

                Status = SusiStorage.SusiStorageGetCaps(info.ID, SusiStorage.SUSI_ID_STORAGE_PSW_MAX_LEN, out info.MaxKeySize);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    info.MaxKeySize = 0;

                DevList.Add(info);
                comboBox_DevList.Items.Add(info.Name);
            }

            if (DevList.Count > 0)
            {
                comboBox_DevList.SelectedIndex = 0;
            }
        }

        private void comboBox_DevList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dev = DevList[comboBox_DevList.SelectedIndex];

            label_TotalSize.Text = Dev.TotalSize.ToString();
            label_BlockSize.Text = Dev.BlockSize.ToString();

            if (Dev.MaxKeySize > 0)
            {
                label_MaxLen.Text = Dev.MaxKeySize.ToString();
                textBox_Password.MaxLength = (int)Dev.MaxKeySize;
                GetStatus();
                groupBox_WriteProtection.Enabled = true;
            }
            else
            {
                groupBox_WriteProtection.Enabled = false;
            }
        }

        #region Access
        private void button_Write_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 offset = Convert.ToUInt32(textBox_Offset.Text, 16);

            Status = SusiStorage.SusiStorageAreaWrite(Dev.ID, offset, baData, (UInt32)baData.Length);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Result.Text = String.Format("SusiStorageAreaWrite() failed. (0x{0:X8})", Status);
			else
				textBox_Result.Text = String.Format("SusiStorageAreaWrite() succeeded.");
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 offset = Convert.ToUInt32(textBox_Offset.Text, 16);
            UInt32 len = Convert.ToUInt32(textBox_RLen.Text);
            byte[] data = new byte[len];

            Status = SusiStorage.SusiStorageAreaRead(Dev.ID, offset, data, (UInt32)data.Length);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Result.Text = String.Format("SusiStorageAreaRead() failed. (0x{0:X8})", Status);
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(string.Format("{0:X2} ", data[i]));
                }
                textBox_Result.Text = sb.ToString();
            }
        }

        private void textBox_Offset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Common.IsHex(e.KeyChar))
                return;
            e.Handled = true;
        }

        private void textBox_Offset_Leave(object sender, EventArgs e)
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

        private void textBox_RLen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void textBox_RLen_Leave(object sender, EventArgs e)
        {
            UInt32 Value;

            if (UInt32.TryParse(textBox_RLen.Text, out Value) == false)
                textBox_RLen.Text = "1";
        }

        private void textBox_Data_TextChanged(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;

            int prevSelection = current.SelectionStart;
            byte[] baData = new byte[0];

            try
            {
                if (current.Text.Length == 0)
                {
                    textBox_WLen.Text = "0";
                }
                else
                {
                    baData = Common.StringToByteArray(current.Text);
                    if (baData.Length == 0)
                    {
                        current.Text = PreviousData;
                        current.SelectionStart = prevSelection;
                        return;
                    }
                }

                textBox_WLen.Text = baData.Length.ToString();
            }
            catch
            {
                current.Text = PreviousData;
                current.SelectionStart = prevSelection;
                return;
            }

            PreviousData = current.Text;
        }

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
        #endregion

        #region Write protection
        private void GetStatus()
        {
            UInt32 Status;
            UInt32 Value;

            Status = SusiStorage.SusiStorageGetCaps(Dev.ID, SusiStorage.SUSI_ID_STORAGE_LOCK_STATUS, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiStorageGetCaps(SUSI_ID_STORAGE_LOCK_STATUS) failed. (0x{0:X8})", Status));
            else
                label_Status.Text = (Value == SusiStorage.SUSI_STORAGE_STATUS_LOCK) ? "Lock" : "Unlock";
        }

        private void button_GetStatus_Click(object sender, EventArgs e)
        {
            GetStatus();
        }

        private void button_Lock_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(textBox_Password.Text);

            Status = SusiStorage.SusiStorageAreaSetLock(Dev.ID, data, (UInt32)data.Length);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiStorageAreaSetLock() failed. (0x{0:X8})", Status));
        }

        private void button_Unlock_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(textBox_Password.Text);

            Status = SusiStorage.SusiStorageAreaSetUnlock(Dev.ID, data, (UInt32)data.Length);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                MessageBox.Show(String.Format("SusiStorageAreaSetUnlock() failed. (0x{0:X8})", Status));
        }
        #endregion

    }
}
