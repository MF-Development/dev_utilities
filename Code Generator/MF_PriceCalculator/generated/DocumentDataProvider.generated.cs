
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/19/2019 4:04:16 PM
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
    #region Document Data Provider

    public partial class DocumentDataProvider : MFEntityDataProviderBase<Document>
    {
        public DocumentDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Document_Id">Document_Id</param>
        /// <returns>Entity</returns>
        public Document GetByPrimaryKey(string Document_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Document_Id", Document_Id);
            Document entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Document entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Document_Id = identity;
        }
    }

    #endregion

}
