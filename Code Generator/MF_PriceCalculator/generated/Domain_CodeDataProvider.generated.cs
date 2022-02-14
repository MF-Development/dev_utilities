
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
    #region Domain_Code Data Provider

    public partial class Domain_CodeDataProvider : MFEntityDataProviderBase<Domain_Code>
    {
        public Domain_CodeDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Domain_Code_Id">Domain_Code_Id</param>
        /// <returns>Entity</returns>
        public Domain_Code GetByPrimaryKey(string Domain_Code_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Domain_Code_Id", Domain_Code_Id);
            Domain_Code entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Domain_Code entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Domain_Code_Id = identity;
        }
    }

    #endregion

}
