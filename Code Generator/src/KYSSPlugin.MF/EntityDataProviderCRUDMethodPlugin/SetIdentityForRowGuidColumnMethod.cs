using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;

using KYSSPluginInterfaces;

namespace MFPlugins.MRM.EntityDataProviderCRUDMethodPlugin
{
    public class SetIdentityForIdentityFieldColumnMethod : IEntityDataProviderCRUDMethodPlugin
    {
        #region IKYSSEntityPlugin Members

        private bool _handledSetIdentity = false;

        public bool HandledSetIdentity        
        {
            get
            {
                return _handledSetIdentity;
            }
            private set
            {
                _handledSetIdentity = value;
            }
        }

        public List<string> GetNamespaces(string namespaceBase)
        {
            return new List<string>();
        }

        public string GetBody(string tableName, DataTable fieldInfoTable)
        {
            return GetBody(tableName, fieldInfoTable, null);
        }

        public string GetBody(string tableName, DataTable fieldInfoTable, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                if (dr["is_identity"].ToString() == "true")
                {
                    HandledSetIdentity = true;

                    sb.AppendLine("        public override SQLInsertQuery CreateInsertQuery([CLASSNAME] entity)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            SQLInsertQuery insertQuery = base.CreateInsertQuery(entity);");
                    sb.AppendLine("            insertQuery.ReturnIdentityFieldName = \"@\" + [CLASSNAME].DBFieldName." + dr["COLUMN_NAME"].ToString() + ".ToString();");
                    sb.AppendLine("");
                    sb.AppendLine("            return insertQuery;");
                    sb.AppendLine("        }");
                    sb.AppendLine("");
                    sb.AppendLine("        protected override void SetIdentity([CLASSNAME] entity, string identity)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            base.SetIdentity(entity, identity);");
                    sb.AppendLine("");
                    sb.AppendLine("            entity." + dr["COLUMN_NAME"].ToString() + " = identity;");
                    sb.AppendLine("        }");
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}

