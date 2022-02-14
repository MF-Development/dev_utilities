
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 2/14/2022 9:46:44 AM
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
    #region ReservationType Data Provider

    public partial class ReservationTypeDataProvider : MFEntityDataProviderBase<ReservationType>
    {
        public ReservationTypeDataProvider() { }

        #region Members
        #endregion

        #region Properties
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Used to retrieve Entity data by primary key
        /// </summary>
        /// <param name="ReservationTypeId">ReservationTypeId</param>
        /// <returns>Entity</returns>
        public ReservationType GetByPrimaryKey(string ReservationTypeId)
        {
            Hashtable parameters = new Hashtable();
             parameters.Add("ReservationTypeId", ReservationTypeId);
            ReservationType entity = GetEntity(parameters);
            return entity;
        }

        #endregion

        protected override void SetIdentity(ReservationType entity, string identity)
        {
            base.SetIdentity(entity, identity);

            entity.ReservationTypeId = identity;
        }
    }

    #endregion

}
