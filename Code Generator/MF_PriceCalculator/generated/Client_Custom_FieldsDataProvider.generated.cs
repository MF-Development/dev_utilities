
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 5/9/2019 2:44:45 PM
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
    #region Client_Custom_Fields Data Provider

    public partial class Client_Custom_FieldsDataProvider : MFEntityDataProviderBase<Client_Custom_Fields>
    {
        public Client_Custom_FieldsDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Client_Custom_Field_Id">Client_Custom_Field_Id</param>
        /// <returns>Entity</returns>
        public Client_Custom_Fields GetByPrimaryKey(string Client_Custom_Field_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Client_Custom_Field_Id", Client_Custom_Field_Id);
            Client_Custom_Fields entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Client_Custom_Fields entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Client_Custom_Field_Id = identity;
        }
    }

    #endregion

}
