
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/17/2019 4:45:43 PM
//-----------------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

using MFEntity.Entity;
using MFDataAccess.Data;
using MFEntity.Core.Entity;

namespace MFEntity.Entity.Data
{
    #region tbl_User Data Provider

    public partial class tbl_UserDataProvider : MFEntityDataProviderBase<tbl_User>
    {
        public tbl_UserDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="User_Id">User_Id</param>
        /// <returns>Entity</returns>
        public tbl_User GetByPrimaryKey(string User_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("User_Id", User_Id);
            tbl_User entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(tbl_User entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.User_Id = identity;
        }
    }

    #endregion

}
