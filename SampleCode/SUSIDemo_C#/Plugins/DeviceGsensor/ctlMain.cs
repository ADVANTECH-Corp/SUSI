using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;
using System.IO;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        private UInt32 iTime = 0;
        private UInt32 MaxTime_ms = 5000;
        private float fData_Xcal_buf, fData_Ycal_buf, fData_Zcal_buf;
        private bool IsCalibration = false;
        private string PreviousData_Xoffset = "";
        private string PreviousData_Yoffset = "";
        private string PreviousData_Zoffset = "";
        private int PreviousData_indexRate = -1;
        private int PreviousData_indexWakeup = -1;
        private int PreviousData_indexGRange = -1;
        private bool _available = false;
        
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
            UInt32 status, tmp;
            status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_INFO_AVAILABLE, out tmp);
            _available = tmp > 0 ? true : false;
            InitializeComponent();            
        }

		public bool Available
		{
			get
			{
                return _available;
			}
		}

        private void Main_Load(object sender, EventArgs e)
        {
            ComboBox_Rate.Items.Add(".098");
            ComboBox_Rate.Items.Add(".195");
            ComboBox_Rate.Items.Add(".39");
            ComboBox_Rate.Items.Add(".782");
            ComboBox_Rate.Items.Add("1.563");
            ComboBox_Rate.Items.Add("3.125");
            ComboBox_Rate.Items.Add("6.25");
            ComboBox_Rate.Items.Add("12.5");
            ComboBox_Rate.Items.Add("25");
            ComboBox_Rate.Items.Add("50");
            ComboBox_Rate.Items.Add("100");
            ComboBox_Rate.Items.Add("200");
            ComboBox_Rate.Items.Add("400");
            ComboBox_Rate.Items.Add("800");
            ComboBox_Rate.Items.Add("1600");
            ComboBox_Rate.Items.Add("3200");

            ComboBox_Wakeup.Items.Add("8");
            ComboBox_Wakeup.Items.Add("4");
            ComboBox_Wakeup.Items.Add("2");
            ComboBox_Wakeup.Items.Add("1");

            ComboBox_GRange.Items.Add("2g");
            ComboBox_GRange.Items.Add("4g");
            ComboBox_GRange.Items.Add("8g");
            ComboBox_GRange.Items.Add("16g");

            TextBox_Xout.ForeColor = LineChartCtrl_Data.Lin11Color;
            TextBox_Yout.ForeColor = LineChartCtrl_Data.Lin12Color;
            TextBox_Zout.ForeColor = LineChartCtrl_Data.Lin13Color;
            //TextBox_Xout.BackColor = System.Drawing.Color.Black;
            //TextBox_Yout.BackColor = System.Drawing.Color.Black;
            //TextBox_Zout.BackColor = System.Drawing.Color.Black;
            TextBox_Xout.Text = "None";
            TextBox_Yout.Text = "None";
            TextBox_Zout.Text = "None";

            TextBox_Xoffset.ForeColor = LineChartCtrl_Data.Lin11Color;
            TextBox_Yoffset.ForeColor = LineChartCtrl_Data.Lin12Color;
            TextBox_Zoffset.ForeColor = LineChartCtrl_Data.Lin13Color;
            //TextBox_Xoffset.BackColor = System.Drawing.Color.Black;
            //TextBox_Yoffset.BackColor = System.Drawing.Color.Black;
            //TextBox_Zoffset.BackColor = System.Drawing.Color.Black;

            //ToolStripLabel_Status.AutoSize = false;
            //ToolStripLabel_Status.Width = 80;

            //LineChartCtrl_Data.ValueMaximum = 1;
            //LineChartCtrl_Data.ValueMinimum = -1;

            //Button_Refresh.Visible = false;

            ToolStripLabel_Result.Text = "";

            GetRegOffset();
            GetRegFormat();
            GetRegBandwidthRate();
            GetRegPower();

            Timer_ReadData.Interval = 125;
            Timer_ReadData.Enabled = true;

            if (CheckBox_Enable.Checked)
            {
                ToolStripLabel_Status.Text = "Scanning...";
            }
            else
            {
                ToolStripLabel_Status.Text = "System standby";
            }
        }

        private void GetRegOffset()
        {
            UInt32 Status;
            UInt32 Value;

            // get offset
            // X
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_X, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: x-offset. (0x{0:X8})", Status);
                TextBox_Xoffset.Text = "FAIL";
            }
            else
                TextBox_Xoffset.Text = String.Format("{0:G}", (Int32)Value / (float)10000);

            // Y
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_Y, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: y-offset. (0x{0:X8})", Status);
                TextBox_Yoffset.Text = "FAIL";
            }
            else
                TextBox_Yoffset.Text = String.Format("{0:G}", (Int32)Value / (float)10000);

            // Z
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_Z, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: z-offset. (0x{0:X8})", Status);
                TextBox_Zoffset.Text = "FAIL";
            }
            else
                TextBox_Zoffset.Text = String.Format("{0:G}", (Int32)Value / (float)10000);
        }

        private void GetRegFormat()
        {
            UInt32 Status;
            UInt32 Value;

            // get g-range
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_MEASURE_RANGE, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: g-range. (0x{0:X8})", Status);
                ComboBox_GRange.SelectedIndex = -1;
            }
            else
            {
                switch (Value)
                {
                    case 2:
                        ComboBox_GRange.SelectedItem = "2g";
                        break;
                    case 4:
                        ComboBox_GRange.SelectedItem = "4g";
                        break;
                    case 8:
                        ComboBox_GRange.SelectedItem = "8g";
                        break;
                    case 16:
                        ComboBox_GRange.SelectedItem = "16g";
                        break;
                }
            }
        }

        private void GetRegBandwidthRate()
        {
            UInt32 Status;
            UInt32 Value;
            
            // get low power
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_POWER_LOWPOWER, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Read byte data failed: low power. (0x{0:X8})", Status);
            }
            else
            {
                CheckBox_LowPower.Checked = (Value > 0);
            }
            
            // get data output rate
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_DATARATE_NORMAL, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: output rate. (0x{0:X8})", Status);
                ComboBox_Rate.SelectedIndex = -1;
            }
            else
            {
                if (Value >= 0 && Value < ComboBox_Rate.Items.Count)
                    ComboBox_Rate.SelectedIndex = (Int32)Value;
            }
        }

        private void GetRegPower()
        {
            UInt32 Status;
            UInt32 Value;

            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_MEASURE_CTRL, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = string.Format("Read byte data failed: measure. (0x{0:X8})", Status);
            else
                CheckBox_Enable.Checked = (Value > 0);

            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_POWER_SLEEP, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = string.Format("Read byte data failed: sleep. (0x{0:X8})", Status);
            else
                CheckBox_Sleep.Checked = (Value > 0);

            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_DATARATE_SEELP, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //ToolStripLabel_Result.Text = string.Format("Read byte data failed: wake up. (0x{0:X8})", Status);
                ComboBox_Wakeup.SelectedIndex = -1;
            }
            else
            {
                switch (Value)
                {
                    case 8:
                        ComboBox_Wakeup.SelectedItem = "8";
                        break;
                    case 4:
                        ComboBox_Wakeup.SelectedItem = "4";
                        break;
                    case 2:
                        ComboBox_Wakeup.SelectedItem = "2";
                        break;
                    case 1:
                        ComboBox_Wakeup.SelectedItem = "1";
                        break;
                }
            }

            if (CheckBox_Enable.Checked)
                ToolStripLabel_Status.Text = "Scanning...";
            else
                ToolStripLabel_Status.Text = "System standby.";
        }
        
        private void CalibrationOffset()
        {
            UInt32 Status;
            UInt32 Value;

            if (iTime > 0)
            {
                ToolStripLabel_Result.Text = "";

                // X
                Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_X, out Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    ToolStripLabel_Result.Text = string.Format("Read byte data failed: x-offset. (0x{0:X8})", Status);
                else
                {
                    fData_Xcal_buf = 0 - fData_Xcal_buf / iTime + (Int32)Value / (float)10000;
                    Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_X, (UInt32)(fData_Xcal_buf * 10000));
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: x-offset. (0x{0:X8})", Status);
                }

                // Y
                Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_Y, out Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    ToolStripLabel_Result.Text = string.Format("Read byte data failed: y-offset. (0x{0:X8})", Status);
                else
                {
                    fData_Ycal_buf = 0 - fData_Ycal_buf / iTime + (Int32)Value / (float)10000;
                    Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Y, (UInt32)(fData_Ycal_buf * 10000));
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: y-offset. (0x{0:X8})", Status);
                }

                // Z
                Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_OFFSET_Z, out Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    ToolStripLabel_Result.Text = string.Format("Read byte data failed: z-offset. (0x{0:X8})", Status);
                else
                {
                    fData_Zcal_buf = 1 - fData_Zcal_buf / iTime + (Int32)Value / (float)10000;
                    Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Z, (UInt32)(fData_Zcal_buf * 10000));
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                        ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: z-offset. (0x{0:X8})", Status);
                }
            }
            iTime = 0;

            fData_Xcal_buf = 0;
            fData_Ycal_buf = 0;
            fData_Zcal_buf = 0;

            IsCalibration = false;
        }

        private void Timer_ReadData_Tick(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;
            float fData_X, fData_Y, fData_Z;

            //Debug.WriteLine("Timer Start");

            // X
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_DATA_X, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Read word data failed: x-axis. (0x{0:X8})", Status);
                fData_X = 0f;
                TextBox_Xout.Text = "FAIL";
            }
            else
            {
                fData_X = (Int32)Value / (float)10000;
                TextBox_Xout.Text = String.Format("{0:0.000}", fData_X);
            }

            // Y
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_DATA_Y, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Read word data failed: y-axis. (0x{0:X8})", Status);
                fData_Y = 0f;
                TextBox_Yout.Text = "FAIL";                
            }
            else
            {
                fData_Y = (Int32)Value / (float)10000;
                TextBox_Yout.Text = String.Format("{0:0.000}", fData_Y);
            }
            
            // Z
            Status = Lib.SusiDeviceGetValue(Lib.ADXL345_ID_DATA_Z, out Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Read word data failed: z-axis. (0x{0:X8})", Status);
                fData_Z = 0f;
                TextBox_Zout.Text = "FAIL";                
            }
            else
            {
                fData_Z = (Int32)Value / (float)10000;
                TextBox_Zout.Text = String.Format("{0:0.000}", fData_Z);
            }

            LineChartCtrl_Data.AddData(fData_X, fData_Y, fData_Z);

            // calibration
            if (IsCalibration)
            {
                if (iTime * Timer_ReadData.Interval < MaxTime_ms)
                {
                    fData_Xcal_buf += fData_X;
                    fData_Ycal_buf += fData_Y;
                    fData_Zcal_buf += fData_Z;
                    iTime++;
                }
                else
                {
                    CalibrationOffset();
                    GetRegOffset();

                    Button_SetOffset.Enabled = true;
                    Button_ResetOffset.Enabled = true;
                    Button_Reset.Enabled = true;
                }
            }

            //Debug.WriteLine("Timer End");
        }

        private void ComboBox_Rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            if (ComboBox_Rate.SelectedIndex >= 0)
            {
                Value = (UInt32)ComboBox_Rate.SelectedIndex;

                Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_DATARATE_NORMAL, Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    //ToolStripLabel_Result.Text = string.Format("Write byte data failed: rate. (0x{0:X8})", Status);
                    ComboBox_Rate.SelectedIndex = -1;
                }
            }
        }

        private void ComboBox_GRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = 0;

            if (ComboBox_GRange.SelectedIndex >= 0)
            {
                switch (ComboBox_GRange.SelectedIndex)
                {
                    case 0:
                        Value = 2;
                        break;
                    case 1:
                        Value = 4;
                        break;
                    case 2:
                        Value = 8;
                        break;
                    case 3:
                        Value = 16;
                        break;
                }

                Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_MEASURE_RANGE, Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    //ToolStripLabel_Result.Text = string.Format("Write byte data failed: g-range. (0x{0:X8})", Status);
                    ComboBox_GRange.SelectedIndex = -1;
                }
                else
                {
                    LineChartCtrl_Data.ValueMaximum = Value;
                    LineChartCtrl_Data.ValueMinimum = -Value;
                    label_DrawMax.Text = string.Format("{0:G}", Value);
                    label_DrawMin.Text = string.Format("{0:G}", -Value);
                }
            }
        }

        private void Button_SetOffset_Click(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            ToolStripLabel_Result.Text = "";

            if (TextBox_Xoffset.Text == "FAIL")
                TextBox_Xoffset.Text = "0";

            if (TextBox_Yoffset.Text == "FAIL")
                TextBox_Yoffset.Text = "0";

            if (TextBox_Zoffset.Text == "FAIL")
                TextBox_Zoffset.Text = "0";

            Value = (UInt32)(Convert.ToDouble(TextBox_Xoffset.Text) * 10000);
            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_X, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: x-offset. (0x{0:X8})", Status);
            

            Value = (UInt32)(Convert.ToDouble(TextBox_Yoffset.Text) * 10000);
            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Y, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: y-offset. (0x{0:X8})", Status);

            Value = (UInt32)(Convert.ToDouble(TextBox_Zoffset.Text) * 10000);
            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Z, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: z-offset. (0x{0:X8})", Status);

            GetRegOffset();
        }

        private void Button_ResetOffset_Click(object sender, EventArgs e)
        {
            UInt32 Status;

            ToolStripLabel_Result.Text = "";

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_X, 0);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: x-offset. (0x{0:X8})", Status);

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Y, 0);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: y-offset. (0x{0:X8})", Status);

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_OFFSET_Z, 0);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                ToolStripLabel_Result.Text = ToolStripLabel_Result.Text + string.Format("Write byte data failed: z-offset. (0x{0:X8})", Status);

            GetRegOffset();
        }

        private void Button_Calibration_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult = MessageBox.Show(
                string.Format("Place machine in the right direction before Click \"OK\", then wait {0:G} sec.", (Int16)MaxTime_ms / (double)1000),
                "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MsgResult == DialogResult.OK)
            {
                Button_SetOffset.Enabled = false;
                Button_ResetOffset.Enabled = false;
                Button_Reset.Enabled = false;
                IsCalibration = true;
            }
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            GetRegOffset();
            GetRegFormat();
            GetRegBandwidthRate();
            GetRegPower();
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            CheckBox_Enable.Checked = true;
            CheckBox_LowPower.Checked = false;
            CheckBox_Sleep.Checked = false;
            ComboBox_Rate.SelectedItem = "100";
            ComboBox_Wakeup.SelectedItem = "8";
            ComboBox_GRange.SelectedItem = "2g";
            Button_ResetOffset_Click(null, null);
        }

        private void CheckBox_Enable_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            if (CheckBox_Enable.Checked)
            {
                CheckBox_LowPower.Enabled = true;
                CheckBox_Sleep.Enabled = true;
                Value = 1;
                if (CheckBox_Sleep.Checked)
                {
                    ComboBox_Rate.Enabled = false;
                    ComboBox_Wakeup.Enabled = true;
                }
                else
                {
                    ComboBox_Rate.Enabled = true;
                    ComboBox_Wakeup.Enabled = false;
                }
            }
            else
            {
                ComboBox_Rate.Enabled = false;
                ComboBox_Wakeup.Enabled = false;
                CheckBox_LowPower.Enabled = false;
                CheckBox_Sleep.Enabled = false;
                Value = 0;
            }

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_MEASURE_CTRL, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Write byte data failed: measure. (0x{0:X8})", Status);
                GetRegPower();
            }

            Button_Calibration.Enabled = CheckBox_Enable.Checked;

            if (CheckBox_Enable.Checked)
            {
                ToolStripLabel_Status.Text = "Scanning...";
            }
            else
            {
                ToolStripLabel_Status.Text = "System standby";
            }
        }

        private void CheckBox_LowPower_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            if (CheckBox_LowPower.Checked)
                Value = 1;
            else
                Value = 0;

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_POWER_LOWPOWER, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Write byte data failed: low power. (0x{0:X8})", Status);
                GetRegBandwidthRate();
            }

            if (CheckBox_LowPower.Checked)
            {
                ToolStripLabel_Status.Text = "Low power now";
            }
            else
            {
                ToolStripLabel_Status.Text = "Normal power now";
            }
        }

        private void CheckBox_Sleep_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value;

            if (CheckBox_Sleep.Checked)
            {
                ComboBox_Rate.Enabled = false;
                ComboBox_Wakeup.Enabled = true;
                Value = 1;
            }
            else
            {
                ComboBox_Rate.Enabled = true;
                ComboBox_Wakeup.Enabled = false;
                Value = 0;
            }

            Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_POWER_SLEEP, Value);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ToolStripLabel_Result.Text = string.Format("Write byte data failed: sleep. (0x{0:X8})", Status);
                GetRegPower();
            }

            //ComboBox_Wakeup.Enabled = CheckBox_Sleep.Checked;

            if (CheckBox_Sleep.Checked)
                ToolStripLabel_Status.Text = "In sleep mode";
            else
                ToolStripLabel_Status.Text = "In normal mode";
        }

        private void ComboBox_Wakeup_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Value = 0;

            if (ComboBox_Wakeup.SelectedIndex >= 0)
            {
                switch (ComboBox_Wakeup.SelectedIndex)
                {
                    case 0:
                        Value = 8;
                        break;
                    case 1:
                        Value = 4;
                        break;
                    case 2:
                        Value = 2;
                        break;
                    case 3:
                        Value = 1;
                        break;
                }

                Status = Lib.SusiDeviceSetValue(Lib.ADXL345_ID_DATARATE_SEELP, Value);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    //ToolStripLabel_Result.Text = string.Format("Write byte data failed: wake up. (0x{0:X8})", Status);
                    //GetRegPower();
                    ComboBox_Wakeup.SelectedIndex = -1;
                }
            }
        }

        #region TextKeyPress
        private void TextBox_Xoffset_TextChanged(object sender, EventArgs e)
        {
            double Value = 0;

            try
            {
                if (TextBox_Xoffset.Text.Length > 0 && TextBox_Xoffset.Text != "FAIL")
                {
                    if (!(TextBox_Xoffset.Text.Length == 1 && ((TextBox_Xoffset.Text == "+") || (TextBox_Xoffset.Text == "-"))))
                    {
                        Value = Convert.ToDouble(TextBox_Xoffset.Text);
                    }
                }
            }
            catch
            {
                TextBox_Xoffset.Text = PreviousData_Xoffset;
                TextBox_Xoffset.SelectAll();
                return;
            }

            PreviousData_Xoffset = TextBox_Xoffset.Text;            
        }

        private void TextBox_Yoffset_TextChanged(object sender, EventArgs e)
        {
            double Value = 0;

            try
            {
                if (TextBox_Yoffset.Text.Length > 0 && TextBox_Yoffset.Text != "FAIL")
                {
                    if (!(TextBox_Yoffset.Text.Length == 1 && ((TextBox_Yoffset.Text == "+") || (TextBox_Yoffset.Text == "-"))))
                    {
                        Value = Convert.ToDouble(TextBox_Yoffset.Text);
                    }
                }
            }
            catch
            {
                TextBox_Yoffset.Text = PreviousData_Yoffset;
                TextBox_Yoffset.SelectAll();
                return;
            }

            PreviousData_Yoffset = TextBox_Yoffset.Text;
        }

        private void TextBox_Zoffset_TextChanged(object sender, EventArgs e)
        {
            double Value = 0;

            try
            {
                if (TextBox_Zoffset.Text.Length > 0 && TextBox_Zoffset.Text != "FAIL")
                {
                    if (!(TextBox_Zoffset.Text.Length == 1 && ((TextBox_Zoffset.Text == "+") || (TextBox_Zoffset.Text == "-"))))
                    {
                        Value = Convert.ToDouble(TextBox_Zoffset.Text);
                    }
                }
            }
            catch
            {
                TextBox_Zoffset.Text = PreviousData_Zoffset;
                TextBox_Zoffset.SelectAll();
                return;
            }

            PreviousData_Zoffset = TextBox_Zoffset.Text;
        }

        private void TextBox_Xoffset_Leave(object sender, EventArgs e)
        {
            if (TextBox_Xoffset.Text == "" || TextBox_Xoffset.Text == "+" || TextBox_Xoffset.Text == "-")
                TextBox_Xoffset.Text = "0";
            else
                TextBox_Xoffset.Text = String.Format("{0:G}", Convert.ToDouble(TextBox_Xoffset.Text));

        }

        private void TextBox_Yoffset_Leave(object sender, EventArgs e)
        {
            if (TextBox_Yoffset.Text == "" || TextBox_Yoffset.Text == "+" || TextBox_Yoffset.Text == "-")
                TextBox_Yoffset.Text = "0";
            else
                TextBox_Yoffset.Text = String.Format("{0:G}", Convert.ToDouble(TextBox_Yoffset.Text));
        }

        private void TextBox_Zoffset_Leave(object sender, EventArgs e)
        {
            if (TextBox_Zoffset.Text == "" || TextBox_Zoffset.Text == "+" || TextBox_Zoffset.Text == "-")
                TextBox_Zoffset.Text = "0";
            else
                TextBox_Zoffset.Text = String.Format("{0:G}", Convert.ToDouble(TextBox_Zoffset.Text));
        }
        
        private void ComboBox_Rate_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_Rate.Text != "")
            {
                if (ComboBox_Rate.Items.IndexOf(ComboBox_Rate.Text) == -1)
                {
                    ComboBox_Rate.SelectedIndex = PreviousData_indexRate;
                }
                else
                {
                    ComboBox_Rate.SelectedIndex = ComboBox_Rate.Items.IndexOf(ComboBox_Rate.Text);
                }
            }
            PreviousData_indexRate = ComboBox_Rate.SelectedIndex;
        }

        private void ComboBox_Wakeup_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_Wakeup.Text != "")
            {
                if (ComboBox_Wakeup.Items.IndexOf(ComboBox_Wakeup.Text) == -1)
                {
                    ComboBox_Wakeup.SelectedIndex = PreviousData_indexWakeup;
                }
                else
                {
                    ComboBox_Wakeup.SelectedIndex = ComboBox_Wakeup.Items.IndexOf(ComboBox_Wakeup.Text);
                }
            }
            PreviousData_indexWakeup = ComboBox_Wakeup.SelectedIndex;
        }

        private void ComboBox_GRange_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox_GRange.Text != "")
            {
                if (ComboBox_GRange.Items.IndexOf(ComboBox_GRange.Text) == -1)
                {
                    ComboBox_GRange.SelectedIndex = PreviousData_indexGRange;
                }
                else
                {
                    ComboBox_GRange.SelectedIndex = ComboBox_GRange.Items.IndexOf(ComboBox_GRange.Text);
                }
            }
            PreviousData_indexGRange = ComboBox_GRange.SelectedIndex;
        }
        #endregion
    }
}