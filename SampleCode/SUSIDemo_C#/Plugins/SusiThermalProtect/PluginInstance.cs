using System;
using System.Collections.Generic;
using System.Text;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public class SusiPlugin : SusiPluginTemplate
    {
        public SusiPlugin(string path)
            : base(path)
        {
            base.myName = "Thermal Protection";
            base.myMainInterface = new ctlMain();
        }

        public override void OnCreate()
        {
            if (Host.Config.HideThermalProtection)
            {
                this.myEnable = false;
            }
            else
            {
                ctlMain main = MainInterface as ctlMain;

                if (main.Available == false)
                {
                    this.myEnable = false;
                }
            }
        }
    }
}
