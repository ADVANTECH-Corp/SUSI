using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Reflection;
using Susi4.Libraries;

namespace Susi4.Plugin
{
    public interface ISusiHost
    {
        DemoConfig Config { get; }
    }

    public interface ISusiPlugin
    {
        ISusiHost Host { get; set; }
        string Name { get; }
        string Description { get; }
        string PluginVersion { get; }
        string InterfaceVersion { get; }

        System.Drawing.Image Icon { get; }
        bool Enable { get; }

        System.Windows.Forms.UserControl MainInterface { get; }

        void OnCreate();
        void OnClose();
        void OnStart();
        void OnStop();
    }

    public abstract class SusiPluginTemplate : ISusiPlugin
    {
        protected string PluginPath = "";

        public SusiPluginTemplate(string path)
        {
            PluginPath = path;
        }

        #region ISusiPlugin Variables
        private ISusiHost myHost = null;
        protected string myName = "Template";
        protected string myDescription = "";
        protected string myPluginVersion = "1.0.0.0";
        private string myInterfaceVersion = "1.0.0.0";
        protected bool myEnable = true;
        protected System.Windows.Forms.UserControl myMainInterface;
        protected System.Drawing.Image myIcon = null;

        public string Name
        {
            get { return myName; }
        }

        public string Description
        {
            get { return myDescription; }
        }

        public string PluginVersion
        {
            get { return myPluginVersion; }
        }

        public string InterfaceVersion
        {
            get { return myInterfaceVersion; }
        }

        public ISusiHost Host
        {
            set { myHost = value; }
            get { return myHost; }
        }

        public System.Windows.Forms.UserControl MainInterface
        {
            get { return myMainInterface; }
        }

        public bool Enable
        {
            get { return myEnable; }
        }

        public System.Drawing.Image Icon
        {
            get { return myIcon; }
        }
        #endregion

        #region ISusiPlugin State Mechine Functions
        public virtual void OnCreate()
        {

        }

        public virtual void OnClose()
        {

        }

        public virtual void OnStart()
        {

        }

        public virtual void OnStop()
        {

        }
        #endregion
    }
}
