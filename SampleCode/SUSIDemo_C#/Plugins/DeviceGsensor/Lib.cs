using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
    public static class Lib
    {
        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);

        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceSetValue(UInt32 Id, UInt32 Value);

        public const UInt32 ADXL345_ID_BASE = 0x00400000;
        
        public const UInt32 ADXL345_ID_INFO_TYPE = 0x00000;
        public const UInt32 ADXL345_ID_INFO_BASE = ADXL345_ID_BASE | ADXL345_ID_INFO_TYPE;
        public const UInt32 ADXL345_ID_INFO_AVAILABLE = ADXL345_ID_INFO_BASE + 0;
        
        public const UInt32 ADXL345_ID_VGA_TYPE = 0x01000;
        public const UInt32 ADXL345_ID_VGA_BASE = ADXL345_ID_BASE | ADXL345_ID_VGA_TYPE;
        public const UInt32 ADXL345_ID_VGA_OVERCURRENT = ADXL345_ID_VGA_BASE + 0;
        
        public const UInt32 ADXL345_ID_DATA_TYPE = 0x10000;
        public const UInt32 ADXL345_ID_DATA_BASE = ADXL345_ID_BASE | ADXL345_ID_DATA_TYPE;
        public const UInt32 ADXL345_ID_DATA_X = ADXL345_ID_DATA_BASE + 0;
        public const UInt32 ADXL345_ID_DATA_Y = ADXL345_ID_DATA_BASE + 1;
        public const UInt32 ADXL345_ID_DATA_Z = ADXL345_ID_DATA_BASE + 2;
        
        public const UInt32 ADXL345_ID_OFFSET_TYPE = 0x20000;
        public const UInt32 ADXL345_ID_OFFSET_BASE = ADXL345_ID_BASE | ADXL345_ID_OFFSET_TYPE;
        public const UInt32 ADXL345_ID_OFFSET_X = ADXL345_ID_OFFSET_BASE + 0;
        public const UInt32 ADXL345_ID_OFFSET_Y = ADXL345_ID_OFFSET_BASE + 1;
        public const UInt32 ADXL345_ID_OFFSET_Z = ADXL345_ID_OFFSET_BASE + 2;
        
        public const UInt32 ADXL345_ID_MEASURE_TYPE = 0x30000;
        public const UInt32 ADXL345_ID_MEASURE_BASE = ADXL345_ID_BASE | ADXL345_ID_MEASURE_TYPE;
        public const UInt32 ADXL345_ID_MEASURE_CTRL = ADXL345_ID_MEASURE_BASE + 0;
        // [1:0] 00		2g		(RW)
        //		 01		4g
        //		 10		8g
        //		 11		16g
        public const UInt32 ADXL345_ID_MEASURE_RANGE = ADXL345_ID_MEASURE_BASE + 1;
        
        public const UInt32 ADXL345_ID_POWER_TYPE = 0x40000;
        public const UInt32 ADXL345_ID_POWER_BASE = ADXL345_ID_BASE | ADXL345_ID_POWER_TYPE;
        public const UInt32 ADXL345_ID_POWER_LOWPOWER = ADXL345_ID_POWER_BASE + 0;
        public const UInt32 ADXL345_ID_POWER_SLEEP = ADXL345_ID_POWER_BASE + 1;
        
        public const UInt32 ADXL345_ID_DATARATE_TYPE = 0x50000;
        public const UInt32 ADXL345_ID_DATARATE_BASE = ADXL345_ID_BASE | ADXL345_ID_DATARATE_TYPE;
        //	[3:0]	0000	.098 Hz	(RW)
        //			0001	.195
        //			0010	.39
        //			0011	.782
        //			0100	1.563
        //			0101	3.125
        //			0110	6.25
        //			0111	12.5
        //			1000	25
        //			1001	50
        //			1010	100	(defaul)
        //			1011	200
        //			1100	400
        //			1101	800
        //			1110	1600
        //			1111	3200
        public const UInt32 ADXL345_ID_DATARATE_NORMAL = ADXL345_ID_DATARATE_BASE + 0;
        // [1:0]	00  8 Hz	(RW)
        //			01	4
        //			10	2
        //			11	1
        public const UInt32 ADXL345_ID_DATARATE_SEELP = ADXL345_ID_DATARATE_BASE + 1;      
    }
}