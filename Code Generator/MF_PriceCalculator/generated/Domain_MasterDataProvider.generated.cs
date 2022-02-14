
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/12/2018 7:24:00 AM
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
    #region Domain_Master Data Provider

    public partial class Domain_MasterDataProvider : MFEntityDataProviderBase<Domain_Master>
    {
        public Domain_MasterDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Domain_Id">Domain_Id</param>
        /// <returns>Entity</returns>
        public Domain_Master GetByPrimaryKey(string Domain_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Domain_Id", Domain_Id);
            Domain_Master entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Domain_Master entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Domain_Id = identity;
        }
    }

    #endregion

}
