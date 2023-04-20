using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Susi4.Plugin
{
    internal class PluginService
    {
        private ISusiHost Host;
        public List<ISusiPlugin> Plugins;

        public PluginService(ISusiHost host)
        {
            Plugins = new List<ISusiPlugin>();
            Host = host;
        }

        public void FindPlugins(string Path)
        {
            Plugins.Clear();

            foreach (string fileOn in Directory.GetFiles(Path))
            {
                FileInfo file = new FileInfo(fileOn);

                if (file.Extension.Equals(".dll"))
                {
                    this.AddPlugin(fileOn);
                }
            }
        }

        private void AddPlugin(string FileName)
        {
            byte[] bytes = File.ReadAllBytes(FileName);
#if DEBUG
            byte[] pdb_bytes = File.ReadAllBytes(Path.ChangeExtension(FileName, "pdb"));
            Assembly pluginAssembly = Assembly.Load(bytes, pdb_bytes);
#else
            Assembly pluginAssembly = Assembly.Load(bytes);
#endif

            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                if (pluginType.IsPublic)
                {
                    if (!pluginType.IsAbstract)
                    {
                        Type typeInterface = pluginType.GetInterface("Susi4.Plugin.ISusiPlugin", true);

                        if (typeInterface != null)
                        {
                            object[] args = { Path.GetDirectoryName(FileName) };
                            ISusiPlugin plugin = Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()), args) as ISusiPlugin;

                            if (plugin != null)
                            {
                                plugin.Host = Host;
                                this.Plugins.Add(plugin);
                                plugin.OnCreate();
                            }
                        }
                    }
                }
            }
        }
    }
}
