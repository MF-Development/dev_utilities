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
    public class CreateGetByIdentityFieldPlugin : KYSSPluginInterfaces.IEntityInstanceMethodPlugin
    {
        #region IKYSSEntityPlugin Members
        
        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable)
        {
            return GetBody(tableName, fieldInfoTable, null);
        }

        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable, params object[] args)
        {
            string body = string.Empty;

            string rowGuidColumnName = string.Empty;

            String query = String.Format(@"SELECT name as COLUMN_NAME FROM syscolumns WHERE id = OBJECT_ID('{0}') AND COLUMNPROPERTY( id, name, 'IsRowGuidCol') = 1", tableName);
            DataTable dt = CommonDataProvider.GetDataTable(query);
            foreach (DataRow dr in dt.Rows)
            {
                rowGuidColumnName = dr["COLUMN_NAME"].ToString();

                // Uppercase first
                char[] chars = rowGuidColumnName.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                rowGuidColumnName = new string(chars);
                break;
            }
            if (!String.IsNullOrEmpty(rowGuidColumnName))
            {
                body = @"
        public static [TABLENAME] GetByIdentityField(string [ROWGUIDCOLUMNNAME])
        {
            [TABLENAME]DataProvider provider = new [TABLENAME]DataProvider();
            return provider.GetByIdentityField([ROWGUIDCOLUMNNAME]);
        }
";                
            }
            body = body.Replace("[ROWGUIDCOLUMNNAME]", String.Format("{0}", rowGuidColumnName.ToLower()));
            return body;
        }


        public List<string> GetNamespaces(string namespaceBase)
        {
            List<string> namespaces = new List<string>();
            return namespaces;
        }

        #endregion
    }
}
