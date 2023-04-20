using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PageStatus : UserControl
    {
        public PageStatus()
        {
            InitializeComponent();
        }

        public void PageStatus_Load(object sender, EventArgs e)
        {
            UInt32 status, Data_u16;

            #region Status

            #region FW_Version
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_VER, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_FW_Version.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_FW_Version.Text = String.Format("V.{0:00} version", Data_u16 & 0xFF);
            #endregion

            #region VP_mode
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_SWITCH2_PWR_SELECT, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_VP_mode.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                if (Data_u16 == 0)
                    label_VP_mode.Text = "Vehicle mode";
                else
                    label_VP_mode.Text = "PC mode";
            }
            #endregion

            #region Battery_Type
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_BAT_TYPE, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Battery_Type.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                switch (Data_u16)
                {
                    case 0:
                        label_Battery_Type.Text = "Err";
                        break;
                    case 1:
                        label_Battery_Type.Text = "12V";
                        break;
                    case 2:
                        label_Battery_Type.Text = "24V";
                        break;
                }
            }
            #endregion

            #region SW1_4_status
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_SWITCH1_CFG_SELECT, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_SW1_4_status.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                if (Data_u16 == 0)
                    label_SW1_4_status.Text = "SW mode";
                else
                    label_SW1_4_status.Text = "HW mode";
            }
            #endregion

            #region 12_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_12V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_12_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_12_low_battery_voltage.Text = String.Format("{0:0.0V}", (double)Data_u16 / 10);
            #endregion

            #region 24_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_24V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_24_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_24_low_battery_voltage.Text = String.Format("{0:0.0V}", (double)Data_u16 / 10);
            #endregion

            #region Low_battery_dection_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Low_battery_dection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Low_battery_dection_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Low_battery_Hard_off
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Low_battery_Hard_off.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_delay_on_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_IGN_DELAY, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_delay_on_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_delay_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_delay_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Retry_time_Press_power_button_for_power_off
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_RETRIES, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Retry_time_Press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Retry_time_Press_power_button_for_power_off.Text = String.Format("{0} times", Data_u16);
            #endregion

            #region Power_button_for_power_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_INTERVAL, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Power_button_for_power_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Power_button_for_power_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_Hard_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_Hard_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #endregion

            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UInt32 status, Data_u16;

            #region Status

            #region FW_Version
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_VER, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_FW_Version.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_FW_Version.Text = String.Format("V.{0:00 version}", Data_u16 & 0xFF);
            #endregion

            #region VP_mode
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_SWITCH2_PWR_SELECT, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_VP_mode.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                if (Data_u16 == 0)
                    label_VP_mode.Text = "Vehicle mode";
                else
                    label_VP_mode.Text = "PC mode";
            }
            #endregion

            #region Battery_Type
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_BAT_TYPE, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Battery_Type.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                switch (Data_u16)
                {
                    case 0:
                        label_Battery_Type.Text = "Err";
                        break;
                    case 1:
                        label_Battery_Type.Text = "12V";
                        break;
                    case 2:
                        label_Battery_Type.Text = "24V";
                        break;
                }
            }
            #endregion

            #region SW1_4_status
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_SWITCH1_CFG_SELECT, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_SW1_4_status.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
            {
                if (Data_u16 == 0)
                    label_SW1_4_status.Text = "SW mode";
                else
                    label_SW1_4_status.Text = "HW mode";
            }
            #endregion

            #region 12_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_12V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_12_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_12_low_battery_voltage.Text = String.Format("{0:0.0V}", (double)Data_u16 / 10);
            #endregion

            #region 24_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_24V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_24_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_24_low_battery_voltage.Text = String.Format("{0:0.0V}", (double)Data_u16 / 10);
            #endregion

            #region Low_battery_dection_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Low_battery_dection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Low_battery_dection_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Low_battery_Hard_off
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Low_battery_Hard_off.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_delay_on_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_IGN_DELAY, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_delay_on_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_delay_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_delay_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Retry_time_Press_power_button_for_power_off
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_RETRIES, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Retry_time_Press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Retry_time_Press_power_button_for_power_off.Text = String.Format("{0} times", Data_u16);
            #endregion

            #region Power_button_for_power_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_INTERVAL, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Power_button_for_power_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Power_button_for_power_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Ignition_Hard_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Ignition_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label_Ignition_Hard_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #endregion
        }
    }
}
