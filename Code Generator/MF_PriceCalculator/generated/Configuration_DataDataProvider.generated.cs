
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/17/2019 4:31:30 PM
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
    #region Configuration_Data Data Provider

    public partial class Configuration_DataDataProvider : MFEntityDataProviderBase<Configuration_Data>
    {
        public Configuration_DataDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Config_Data_Id">Config_Data_Id</param>
        /// <returns>Entity</returns>
        public Configuration_Data GetByPrimaryKey(string Config_Data_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Config_Data_Id", Config_Data_Id);
            Configuration_Data entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Configuration_Data entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Config_Data_Id = identity;
        }
    }

    #endregion

}
