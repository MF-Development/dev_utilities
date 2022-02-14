
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/6/2019 11:36:39 PM
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
    #region Sub_Category Data Provider

    public partial class Sub_CategoryDataProvider : MFEntityDataProviderBase<Sub_Category>
    {
        public Sub_CategoryDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Sub_Category_id">Sub_Category_id</param>
        /// <returns>Entity</returns>
        public Sub_Category GetByPrimaryKey(string Sub_Category_id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Sub_Category_id", Sub_Category_id);
            Sub_Category entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Sub_Category entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Sub_Category_id = identity;
        }
    }

    #endregion

}
