using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using KYSSPluginInterfaces;
using CodeGenerator.SQLServer.DataAccess;

namespace MFPlugins.MRM.EntityInstanceMethodPlugin
{
    public class CreateApplyDefaultsOverrideMethodCustom : KYSSPluginInterfaces.IEntityInstanceMethodCustomPlugin
    {
        #region IKYSSEntityPlugin Members

        public List<string> GetNamespaces(string namespaceBase)
        {
            List<string> namespaces = new List<string>();
            return namespaces;
        
        }

        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable)
        {
            return GetBody(tableName, fieldInfoTable, null);
        }

        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable, params object[] args)
        {            
            string body = string.Empty;

            StringBuilder defaults = new StringBuilder();

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                string dataType = dr["DATA_TYPE"].ToString().ToLower();
                bool isExcluded = (dr["EXCLUDED"].ToString().ToLower() == "true");
                bool isRequired = (dr["IS_REQUIRED"].ToString().ToLower() == "true");
                bool hasDatabaseDefault = (dr["HAS_DATABASE_DEFAULT"].ToString().ToLower() == "true");
                string defaultValue = dr["DEFAULT_VALUE"].ToString();

                if (!isExcluded)
                {                
                    string columnName = dr["COLUMN_NAME"].ToString();

                    // Uppercase first
                    char[] chars = columnName.ToCharArray();
                    chars[0] = char.ToUpper(chars[0]);
                    columnName = new string(chars);

                    const string todoValue = "KYSS_TODO!";

                    if (string.IsNullOrEmpty(defaultValue))
                    {
                        defaultValue = todoValue;
                    }

                    if (defaults.Length == 0)
                    {
                        defaults.Append(
@"
        public override void ApplyDefaults()        
        {
");
                    }

                    // Two cases:
                    // 1) In the general case, if it is required, and there is no default, then add to the method
                    // 2) Otherwise, if it is required and the KYSS_DEFAULT_VALUE has been manually specified in
                    // the extended attributes, then add to the method
                    if ((isRequired && !hasDatabaseDefault) || (isRequired && defaultValue != todoValue))
                    {
                        defaults.Append(
@"            this." + columnName + @" = " + defaultValue + @";
");

                    }                
                }
            }

            if (defaults.Length > 0)
            {
                defaults.Append(@"
        }
");
                if (defaults.Length > 0)
                {
                    body = defaults.ToString();
                }
            }

            return body;
        }
    }
}
        #endregion
