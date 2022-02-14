
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/19/2019 4:49:17 PM
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
    #region Document_Template Data Provider

    public partial class Document_TemplateDataProvider : MFEntityDataProviderBase<Document_Template>
    {
        public Document_TemplateDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="Template_Id">Template_Id</param>
        /// <returns>Entity</returns>
        public Document_Template GetByPrimaryKey(string Template_Id)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("Template_Id", Template_Id);
            Document_Template entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(Document_Template entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.Template_Id = identity;
        }
    }

    #endregion

}
