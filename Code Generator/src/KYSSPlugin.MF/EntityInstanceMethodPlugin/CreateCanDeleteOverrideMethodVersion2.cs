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
    public class CreateCanDeleteOverrideMethodVersion2 : KYSSPluginInterfaces.IEntityInstanceMethodPlugin
    {

        #region IKYSSEntityPlugin Members

        public List<string> GetNamespaces(string namespaceBase)
        {
            return new List<string>();
        }

        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable)
        {
            return GetBody(tableName, fieldInfoTable, null);
        }

        public string GetBody(string tableName, System.Data.DataTable fieldInfoTable, params object[] args)
        {
            string body = string.Empty;

            string queryString = string.Format(
@"
SELECT count(*)
FROM
    fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', '{0}', NULL, NULL) AS ex
WHERE 
    ex.name = 'KYSS_Skip_CanDelete' AND
    ex.value = 'true'
", tableName);

            int count = Convert.ToInt32(CommonDataProvider.ExecuteScalar(queryString));

            if (count == 0)
            {
                queryString =
                    string.Format(
                        "SELECT SPECIFIC_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_NAME = 'MPI_{0}_CanDelete'",
                        tableName);

                DataTable table = CommonDataProvider.GetDataTable(queryString, new Hashtable(), false);

                string rowGuidColumnName = string.Empty;

                foreach (DataRow dr in fieldInfoTable.Rows)
                {
                    if (dr["IS_ROWGUID"].ToString() == "true")
                    {
                        rowGuidColumnName = dr["COLUMN_NAME"].ToString();

                        // Uppercase first
                        char[] chars = rowGuidColumnName.ToCharArray();
                        chars[0] = char.ToUpper(chars[0]);
                        rowGuidColumnName = new string(chars);
                    }
                }

                // If there is a row, then we need to override the CanDelete method
                if (table.Rows.Count > 0)
                {
                    body =
    @"
        protected override bool CanDelete()
        {
            bool canDelete = base.CanDelete();

            if (canDelete)
            {
                DataTable messages = MessageDefinition.GetMessagesFromProcedureCall(
                    ""MPI_" + tableName + @"_CanDelete"", this." + rowGuidColumnName + @");

                if (messages.Rows.Count > 0)
                {
                    canDelete = false;

                    foreach (DataRow row in messages.Rows)
                    {
                        MessageDefinition message = MessageDefinition.DataBind(row);

                        AddError(message.Msg);
                    }
                }
            }

            return canDelete;
        }
";
                }
            }

            return body;
        }

        #endregion
    }
}
