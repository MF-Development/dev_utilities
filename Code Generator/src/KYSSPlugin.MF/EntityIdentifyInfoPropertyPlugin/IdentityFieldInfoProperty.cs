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
    public class IdentityFieldInfoProperty : KYSSPluginInterfaces.IEntityStaticPropertyPlugin
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
            
            String query = String.Format(@"SELECT name as COLUMN_NAME FROM syscolumns WHERE id = OBJECT_ID('{0}') AND COLUMNPROPERTY( id, name, 'isidentity') = 1", tableName);
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
            if( !String.IsNullOrEmpty(rowGuidColumnName))
            {
            body = @"
#region Identify Field Properties
private string _IdentityFieldName = String.Empty;
public override string IdentityFieldName
{
    get
    {   
        // only return our private variable if its set
        if( String.IsNullOrEmpty( _IdentityFieldName ))
        {
            return [ROWGUIDCOLUMNNAME];
        }

        return _IdentityFieldName;
    }
    set
    {
        _IdentityFieldName = value;
    }
}

public override string IdentityFieldValue
{            
    get
    {
        return GetProperty(IdentityFieldName);
    }
    set
    {
        SetProperty(IdentityFieldName, value);
    }
}
#endregion        
";
            }

            body = body.Replace("[ROWGUIDCOLUMNNAME]", String.Format("\"{0}\"", rowGuidColumnName));
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
