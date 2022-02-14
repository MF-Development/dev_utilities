
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/14/2019 9:59:49 AM
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
    #region Client Data Provider

    public partial class ClientDataProvider : MFEntityDataProviderBase<Client>
    {
        public ClientDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Client_Id">Client_Id</param>
        /// <returns>Entity</returns>
        public Client GetByPrimaryKey(string Client_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Client_Id", Client_Id);
            Client entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Client entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Client_Id = identity;
        }
    }

    #endregion

}
