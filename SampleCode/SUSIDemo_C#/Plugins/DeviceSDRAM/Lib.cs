using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
    public static class Lib
    {
        public const UInt32 SPD_ID_BASE = 0x00A00000;

        public const UInt32 SPD_ID_INFO_TYPE = 0x00000;
        public const UInt32 SPD_ID_INFO_SUBTYPE = 0xF00;
        public const UInt32 SPD_ID_DRAM_BASE = (SPD_ID_BASE | SPD_ID_INFO_TYPE);
        public static UInt32 SPD_ID_DRAM_SOCKET(UInt32 n)
        {
            return (SPD_ID_INFO_SUBTYPE & (n << 8));
        }

        public const UInt32 SPD_ID_DRAM_QTY = (SPD_ID_DRAM_BASE + 0);

        public static UInt32 SPD_ID_DRAM_TYPE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x01);
        }
        public static UInt32 SPD_ID_DRAM_PARTNUMBER1(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x11);
        }
        public static UInt32 SPD_ID_DRAM_PARTNUMBER2(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x12);
        }
        public static UInt32 SPD_ID_DRAM_PARTNUMBER3(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x13);
        }
        public static UInt32 SPD_ID_DRAM_PARTNUMBER4(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x14);
        }
        public static UInt32 SPD_ID_DRAM_PARTNUMBER5(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x15);
        }

        public static UInt32 SPD_ID_DRAM_SPECIFICDATA1(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x21);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA2(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x22);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA3(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x23);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA4(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x24);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA5(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x25);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA6(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x26);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA7(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x27);
        }
        public static UInt32 SPD_ID_DRAM_SPECIFICDATA8(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x28);
        }
        public static UInt32 SPD_ID_DRAM_MODULETYPE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x02);
        }
        public static UInt32 SPD_ID_DRAM_SIZE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x03);
        }
        public static UInt32 SPD_ID_DRAM_SPEED(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x04);
        }
        public static UInt32 SPD_ID_DRAM_RANK(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x05);
        }
        public static UInt32 SPD_ID_DRAM_VOLTAGE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x06);
        }
        public static UInt32 SPD_ID_DRAM_BANK(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x07);
        }
        public static UInt32 SPD_ID_DRAM_WEEKYEAR(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x08);
        }
        public static UInt32 SPD_ID_DRAM_TEMPERATURE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x09);
        }
        public static UInt32 SPD_ID_DRAM_WRITEPROTECTION(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x0A);
        }
        public static UInt32 SPD_ID_DRAM_MANUFACTURE(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x0B);
        }
        public static UInt32 SPD_ID_DRAM_DRAMIC(UInt16 n)
        {
            return (SPD_ID_DRAM_BASE + SPD_ID_DRAM_SOCKET(n) + 0x0C);
        }

       


        private static Dictionary<byte, string> DRAMDeviceTypeName = new Dictionary<byte, string>()
        {
            {0x00,"Reserved"},
            {0x01,"Standard FPM DRAM"},
            {0x02,"EDO"},
            {0x03,"Pipelined Nibble"},
            {0x04,"SDRAM"},
            {0x05,"ROM"},
            {0x06,"DDR SGRAM"},
            {0x07,"DDR SDRAM"},
            {0x08,"DDR2 SDRAM"},
            {0x09,"DDR2 SDRAM FB-DIMM"},
            {0x0A,"DDR2 SDRAM FB-DIMM PROBE"},
            {0x0B,"DDR3 SDRAM"},
            {0x0C,"DDR4 SDRAM"},
            {0x12,"DDR5 SDRAM"}
        };

        public static string FindDRAMTypeName(byte target)
        {
            if (DRAMDeviceTypeName.ContainsKey(target) == true)
                return DRAMDeviceTypeName[target];
            else
                return "Not found!";
        }

        private static Dictionary<byte, string> DDR3ModuleType = new Dictionary<byte, string>()
        {
            {0x00,"Undefined"},
            {0x01,"RDIMM"},
            {0x02,"UDIMM"},
            {0x03,"SO-DIMM"},
            {0x04,"Micro-DIMM"},
            {0x05,"Mini-RDIMM"},
            {0x06,"Mini-UDIMM"},
            {0x07,"Mini-CDIMM"},
            {0x08,"72b-SO-UDIMM"},
            {0x09,"72b-SO-RDIMM"},
            {0x0A,"72b-SO-CDIMM"},
            {0x0B,"LRDIMM"}
        };

        public static string FindDDR3ModuleType(byte target)
        {
            if (DDR3ModuleType.ContainsKey(target) == true)
                return DDR3ModuleType[target];
            else
                return "Not found!";
        }

        private static Dictionary<byte, string> DDR4ModuleType = new Dictionary<byte, string>()
        {
            {0x00,"Undefined"},
            {0x01,"RDIMM"},
            {0x02,"UDIMM"},
            {0x03,"SO-DIMM"},
            {0x04,"LRDIMM"},
            {0x05,"Mini-RDIMM"},
            {0x06,"Mini-UDIMM"},
            {0x07,"Reserved"},
            {0x08,"72b-SO-RDIMM"},
            {0x09,"72b-SO-UDIMM"},
            {0x0A,"Reserved"},
            {0x0B,"Reserved"},
            {0x0C,"16b-SO-DIMM"},
            {0x0D,"32b-SO-DIMM"},
            {0x0E,"Reserved"},
            {0x0F,"Reserved"}
        };

        public static string FindDDR4ModuleType(byte target)
        {
            if (DDR4ModuleType.ContainsKey(target) == true)
                return DDR4ModuleType[target];
            else
                return "Not found!";
        }


        private static Dictionary<byte, string> DDR5ModuleType = new Dictionary<byte, string>()
        {
            { 0x00,"Undefined" },
            { 0x01,"RDIMM" },
            { 0x02,"UDIMM" },
            { 0x03,"SO-DIMM" },
            { 0x04,"LRDIMM" },
            { 0x05,"Undefined" },
            { 0x06,"Undefined" },
            { 0x07,"MRDIMM" },
            { 0x08,"Undefined" },
            { 0x09,"Undefined" },
            { 0x0A,"DDIMM" },
            { 0x0B,"Solder down" },
            { 0x0C,"Reserved" },
            { 0x0D,"Reserved" },
            { 0x0E,"Reserved" },
            { 0x0F,"Reserved" }
        };
        public static string FindDDR5ModuleType(byte target)
        {
            if (DDR5ModuleType.ContainsKey(target) == true)
                return DDR5ModuleType[target];
            else
                return "Not found!";
        }

        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);
    }
}