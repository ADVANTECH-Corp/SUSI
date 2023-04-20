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

		public const UInt32 POE_ID_BASE = 0x00200000;

		public const UInt32 POE_ID_INFO_TYPE = 0x00000;
		public const UInt32 POE_ID_INFO_BASE = POE_ID_BASE | POE_ID_INFO_TYPE;
        public const UInt32 POE_ID_INFO_AVAILABLE = POE_ID_INFO_BASE + 0;

		public const UInt32 POE_ID_POWER_TYPE = 0x10000;
		public const UInt32 POE_ID_POWER_BASE = POE_ID_BASE | POE_ID_POWER_TYPE;
		public const UInt32 POE_ID_POWER_ENABLE = POE_ID_POWER_BASE + 0;
		public const UInt32 POE_ID_POWER_DISABLE = POE_ID_POWER_BASE + 1;

        // for Port(n), ID = ID_BASE + n - 1, n = 1 ... N
		public const UInt32 POE_ID_DETECT_TYPE = 0x20000;
		public const UInt32 POE_ID_DETECT_BASE = POE_ID_BASE | POE_ID_DETECT_TYPE; 
		public const UInt32 POE_ID_CLASS_TYPE = 0x30000;
		public const UInt32 POE_ID_CLASS_BASE = POE_ID_BASE | POE_ID_CLASS_TYPE;
		public const UInt32 POE_ID_CURRENT_TYPE = 0x40000;
		public const UInt32 POE_ID_CURRENT_BASE = POE_ID_BASE | POE_ID_CURRENT_TYPE;
		public const UInt32 POE_ID_VOLTAGE_TYPE = 0x50000;
		public const UInt32 POE_ID_VOLTAGE_BASE = POE_ID_BASE | POE_ID_VOLTAGE_TYPE;
        public const UInt32 POE_ID_CAP_TYPE = 0x60000;
        public const UInt32 POE_ID_CAP_BASE = POE_ID_BASE | POE_ID_CAP_TYPE;
        public const UInt32 POE_ID_PORT_POWER_TYPE = 0x70000;
        public const UInt32 POE_ID_PORT_POWER_BASE = POE_ID_BASE | POE_ID_PORT_POWER_TYPE;
	}
}
