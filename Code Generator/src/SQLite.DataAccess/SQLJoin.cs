using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.SQLite.DataAccess
{


    public class SQLJoin : Object
    {
        #region Members
        /// <summary>
        /// Keyword to use for join (NOTE: InnerJoin is the default if none specified.)
        /// </summary>
        public enum JoinKeyword
        {
            InnerJoin,
            LeftJoin,
            RightJoin,
        }

        private JoinKeyword _joinType = JoinKeyword.InnerJoin;
        private string _objectName = String.Empty;
        private string _leftField = String.Empty;
        private string _rightField = String.Empty;
        private string _operator = "=";         
        #endregion

        #region Properties
        public string LeftField
        {
            get
            {
                return _leftField;
            }
            set
            {
                _leftField = value;
            }
        }

        public string RightField
        {
            get 
            {
                return _rightField;
            }
            set 
            {
                _rightField = value;
            }
        }

        private List<String> _joinExpression;

        public List<String> JoinExpression
        {
            get
            {
                if (_joinExpression == null)
                {
                    _joinExpression = new List<String>();
                }

                return _joinExpression;
            }
            set
            {
                _joinExpression = value;
            }
        }

        public string Operator
        {
            get
            {
                return _operator;
            }

            set
            {
                _operator = value;
            }
        }

        public string CurrentExpression
        {
            get
            {
                return LeftField + Operator + RightField;
            }
        }
        /// <summary>
        /// Type of join
        /// </summary>
        public JoinKeyword JoinType
        {
            get 
            {
                return _joinType;
            }
            set 
            {
                _joinType = value;
            }
        }

        public string ObjectName
        {
            get 
            {
                return _objectName.Trim();
            }
            set
            {
                _objectName = value;
            }

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder join = new StringBuilder();
            join.Append(GetJoinTypeString());
            join.Append(ObjectName + " ");
            join.Append("ON ");

            string joinOn = String.Empty;
            foreach (string expression in JoinExpression)
            {
                if (joinOn.Length > 0)
                {
                    joinOn += "AND ";
                }

                joinOn += expression + " ";
            }

            join.Append(joinOn);

            return join.ToString();
        }

        private string GetJoinTypeString()
        {
            string joinType = String.Empty;

            switch (this.JoinType.ToString().ToLower())
            {
                case "innerjoin":
                    joinType += "INNER JOIN ";
                    break;
                case "leftjoin":
                    joinType += "LEFT JOIN ";
                    break;
                case "rightjoin":
                    joinType += "RIGHT JOIN ";
                    break;
            }

            return joinType; 
        }
        #endregion

    }
}

