using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        public String _DRAMTYPE = "";
        public UInt16 socket = 0;
        public bool SQR_flag = false;
        RadioButton[] rb = new RadioButton[9];

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
        }

        public bool Available
        {
            get
            {
                UInt32 status, tmp;
                status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_QTY, out tmp);
                return tmp > 0 ? true : false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UInt32 Value;

            Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_QTY, out Value);
            if (Value > 0)
            {
                InitializeRadioButtons(Value);
                GetDRAMValue(0);
                GetDRAMTemperature(0);
            }
            else
            {
                MessageBox.Show("NOT FOUND Device.");
                //this.Close();
            }
        }
        
        public void InitializeRadioButtons(uint num)
        {
            for (int i = 1; i <= 8; i++)
            {
                rb[i] = new RadioButton();

                if (i <= num)
                {
                    rb[i].AutoSize = true;
                    rb[i].Text = "No." + i.ToString();
                    rb[i].Location = new System.Drawing.Point((52 * (i - 1)) + 13, 16);
                    rb[i].TabIndex = i;
                    rb[i].Name = "radioButton" + i.ToString();
                    rb[i].Enabled = true;
                    groupBox1.Controls.Add(rb[i]);
                }
            }
            rb[1].Checked = true;
            rb[1].CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            rb[2].CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            rb[3].CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            rb[4].CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            rb[5].CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            rb[6].CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            rb[7].CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            rb[8].CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
        }

        private void GetDRAMValue(UInt16 n)
        {
            UInt32 Status;
            UInt32 Value, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8;
            SQR_flag = false;

           

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_TYPE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                _DRAMTYPE = Lib.FindDRAMTypeName((byte)Value);
                label_Memory.Text = _DRAMTYPE;
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Memory.Text = "----";
            }
            else
            {
                label_Memory.Text = "";

            }
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_PARTNUMBER1(n), out Value1);
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_PARTNUMBER2(n), out Value2);
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_PARTNUMBER3(n), out Value3);
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_PARTNUMBER4(n), out Value4);
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_PARTNUMBER5(n), out Value5);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                
                if (Value1 == 1397838381)
                    SQR_flag = true;
                UInt32[] SQR = { Value1, Value2, Value3, Value4, Value5 };
                String text = "";
                for (int i = 0; i < 5; i++)
                {
                    text += ((char)((SQR[i] >> 24) & 0xFF)).ToString() +
                        ((char)((SQR[i] >> 16) & 0xFF)).ToString() +
                        ((char)((SQR[i] >> 8) & 0xFF)).ToString() +
                        ((char)(SQR[i] & 0xFF)).ToString();
                    //if (i == 0 && text == "SQR-")
                      //  SQR_flag = true;
                }
                label_PartNum.Text = text;
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_PartNum.Text = "----";
            }
            else
            {
                label_PartNum.Text = "";

            }

            if (SQR_flag)
            {
                label6.Visible = true;
                label_Spe.Visible = true;

                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA1(n), out Value1);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA2(n), out Value2);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA3(n), out Value3);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA4(n), out Value4);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA5(n), out Value5);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA6(n), out Value6);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA7(n), out Value7);
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPECIFICDATA8(n), out Value8);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                   
                    //label6.Visible = true;
                    //label_Spe.Visible = true;
                    UInt32[] SPE = { Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8 };
                    String text = "";
                    for (int i = 0; i < 8; i++)
                    {
                        text += ((char)((SPE[i] >> 24) & 0xFF)).ToString() +
                            ((char)((SPE[i] >> 16) & 0xFF)).ToString() +
                            ((char)((SPE[i] >> 8) & 0xFF)).ToString() +
                            ((char)(SPE[i] & 0xFF)).ToString();
                    }
                    label_Spe.Text = text;
                }
                else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
                {
                    label_Spe.Text = "----";
                }
               
            }
            else
            {
                label6.Visible = false;
                label_Spe.Visible = false;
            }

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_MODULETYPE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (_DRAMTYPE.Substring(0, 4) == "DDR3")
                {
                    label_Module.Text = Lib.FindDDR3ModuleType((byte)Value);
                }
                else if (_DRAMTYPE.Substring(0, 4) == "DDR4")
                {
                    label_Module.Text = Lib.FindDDR4ModuleType((byte)Value);
                }
                else if (_DRAMTYPE.Substring(0, 4) == "DDR5")
                    label_Module.Text = Lib.FindDDR5ModuleType((byte)Value);
                else
                {
                    label_Module.Text = "Unknown";
                }
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Module.Text = "----";
            }
            else
                label_Module.Text = "";

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SIZE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Size.Text = String.Format("{0} GB", Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Size.Text = "----";
            }
            else
            {
                label_Size.Text = "";
                
            }

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_SPEED(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Speed.Text = String.Format("{0} (MT/s)", Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Speed.Text = "----";
            }
            else
            {
                label_Speed.Text = "";
               
            }
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_RANK(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Rank.Text = String.Format("{0} Ranks", Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Rank.Text = "----";
            }
            else
            {
                label_Rank.Text = "";
               
            }

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_VOLTAGE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Vol.Text = String.Format("{0} V", (double)Value / 1000);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Vol.Text = "----";
            }
            else
                label_Vol.Text = "";


            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_BANK(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Bank.Text = String.Format("{0}", Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Bank.Text = "----";
            }
            else
            {
                label_Bank.Text = "";
               
            }
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_WEEKYEAR(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_WeekYear.Text = (Value >> 8).ToString("X2") + " - " + ((byte)Value).ToString("X2");
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_WeekYear.Text = "----";
            }
            else
            {
                label_WeekYear.Text = "";
            }

            if (SQR_flag)
            {
                label_WP.Visible = true;
                label7.Visible = true;
                Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_WRITEPROTECTION(n), out Value1);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    
                    label_WP.Text = (Value1 >> 8).ToString("X2") + " - " + ((byte)Value1).ToString("X2");
                    if (Value1 == 0)
                    {
                        label_WP.Text = "Disable";
                    }
                    else if (Value1 == 0x5750)
                    {
                        label_WP.Text = "Enable";
                    }
                    else
                        label_WP.Text = "Unknown";
                }
                else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
                {
                    label_WP.Text = "----";
                }
            }
            else
            {
                label_WP.Visible = false;
                label7.Visible = false;

            }

            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_MANUFACTURE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //Value = (Value >> 8) + ((Value & 0xFF) << 8);
                label_ModuleManufacture.Text = JEP106.FindManufacture(Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_ModuleManufacture.Text = "----";
            }
            else
            {
                label_ModuleManufacture.Text = "";
            }
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_DRAMIC(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                //Value = (Value >> 8) + ((Value&0xFF) << 8);
                label_DRAMManufacture.Text = JEP106.FindManufacture(Value);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_DRAMManufacture.Text = "----";
            }
            else
            {
                label_DRAMManufacture.Text = "";

            }
        }
        private void GetDRAMTemperature(UInt16 n)
        {
            UInt32 Status;
            UInt32 Value;
            Status = Lib.SusiDeviceGetValue(Lib.SPD_ID_DRAM_TEMPERATURE(n), out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                
                label_Temperature.Text = String.Format("{0} °C", ((Value) / 100.00) - 273.15);
            }
            else if (Status == SusiStatus.SUSI_STATUS_READ_ERROR)
            {
                label_Temperature.Text = "----";
            }
            else
                label_Temperature.Text = "No sensor to detect";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            socket = 0;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            socket = 1;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            socket = 2;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            socket = 3;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            socket = 4;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            socket = 5;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            socket = 6;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            socket = 7;
            GetDRAMValue(socket);
            GetDRAMTemperature(socket);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            GetDRAMTemperature(socket);
        }
    }
}