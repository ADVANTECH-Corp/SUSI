using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Susi4.APIs;
using Susi4.Plugin;
using Susi4.Libraries;

namespace Susi4.Demo
{
    public partial class Main : Form, ISusiHost
    {
        #region ISusiHost
        private DemoConfig config;
        public DemoConfig Config
        {
            get { return config; }
        }
        #endregion

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            config = new DemoConfig();
            LoadPlugins();
        }

        private void LoadPlugins()
        {
            PluginService pluginService = new PluginService(this as ISusiHost);

            pluginService.FindPlugins(Path.Combine(Application.StartupPath, Program.PLUGIN_PATH));

            foreach (ISusiPlugin isp in pluginService.Plugins)
            {
                if (!isp.Enable)
                    continue;

                TabPage newPage = new TabPage(isp.Name);
                newPage.Controls.Add(isp.MainInterface);
                isp.MainInterface.Dock = DockStyle.Fill;
                tabControl.TabPages.Add(newPage);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutf = new AboutForm(this as ISusiHost);
            aboutf.ShowDialog();
        }
    }
}