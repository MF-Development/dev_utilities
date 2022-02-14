
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/24/2019 12:41:49 PM
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
    #region Field Data Provider

    public partial class FieldDataProvider : MFEntityDataProviderBase<Field>
    {
        public FieldDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Field_Id">Field_Id</param>
        /// <returns>Entity</returns>
        public Field GetByPrimaryKey(string Field_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Field_Id", Field_Id);
            Field entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Field entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Field_Id = identity;
        }
    }

    #endregion

}
