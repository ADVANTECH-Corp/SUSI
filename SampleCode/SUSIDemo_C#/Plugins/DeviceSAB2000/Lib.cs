using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
    public static class Lib
    {
        public const UInt32 SAB2000_ID_BASE = 0x00800000;

        public const UInt32 SAB2000_ID_INFO_TYPE = 0x00000;
        public const UInt32 SAB2000_ID_INFO_BASE = (SAB2000_ID_BASE | SAB2000_ID_INFO_TYPE);
        public const UInt32 SAB2000_ID_DEVICE_AVAILABLE = (SAB2000_ID_INFO_BASE + 0);
        //--------------------------------
        // [7:0]	(byte) Version 0
        // [15:8]	(byte) Version 1
        // [23:16]	(char)
        // [31:24]	Reserved
        public const UInt32 SAB2000_ID_FW_VER = (SAB2000_ID_INFO_BASE + 1);
        //--------------------------------
        // [7:0]	(byte) TBD
        // [15:8]	(byte) 0x12: 8512, 0x16: 8516, 0x18: 8518
        // [23:16]	(char) I: ITE, N: ENE
        // [31:24]	Reserved
        public const UInt32 SAB2000_ID_EC_TYPE = (SAB2000_ID_INFO_BASE + 2);
        //--------------------------------
        // [7:0]	(byte) Minor
        // [15:8]	(byte) Major
        // [23:16]	(char) X or V
        // [31:24]	Reserved
        public const UInt32 SAB2000_ID_KERNEL_VER = (SAB2000_ID_INFO_BASE + 3);
        public const UInt32 SAB2000_ID_CASEOPEN = (SAB2000_ID_INFO_BASE + 0x10);


        public const UInt32 SAB2000_ID_CTRL_TYPE = 0x10000;
        public const UInt32 SAB2000_ID_CTRL_BASE = (SAB2000_ID_BASE | SAB2000_ID_CTRL_TYPE);
        //--------------------------------
        // [0]	 0: OFF, 1: ON	(RW)
        public const UInt32 SAB2000_ID_CTRL_ALERT = (SAB2000_ID_CTRL_BASE + 0);
        // [1:0] 1: Winbond, 2: Nuvoton	
        public const UInt32 SAB2000_ID_CTRL_CHIP = (SAB2000_ID_CTRL_BASE + 1);


        public const UInt32 SAB2000_ID_HWM_TEMP_TYPE = 0x20000;
        public const UInt32 SAB2000_ID_HWM_TEMP_BASE = (SAB2000_ID_BASE | SAB2000_ID_HWM_TEMP_TYPE);
        public const UInt32 SAB2000_ID_HWM_TEMP_VTIN1 = (SAB2000_ID_HWM_TEMP_BASE + 0x000);	         // Unit: 0.1 Kelvins
        public const UInt32 SAB2000_ID_HWM_TEMP_VTIN2 = (SAB2000_ID_HWM_TEMP_BASE + 0x001);
        public const UInt32 SAB2000_ID_HWM_TEMP_VTIN3 = (SAB2000_ID_HWM_TEMP_BASE + 0x002);
        public const UInt32 SAB2000_ID_HWM_TEMP_BT1 = (SAB2000_ID_HWM_TEMP_BASE + 0x003);
        public const UInt32 SAB2000_ID_HWM_TEMP_BT2 = (SAB2000_ID_HWM_TEMP_BASE + 0x004);
        public const UInt32 SAB2000_ID_HWM_TEMP_BT3 = (SAB2000_ID_HWM_TEMP_BASE + 0x005);
        public const UInt32 SAB2000_ID_HWM_TEMP_BT4 = (SAB2000_ID_HWM_TEMP_BASE + 0x006);
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_VTIN1 = (SAB2000_ID_HWM_TEMP_BASE + 0x100);   // RW
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_VTIN2 = (SAB2000_ID_HWM_TEMP_BASE + 0x101);	// RW
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_BT1 = (SAB2000_ID_HWM_TEMP_BASE + 0x103);	    // RW
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_BT2 = (SAB2000_ID_HWM_TEMP_BASE + 0x104);	    // RW
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_BT3 = (SAB2000_ID_HWM_TEMP_BASE + 0x105);	    // RW
        public const UInt32 SAB2000_ID_HWM_TEMP_ALERT_BT4 = (SAB2000_ID_HWM_TEMP_BASE + 0x106);	    // RW


        public const UInt32 SAB2000_ID_HWM_VOLT_TYPE = 0x21000;
        public const UInt32 SAB2000_ID_HWM_VOLT_BASE = (SAB2000_ID_BASE | SAB2000_ID_HWM_VOLT_TYPE);
        public const UInt32 SAB2000_ID_HWM_VOLT_VCOREA = (SAB2000_ID_HWM_VOLT_BASE + 0);		    // Unit: millivolts
        public const UInt32 SAB2000_ID_HWM_VOLT_VCOREB = (SAB2000_ID_HWM_VOLT_BASE + 1);
        public const UInt32 SAB2000_ID_HWM_VOLT_3V3 = (SAB2000_ID_HWM_VOLT_BASE + 2);
        public const UInt32 SAB2000_ID_HWM_VOLT_5V = (SAB2000_ID_HWM_VOLT_BASE + 3);
        public const UInt32 SAB2000_ID_HWM_VOLT_12V = (SAB2000_ID_HWM_VOLT_BASE + 4);
        public const UInt32 SAB2000_ID_HWM_VOLT_12NV = (SAB2000_ID_HWM_VOLT_BASE + 5);
        public const UInt32 SAB2000_ID_HWM_VOLT_5VSB = (SAB2000_ID_HWM_VOLT_BASE + 6);
        public const UInt32 SAB2000_ID_HWM_VOLT_5NV = (SAB2000_ID_HWM_VOLT_BASE + 7);
        public const UInt32 SAB2000_ID_HWM_VOLT_VBAT = (SAB2000_ID_HWM_VOLT_BASE + 8);


        public const UInt32 SAB2000_ID_HWM_FAN_TYPE = 0x22000;
        public const UInt32 SAB2000_ID_HWM_FAN_BASE = (SAB2000_ID_BASE | SAB2000_ID_HWM_FAN_TYPE);
        public const UInt32 SAB2000_ID_HWM_FAN_0 = (SAB2000_ID_HWM_FAN_BASE + 0);		            // Unit: RPM
        public const UInt32 SAB2000_ID_HWM_FAN_1 = (SAB2000_ID_HWM_FAN_BASE + 1);
        public const UInt32 SAB2000_ID_HWM_FAN_2 = (SAB2000_ID_HWM_FAN_BASE + 2);
        public const UInt32 SAB2000_ID_HWM_FAN_OB1 = (SAB2000_ID_HWM_FAN_BASE + 3);
        public const UInt32 SAB2000_ID_HWM_FAN_OB2 = (SAB2000_ID_HWM_FAN_BASE + 4);
        public const UInt32 SAB2000_ID_HWM_FAN_OB3 = (SAB2000_ID_HWM_FAN_BASE + 5);
        public const UInt32 SAB2000_ID_HWM_FAN_OB4 = (SAB2000_ID_HWM_FAN_BASE + 6);
        public const UInt32 SAB2000_ID_HWM_FAN_OB5 = (SAB2000_ID_HWM_FAN_BASE + 7);
        public const UInt32 SAB2000_ID_HWM_FAN_OB6 = (SAB2000_ID_HWM_FAN_BASE + 8);
        public const UInt32 SAB2000_ID_HWM_FAN_OB7 = (SAB2000_ID_HWM_FAN_BASE + 9);


        public const UInt32 SAB2000_ID_GSENSOR_TYPE = 0x30000;
        public const UInt32 SAB2000_ID_GSENSOR_BASE = (SAB2000_ID_BASE | SAB2000_ID_GSENSOR_TYPE);
        public const UInt32 SAB2000_ID_GSENSOR_AXIS_X = (SAB2000_ID_GSENSOR_BASE + 0);
        public const UInt32 SAB2000_ID_GSENSOR_AXIS_Y = (SAB2000_ID_GSENSOR_BASE + 1);
        public const UInt32 SAB2000_ID_GSENSOR_AXIS_Z = (SAB2000_ID_GSENSOR_BASE + 2);
        public const UInt32 SAB2000_ID_GSENSOR_FF_COUNT = (SAB2000_ID_GSENSOR_BASE + 3);
        //--------------------------------
        // [1:0] 00		2g		(RW)
        //		 01		4g
        //		 10		8g
        //		 11		16g
        public const UInt32 SAB2000_ID_GSENSOR_GVALUE = (SAB2000_ID_GSENSOR_BASE + 4);


        public const UInt32 SAB2000_ID_LED_TYPE = 0x31000;
        public const UInt32 SAB2000_ID_LED_BASE = (SAB2000_ID_BASE | SAB2000_ID_LED_TYPE);
        //--------------------------------
        // [2:0] 001	Green
        //		 010	Red
        //		 101	Green Blink
        //		 110	Red Blink
        //		 Other	N/A
        public const UInt32 SAB2000_ID_LED_POWER = (SAB2000_ID_LED_BASE + 0);
        //--------------------------------
        // [2:0] 001	Green
        //		 010	Red
        //		 101	Green Blink
        //		 110	Red Blink
        //		 Other	N/A
        public const UInt32 SAB2000_ID_LED_TEMP = (SAB2000_ID_LED_BASE + 1);
        //--------------------------------
        // [2:0] 001	Green
        //		 010	Red
        //		 101	Green Blink
        //		 110	Red Blink
        //		 Other	N/A
        public const UInt32 SAB2000_ID_LED_FAN = (SAB2000_ID_LED_BASE + 2);



        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);

        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceSetValue(UInt32 Id, UInt32 Value);
    }
}