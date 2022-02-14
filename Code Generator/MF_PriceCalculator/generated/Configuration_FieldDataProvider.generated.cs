
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 8/5/2019 11:16:27 AM
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
    #region Configuration_Field Data Provider

    public partial class Configuration_FieldDataProvider : MFEntityDataProviderBase<Configuration_Field>
    {
        public Configuration_FieldDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Config_Field_Id">Config_Field_Id</param>
        /// <returns>Entity</returns>
        public Configuration_Field GetByPrimaryKey(string Config_Field_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Config_Field_Id", Config_Field_Id);
            Configuration_Field entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Configuration_Field entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Config_Field_Id = identity;
        }
    }

    #endregion

}
