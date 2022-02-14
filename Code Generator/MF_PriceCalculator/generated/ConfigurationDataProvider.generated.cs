
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/18/2019 9:37:40 PM
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
    #region Configuration Data Provider

    public partial class ConfigurationDataProvider : MFEntityDataProviderBase<Configuration>
    {
        public ConfigurationDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Config_Id">Config_Id</param>
        /// <returns>Entity</returns>
        public Configuration GetByPrimaryKey(string Config_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Config_Id", Config_Id);
            Configuration entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Configuration entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Config_Id = identity;
        }
    }

    #endregion

}
