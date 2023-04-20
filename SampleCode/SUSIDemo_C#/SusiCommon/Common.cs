using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Susi4.Libraries
{
    public class Common
    {
        public static bool IsHex(char c)
        {
            if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))
            {
                return true;
            }

            return false;
        }

        public static byte[] StringToByteArray(string str)
        {
            int index = 0;
            byte[] baByte;

            try
            {
                str = str.Trim();

                while (str.IndexOf("  ", index) >= 0)
                {
                    str = str.Replace("  ", " ");
                }

                string[] saTemp = str.Split(new char[] { ' ' });
                baByte = new byte[saTemp.Length];

                for (int i = 0; i < saTemp.Length; i++)
                {
                    UInt32 dwTemp = Convert.ToUInt32(saTemp[i], 16);

                    if (dwTemp > 255)
                    {
                        return new byte[0];
                    }
                    baByte[i] = (byte)dwTemp;
                }
            }
            catch
            {
                return new byte[0];
            }

            return baByte;
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(String.Format("{0:X2} ", bytes[i]));
            }

            return sb.ToString().TrimEnd();
        }
    }

    public class DemoConfig
    {
        private string OEMPath;
        private string ConfigFile;
        private string DefaultLogoFile;

        private const string SECTION_DEMO4_PAGE = "Susi4DemoPage";
        private const string SECTION_DEMO4_LOGO = "Susi4DemoLogo";

        public bool HideWDT;
        public bool HideHWM;
        public bool HideGPIO;
        public bool HideSMBus;
        public bool HideIIC;
        public bool HideSmartFan;
        public bool HideVGA;
        public bool HideStorage;
        public bool HideThermalProtection;
        public bool HideInformation;
	    public bool HidePoE;
        public bool HidePIC;
	    public bool HideSAB2000;
	    public bool HideGSensor;
        public bool HideSDRAM;
        public bool HideSmartBattery;

        public Image Logo;
        public Point LogoLocation;
        public Size LogoSize;

        public DemoConfig()
        {
            OEMPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), "SUSI");
            ConfigFile = Path.Combine(OEMPath, "config.ini");
            DefaultLogoFile = Path.Combine(OEMPath, "Logo.png");

            if (LoadConfig() == false)
            {
                HideWDT = false;
                HideHWM = false;
                HideGPIO = false;
                HideSMBus = false;
                HideIIC = false;
                HideSmartFan = false;
                HideVGA = false;
                HideStorage = false;
                HideThermalProtection = false;
                HideInformation = false;
				HidePoE = false;
                HidePIC = false;
				HideSAB2000 = false;
				HideGSensor = false;
                HideSDRAM = false;
                HideSmartBattery = false;
            }

            if (Logo == null && File.Exists(DefaultLogoFile))
            {
                Logo = Image.FromFile(DefaultLogoFile);
            }
        }

        private bool LoadConfig()
        {
            EZini ini = new EZini(ConfigFile);

            if (ini.Exists() == false)
                return false;

            ini.Load();

            if (ini.HasSection(SECTION_DEMO4_PAGE))
            {
                string tmp;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideWDT", out tmp))
                    HideWDT = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideHWM", out tmp))
                    HideHWM = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideGPIO", out tmp))
                    HideGPIO = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideSMBus", out tmp))
                    HideSMBus = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideIIC", out tmp))
                    HideIIC = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideSmartFan", out tmp))
                    HideSmartFan = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideVGA", out tmp))
                    HideVGA = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideStorage", out tmp))
                    HideStorage = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideThermalProtection", out tmp))
                    HideThermalProtection = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideInformation", out tmp))
                    HideInformation = tmp == "1" ? true : false;

				if (ini[SECTION_DEMO4_PAGE].TryGetValue("HidePoE", out tmp))
					HidePoE = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HidePIC", out tmp))
                    HidePIC = tmp == "1" ? true : false;

				if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideSAB2000", out tmp))
					HideSAB2000 = tmp == "1" ? true : false;

				if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideGSensor", out tmp))
					HideGSensor = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideSDRAM", out tmp))
                    HideSDRAM = tmp == "1" ? true : false;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("HideSmartBattery", out tmp))
                    HideSmartBattery = tmp == "1" ? true : false;
            }

            if (ini.HasSection(SECTION_DEMO4_LOGO))
            {
                string tmp;

                if (ini[SECTION_DEMO4_PAGE].TryGetValue("OEMEnable", out tmp))
                {
                    if (tmp == "1")
                    {
                        if (ini[SECTION_DEMO4_PAGE].TryGetValue("Path", out tmp))
                        {
                            if (tmp != "")
                            {
                                if (File.Exists(tmp))
                                {
                                    Logo = Image.FromFile(tmp);
                                }
                            }
                        }
                    }
                }

                if (Logo != null)
                {
                    try
                    {
                        if (ini[SECTION_DEMO4_PAGE].TryGetValue("X", out tmp))
                        {
                            int x = Convert.ToInt32(tmp);

                            if (ini[SECTION_DEMO4_PAGE].TryGetValue("Y", out tmp))
                            {
                                int y = Convert.ToInt32(tmp);
                                LogoLocation = new Point(x, y);
                            }
                        }

                        if (ini[SECTION_DEMO4_PAGE].TryGetValue("Width", out tmp))
                        {
                            int w = Convert.ToInt32(tmp);

                            if (ini[SECTION_DEMO4_PAGE].TryGetValue("Height", out tmp))
                            {
                                int h = Convert.ToInt32(tmp);
                                LogoSize = new Size(w, h);
                            }
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            return true;
        }
    }

}
