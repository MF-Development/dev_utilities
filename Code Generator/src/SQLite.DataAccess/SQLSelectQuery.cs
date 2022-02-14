using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApplication.SQLite.DataAccess
{
    public class SQLSelectQuery : Object
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

        private bool _distinct;

        public bool Distinct
        {
            get
            {
                return _distinct;
            }
            set
            {
                _distinct = value;
            }
        }
    
        private List<string> _fields;

        public List<string> Fields
        { 
            get
            {
                if (_fields == null)
                {
                    _fields = new List<string>();
                }

                return _fields;
            }
            set
            {
                _fields = value;
            }
        }

        public List<SQLJoin> _joinCollection;
        
        public List<SQLJoin> JoinCollection
        {
            get
            {
                if (_joinCollection == null)
                {
                    _joinCollection = new List<SQLJoin>();
                }

                return _joinCollection;
            }
            set
            {
                _joinCollection = value;
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

        private string _whereClauseStatement;

        public string WhereClauseStatement
        {
            get
            {
                if (_whereClauseStatement == null)
                {
                    _whereClauseStatement = string.Empty;
                }
                
                return _whereClauseStatement;
            }
            set
            {
                _whereClauseStatement = value;
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

        private string _orderByClause;

        public string OrderByClause
        {
            get
            {
                if (_orderByClause == null)
                {
                    _orderByClause = string.Empty;
                }

                return _orderByClause;
            }
            set
            {
                _orderByClause = value;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ObjectName))
            {
                throw new InvalidOperationException("SQLSelectQuery.ObjectName must not be null or empty.");
            }

            if (!string.IsNullOrEmpty(WhereClauseStatement) && WhereClauseParameters.Count < 1)
            {
                throw new InvalidOperationException("SQLSelectQuery.WhereClauseParameters must not be null or empty when specifiying WhereClauseStatement.");
            }

            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            int position;

            sql.Append("SELECT ");

            if (Distinct)
            {
                sql.Append("DISTINCT ");
            }

            if (Fields.Count < 1)
            {
                if (JoinCollection.Count > 0)
                {
                    sql.Append(ObjectName + ".*");
                }
                else
                {
                    sql.Append("*");
                }
            }
            else
            {
                position = 0;

                foreach (string field in Fields)
                {
                    if (position > 0)
                    {
                        sql.Append(", ");
                    }

                    sql.Append(field);

                    position++;
                }
            }

            sql.AppendLine(Environment.NewLine + "FROM " + ObjectName);

            //RJT 2009.06.18 - Added JOIN Collection
            if (JoinCollection.Count > 0)
            {
                StringBuilder joinString = new StringBuilder();
                foreach (SQLJoin join in JoinCollection)
                {
                    joinString.AppendLine(join.ToString());
                }

                sql.Append(joinString.ToString());
            }

            // reset position
            position = 0;

            if (WhereClauseParameters.Count > 0)
            {
                if (!string.IsNullOrEmpty(WhereClauseStatement))
                {
                    sql.AppendLine("WHERE");
                    sql.AppendLine(WhereClauseStatement);
                    position++;
                }
                else
                {
                    foreach (string key in WhereClauseParameters.Keys)
                    {
                        if (position == 0)
                        {
                            sql.AppendLine("WHERE");
                        }
                        else
                        {
                            sql.AppendLine(Environment.NewLine + "AND ");
                        }

                        //rjt 2009.06.18 added
                        string parameterName = key;
                        if (parameterName.Contains("."))
                        {
                            parameterName = key.Substring(key.IndexOf('.') + 1);
                        }

                        sql.Append(key + " = @" + parameterName);

                        position++;
                    }
                }
            }            

            if (!string.IsNullOrEmpty(WhereClauseFragment))
            {
                if (position == 0)
                {
                    sql.AppendLine("WHERE " + WhereClauseFragment);
                }
                else
                {
                    sql.AppendLine(Environment.NewLine + "AND " + WhereClauseFragment);
                }
            }

            string sqlText = sql.ToString();

            if (!string.IsNullOrEmpty(OrderByClause))
            {
                if (!sqlText.EndsWith(Environment.NewLine))
                {
                    sqlText += Environment.NewLine;
                }

                sqlText += "ORDER BY " + OrderByClause;
            }

            return sqlText;
        }

        #endregion
    }
}
