using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PageRealTimeStatus : UserControl
    {
        public PageRealTimeStatus()
        {
            InitializeComponent();
        }

        private void PageRealTimeStatus_Load(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Data_u16;

            #region Real-time status

            #region Current_IGN_status
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_IGN_LEVEL, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_IGN_status.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
            {
                if (Data_u16 == 0)
                    label_Current_IGN_status.Text = "off";
                else
                    label_Current_IGN_status.Text = "on";
            }
            #endregion

            #region Current_Ignition_off_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_DELAY_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_Ignition_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_Ignition_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Current_power_input
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_BAT_VOLT, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_power_input.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_power_input.Text = String.Format("{0:0.0V}", (double)Data_u16 * 0.1);
            #endregion

            #region Current_low_battery_detection_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_BL_DELAY_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_low_battery_detection_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region 48V_output
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_V48_STATUS, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_48V_output.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
            {
                if (Data_u16 == 0)
                    label_48V_output.Text = "off";
                else
                    label_48V_output.Text = "on";
            }
            #endregion

            #region Current_retry_times_Press_power_button_for_power_off
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_PWR_OFF_RETRIES, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_retry_times_Press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_retry_times_Press_power_button_for_power_off.Text = String.Format("{0} times", Data_u16);
            #endregion

            #region Current_timer_press_power_button_for_power_off
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_PWR_OFF_INTERVAL, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_timer_press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_timer_press_power_button_for_power_off.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Current_hard_off_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_HARD_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_hard_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #endregion

            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UInt32 Status;
            UInt32 Data_u16;

            #region Real-time status

            #region Current_IGN_status
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_IGN_LEVEL, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_IGN_status.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
            {
                if (Data_u16 == 0)
                    label_Current_IGN_status.Text = "off";
                else
                    label_Current_IGN_status.Text = "on";
            }
            #endregion

            #region Current_Ignition_off_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_DELAY_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_Ignition_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_Ignition_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Current_power_input
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_BAT_VOLT, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_power_input.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_power_input.Text = String.Format("{0:0.0V}", (double)Data_u16 * 0.1);
            #endregion

            #region Current_low_battery_detection_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_BL_DELAY_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_low_battery_detection_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region 48V_output
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_FW_V48_STATUS, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_48V_output.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
            {
                if (Data_u16 == 0)
                    label_48V_output.Text = "off";
                else
                    label_48V_output.Text = "on";
            }
            #endregion

            #region Current_retry_times_Press_power_button_for_power_off
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_PWR_OFF_RETRIES, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_retry_times_Press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_retry_times_Press_power_button_for_power_off.Text = String.Format("{0} times", Data_u16);
            #endregion

            #region Current_timer_press_power_button_for_power_off
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_PWR_OFF_INTERVAL, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_timer_press_power_button_for_power_off.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_timer_press_power_button_for_power_off.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #region Current_hard_off_timer
            Status = Lib.SusiDeviceGetValue(Lib.PIC_ID_TIMER_TMR_HARD_OFF, out Data_u16);
            if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                label_Current_hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
            else
                label_Current_hard_off_timer.Text = String.Format("{0} sec", Data_u16);
            #endregion

            #endregion
        }
    }
}
