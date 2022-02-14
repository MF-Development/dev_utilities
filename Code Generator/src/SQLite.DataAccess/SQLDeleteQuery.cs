using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.SQLite.DataAccess
{
    /// <summary>
    /// Encapsulates the construction of DELETE statement against a specific database object.
    /// </summary>
    public class SQLDeleteQuery
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

        private Hashtable _whereClauseParameters;

        public Hashtable WhereClauseParameters
        {
            get
            {
                if (_whereClauseParameters == null)
                {
                    _whereClauseParameters = new Hashtable();
                }

                return _whereClauseParameters;
            }
            set
            {
                _whereClauseParameters = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ObjectName))
            {
                throw new InvalidOperationException("SQLDeleteQuery.ObjectName must not be null or empty.");
            }

            if (WhereClauseParameters.Count < 1)
            {
                throw new InvalidOperationException("SQLDeleteQuery does not support delete when WhereClauseParameters is empty.");
            }

            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.AppendLine("DELETE FROM " + ObjectName);

            int position = 0;

            foreach (string key in WhereClauseParameters.Keys)
            {
                if (position == 0)
                {
                    sql.Append("WHERE ");
                }
                else
                {
                    sql.Append(Environment.NewLine + "AND ");
                }

                sql.Append(key + " = @" + key);

                position++;
            }

            return sql.ToString();
        }

        #endregion
    }
}