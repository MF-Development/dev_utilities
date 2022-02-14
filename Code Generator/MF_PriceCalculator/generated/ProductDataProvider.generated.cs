
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/12/2018 7:33:20 AM
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
    #region Product Data Provider

    public partial class ProductDataProvider : MFEntityDataProviderBase<Product>
    {
        public ProductDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Product_Id">Product_Id</param>
        /// <returns>Entity</returns>
        public Product GetByPrimaryKey(string Product_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Product_Id", Product_Id);
            Product entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Product entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Product_Id = identity;
        }
    }

    #endregion

}
