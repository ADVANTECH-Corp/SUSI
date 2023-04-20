using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Susi4.APIs
{
    public static class SusiStatus
    {
        public const UInt32 SUSI_STATUS_NOT_INITIALIZED = 0xFFFFFFFF;
        public const UInt32 SUSI_STATUS_INITIALIZED = 0xFFFFFFFE;
        public const UInt32 SUSI_STATUS_ALLOC_ERROR = 0xFFFFFFFD;
        public const UInt32 SUSI_STATUS_DRIVER_TIMEOUT = 0xFFFFFFFC;
        public const UInt32 SUSI_STATUS_INVALID_PARAMETER = 0xFFFFFEFF;
        public const UInt32 SUSI_STATUS_INVALID_BLOCK_ALIGNMENT = 0xFFFFFEFE;
        public const UInt32 SUSI_STATUS_INVALID_BLOCK_LENGTH = 0xFFFFFEFD;
        public const UInt32 SUSI_STATUS_INVALID_DIRECTION = 0xFFFFFEFC;
        public const UInt32 SUSI_STATUS_INVALID_BITMASK = 0xFFFFFEFB;
        public const UInt32 SUSI_STATUS_RUNNING = 0xFFFFFEFA;
        public const UInt32 SUSI_STATUS_UNSUPPORTED = 0xFFFFFCFF;
        public const UInt32 SUSI_STATUS_NOT_FOUND = 0xFFFFFBFF;
        public const UInt32 SUSI_STATUS_TIMEOUT = 0xFFFFFBFE;
        public const UInt32 SUSI_STATUS_BUSY_COLLISION = 0xFFFFFBFD;
        public const UInt32 SUSI_STATUS_READ_ERROR = 0xFFFFFAFF;
        public const UInt32 SUSI_STATUS_WRITE_ERROR = 0xFFFFFAFE;
        public const UInt32 SUSI_STATUS_MORE_DATA = 0xFFFFF9FF;
        public const UInt32 SUSI_STATUS_ERROR = 0xFFFFF0FF;
        public const UInt32 SUSI_STATUS_SUCCESS = 0x00000000;
    }

    public static class SusiLib
    {
        [DllImport("Susi4")]
        public static extern UInt32 SusiLibInitialize();

        [DllImport("Susi4")]
        public static extern UInt32 SusiLibUninitialize();
    }

    public static class SusiBoard
    {
        public const UInt32 SUSI_ID_UNKNOWN = 0xFFFFFFFF;

        public const UInt32 SUSI_ID_GET_SPEC_VERSION = 0x00000000;
        public const UInt32 SUSI_ID_BOARD_BOOT_COUNTER_VAL = 0x00000001;
        public const UInt32 SUSI_ID_BOARD_RUNNING_TIME_METER_VAL = 0x00000002;
        public const UInt32 SUSI_ID_BOARD_PNPID_VAL = 0x00000003;
        public const UInt32 SUSI_ID_BOARD_PLATFORM_REV_VAL = 0x00000004;
        public const UInt32 SUSI_ID_BOARD_DRIVER_VERSION_VAL = 0x00010000;
        public const UInt32 SUSI_ID_BOARD_LIB_VERSION_VAL = 0x00010001;
        public const UInt32 SUSI_ID_BOARD_FIRMWARE_VERSION_VAL = 0x00010002;
        public const UInt32 SUSI_ID_BOARD_LAST_SHUTDOWN_STATUS_VAL = 0x00010003;
        public const UInt32 SUSI_ID_BOARD_LAST_SHUTDOWN_EVENT_VAL = 0x00010004;
        public const UInt32 SUSI_ID_BOARD_DOCUMENT_VERSION_VAL = 0x00010005;

        public const UInt32 SUSI_ID_HWM_TEMP_MAX = 11;
        public const UInt32 SUSI_ID_HWM_TEMP_CPU = 0x00020000;
        public const UInt32 SUSI_ID_HWM_TEMP_CHIPSET = SUSI_ID_HWM_TEMP_CPU + 1;
        public const UInt32 SUSI_ID_HWM_TEMP_SYSTEM = SUSI_ID_HWM_TEMP_CPU + 2;
        public const UInt32 SUSI_ID_HWM_TEMP_CPU2 = SUSI_ID_HWM_TEMP_CPU + 3;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM0 = SUSI_ID_HWM_TEMP_CPU + 4;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM1 = SUSI_ID_HWM_TEMP_CPU + 5;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM2 = SUSI_ID_HWM_TEMP_CPU + 6;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM3 = SUSI_ID_HWM_TEMP_CPU + 7;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM4 = SUSI_ID_HWM_TEMP_CPU + 8;
        public const UInt32 SUSI_ID_HWM_TEMP_OEM5 = SUSI_ID_HWM_TEMP_CPU + 9;
        public const UInt32 SUSI_ID_HWM_TEMP_SYSTEM2 = SUSI_ID_HWM_TEMP_CPU + 10;

        public const UInt32 SUSI_ID_HWM_VOLTAGE_MAX = 24;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_VCORE = 0x00021000;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_VCORE2 = SUSI_ID_HWM_VOLTAGE_VCORE + 1;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_2V5 = SUSI_ID_HWM_VOLTAGE_VCORE + 2;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_3V3 = SUSI_ID_HWM_VOLTAGE_VCORE + 3;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_5V = SUSI_ID_HWM_VOLTAGE_VCORE + 4;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_12V = SUSI_ID_HWM_VOLTAGE_VCORE + 5;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_5VSB = SUSI_ID_HWM_VOLTAGE_VCORE + 6;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_3VSB = SUSI_ID_HWM_VOLTAGE_VCORE + 7;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_VBAT = SUSI_ID_HWM_VOLTAGE_VCORE + 8;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_5NV = SUSI_ID_HWM_VOLTAGE_VCORE + 9;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_12NV = SUSI_ID_HWM_VOLTAGE_VCORE + 10;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_VTT = SUSI_ID_HWM_VOLTAGE_VCORE + 11;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_24V = SUSI_ID_HWM_VOLTAGE_VCORE + 12;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_DC = SUSI_ID_HWM_VOLTAGE_VCORE + 13;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_DCSTBY = SUSI_ID_HWM_VOLTAGE_VCORE + 14;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_VBATLI = SUSI_ID_HWM_VOLTAGE_VCORE + 15;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_OEM0 = SUSI_ID_HWM_VOLTAGE_VCORE + 16;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_OEM1 = SUSI_ID_HWM_VOLTAGE_VCORE + 17;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_OEM2 = SUSI_ID_HWM_VOLTAGE_VCORE + 18;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_OEM3 = SUSI_ID_HWM_VOLTAGE_VCORE + 19;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_1V05 = SUSI_ID_HWM_VOLTAGE_VCORE + 20;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_1V5 = SUSI_ID_HWM_VOLTAGE_VCORE + 21;
		public const UInt32 SUSI_ID_HWM_VOLTAGE_1V8 = SUSI_ID_HWM_VOLTAGE_VCORE + 22;
        public const UInt32 SUSI_ID_HWM_VOLTAGE_12VS5 = SUSI_ID_HWM_VOLTAGE_VCORE + 23;

        public const UInt32 SUSI_ID_HWM_FAN_MAX = 13;
        public const UInt32 SUSI_ID_HWM_FAN_CPU = 0x00022000;
        public const UInt32 SUSI_ID_HWM_FAN_SYSTEM = SUSI_ID_HWM_FAN_CPU + 1;
        public const UInt32 SUSI_ID_HWM_FAN_CPU2 = SUSI_ID_HWM_FAN_CPU + 2;
        public const UInt32 SUSI_ID_HWM_FAN_OEM0 = SUSI_ID_HWM_FAN_CPU + 3;
        public const UInt32 SUSI_ID_HWM_FAN_OEM1 = SUSI_ID_HWM_FAN_CPU + 4;
        public const UInt32 SUSI_ID_HWM_FAN_OEM2 = SUSI_ID_HWM_FAN_CPU + 5;
        public const UInt32 SUSI_ID_HWM_FAN_OEM3 = SUSI_ID_HWM_FAN_CPU + 6;
        public const UInt32 SUSI_ID_HWM_FAN_OEM4 = SUSI_ID_HWM_FAN_CPU + 7;
        public const UInt32 SUSI_ID_HWM_FAN_OEM5 = SUSI_ID_HWM_FAN_CPU + 8;
        public const UInt32 SUSI_ID_HWM_FAN_OEM6 = SUSI_ID_HWM_FAN_CPU + 9;
        public const UInt32 SUSI_ID_HWM_FAN_SYSTEM2 = SUSI_ID_HWM_FAN_CPU + 10;
        public const UInt32 SUSI_ID_HWM_FAN_SYSTEM3 = SUSI_ID_HWM_FAN_CPU + 11;
        public const UInt32 SUSI_ID_HWM_FAN_SYSTEM4 = SUSI_ID_HWM_FAN_CPU + 12;

        public const UInt32 SUSI_ID_HWM_CURRENT_MAX = 3;
        public const UInt32 SUSI_ID_HWM_CURRENT_OEM0 = 0x00023000;
        public const UInt32 SUSI_ID_HWM_CURRENT_OEM1 = SUSI_ID_HWM_CURRENT_OEM0 + 1;
        public const UInt32 SUSI_ID_HWM_CURRENT_OEM2 = SUSI_ID_HWM_CURRENT_OEM0 + 2;

        public const UInt32 SUSI_ID_HWM_CASEOPEN_MAX = 3;
        public const UInt32 SUSI_ID_HWM_CASEOPEN_OEM0 = 0x00024000;
        public const UInt32 SUSI_ID_HWM_CASEOPEN_OEM1 = SUSI_ID_HWM_CASEOPEN_OEM0 + 1;
        public const UInt32 SUSI_ID_HWM_CASEOPEN_OEM2 = SUSI_ID_HWM_CASEOPEN_OEM0 + 2;
        public const UInt32 CASEOPEN_CLEAR_CMD = 0x55AA55AA;

        public const UInt32 SUSI_ID_SMBUS_SUPPORTED = 0x00030000;
        public const UInt32 SUSI_SMBUS_EXTERNAL_SUPPORTED = (1 << 0);
        public const UInt32 SUSI_SMBUS_OEM0_SUPPORTED = (1 << 1);
        public const UInt32 SUSI_SMBUS_OEM1_SUPPORTED = (1 << 2);
        public const UInt32 SUSI_SMBUS_OEM2_SUPPORTED = (1 << 3);
        public const UInt32 SUSI_SMBUS_OEM3_SUPPORTED = (1 << 4);
        public const UInt32 SUSI_ID_I2C_SUPPORTED = 0x00030100;
        public const UInt32 SUSI_I2C_EXTERNAL_SUPPORTED = (1 << 0);
        public const UInt32 SUSI_I2C_OEM0_SUPPORTED = (1 << 1);
        public const UInt32 SUSI_I2C_OEM1_SUPPORTED = (1 << 2);
        public const UInt32 SUSI_I2C_OEM2_SUPPORTED = (1 << 3);

        public const UInt32 SUSI_KELVINS_OFFSET = 2731;
        public static UInt32 SusiEncodeCelcius(UInt32 Celsius)
        {
            return (((Celsius) * 10) + SUSI_KELVINS_OFFSET);
        }

        public static float SusiDecodeCelcius(UInt32 KelvinsTenth)
        {
            return (((int)KelvinsTenth - SUSI_KELVINS_OFFSET) / 10f);
        }

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardGetValue(UInt32 Id, ref UInt32 pValue);

        public const UInt32 SUSI_ID_GET_NAME_MASK = 0xF0000000;
        public static UInt32 SUSI_ID_GET_NAME_BASE(UInt32 Id)
        {
            return (Id & SUSI_ID_GET_NAME_MASK);
        }

        public const UInt32 SUSI_ID_BASE_GET_NAME_HWM = 0x00000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_HWM_FANCONTROL = 0x10000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_I2C = 0x20000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_SMB = 0x30000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_GPIO = 0x40000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_WDT = 0x50000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_VGA_BACKLIGHT = 0x60000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_STORAGE = 0x70000000;
        public const UInt32 SUSI_ID_BASE_GET_NAME_TML = 0x80000000;
		public const UInt32 SUSI_ID_BASE_GET_NAME_INFO = 0x90000000;

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_HWM(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_HWM);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_HWM_FANCONTROL(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_HWM_FANCONTROL);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_I2C(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_I2C);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_SMB(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_SMB);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_GPIO(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_GPIO);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_WDT(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_WDT);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_VGA_BACKLIGHT(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_VGA_BACKLIGHT);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_STORAGE(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_STORAGE);
        }

        public static UInt32 SUSI_ID_MAPPING_GET_NAME_TML(UInt32 Id)
        {
            return (Id | SUSI_ID_BASE_GET_NAME_TML);
        }

		public static UInt32 SUSI_ID_MAPPING_GET_NAME_INFO(UInt32 Id)
		{
			return (Id | SUSI_ID_BASE_GET_NAME_INFO);
		}

        public const UInt32 SUSI_ID_BOARD_MANUFACTURER_STR = 0x00000000;
        public const UInt32 SUSI_ID_BOARD_NAME_STR = 0x00000001;
        public const UInt32 SUSI_ID_BOARD_REVISION_STR = 0x00000002;
        public const UInt32 SUSI_ID_BOARD_SERIAL_STR = 0x00000003;
        public const UInt32 SUSI_ID_BOARD_BIOS_REVISION_STR = 0x00000004;
        public const UInt32 SUSI_ID_BOARD_HW_REVISION_STR = 0x00000005;
        public const UInt32 SUSI_ID_BOARD_PLATFORM_TYPE_STR = 0x00000006;
        public const UInt32 SUSI_ID_BOARD_EC_FW_STR = 0x00000007;
		public const UInt32 SUSI_ID_BOARD_BIOS_FW_STR = 0x00000008;

		public const UInt32 SUSI_ID_BOARD_OEM0_STR = 0x00000010;
        public const UInt32 SUSI_ID_BOARD_OEM1_STR = 0x00000011;
        public const UInt32 SUSI_ID_BOARD_OEM2_STR = 0x00000012;

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardGetStringA(UInt32 Id, StringBuilder pBuffer, ref UInt32 pBufLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardReadIO(UInt16 Port, ref UInt32 pValue, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardWriteIO(UInt16 Port, UInt32 Value, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardReadPCI(byte Bus, byte Device, byte Function, UInt32 Offset, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pData, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardWritePCI(byte Bus, byte Device, byte Function, UInt32 Offset, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pData, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardReadMemory(UInt32 Address, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pData, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardWriteMemory(UInt32 Address, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pData, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardReadMSR(UInt32 index, ref UInt32 EAX, ref UInt32 EDX);

        [DllImport("Susi4")]
        public static extern UInt32 SusiBoardWriteMSR(UInt32 index, UInt32 EAX, UInt32 EDX);
    }

    public static class SusiSMB
    {
        public const UInt32 SUSI_SMBUS_MAX_DEVICE = 5;

        public const UInt32 SUSI_ID_SMBUS_EXTERNAL = 0x00000000;
        public const UInt32 SUSI_ID_SMBUS_OEM0 = 0x00000001;
        public const UInt32 SUSI_ID_SMBUS_OEM1 = 0x00000002;
        public const UInt32 SUSI_ID_SMBUS_OEM2 = 0x00000003;
        public const UInt32 SUSI_ID_SMBUS_OEM3 = 0x00000004;

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBReadByte(UInt32 Id, byte Addr, byte Cmd, out byte pBuffer);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBWriteByte(UInt32 Id, byte Addr, byte Cmd, byte Data);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBReadWord(UInt32 Id, byte Addr, byte Cmd, out UInt16 pBuffer);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBWriteWord(UInt32 Id, byte Addr, byte Cmd, UInt16 Data);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBReceiveByte(UInt32 Id, byte Addr, out byte pBuffer);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBSendByte(UInt32 Id, byte Addr, byte Data);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBReadQuick(UInt32 Id, byte Addr);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBWriteQuick(UInt32 Id, byte Addr);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBReadBlock(UInt32 Id, byte Addr, byte Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, ref UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBWriteBlock(UInt32 Id, byte Addr, byte Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBI2CReadBlock(UInt32 Id, byte Addr, byte Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, UInt32 Length);

        [DllImport("Susi4")]
        public static extern UInt32 SusiSMBI2CWriteBlock(UInt32 Id, byte Addr, byte Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, UInt32 Length);
    }

    public static class SusiI2C
    {
        public const UInt32 SUSI_I2C_MAX_DEVICE = 7;

        public const UInt32 SUSI_ID_I2C_EXTERNAL = 0x00000000;
        public const UInt32 SUSI_ID_I2C_OEM0 = 0x00000001;
        public const UInt32 SUSI_ID_I2C_OEM1 = 0x00000002;
        public const UInt32 SUSI_ID_I2C_OEM2 = 0x00000003;
        public const UInt32 SUSI_ID_I2C_OEM3 = 0x00000004;


        public static UInt32 SUSI_I2C_ENC_7BIT_ADDR(UInt32 addr)
        {
            return (addr << 1);
        }

        public static UInt32 SUSI_I2C_DEC_7BIT_ADDR(UInt32 addr)
        {
            return (addr >> 1);
        }

        public static UInt32 SUSI_I2C_ENC_10BIT_ADDR(UInt32 addr)
        {
            return ((addr & 0x00FF) | ((addr & 0x0300) << 1) | 0xF000);
        }

        public static UInt32 SUSI_I2C_DEC_10BIT_ADDR(UInt32 addr)
        {
            return ((addr & 0x00FF) | ((addr >> 1) & 0x0300));
        }

        public static bool SUSI_I2C_IS_10BIT_ADDR(UInt32 addr)
        {
            return ((addr & 0xF800) == 0xF000);
        }

        public static bool SUSI_I2C_IS_7BIT_ADDR(UInt32 addr)
        {
            return !SUSI_I2C_IS_10BIT_ADDR(addr);
        }

        // Bits 31 & 30 Selects Command Type
        public const UInt32 SUSI_I2C_STD_CMD = (0 << 30);
        public const UInt32 SUSI_I2C_EXT_CMD = ((UInt32)2 << 30);
        public const UInt32 SUSI_I2C_NO_CMD = ((UInt32)1 << 30);
        public const UInt32 SUSI_I2C_CMD_TYPE_MASK = ((UInt32)3 << 30);

        public static UInt32 SUSI_I2C_ENC_STD_CMD(UInt32 cmd)
        {
            return ((cmd & 0xFF) | SUSI_I2C_STD_CMD);
        }

        public static UInt32 SUSI_I2C_ENC_EXT_CMD(UInt32 cmd)
        {
            return ((cmd & 0xFFFF) | SUSI_I2C_EXT_CMD);
        }

        public static UInt32 SUSI_I2C_ENC_NO_CMD(UInt32 cmd)
        {
            return ((cmd & 0xFFFF) | SUSI_I2C_NO_CMD);
        }

        public static bool SUSI_I2C_IS_EXT_CMD(UInt32 cmd)
        {
            return ((cmd & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_EXT_CMD);
        }

        public static bool SUSI_I2C_IS_STD_CMD(UInt32 cmd)
        {
            return ((cmd & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_STD_CMD);
        }

        public static bool SUSI_I2C_IS_NO_CMD(UInt32 cmd)
        {
            return ((cmd & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_NO_CMD);
        }

        // Item ID
        public const UInt32 SUSI_ID_I2C_MAXIMUM_BLOCK_LENGTH = 0x00000000;
        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CWriteReadCombine(UInt32 Id, byte Addr, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pWBuffer, UInt32 WriteLen, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pRBuffer, UInt32 ReadLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CReadTransfer(UInt32 Id, UInt32 Addr, UInt32 Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, UInt32 ReadLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CWriteTransfer(UInt32 Id, UInt32 Addr, UInt32 Cmd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pBuffer, UInt32 ByteCnt);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CProbeDevice(UInt32 Id, UInt32 Addr);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CGetFrequency(UInt32 Id, out UInt32 pFreq);

        [DllImport("Susi4")]
        public static extern UInt32 SusiI2CSetFrequency(UInt32 Id, UInt32 Freq);
    }

    public static class SusiGPIO
    {
        public static UInt32 SUSI_ID_GPIO(UInt32 Num)
        {
            return Num;
        }

        public static UInt32 SUSI_ID_GPIO_BANK(UInt32 BankNum)
        {
            return BankNum + 0x00010000;
        }

        public static UInt32 SUSI_ID_GPIO_PIN_BANK(UInt32 GPIO_NUM)
        {
            return (0x00010000 | ((GPIO_NUM) >> 5));
        }

        // Item ID
        public const UInt32 SUSI_ID_GPIO_INPUT_SUPPORT = 0;
        public const UInt32 SUSI_ID_GPIO_OUTPUT_SUPPORT = 1;
        public const UInt32 SUSI_ID_GPIO_INT_SUPPORT = 2;

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);

        public const UInt32 SUSI_GPIO_OUTPUT = 0;
        public const UInt32 SUSI_GPIO_INPUT = 1;
        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOGetDirection(UInt32 Id, UInt32 Bitmask, out UInt32 pDirection);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOSetDirection(UInt32 Id, UInt32 Bitmask, UInt32 Direction);

        public const UInt32 SUSI_GPIO_LOW = 0;
        public const UInt32 SUSI_GPIO_HIGH = 1;
        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOGetLevel(UInt32 Id, UInt32 Bitmask, out UInt32 pLevel);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOSetLevel(UInt32 Id, UInt32 Bitmask, UInt32 Level);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntGetPin(UInt32 Id, UInt32 Bitmask, out UInt32 Enable);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntSetPin(UInt32 Id, UInt32 Bitmask, UInt32 Enable);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntGetEdge(UInt32 Id, UInt32 Bitmask, out UInt32 Edge);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntSetEdge(UInt32 Id, UInt32 Bitmask, UInt32 Edge);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void SUSI_GPIO_INT_CALLBACK(IntPtr context);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntRegister(IntPtr pfnCallback);

        [DllImport("Susi4")]
        public static extern UInt32 SusiGPIOIntUnRegister();
    }

    public static class SusiVga
    {
        public const UInt32 SUSI_ID_BACKLIGHT_MAX = 3;

        public const UInt32 SUSI_ID_BACKLIGHT_1 = 0x00000000;
        public const UInt32 SUSI_ID_BACKLIGHT_2 = 0x00000001;
        public const UInt32 SUSI_ID_BACKLIGHT_3 = 0x00000002;

        // Item ID
        public const UInt32 SUSI_ID_VGA_BRIGHTNESS_MAXIMUM = 0x00010000;
        public const UInt32 SUSI_ID_VGA_BRIGHTNESS_MINIMUM = 0x00010001;
        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);

        public const UInt32 SUSI_BACKLIGHT_SET_OFF = 0;
        public const UInt32 SUSI_BACKLIGHT_SET_ON = 1;
        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetBacklightEnable(UInt32 Id, out UInt32 pEnable);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetBacklightEnable(UInt32 Id, UInt32 Enable);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetBacklightBrightness(UInt32 Id, out UInt32 pBright);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetBacklightBrightness(UInt32 Id, UInt32 Bright);

        public const UInt32 SUSI_BACKLIGHT_LEVEL_MAXIMUM = 9;
        public const UInt32 SUSI_BACKLIGHT_LEVEL_MINIMUM = 0;
        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetBacklightLevel(UInt32 Id, out UInt32 pLevel);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetBacklightLevel(UInt32 Id, UInt32 Level);

        public const UInt32 SUSI_SCREEN_ON = 1;
        public const UInt32 SUSI_SCREEN_OFF = 0;
        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetScreenEnable(UInt32 Id, out UInt32 pEnable);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetScreenEnable(UInt32 Id, UInt32 Enable);

        public const UInt32 SUSI_BACKLIGHT_POLARITY_ON = 1;
        public const UInt32 SUSI_BACKLIGHT_POLARITY_OFF = 0;
        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetPolarity(UInt32 Id, out UInt32 pPolarity);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetPolarity(UInt32 Id, UInt32 Polarity);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaGetFrequency(UInt32 Id, out UInt32 pFrequency);

        [DllImport("Susi4")]
        public static extern UInt32 SusiVgaSetFrequency(UInt32 Id, UInt32 Frequency);
    }

    public static class SusiStorage
    {
        public const UInt32 SUSI_ID_STORAGE_MAX = 3;

        public const UInt32 SUSI_ID_STORAGE_STD = 0x00000000;
        public const UInt32 SUSI_ID_STORAGE_OEM0 = 0x00000001;
        public const UInt32 SUSI_ID_STORAGE_OEM1 = 0x00000002;

        // Item ID
        public const UInt32 SUSI_ID_STORAGE_TOTAL_SIZE = 0x00000000;
        public const UInt32 SUSI_ID_STORAGE_BLOCK_SIZE = 0x00000001;
        public const UInt32 SUSI_ID_STORAGE_LOCK_STATUS = 0x00010000;
        public const UInt32 SUSI_ID_STORAGE_PSW_MAX_LEN = 0x00010001;
        // Lock status
        public const UInt32 SUSI_STORAGE_STATUS_LOCK = 1;
        public const UInt32 SUSI_STORAGE_STATUS_UNLOCK = 0;
        [DllImport("Susi4")]
        public static extern UInt32 SusiStorageGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);

        [DllImport("Susi4")]
        public static extern UInt32 SusiStorageAreaRead(UInt32 Id, UInt32 Offset, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pBuffer, UInt32 BufLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiStorageAreaWrite(UInt32 Id, UInt32 Offset, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pBuffer, UInt32 BufLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiStorageAreaSetUnlock(UInt32 Id, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pBuffer, UInt32 BufLen);

        [DllImport("Susi4")]
        public static extern UInt32 SusiStorageAreaSetLock(UInt32 Id, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pBuffer, UInt32 BufLen);
    }

    public static class SusiFan
    {
        // ID same as SUSI_ID_HWM_FAN_XXX, Example: SUSI_ID_HWM_FAN_CPU

        // Fan control value item IDs
        public const UInt32 SUSI_ID_FC_CONTROL_SUPPORT_FLAGS = 0x00000000;  // Reference "Control Support Flags"
        public const UInt32 SUSI_ID_FC_AUTO_SUPPORT_FLAGS = 0x00000001;	    // Reference "Auto Support Flags"

        // Control Support Flags
        public const UInt32  SUSI_FC_FLAG_SUPPORT_OFF_MODE = (1 << 0);	    // Support OFF mode
        public const UInt32  SUSI_FC_FLAG_SUPPORT_FULL_MODE = (1 << 1);	    // Support FULL mode
        public const UInt32  SUSI_FC_FLAG_SUPPORT_MANUAL_MODE = (1 << 2);	// Support Manual mode
        public const UInt32  SUSI_FC_FLAG_SUPPORT_AUTO_MODE = (1 << 3);	    // Support Auto mode

        // Auto Support Flags
        public const UInt32  SUSI_FC_FLAG_SUPPORT_AUTO_LOW_STOP = (1 << 0);	    // Support Low Stop Behavior (Depend on Auto mode)
        public const UInt32  SUSI_FC_FLAG_SUPPORT_AUTO_LOW_LIMIT = (1 << 1);	// Support Low Limit Behavior (Depend on Auto mode)
        public const UInt32  SUSI_FC_FLAG_SUPPORT_AUTO_HIGH_LIMIT = (1 << 2);	// Support High Limit Behavior (Depend on Auto mode)
        public const UInt32  SUSI_FC_FLAG_SUPPORT_AUTO_PWM = (1 << 8);	        // Support PWM operate mode (Depend on Auto mode)
        public const UInt32 SUSI_FC_FLAG_SUPPORT_AUTO_RPM = (1 << 9);	        // Support RPM operate mode (Depend on Auto mode)

        [DllImport("Susi4")]
        public static extern UInt32 SusiFanControlGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);


        public const UInt32 SUSI_FAN_AUTO_CTRL_OPMODE_PWM = 0;
        public const UInt32 SUSI_FAN_AUTO_CTRL_OPMODE_RPM = 1;
        public struct AutoFan
        {
            public UInt32 TmlSource;
            public UInt32 OpMode;
            public UInt32 LowStopLimit;	    // Temperature (0.1 Kelvins)
            public UInt32 LowLimit;		    // Temperature (0.1 Kelvins)
            public UInt32 HighLimit;		// Temperature (0.1 Kelvins)
            public UInt32 MinPWM;		    // Enable when OpMode == FAN_AUTO_CTRL_OPMODE_PWM
            public UInt32 MaxPWM;		    // Enable when OpMode == FAN_AUTO_CTRL_OPMODE_PWM
            public UInt32 MinRPM;		    // Enable when OpMode == FAN_AUTO_CTRL_OPMODE_RPM
            public UInt32 MaxRPM;		    // Enable when OpMode == FAN_AUTO_CTRL_OPMODE_RPM
        }

        // Mode
        public const UInt32 SUSI_FAN_CTRL_MODE_OFF = 0;
        public const UInt32 SUSI_FAN_CTRL_MODE_FULL = 1;
        public const UInt32 SUSI_FAN_CTRL_MODE_MANUAL = 2;
        public const UInt32 SUSI_FAN_CTRL_MODE_AUTO = 3;
        public struct SusiFanControl
        {
            public UInt32 Mode;
            public UInt32 PWM;			    // Manual mode only (0 - 100%)
            public AutoFan AutoControl;     // Auto mode only
        }

        [DllImport("Susi4")]
        public static extern UInt32 SusiFanControlGetConfig(UInt32 Id, out SusiFanControl pConfig);

        [DllImport("Susi4")]
        public static extern UInt32 SusiFanControlSetConfig(UInt32 Id, ref SusiFanControl Config);
    }

    public static class SusiThermalProtection
    {
        public const UInt32 SUSI_ID_THERMAL_MAX = 4;
        public const UInt32 SUSI_ID_THERMAL_PROTECT_1 = 0x00000000;
        public const UInt32 SUSI_ID_THERMAL_PROTECT_2 = 0x00000001;
        public const UInt32 SUSI_ID_THERMAL_PROTECT_3 = 0x00000002;
        public const UInt32 SUSI_ID_THERMAL_PROTECT_4 = 0x00000003;

        // Thermal Protection value item IDs
        public const UInt32 SUSI_ID_TP_EVENT_SUPPORT_FLAGS = 0x00000000;	// Reference "Support Flags"
        public const UInt32 SUSI_ID_TP_EVENT_TRIGGER_MAXIMUM = 0x00000001;	// Send Event
        public const UInt32 SUSI_ID_TP_EVENT_TRIGGER_MINIMUM = 0x00000002;
        public const UInt32 SUSI_ID_TP_EVENT_CLEAR_MAXIMUM = 0x00000003;
        public const UInt32 SUSI_ID_TP_EVENT_CLEAR_MINIMUM = 0x00000004;

        // Thermal Protection Support Flags
        public const UInt32 SUSI_THERMAL_FLAG_SUPPORT_SHUTDOWN = 0x00000001;
        public const UInt32 SUSI_THERMAL_FLAG_SUPPORT_THROTTLE = 0x00000002;
        public const UInt32 SUSI_THERMAL_FLAG_SUPPORT_POWEROFF = 0x00000004;

        [DllImport("Susi4")]
        public static extern UInt32 SusiThermalProtectionGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);


        // Thermal Protection Event type
        public const UInt32 SUSI_THERMAL_EVENT_SHUTDOWN = 0x00;
        public const UInt32 SUSI_THERMAL_EVENT_THROTTLE = 0x01;
        public const UInt32 SUSI_THERMAL_EVENT_POWEROFF = 0x02;
        public const UInt32 SUSI_THERMAL_EVENT_NONE = 0xFF;

        public struct SusiThermalProtect
        {
            public UInt32 SourceId;
            public UInt32 EventType;
            public UInt32 SendEventTemperature;		// 0.1 Kelvins
            public UInt32 ClearEventTemperature;    // 0.1 Kelvins
        }

        [DllImport("Susi4")]
        public static extern UInt32 SusiThermalProtectionSetConfig(UInt32 Id, ref SusiThermalProtect pConfig);

        [DllImport("Susi4")]
        public static extern UInt32 SusiThermalProtectionGetConfig(UInt32 Id, out SusiThermalProtect pConfig);
    }

    public static class SusiWDog
    {
        public const UInt32 SUSI_ID_WATCHDOG_MAX = 4;

        public const UInt32 SUSI_ID_WATCHDOG_1 = 0x00000000;
        public const UInt32 SUSI_ID_WATCHDOG_2 = 0x00000001;
        public const UInt32 SUSI_ID_WATCHDOG_3 = 0x00000002;
		public const UInt32 SUSI_ID_WATCHDOG_4 = 0x00000003;

        // Event Types
        public const UInt32 SUSI_WDT_EVENT_TYPE_NONE = 0x00000000;
        public const UInt32 SUSI_WDT_EVENT_TYPE_IRQ = 0x00000001;
        public const UInt32 SUSI_WDT_EVENT_TYPE_SCI = 0x00000002;
        public const UInt32 SUSI_WDT_EVENT_TYPE_PWRBTN = 0x00000003;
        public const UInt32 SUSI_WDT_EVENT_TYPE_PIN = 0x00000004;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void SUSI_WDT_INT_CALLBACK(IntPtr context);

        // Item ID
		public const UInt32 SUSI_ID_WDT_SUPPORT_FLAGS = 0x00000000;
        public const UInt32 SUSI_ID_WDT_DELAY_MAXIMUM = 0x00000001;
        public const UInt32 SUSI_ID_WDT_DELAY_MINIMUM = 0x00000002;
        public const UInt32 SUSI_ID_WDT_EVENT_MAXIMUM = 0x00000003;
        public const UInt32 SUSI_ID_WDT_EVENT_MINIMUM = 0x00000004;
        public const UInt32 SUSI_ID_WDT_RESET_MAXIMUM = 0x00000005;
        public const UInt32 SUSI_ID_WDT_RESET_MINIMUM = 0x00000006;
        public const UInt32 SUSI_ID_WDT_UNIT_MINIMUM = 0x0000000F;
        public const UInt32 SUSI_ID_WDT_DELAY_TIME = 0x00010001;
        public const UInt32 SUSI_ID_WDT_EVENT_TIME = 0x00010002;
        public const UInt32 SUSI_ID_WDT_RESET_TIME = 0x00010003;
        public const UInt32 SUSI_ID_WDT_EVENT_TYPE = 0x00010004;

		// Support Flags
		public const UInt32 SUSI_WDT_FLAG_SUPPORT_IRQ = 0x00000002;
		public const UInt32 SUSI_WDT_FLAG_SUPPORT_SCI = 0x00000004;
		public const UInt32 SUSI_WDT_FLAG_SUPPORT_PWRBTN = 0x00000008;
        public const UInt32 SUSI_WDT_FLAG_SUPPORT_PIN = 0x00000010;

        [DllImport("Susi4")]
        public static extern UInt32 SusiWDogGetCaps(UInt32 Id, UInt32 ItemId, out UInt32 pValue);

        [DllImport("Susi4")]
        public static extern UInt32 SusiWDogStart(UInt32 Id, UInt32 DelayTime, UInt32 EventTime, UInt32 ResetTime, UInt32 EventType);

        [DllImport("Susi4")]
        public static extern UInt32 SusiWDogStop(UInt32 Id);

        [DllImport("Susi4")]
        public static extern UInt32 SusiWDogTrigger(UInt32 Id);

        [DllImport("Susi4")]
        public static extern UInt32 SusiWDogSetCallBack(UInt32 Id, IntPtr pfnCallback, IntPtr Context);
    }
}
