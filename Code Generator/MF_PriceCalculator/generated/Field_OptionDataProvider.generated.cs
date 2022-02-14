
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 5/29/2019 8:46:05 AM
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
    #region Field_Option Data Provider

    public partial class Field_OptionDataProvider : MFEntityDataProviderBase<Field_Option>
    {
        public Field_OptionDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Option_Id">Option_Id</param>
        /// <returns>Entity</returns>
        public Field_Option GetByPrimaryKey(string Option_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Option_Id", Option_Id);
            Field_Option entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Field_Option entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Option_Id = identity;
        }
    }

    #endregion

}
