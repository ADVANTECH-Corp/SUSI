using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PageSetup : UserControl
    {
        public PageSetup()
        {
            InitializeComponent();
        }

        private void PageSetup_Load(object sender, EventArgs e)
        {
            UInt32 status;
            UInt32 Data_u16;
            UInt32 Max, Min;

            #region Load Set up

            #region Low_battery_switch
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_LOW_SWITCH, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Low_battery_switch.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Low_battery_switch.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_BAT_LOW_SWITCH, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label45.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_BAT_LOW_SWITCH, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label45.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label45.Text = String.Format("({0}: Disable, {1}: Enable)", Min, Max);
            #endregion

            #region Battery type setting
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_TYPE, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Battery_type_setting.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Battery_type_setting.Text = String.Format("{0}", Data_u16);
            label1.Text = String.Format("(0: Auto, 1: 12V, 2: 24V)");
            #endregion

            #region 12_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_12V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_12V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_12V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u16 / 10);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_BL_12V, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label17.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_BL_12V, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label17.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label17.Text = String.Format("({0:0.0}~{1:0.0} V)", (double)Min / 10, (double)Max / 10);
            #endregion

            #region 24_low_battery_voltage
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_24V, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_24V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_24V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u16 / 10);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_BL_24V, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label37.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_BL_24V, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label37.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label37.Text = String.Format("({0:0.0}~{1:0.0} V)", (double)Min / 10, (double)Max / 10);
            #endregion

            #region Low_battery_detection_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Low_battery_detection_timer.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_BL_DELAY_OFF, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label38.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_BL_DELAY_OFF, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label38.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label38.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #region Low_battery_hard_off
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Low_battery_Hard_off.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_BL_HARD_OFF, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label39.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_BL_HARD_OFF, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label39.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label39.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #region Ignition_delay_on_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_IGN_DELAY, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Ignition_delay_on_timer.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_IGN_DELAY, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label40.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_IGN_DELAY, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label40.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label40.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #region Ignition_delay_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_DELAY_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Ignition_delay_off_timer.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_DELAY_OFF, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label41.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_DELAY_OFF, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label41.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label41.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #region Hard_off_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_HARD_OFF, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Hard_off_timer.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_HARD_OFF, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label44.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_HARD_OFF, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label44.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label44.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #region Power_off_Retry_times
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_RETRIES, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Power_off_Retry_times.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Power_off_Retry_times.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_PWR_RETRIES, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label42.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_PWR_RETRIES, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label42.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label42.Text = String.Format("({0}~{1} times)", Min, Max);
            #endregion

            #region Power_off_Retry_timer
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_INTERVAL, out Data_u16);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                textBox_Power_off_Retry_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                textBox_Power_off_Retry_timer.Text = String.Format("{0}", Data_u16);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MIN_PWR_INTERVAL, out Min);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label43.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            status = Lib.SusiDeviceGetValue(Lib.PIC_ID_MAX_PWR_INTERVAL, out Max);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                label43.Text = string.Format("Read word data failed. (0x{0:X8})", status);
            else
                label43.Text = String.Format("({0}~{1} sec)", Min, Max);
            #endregion

            #endregion

        }

        private void button_Set_up_Click(object sender, EventArgs e)
        {
            UInt32 Status, status, Data_u32;
            UInt16 Data_u16;
            Double Date;

            if (MessageBox.Show("Do you want to apply setting?", "Apply setting",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {

                try
                {

                    #region Set

                    #region Low_battery_switch
                    Data_u16 = UInt16.Parse(textBox_Low_battery_switch.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BAT_LOW_SWITCH, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Low_battery_switch.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Battery type setting
                    Data_u16 = UInt16.Parse(textBox_Battery_type_setting.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BAT_TYPE, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Battery_type_setting.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region 12V_low_battery_voltage
                    Date = Double.Parse(textBox_12V_low_battery_voltage.Text) * 10;
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_12V, (UInt16)Date);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_12V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region 24V_low_battery_voltage
                    Date = Double.Parse(textBox_24V_low_battery_voltage.Text) * 10;
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_24V, (UInt16)Date);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_24V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Low_battery_detection_timer
                    Data_u16 = UInt16.Parse(textBox_Low_battery_detection_timer.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_DELAY_OFF, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Low_battery_Hard_off
                    Data_u16 = UInt16.Parse(textBox_Low_battery_Hard_off.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_HARD_OFF, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Ignition_delay_on_timer
                    Data_u16 = UInt16.Parse(textBox_Ignition_delay_on_timer.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_IGN_DELAY, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Ignition_delay_off_timer
                    Data_u16 = UInt16.Parse(textBox_Ignition_delay_off_timer.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_DELAY_OFF, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Hard_off_timer
                    Data_u16 = UInt16.Parse(textBox_Hard_off_timer.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_HARD_OFF, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Power_off_Retry_times
                    Data_u16 = UInt16.Parse(textBox_Power_off_Retry_times.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_PWR_RETRIES, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Power_off_Retry_times.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #region Power_off_Retry_timer
                    Data_u16 = UInt16.Parse(textBox_Power_off_Retry_timer.Text);
                    Status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_PWR_INTERVAL, Data_u16);
                    if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        textBox_Power_off_Retry_timer.Text = string.Format("Read word data failed. (0x{0:X8})", Status);
                    }
                    #endregion

                    #endregion
                }
                catch
                {

                }
                try
                {
                    #region Read

                    #region Low_battery_switch
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_LOW_SWITCH, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Low_battery_switch.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Low_battery_switch.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Battery type setting
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_TYPE, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Battery_type_setting.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Battery_type_setting.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region 12_low_battery_voltage
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_12V, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_12V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_12V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u32 / 10);
                    #endregion

                    #region 24_low_battery_voltage
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_24V, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_24V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_24V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u32 / 10);
                    #endregion

                    #region Low_battery_detection_timer
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_DELAY_OFF, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Low_battery_detection_timer.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Low_battery_Hard_off
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_HARD_OFF, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Low_battery_Hard_off.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Ignition_delay_on_timer
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_IGN_DELAY, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Ignition_delay_on_timer.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Ignition_delay_off_timer
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_DELAY_OFF, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Ignition_delay_off_timer.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Hard_off_timer
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_HARD_OFF, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Hard_off_timer.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Power_off_Retry_times
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_RETRIES, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Power_off_Retry_times.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Power_off_Retry_times.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #region Power_off_Retry_timer
                    status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_INTERVAL, out Data_u32);
                    if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                        textBox_Power_off_Retry_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                    else
                        textBox_Power_off_Retry_timer.Text = String.Format("{0}", Data_u32);
                    #endregion

                    #endregion
                }
                catch
                {

                }
                
            }
        }

        private void button_Default_Setting_Click(object sender, EventArgs e)
        {
            UInt32 status;
            UInt32 Data_u32;

            if (MessageBox.Show("Do you want to reset default setting?", "Default setting",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {

                #region Set

                #region Low_battery_switch
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BAT_LOW_SWITCH, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BAT_LOW_SWITCH, Data_u32);
                #endregion

                #region Battery type setting
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BAT_TYPE, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BAT_TYPE, Data_u32);
                #endregion

                #region 12_low_battery_voltage
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BL_12V, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_12V, Data_u32);
                #endregion

                #region 24_low_battery_voltage
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BL_24V, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_24V, Data_u32);
                #endregion

                #region Low_battery_detection_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BL_DELAY_OFF, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_DELAY_OFF, Data_u32);
                #endregion

                #region Low_battery_Hard_off
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_BL_HARD_OFF, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_BL_HARD_OFF, Data_u32);
                #endregion

                #region Ignition_delay_on_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_IGN_DELAY, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_IGN_DELAY, Data_u32);
                #endregion

                #region Ignition_delay_off_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_DELAY_OFF, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_DELAY_OFF, Data_u32);
                #endregion

                #region Hard_off_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_HARD_OFF, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_HARD_OFF, Data_u32);
                #endregion

                #region Power_off_Retry_times
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_PWR_RETRIES, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_PWR_RETRIES, Data_u32);
                #endregion

                #region Power_off_Retry_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_DEF_PWR_INTERVAL, out Data_u32);
                status = Lib.SusiDeviceSetValue(Lib.PIC_ID_SET_PWR_INTERVAL, Data_u32);
                #endregion

                #endregion

                #region Read

                #region Low_battery_switch
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_LOW_SWITCH, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Low_battery_switch.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Low_battery_switch.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Battery type setting
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BAT_TYPE, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Battery_type_setting.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Battery_type_setting.Text = String.Format("{0}", Data_u32);
                #endregion

                #region 12_low_battery_voltage
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_12V, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_12V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_12V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u32 / 10);
                #endregion

                #region 24_low_battery_voltage
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_24V, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_24V_low_battery_voltage.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_24V_low_battery_voltage.Text = String.Format("{0:0.0}", (double)Data_u32 / 10);
                #endregion

                #region Low_battery_detection_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_DELAY_OFF, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Low_battery_detection_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Low_battery_detection_timer.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Low_battery_Hard_off
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_BL_HARD_OFF, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Low_battery_Hard_off.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Low_battery_Hard_off.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Ignition_delay_on_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_IGN_DELAY, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Ignition_delay_on_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Ignition_delay_on_timer.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Ignition_delay_off_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_DELAY_OFF, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Ignition_delay_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Ignition_delay_off_timer.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Hard_off_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_HARD_OFF, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Hard_off_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Hard_off_timer.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Power_off_Retry_times
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_RETRIES, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Power_off_Retry_times.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Power_off_Retry_times.Text = String.Format("{0}", Data_u32);
                #endregion

                #region Power_off_Retry_timer
                status = Lib.SusiDeviceGetValue(Lib.PIC_ID_GET_PWR_INTERVAL, out Data_u32);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                    textBox_Power_off_Retry_timer.Text = string.Format("Read word data failed. (0x{0:X8})", status);
                else
                    textBox_Power_off_Retry_timer.Text = String.Format("{0}", Data_u32);
                #endregion

                #endregion

            }          
        }
    }
}
