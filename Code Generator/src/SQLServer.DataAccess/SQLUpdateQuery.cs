using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.SQLServer.DataAccess
{
    /// <summary>
    /// Encapsulates the construction of an UPDATE statement against a specific database object.
    /// </summary>
    public class SQLUpdateQuery
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

        private string _whereClauseFragment;

        public string WhereClauseFragment
        {
            get
            {
                if (_whereClauseFragment == null)
                {
                    _whereClauseFragment = string.Empty;
                }

                return _whereClauseFragment;
            }
            set
            {
                _whereClauseFragment = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ObjectName))
            {
                throw new InvalidOperationException("SQLUpdateQuery.ObjectName must not be null or empty.");
            }

            if (ValueParameters.Count < 1)
            {
                throw new InvalidOperationException("SQLUpdateQuery does not support updates when ValueParameters is empty.");
            }

            if (WhereClauseParameters.Count < 1)
            {
                throw new InvalidOperationException("SQLUpdateQuery does not support updates when WhereClauseParameters is empty.");
            }

            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("UPDATE " + ObjectName + Environment .NewLine + "SET ");

            int position = 0;

            foreach (string field in ValueParameters.Keys)
            {
                if (position > 0)
                {
                    sql.Append(", ");
                }

                sql.Append(field + " = " + (String.IsNullOrEmpty(ValueParameters[field].ToString()) ? "null" : "@" + field));

                position++;
            }

            sql.Append(Environment.NewLine);

            position = 0;

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

            if (!string.IsNullOrEmpty(WhereClauseFragment))
            {
                if (position == 0)
                {
                    sql.Append("WHERE " + WhereClauseFragment);
                }
                else
                {
                    sql.Append(Environment.NewLine + "AND " + WhereClauseFragment);
                }
            }

            return sql.ToString();
        }

        #endregion
    }
}