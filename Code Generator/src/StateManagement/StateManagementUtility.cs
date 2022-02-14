using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MyApplication.Utility
{
    public static class StateManagementUtility
    {
        public enum StorageType
        {
            Session,
            Context
        }

        public static object Get(string key)
        {
            return Get(key, StorageType.Context);
        }

        public static object Get(string key, StorageType storage)
        {
            if (IsInWebContext())
            {
                if (storage == StorageType.Context)
                {
                    return HttpContext.Current.Items[key] as object;
                }
                else if (storage == StorageType.Session)
                {
                    return HttpContext.Current.Session[key] as object;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return CallContext.GetData(key) as object;
            }
        }

        public static void Set(string key, object data)
        {
            Set(key, data, StorageType.Context);
        }

        public static void Set(string key, object data, StorageType storage)
        {
            if (IsInWebContext())
            {
                if (storage == StorageType.Context)
                {
                    HttpContext.Current.Items[key] = data;
                }
                else if (storage == StorageType.Session)
                {
                    HttpContext.Current.Session[key] = data;
                }
            }
            else
            {
                CallContext.SetData(key, data);
            }
        }

        public static void Remove(string key)
        {
            Remove(key, StorageType.Context);
        }

        public static void Remove(string key, StorageType storage)
        {
            if (IsInWebContext())
            {
                if (storage == StorageType.Context)
                {
                    if (HttpContext.Current.Items.Contains(key))
                    {
                        HttpContext.Current.Items.Remove(key);
                    }
                }
                else if (storage == StorageType.Session)
                {
                    bool found = false;
                    
                    foreach (string collKey in HttpContext.Current.Session.Keys)
                    {
                        if (collKey.ToLower().Equals(key.ToLower()))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        HttpContext.Current.Session.Remove(key);
                    }
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
