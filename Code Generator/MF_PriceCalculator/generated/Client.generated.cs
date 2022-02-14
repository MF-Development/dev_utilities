
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/14/2019 9:59:49 AM
//-----------------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
//using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Linq;
using MFEntity.Entity.Data;
using MFDataAccess.Data;
using MFEntity.Core.Entity;

using MFUtility.Utility.StringExtensions;

#region Plugin Namespaces


#endregion

namespace MFEntity.Entity
{
    #region Client Entity

    /// <summary>
    /// Data object representation of the Client database table
    /// </summary>
    [Serializable]
    public partial class Client : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Client_Id,
           Client_Name,
           Club_Id,
           Salesforce_Id,
        }
        #endregion

        #region Class Member Declarations
        private string _Client_Id = String.Empty;
        private string _Client_Name = String.Empty;
        private string _Club_Id = String.Empty;
        private string _Salesforce_Id = String.Empty;
        #endregion

        #region Constructors
        public Client()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Client( string Client_Id, string Client_Name, string Club_Id, string Salesforce_Id)
        {
            this._Client_Id = Client_Id;
            this._Client_Name = Client_Name;
            this._Club_Id = Club_Id;
            this._Salesforce_Id = Salesforce_Id;
        }
        #endregion

        #region Plugin Class Property Declarations

        #region Identify Field Properties
        private string _IdentityFieldName = String.Empty;
        public override string IdentityFieldName
        {
            get
            {   
                // only return our private variable if its set
                if( String.IsNullOrEmpty( _IdentityFieldName ))
                {
                    return "Client_Id";
                }
        
                return _IdentityFieldName;
            }
            set
            {
                _IdentityFieldName = value;
            }
        }
        
        public override string IdentityFieldValue
        {            
            get
            {
                return GetProperty(IdentityFieldName);
            }
            set
            {
                SetProperty(IdentityFieldName, value);
            }
        }
        #endregion        
        
        #endregion

        #region Class Property Declarations
        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Client_Id
        {
            get {  return _Client_Id; }
            set
            {
                    if (!_Client_Id.Equals(value))
                    {
                       _Client_Id = value;
                       AddChangedField(Client.DBFieldName.Client_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Client_Name
        {
            get {  return _Client_Name; }
            set
            {
                    if (!_Client_Name.Equals(value))
                    {
                       _Client_Name = value;
                       AddChangedField(Client.DBFieldName.Client_Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Club_Id
        {
            get {  return _Club_Id; }
            set
            {
                    if (!_Club_Id.Equals(value))
                    {
                       _Club_Id = value;
                       AddChangedField(Client.DBFieldName.Club_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Salesforce_Id
        {
            get {  return _Salesforce_Id; }
            set
            {
                    if (!_Salesforce_Id.Equals(value))
                    {
                       _Salesforce_Id = value;
                       AddChangedField(Client.DBFieldName.Salesforce_Id.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "client_id":
                    this.Client_Id = value;
                    break;
                case "client_name":
                    this.Client_Name = value;
                    break;
                case "club_id":
                    this.Club_Id = value;
                    break;
                case "salesforce_id":
                    this.Salesforce_Id = value;
                    break;
                default:
                    base.SetCustomProperty(propertyName, value);
                    break;
            }
        }

        public override string GetProperty(string propertyName)
        {
            string returnValue = string.Empty;
            switch(propertyName.ToLower())
            {
                case "client_id":
                    returnValue = this.Client_Id;
                    break;
                case "client_name":
                    returnValue = this.Client_Name;
                    break;
                case "club_id":
                    returnValue = this.Club_Id;
                    break;
                case "salesforce_id":
                    returnValue = this.Salesforce_Id;
                    break;
                default:
                    returnValue = base.GetCustomProperty(propertyName);
                    break;
            }
            return returnValue;
        }

        #endregion

        #region Factory Methods
        
        /// <summary>
        /// Factory for creating an entity instance without default values
        /// </summary>
        /// <returns></returns>
        public static Client CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Client CreateEntity(bool applyDefaults)
        {
            if (applyDefaults)
            {
                return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithDefaultValues);
            }
            else
            {
                return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
            }
        }

        /// <summary>
        /// Factory for creating an entity instance in the specified style, WithDefaultValues or WithoutDefaultValues
        /// </summary>
        /// <param name="options">Specifies the creation style</param>
        /// <returns>Client instance</returns>
        public static Client CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Client entity = new Client();

            if (options == CreateEntityFactoryMethodOptionsEnum.WithDefaultValues)
            {
                entity.ApplyDefaults();
            }

            return entity;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Returns the name of the entity
        /// </summary>
        /// <returns>Entity Name</returns>
        public static string GetEntityName()
        {
            return typeof(Client).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Client";
        }

        /// <summary>
        /// Retrieves entity information by Client_Id
        /// </summary>
        /// <param name="Client_Id">Client_Id</param>
        /// <returns>Entity</returns>
        public static Client GetByPrimaryKey(string Client_Id)
        {
        	    ClientDataProvider provider = new ClientDataProvider();
        	    Client client = provider.GetByPrimaryKey(Client_Id);

        	    if (client == null)
        	    {
        		    client = new Client();
        	    }

        	    return client;
         }

        /// <summary>
        /// Retrieves a list of all client data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            ClientDataProvider provider = new ClientDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of client data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Client</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            ClientDataProvider provider = new ClientDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Client</returns>
        public static Client GetEntity(Hashtable parameters)
        {
            ClientDataProvider provider = new ClientDataProvider();
            return provider.GetEntity(parameters);
        }

        #region CRUD Abstract Method Implementations

        /// <summary>
        /// Saves Entity to database
        /// </summary>
        public override bool Save()
        {
            bool success = false;

            if (IsEntityModified)
            {
                PreSave();

                bool canSave = CanSave();

                if (!canSave)
                {
                    return false;
                }

                ApplyMandatoryDefaults();
                
                if (IsValid(this))
                {
                    ClientDataProvider provider = new ClientDataProvider();
                    success = provider.Save(this);
                }
            }
            else
            {
                success = true;
            }

            PostSave(success);

            return success;
        }

        /// <summary>
        /// Deletes Entity from database
        /// </summary>
        public override bool Delete()
        {
            bool success = false;

            PreDelete();

            bool canDelete = CanDelete();

            if (!canDelete)
            {
                return false;
            }

            ClientDataProvider provider = new ClientDataProvider();
            success = provider.Delete(this);

            PostDelete(success);

            return success;
        }

        #endregion

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Datatable</returns>
        public override DataTable DataBind()
        {
             ClientDataProvider provider = new ClientDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Client</returns>
        public static Client DataBind(DataRow dr)
        {
             ClientDataProvider provider = new ClientDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Client</returns>
        public static Client DataBindCopy(DataRow dr)
        {
             object[] itemArray = dr.ItemArray;
             DataTable table = dr.Table.Clone();
             table.Rows.Add(itemArray);
             return DataBind(table.Rows[0]);
        }

        #endregion

        #region Plugin Instance Methods

        #endregion
    }

    #endregion

}
