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
    public class CreateApplyMandatoryDefaultsOverrideMethod : KYSSPluginInterfaces.IEntityInstanceMethodPlugin
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

            var numericTypes = new string[] {
                "bigint",
                "int",
                "smallint",
                "tinyint",
                "bit",
                "decimal",
                "numeric",
                "money",
                "smallmoney",
                "float",
                "real"
            };

            StringBuilder defaults = new StringBuilder();

            foreach (DataRow dr in fieldInfoTable.Rows)
            {
                string dataType = dr["DATA_TYPE"].ToString().ToLower();
                bool isExcluded = (dr["EXCLUDED"].ToString().ToLower() == "true");
                bool isRequired = (dr["IS_REQUIRED"].ToString().ToLower() == "true");
                bool hasDatabaseDefault = (dr["HAS_DATABASE_DEFAULT"].ToString().ToLower() == "true");
                string defaultValue = dr["DEFAULT_VALUE"].ToString();

                if (!isExcluded && !String.IsNullOrEmpty(defaultValue))
                {
                    // Implicitly, numeric/bit fields are required to have defaults
                    if (numericTypes.Contains(dataType))
                    {
                        string columnName = dr["COLUMN_NAME"].ToString();
                        
                        // Uppercase first
                        char[] chars = columnName.ToCharArray();
                        chars[0] = char.ToUpper(chars[0]);
                        columnName = new string(chars);

                        // Business Requirement: all numeric or bit fields must default to 0 if they
                        // are string.Empty before insert.
                        // Enforcement: If no physical database default and no KYSS_DEFAULT_VALUE present, then exit
                        if (string.IsNullOrEmpty(defaultValue))
                        {
                            throw new InvalidOperationException(string.Format("Code generation failed: the column '{0}.{1}' is numeric or bit, but has no KYSS_Default_Value extended property defined in the database schema.",
                                tableName, columnName));
                        }
                        else
                        {

                            if (defaults.Length == 0)
                            {
                                // used to append KYSSEntityBase but we inherit so we should be ok
                                // AJD 08.12.2014
                                defaults.Append(
@"
        protected override void ApplyMandatoryDefaults()
        {
            bool isNewModified = CurrentEntityState == EntityState.NewModified;
");
                            } 
                       
                            string code;
                            if (String.IsNullOrEmpty(defaultValue))
                            {
                                code = "// TODO YOU NEED TO ADD METADATA FOR KYSS_Default_Value to the DB field and regenerate this!";
                            }
                            else
                            {
                                code =
@"            
            if (String.IsNullOrEmpty(this._" + columnName + @"))
            {
                if (isNewModified || PermissionFor(DBFieldName." + columnName + @".ToString()).IsAllowed(ResourceOperationEnum.Update))
                {
                    this._" + columnName + @" = " + defaultValue + @";
                }
            }";
                            }
                            defaults.Append(code);
                        }
                    }
                }
            }

            if (defaults.Length > 0)
            {
                defaults.Append(
@"
            return;
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
