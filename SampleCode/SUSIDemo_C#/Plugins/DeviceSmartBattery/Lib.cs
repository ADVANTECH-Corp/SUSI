using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Susi4.Plugin
{
    public static class Lib
    {
        public const UInt32 SBS_ID_BASE = 0x00B00000;
        public const UInt32 SBS_ID_Unit = (SBS_ID_BASE + 0x00);
        public const UInt32 SBS_ID_RemainingCapacityAlarm = (SBS_ID_BASE + 0x01);
        public const UInt32 SBS_ID_RemainingTimeAlarm = (SBS_ID_BASE + 0x02);
        public const UInt32 SBS_ID_BatteryMode = (SBS_ID_BASE + 0x03);
        public const UInt32 SBS_ID_AtRate = (SBS_ID_BASE + 0x04);
        public const UInt32 SBS_ID_AtRateTimeToFull = (SBS_ID_BASE + 0x05);
        public const UInt32 SBS_ID_AtRateTimeToEmpty = (SBS_ID_BASE + 0x06);
        public const UInt32 SBS_ID_AtRateOK = (SBS_ID_BASE + 0x07);
        public const UInt32 SBS_ID_Temperature = (SBS_ID_BASE + 0x08);
        public const UInt32 SBS_ID_Voltage = (SBS_ID_BASE + 0x09);
        public const UInt32 SBS_ID_Current = (SBS_ID_BASE + 0x0A);
        public const UInt32 SBS_ID_AverageCurrent = (SBS_ID_BASE + 0x0B);
        public const UInt32 SBS_ID_MaxError = (SBS_ID_BASE + 0x0C);
        public const UInt32 SBS_ID_RelativeStateOfCharge = (SBS_ID_BASE + 0x0D);
        public const UInt32 SBS_ID_AbsoluteStateOfCharge = (SBS_ID_BASE + 0x0E);
        public const UInt32 SBS_ID_RemainingCapacity = (SBS_ID_BASE + 0x0F);
        public const UInt32 SBS_ID_FullChargeCapacity = (SBS_ID_BASE + 0x10);
        public const UInt32 SBS_ID_RunTimeToEmpty = (SBS_ID_BASE + 0x11);
        public const UInt32 SBS_ID_AverageTimeToEmpty = (SBS_ID_BASE + 0x12);
        public const UInt32 SBS_ID_AverageTimeToFull = (SBS_ID_BASE + 0x13);
        public const UInt32 SBS_ID_ChargingCurrent = (SBS_ID_BASE + 0x14);
        public const UInt32 SBS_ID_ChargingVoltage = (SBS_ID_BASE + 0x15);
        public const UInt32 SBS_ID_BatteryStatus = (SBS_ID_BASE + 0x16);
        public const UInt32 SBS_ID_CycleCount = (SBS_ID_BASE + 0x17);
        public const UInt32 SBS_ID_DesignCapacity = (SBS_ID_BASE + 0x18);
        public const UInt32 SBS_ID_DesignVoltage = (SBS_ID_BASE + 0x19);
        public const UInt32 SBS_ID_SpecificationInfo = (SBS_ID_BASE + 0x1A);
        public const UInt32 SBS_ID_ManufacturerDate = (SBS_ID_BASE + 0x1B);
        public const UInt32 SBS_ID_SerialNumber = (SBS_ID_BASE + 0x1C);
        public const UInt32 SBS_ID_SoH = (SBS_ID_BASE + 0x4F);
        public const UInt32 SBS_ID_ManufacturerName_Len = (SBS_ID_BASE + 0x20);
        public const UInt32 SBS_ID_ManufacturerName1 = (SBS_ID_BASE + 0x24);
        public const UInt32 SBS_ID_ManufacturerName2 = (SBS_ID_BASE + 0x25);
        public const UInt32 SBS_ID_ManufacturerName3 = (SBS_ID_BASE + 0x26);
        public const UInt32 SBS_ID_ManufacturerName4 = (SBS_ID_BASE + 0x27);
        public const UInt32 SBS_ID_ManufacturerName5 = (SBS_ID_BASE + 0x28);

        [DllImport("SusiDevice")]
        public static extern UInt32 SusiDeviceGetValue(UInt32 Id, out UInt32 pValue);
    }
}