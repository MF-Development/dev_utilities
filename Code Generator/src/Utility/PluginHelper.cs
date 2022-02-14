using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyApplication.Utility
{
    public static class PluginHelper
    {
        public static T CreateInstance<T>(string typeName) where T : class
        {
            Type type = Type.GetType(typeName);
            T instance = Activator.CreateInstance(type) as T;

            return instance;
        }
    }
}
