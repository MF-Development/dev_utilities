using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using KYSSPluginInterfaces;

namespace CodeGenerator
{
    public class PluginLoader
    {
        #region Members
        
        private List<string> _pluginsSelected = new List<string>();
        private string _pluginRootPath = string.Empty;
        
        #endregion

        #region Properties

        public List<string> PluginsSelected
        {
            get
            {
                return _pluginsSelected;
            }
            set
            {
                _pluginsSelected = value;
            }
        }

        public string PluginRootPath
        {
            get
            {
                return _pluginRootPath;
            }

            set
            {
                _pluginRootPath = value;
            }
        }        

        #endregion

        #region Methods

        public PluginLoader(string pluginRootPath)
        {
            if (!Path.IsPathRooted(pluginRootPath))
            {
                string path = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

                pluginRootPath = path + Path.DirectorySeparatorChar + pluginRootPath;                
            }

            PluginRootPath = pluginRootPath;
        }

        public List<IKYSSEntityPlugin> GetEntityPlugins( bool includeAll)
        {
            List<IKYSSEntityPlugin> plugins = new List<IKYSSEntityPlugin>();

            string[] assemblyFiles = GetAssemblyFiles();

            foreach (string assemblyFile in assemblyFiles)
            {
                if (assemblyFile.EndsWith(".dll"))
                {
                    Assembly asm = Assembly.LoadFile(assemblyFile);

                    Type[] types = asm.GetTypes();

                    foreach (Type type in types)
                    {
                        if (type.GetInterfaces().Contains(typeof(IKYSSEntityPlugin)))
                        {
                            IKYSSEntityPlugin plugin = Activator.CreateInstance(type) as IKYSSEntityPlugin;

                            string typeName = plugin.GetType().Name;

                            //RJT - this doesn't make sense
                            if (includeAll == false && PluginsSelected.Contains(typeName))
                            {
                                plugins.Add(plugin);
                            }
                            else if( includeAll == true)
                            {
                                plugins.Add(plugin);
                            }
                        }
                    }
                }
            }

            return plugins;
        }


        public List<IKYSSEntityPlugin> GetEntityPlugins(Type pluginType, bool includeAll)
        {
            List<IKYSSEntityPlugin> allPlugins = GetEntityPlugins(includeAll);
            List<IKYSSEntityPlugin> filteredPlugins = new List<IKYSSEntityPlugin>();

            foreach (IKYSSEntityPlugin plugin in allPlugins)
            {
                Type currentPluginType = plugin.GetType();

                if (this.PluginsSelected.Contains(currentPluginType.Name))
                {
                    if (currentPluginType.GetInterfaces().Contains(pluginType))
                    {
                        filteredPlugins.Add(plugin);
                    }
                }
            }

            return filteredPlugins;            
        }

        public string[] GetAssemblyFiles()
        {
            string[] files = new string[] { };

            if (Directory.Exists(PluginRootPath))
            {
                files = Directory.GetFiles(PluginRootPath);
            }

            return files;
        }

        #endregion

    }
}
