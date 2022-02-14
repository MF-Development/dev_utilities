using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KYSSPluginInterfaces
{
    public interface IKYSSEntityPlugin
    {
        List<string> GetNamespaces(string namespaceBase);
        string GetBody(string tableName, DataTable fieldInfoTable);
        string GetBody(string tableName, DataTable fieldInfoTable, params object[] args);
    }
}
