using System.Runtime.Remoting.Messaging;
using System.Web;

namespace WebApplication.Utility
{
    public static class StateManagementUtility
    {
        public static object Get(string key)
        {
            if (IsInWebContext())
            {
                return HttpContext.Current.Items[key] as object;
            }
            else
            {
                return CallContext.GetData(key) as object;
            }
        }

        public static void Set(string key, object data)
        {
            if (IsInWebContext())
            {
                HttpContext.Current.Items[key] = data;
            }
            else
            {
                CallContext.SetData(key, data);
            }
        }

        public static void Remove(string key)
        {
            if (IsInWebContext())
            {
                if (HttpContext.Current.Items.Contains(key))
                {
                    HttpContext.Current.Items.Remove(key);
                }
            }
            else
            {
                CallContext.FreeNamedDataSlot(key);
            }
        }

        public static bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }
    }
}
