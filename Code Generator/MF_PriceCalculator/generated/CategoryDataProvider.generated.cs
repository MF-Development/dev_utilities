
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
    #region Category Data Provider

    public partial class CategoryDataProvider : MFEntityDataProviderBase<Category>
    {
        public CategoryDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Category_Id">Category_Id</param>
        /// <returns>Entity</returns>
        public Category GetByPrimaryKey(string Category_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Category_Id", Category_Id);
            Category entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Category entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Category_Id = identity;
        }
    }

    #endregion

}
