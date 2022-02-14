using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.SQLite.DataAccess
{
    /// <summary>
    /// Encapsulates the construction of an INSERT statement against a specific database object.
    /// </summary>
    public class SQLInsertQuery
    {
        #region Properties

        private string _objectName;

        public string ObjectName
        {
            get
            {
                if (_objectName == null)
                {
                    _objectName = string.Empty;
                }

                return _objectName;
            }
            set
            {
                _objectName = value;
            }
        }

        private Hashtable _valueParameters;

        public Hashtable ValueParameters
        {
            get
            {
                if (_valueParameters == null)
                {
                    _valueParameters = new Hashtable();
                }

                return _valueParameters;
            }
            set
            {
                _valueParameters = value;
            }
        }

        private string _returnIdentityFieldName;

        public string ReturnIdentityFieldName
        {
            get
            {
                if (_returnIdentityFieldName == null)
                {
                    _returnIdentityFieldName = "SCOPE_IDENTITY()";
                }

                return _returnIdentityFieldName;
            }
            set
            {
                _returnIdentityFieldName = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ObjectName))
            {
                throw new InvalidOperationException("SQLInsertQuery.ObjectName must not be null or empty.");
            }

            if (ValueParameters.Count < 1)
            {
                throw new InvalidOperationException("SQLInsertQuery does not support insert when ValueParameters is empty.");
            }

            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("INSERT INTO " + ObjectName + " ");

            int position = 0;

            foreach (string field in ValueParameters.Keys)
            {
                if (position == 0)
                {
                    sql.Append("(");
                }
                else
                {
                    sql.Append(", ");
                }

                sql.Append(field);

                position++;
            }

            sql.AppendLine(")");

            position = 0;

            foreach (string field in ValueParameters.Keys)
            {
                if (position == 0)
                {
                    sql.Append("VALUES (");
                }
                else
                {
                    sql.Append(", ");
                }

                sql.Append("@" + field);

                position++;
            }

            sql.AppendLine(")");
            sql.AppendLine();
            sql.Append(string.Format("SELECT {0}", ReturnIdentityFieldName));

            return sql.ToString();
        }

        #endregion
    }
}