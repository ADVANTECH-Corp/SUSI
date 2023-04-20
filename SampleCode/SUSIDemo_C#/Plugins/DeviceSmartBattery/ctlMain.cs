using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        string Unit = "";

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
                status = Lib.SusiDeviceGetValue(Lib.SBS_ID_BASE, out tmp);
                return status == SusiStatus.SUSI_STATUS_SUCCESS ? true : false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UInt32 Value;

            Lib.SusiDeviceGetValue(Lib.SBS_ID_BASE, out Value);
            if (Value >= 0)
            {
                GetBasicInfo();
                GetSBSInfo();
            }
            else
            {
                MessageBox.Show("NOT FOUND Device.");
                //this.Close();
            }
        }

        private void GetBasicInfo()
        {
            UInt32 Status;
            UInt32 Value;

            UInt32 Value1, Value2, Value3, Value4, Value5;

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_Unit, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                Unit = (Value == 1 ? "0 mW" : " mAh");

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_DesignCapacity, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_DC.Text = (ushort)Value + Unit;
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_DesignVoltage, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_DV.Text = Value + " mV";
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerDate, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_MD.Text = ((Value >> 9) + 1980) + "/" + ((Value >> 5) & 0xF) + "/" + (Value & 0x01F);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_SerialNumber, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_SN.Text = "0x" + Value.ToString("X4");
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName_Len, out Value);
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName1, out Value1);
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName2, out Value2);
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName3, out Value3);
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName4, out Value4);
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_ManufacturerName5, out Value5);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                UInt32[] Manu = { Value1, Value2, Value3, Value4, Value5 };
                String text = "";
                for (int i = 0; i < 5; i++)
                {
                    text += ((char)((Manu[i] >> 24) & 0xFF)).ToString() +
                        ((char)((Manu[i] >> 16) & 0xFF)).ToString() +
                        ((char)((Manu[i] >> 8) & 0xFF)).ToString() +
                        ((char)(Manu[i] & 0xFF)).ToString();
                }
                label_Manu.Text = text;
            }
        }

        private void GetSBSInfo()
        {
            UInt32 Status;
            UInt32 Value;
            UInt32 charge;
            UInt32 ErrorCode = 0;
            Int16 current = 0;
            
            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_Unit, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                Unit = (Value == 1 ? "0 mWh" : " mAh");

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_Voltage, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Vol.Text = String.Format("{0} mV", Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_Current, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                current = (short)Value;
                label_Cur.Text = String.Format("{0} mA", current);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_RelativeStateOfCharge, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_RSC.Text = String.Format("{0} %", Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_AbsoluteStateOfCharge, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_ASC.Text = String.Format("{0} %", Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_SoH, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_SoH.Text = String.Format("{0} %", Value);
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_FullChargeCapacity, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_FCC.Text = Convert.ToUInt16(Value).ToString() + Unit;
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_RemainingCapacity, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_RC.Text = Convert.ToUInt16(Value).ToString() + Unit;
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_AverageTimeToEmpty, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (current == 0 || Value == 65535)
                {
                    label_ATTE.Text = " --";
                }
                else
                {
                    label_ATTE.Text = String.Format("{0} h {1} m", Convert.ToUInt16(Value) / 60, Convert.ToUInt16(Value) % 60);
                }
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_AverageTimeToFull, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                if (current == 0 || Value == 65535)
                {
                    label_ATTF.Text = " --";
                }
                else
                {
                    label_ATTF.Text = String.Format("{0} h {1} m", Convert.ToUInt16(Value) / 60, Convert.ToUInt16(Value) % 60);
                }
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_BatteryStatus, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                charge = (Value & 0x40) >> 6;
                if (current == 0)
                    label_BS.Text = "AC Power";
                else
                    label_BS.Text = (charge > 0 ? "Discharging" : "Charging") ;
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_BatteryStatus, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                ErrorCode = (Value & 0x0000000F);
                label_EC.Text = "0x" + ErrorCode.ToString("X2");
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_CycleCount, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_CC.Text = Value + " cycles";
            }

            Status = Lib.SusiDeviceGetValue(Lib.SBS_ID_Temperature, out Value);
            if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
            {
                label_Temp.Text = String.Format("{0:F} °C", (Value * 0.10) - 273.15);
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetSBSInfo();
        }

    }
}