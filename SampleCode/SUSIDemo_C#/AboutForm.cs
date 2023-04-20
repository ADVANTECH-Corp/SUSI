using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using Susi4.Plugin;

namespace Susi4.Demo
{
    public partial class AboutForm : Form
    {
        private ISusiHost Host;

        public AboutForm(ISusiHost host)
        {
            InitializeComponent();
            Host = host;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            label_Version.Text = fvi.FileVersion;
            label_CopyRight.Text = fvi.LegalCopyright;

            if (Host.Config.Logo != null)
            {
                pictureBox1.Image = Host.Config.Logo;

                if (Host.Config.LogoLocation.IsEmpty == false)
                    pictureBox1.Location = Host.Config.LogoLocation;

                if (Host.Config.LogoSize.IsEmpty == false)
                    pictureBox1.Size = Host.Config.LogoSize;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }
    }
}