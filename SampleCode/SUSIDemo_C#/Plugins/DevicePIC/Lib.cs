using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
	public static class Lib
	{
		[DllImport("SusiDevice")]
		public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);

		[DllImport("SusiDevice")]
		public static extern UInt32 SusiDeviceSetValue(UInt32 Id, UInt32 Value);

        public const UInt32 PIC_ID_BASE = 0x00600000;

        public const UInt32 PIC_ID_INFO_TYPE = 0x00000;
        public const UInt32 PIC_ID_INFO_BASE =	PIC_ID_BASE | PIC_ID_INFO_TYPE;
        public const UInt32 PIC_ID_INFO_AVAILABLE = PIC_ID_INFO_BASE + 8;

        //General Info
        public const UInt32 PIC_ID_FW_VER	= PIC_ID_INFO_BASE + 0;
        public const UInt32 PIC_ID_FW_CONFIG_MASK	= PIC_ID_INFO_BASE + 1;
        public const UInt32 PIC_ID_BOARD_ID = PIC_ID_INFO_BASE + 2;
        public const UInt32 PIC_ID_BOARD_NAME_LEN = PIC_ID_INFO_BASE + 3;
        public const UInt32 PIC_ID_BOARD_NAME1 = PIC_ID_INFO_BASE + 4;
        public const UInt32 PIC_ID_BOARD_NAME2	= PIC_ID_INFO_BASE + 5;
        public const UInt32 PIC_ID_BOARD_NAME3	= PIC_ID_INFO_BASE + 6;
        public const UInt32 PIC_ID_BOARD_NAME4	= PIC_ID_INFO_BASE + 7;

        //Switch status
        public const UInt32 PIC_ID_SWITCH_TYPE = 0x10000;
        public const UInt32 PIC_ID_SWITCH_BASE	= PIC_ID_BASE | PIC_ID_SWITCH_TYPE;
        public const UInt32 PIC_ID_SWITCH_STATE = PIC_ID_SWITCH_BASE + 0;
        public const UInt32 PIC_ID_SWITCH1_MODE = PIC_ID_SWITCH_BASE + 1;
        public const UInt32 PIC_ID_SWITCH1_CFG_SELECT = PIC_ID_SWITCH_BASE + 2;
        public const UInt32 PIC_ID_SWITCH2_PWR_SELECT = PIC_ID_SWITCH_BASE + 3;
        	
        //FW info
        public const UInt32 PIC_ID_FW_TYPE = 0x20000;
        public const UInt32 PIC_ID_FW_BASE = PIC_ID_BASE | PIC_ID_FW_TYPE;
        public const UInt32 PIC_ID_FW_STATE = PIC_ID_FW_BASE + 0;
        public const UInt32 PIC_ID_FW_SYS_STATUS = PIC_ID_FW_BASE + 1;
        public const UInt32 PIC_ID_FW_BAT_STATUS = PIC_ID_FW_BASE + 2;
        public const UInt32 PIC_ID_FW_TMR_STATUS = PIC_ID_FW_BASE + 3;
        public const UInt32 PIC_ID_FW_BAT_TYPE	= PIC_ID_FW_BASE + 4;
        public const UInt32 PIC_ID_FW_BAT_VOLT	= PIC_ID_FW_BASE + 5;
        public const UInt32 PIC_ID_FW_BAT_VOLT_STATUS = PIC_ID_FW_BASE + 6;
        public const UInt32 PIC_ID_FW_BAT_ADC = PIC_ID_FW_BASE + 7;
        public const UInt32 PIC_ID_FW_BAT_LOW_ADC = PIC_ID_FW_BASE + 8;
        public const UInt32 PIC_ID_FW_SYSON_LEVEL = PIC_ID_FW_BASE + 9;
        public const UInt32 PIC_ID_FW_IGN_LEVEL = PIC_ID_FW_BASE + 10;
        public const UInt32 PIC_ID_FW_V12_STATUS = PIC_ID_FW_BASE + 11;
        public const UInt32 PIC_ID_FW_V48_STATUS = PIC_ID_FW_BASE + 12;
        public const UInt32 PIC_ID_FW_CHECK_SUM = PIC_ID_FW_BASE + 13;

        //HW config table
        public const UInt32 PIC_ID_HW_TYPE = 0x30000;
        public const UInt32 PIC_ID_HW_BASE = PIC_ID_BASE | PIC_ID_HW_TYPE;
        public const UInt32 PIC_ID_HW_TAB_IGN1 = PIC_ID_HW_BASE + 0;
        public const UInt32 PIC_ID_HW_TAB_IGN2 = PIC_ID_HW_BASE + 1;
        public const UInt32 PIC_ID_HW_TAB_IGN3 = PIC_ID_HW_BASE + 2;
        public const UInt32 PIC_ID_HW_TAB_IGN4 = PIC_ID_HW_BASE + 3;
        public const UInt32 PIC_ID_HW_TAB_IGN5 = PIC_ID_HW_BASE + 4;
        public const UInt32 PIC_ID_HW_TAB_IGN6 = PIC_ID_HW_BASE + 5;
        public const UInt32 PIC_ID_HW_TAB_IGN7 = PIC_ID_HW_BASE + 6;
        public const UInt32 PIC_ID_HW_TAB_IGN8 = PIC_ID_HW_BASE + 7;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF1 = PIC_ID_HW_BASE + 8;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF2 = PIC_ID_HW_BASE + 9;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF3 = PIC_ID_HW_BASE + 10;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF4 = PIC_ID_HW_BASE + 11;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF5 = PIC_ID_HW_BASE + 12;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF6 = PIC_ID_HW_BASE + 13;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF7 = PIC_ID_HW_BASE + 14;
        public const UInt32 PIC_ID_HW_TAB_DELAY_OFF8 = PIC_ID_HW_BASE + 15;

        //Setup SW settings
        public const UInt32 PIC_ID_SET_TYPE = 0x80000;
        public const UInt32 PIC_ID_SET_BASE = PIC_ID_BASE | PIC_ID_SET_TYPE;
        public const UInt32 PIC_ID_SET_IGN_DELAY = PIC_ID_SET_BASE + 0;
        public const UInt32 PIC_ID_SET_DELAY_OFF =	PIC_ID_SET_BASE + 1;
        public const UInt32 PIC_ID_SET_HARD_OFF = PIC_ID_SET_BASE + 2;
        public const UInt32 PIC_ID_SET_PWR_RETRIES	= PIC_ID_SET_BASE + 3;
        public const UInt32 PIC_ID_SET_PWR_INTERVAL = PIC_ID_SET_BASE + 4;
        public const UInt32 PIC_ID_SET_BL_12V = PIC_ID_SET_BASE + 5;
        public const UInt32 PIC_ID_SET_BL_24V = PIC_ID_SET_BASE + 6;
        public const UInt32 PIC_ID_SET_BL_DELAY_OFF = PIC_ID_SET_BASE + 7;
        public const UInt32 PIC_ID_SET_BL_HARD_OFF	= PIC_ID_SET_BASE + 8;
        public const UInt32 PIC_ID_SET_BAT_LOW_SWITCH = PIC_ID_SET_BASE + 9;
        public const UInt32 PIC_ID_SET_BAT_TYPE = PIC_ID_SET_BASE + 10;

        //Get current settings		
        public const UInt32 PIC_ID_GET_TYPE = 0x90000;
        public const UInt32 PIC_ID_GET_BASE = PIC_ID_BASE | PIC_ID_GET_TYPE;
        public const UInt32 PIC_ID_GET_IGN_DELAY = PIC_ID_GET_BASE + 0;
        public const UInt32 PIC_ID_GET_DELAY_OFF =	PIC_ID_GET_BASE + 1;
        public const UInt32 PIC_ID_GET_HARD_OFF = PIC_ID_GET_BASE + 2;
        public const UInt32 PIC_ID_GET_PWR_RETRIES	= PIC_ID_GET_BASE + 3;
        public const UInt32 PIC_ID_GET_PWR_INTERVAL = PIC_ID_GET_BASE + 4;
        public const UInt32 PIC_ID_GET_BL_12V = PIC_ID_GET_BASE + 5;
        public const UInt32 PIC_ID_GET_BL_24V = PIC_ID_GET_BASE + 6;
        public const UInt32 PIC_ID_GET_BL_DELAY_OFF = PIC_ID_GET_BASE + 7;
        public const UInt32 PIC_ID_GET_BL_HARD_OFF	= PIC_ID_GET_BASE + 8;
        public const UInt32 PIC_ID_GET_BAT_LOW_SWITCH = PIC_ID_GET_BASE + 9;
        public const UInt32 PIC_ID_GET_BAT_TYPE = PIC_ID_GET_BASE + 10;


        //Timer		
        public const UInt32 PIC_ID_TIMER_TYPE = 0xA0000;
        public const UInt32 PIC_ID_TIMER_BASE = PIC_ID_BASE | PIC_ID_TIMER_TYPE;
        public const UInt32 PIC_ID_TIMER_TMR_IGN_ON = PIC_ID_TIMER_BASE + 0;
        public const UInt32 PIC_ID_TIMER_PWR_ON_RETRIES = PIC_ID_TIMER_BASE + 1;
        public const UInt32 PIC_ID_TIMER_PWR_ON_INTERVAL =	PIC_ID_TIMER_BASE + 2;
        public const UInt32 PIC_ID_TIMER_PWR_OFF_RETRIES =	PIC_ID_TIMER_BASE + 3;
        public const UInt32 PIC_ID_TIMER_PWR_OFF_INTERVAL = PIC_ID_TIMER_BASE + 4;
        public const UInt32 PIC_ID_TIMER_TMR_DELAY_OFF = PIC_ID_TIMER_BASE + 5;
        public const UInt32 PIC_ID_TIMER_TMR_HARD_OFF = PIC_ID_TIMER_BASE + 6;
        public const UInt32 PIC_ID_TIMER_TMR_BL_DELAY_OFF = PIC_ID_TIMER_BASE + 7;
        public const UInt32 PIC_ID_TIMER_PWR_12V48V_INTERVAL = PIC_ID_TIMER_BASE + 8;
        public const UInt32 PIC_ID_TIMER_TMR_FW_UP_TIME = PIC_ID_TIMER_BASE + 15;

        //Min. settings		
        public const UInt32 PIC_ID_MIN_TYPE = 0xB0000;
        public const UInt32 PIC_ID_MIN_BASE = PIC_ID_BASE | PIC_ID_MIN_TYPE;
        public const UInt32 PIC_ID_MIN_IGN_DELAY = PIC_ID_MIN_BASE + 0;
        public const UInt32 PIC_ID_MIN_DELAY_OFF = PIC_ID_MIN_BASE + 1;
        public const UInt32 PIC_ID_MIN_HARD_OFF = PIC_ID_MIN_BASE + 2;
        public const UInt32 PIC_ID_MIN_PWR_RETRIES = PIC_ID_MIN_BASE + 3;
        public const UInt32 PIC_ID_MIN_PWR_INTERVAL = PIC_ID_MIN_BASE + 4;
        public const UInt32 PIC_ID_MIN_BL_12V = PIC_ID_MIN_BASE + 5;
        public const UInt32 PIC_ID_MIN_BL_24V = PIC_ID_MIN_BASE + 6;
        public const UInt32 PIC_ID_MIN_BL_DELAY_OFF = PIC_ID_MIN_BASE + 7;
        public const UInt32 PIC_ID_MIN_BL_HARD_OFF = PIC_ID_MIN_BASE + 8;
        public const UInt32 PIC_ID_MIN_BAT_LOW_SWITCH = PIC_ID_MIN_BASE + 9;
        public const UInt32 PIC_ID_MIN_BAT_TYPE = PIC_ID_MIN_BASE + 10;
                
        //Max. settings		
        public const UInt32 PIC_ID_MAX_TYPE = 0xC0000;
        public const UInt32 PIC_ID_MAX_BASE = PIC_ID_BASE | PIC_ID_MAX_TYPE;
        public const UInt32 PIC_ID_MAX_IGN_DELAY = PIC_ID_MAX_BASE + 0;
        public const UInt32 PIC_ID_MAX_DELAY_OFF = PIC_ID_MAX_BASE + 1;
        public const UInt32 PIC_ID_MAX_HARD_OFF = PIC_ID_MAX_BASE + 2;
        public const UInt32 PIC_ID_MAX_PWR_RETRIES = PIC_ID_MAX_BASE + 3;
        public const UInt32 PIC_ID_MAX_PWR_INTERVAL = PIC_ID_MAX_BASE + 4;
        public const UInt32 PIC_ID_MAX_BL_12V = PIC_ID_MAX_BASE + 5;
        public const UInt32 PIC_ID_MAX_BL_24V = PIC_ID_MAX_BASE + 6;
        public const UInt32 PIC_ID_MAX_BL_DELAY_OFF = PIC_ID_MAX_BASE + 7;
        public const UInt32 PIC_ID_MAX_BL_HARD_OFF = PIC_ID_MAX_BASE + 8;
        public const UInt32 PIC_ID_MAX_BAT_LOW_SWITCH = PIC_ID_MAX_BASE + 9;
        public const UInt32 PIC_ID_MAX_BAT_TYPE = PIC_ID_MAX_BASE + 10;

        //Default settings	
        public const UInt32 PIC_ID_DEF_TYPE = 0xD0000;
        public const UInt32 PIC_ID_DEF_BASE = PIC_ID_BASE | PIC_ID_DEF_TYPE;
        public const UInt32 PIC_ID_DEF_IGN_DELAY = PIC_ID_DEF_BASE + 0;
        public const UInt32 PIC_ID_DEF_DELAY_OFF = PIC_ID_DEF_BASE + 1;
        public const UInt32 PIC_ID_DEF_HARD_OFF = PIC_ID_DEF_BASE + 2;
        public const UInt32 PIC_ID_DEF_PWR_RETRIES = PIC_ID_DEF_BASE + 3;
        public const UInt32 PIC_ID_DEF_PWR_INTERVAL = PIC_ID_DEF_BASE + 4;
        public const UInt32 PIC_ID_DEF_BL_12V = PIC_ID_DEF_BASE + 5;
        public const UInt32 PIC_ID_DEF_BL_24V = PIC_ID_DEF_BASE + 6;
        public const UInt32 PIC_ID_DEF_BL_DELAY_OFF = PIC_ID_DEF_BASE + 7;
        public const UInt32 PIC_ID_DEF_BL_HARD_OFF = PIC_ID_DEF_BASE + 8;
        public const UInt32 PIC_ID_DEF_BAT_LOW_SWITCH = PIC_ID_DEF_BASE + 9;
        public const UInt32 PIC_ID_DEF_BAT_TYPE = PIC_ID_DEF_BASE + 10;

        //Read EEPROM data	
        public const UInt32 PIC_ID_EEPROM_TYPE = 0xE0000;
        public const UInt32 PIC_ID_EEPROM_BASE = PIC_ID_BASE | PIC_ID_EEPROM_TYPE;
        public const UInt32 PIC_ID_EEPROM_DATA1 = PIC_ID_EEPROM_BASE + 0;
        public const UInt32 PIC_ID_EEPROM_DATA2 = PIC_ID_EEPROM_BASE + 1;
        public const UInt32 PIC_ID_EEPROM_DATA3 = PIC_ID_EEPROM_BASE + 2;
        public const UInt32 PIC_ID_EEPROM_DATA4 = PIC_ID_EEPROM_BASE + 3;
        public const UInt32 PIC_ID_EEPROM_DATA5 = PIC_ID_EEPROM_BASE + 4;
        public const UInt32 PIC_ID_EEPROM_DATA6 = PIC_ID_EEPROM_BASE + 5;
        public const UInt32 PIC_ID_EEPROM_DATA7 = PIC_ID_EEPROM_BASE + 6;
        public const UInt32 PIC_ID_EEPROM_DATA8 = PIC_ID_EEPROM_BASE + 7;
        public const UInt32 PIC_ID_EEPROM_DATA9 = PIC_ID_EEPROM_BASE + 8;
        public const UInt32 PIC_ID_EEPROM_DATA10 = PIC_ID_EEPROM_BASE + 9;
        public const UInt32 PIC_ID_EEPROM_DATA11 = PIC_ID_EEPROM_BASE + 10;
        public const UInt32 PIC_ID_EEPROM_DATA12 = PIC_ID_EEPROM_BASE + 11;
        public const UInt32 PIC_ID_EEPROM_DATA13 = PIC_ID_EEPROM_BASE + 12;
        public const UInt32 PIC_ID_EEPROM_DATA14 = PIC_ID_EEPROM_BASE + 13;
        public const UInt32 PIC_ID_EEPROM_DATA15 = PIC_ID_EEPROM_BASE + 14;
        	
        //System Command		
        public const UInt32 PIC_ID_SYSTEM_TYPE = 0xF0000;
        public const UInt32 PIC_ID_SYSTEM_BASE = PIC_ID_BASE | PIC_ID_SYSTEM_TYPE;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_CHECKSUM = PIC_ID_SYSTEM_BASE + 0;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_CONFIG1 = PIC_ID_SYSTEM_BASE + 1;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_CONFIG2 = PIC_ID_SYSTEM_BASE + 2;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_DEVICE_ID = PIC_ID_SYSTEM_BASE + 3;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_USER_ID0 = PIC_ID_SYSTEM_BASE + 4;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_USER_ID1 = PIC_ID_SYSTEM_BASE + 5;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_USER_ID2 = PIC_ID_SYSTEM_BASE + 6;
        public const UInt32 PIC_ID_SYSTEM_GET_PIC_USER_ID3 = PIC_ID_SYSTEM_BASE + 7;
        public const UInt32 PIC_ID_SYSTEM_SET_DEFAULT = PIC_ID_SYSTEM_BASE + 14;
        public const UInt32 PIC_ID_SYSTEM_SET_PIC_RESET = PIC_ID_SYSTEM_BASE + 15;
	}
}
