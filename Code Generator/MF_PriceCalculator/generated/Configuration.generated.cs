
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/18/2019 9:37:40 PM
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
    #region Configuration Entity

    /// <summary>
    /// Data object representation of the Configuration database table
    /// </summary>
    [Serializable]
    public partial class Configuration : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Client_Id,
           Config_Desc,
           Config_Id,
           Created_date,
           Last_updated_date,
           Last_updated_user,
           Locked,
           Locked_by,
           Locked_date,
           Status,
        }
        #endregion

        #region Class Member Declarations
        private string _Client_Id = String.Empty;
        private string _Config_Desc = String.Empty;
        private string _Config_Id = String.Empty;
        private string _Created_date = String.Empty;
        private string _Last_updated_date = String.Empty;
        private string _Last_updated_user = String.Empty;
        private string _Locked = String.Empty;
        private string _Locked_by = String.Empty;
        private string _Locked_date = String.Empty;
        private string _Status = String.Empty;
        #endregion

        #region Constructors
        public Configuration()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Configuration( string Client_Id, string Config_Desc, string Config_Id, string Created_date, string Last_updated_date, string Last_updated_user, string Locked, string Locked_by, string Locked_date, string Status)
        {
            this._Client_Id = Client_Id;
            this._Config_Desc = Config_Desc;
            this._Config_Id = Config_Id;
            this._Created_date = Created_date;
            this._Last_updated_date = Last_updated_date;
            this._Last_updated_user = Last_updated_user;
            this._Locked = Locked;
            this._Locked_by = Locked_by;
            this._Locked_date = Locked_date;
            this._Status = Status;
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
                    return "Config_Id";
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
        [IsRequiredField(true)]
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
                       AddChangedField(Configuration.DBFieldName.Client_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Config_Desc
        {
            get {  return _Config_Desc; }
            set
            {
                    if (!_Config_Desc.Equals(value))
                    {
                       _Config_Desc = value;
                       AddChangedField(Configuration.DBFieldName.Config_Desc.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Config_Id
        {
            get {  return _Config_Id; }
            set
            {
                    if (!_Config_Id.Equals(value))
                    {
                       _Config_Id = value;
                       AddChangedField(Configuration.DBFieldName.Config_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Created_date
        {
            get {  return _Created_date; }
            set
            {
                    if (!_Created_date.Equals(value))
                    {
                       _Created_date = value;
                       AddChangedField(Configuration.DBFieldName.Created_date.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Last_updated_date
        {
            get {  return _Last_updated_date; }
            set
            {
                    if (!_Last_updated_date.Equals(value))
                    {
                       _Last_updated_date = value;
                       AddChangedField(Configuration.DBFieldName.Last_updated_date.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Last_updated_user
        {
            get {  return _Last_updated_user; }
            set
            {
                    if (!_Last_updated_user.Equals(value))
                    {
                       _Last_updated_user = value;
                       AddChangedField(Configuration.DBFieldName.Last_updated_user.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Locked
        {
            get {  return _Locked; }
            set
            {
                    if (!_Locked.Equals(value))
                    {
                       _Locked = value;
                       AddChangedField(Configuration.DBFieldName.Locked.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Locked_by
        {
            get {  return _Locked_by; }
            set
            {
                    if (!_Locked_by.Equals(value))
                    {
                       _Locked_by = value;
                       AddChangedField(Configuration.DBFieldName.Locked_by.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Locked_date
        {
            get {  return _Locked_date; }
            set
            {
                    if (!_Locked_date.Equals(value))
                    {
                       _Locked_date = value;
                       AddChangedField(Configuration.DBFieldName.Locked_date.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Status
        {
            get {  return _Status; }
            set
            {
                    if (!_Status.Equals(value))
                    {
                       _Status = value;
                       AddChangedField(Configuration.DBFieldName.Status.ToString(), value);
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
                case "config_desc":
                    this.Config_Desc = value;
                    break;
                case "config_id":
                    this.Config_Id = value;
                    break;
                case "created_date":
                    this.Created_date = value;
                    break;
                case "last_updated_date":
                    this.Last_updated_date = value;
                    break;
                case "last_updated_user":
                    this.Last_updated_user = value;
                    break;
                case "locked":
                    this.Locked = value;
                    break;
                case "locked_by":
                    this.Locked_by = value;
                    break;
                case "locked_date":
                    this.Locked_date = value;
                    break;
                case "status":
                    this.Status = value;
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
                case "config_desc":
                    returnValue = this.Config_Desc;
                    break;
                case "config_id":
                    returnValue = this.Config_Id;
                    break;
                case "created_date":
                    returnValue = this.Created_date;
                    break;
                case "last_updated_date":
                    returnValue = this.Last_updated_date;
                    break;
                case "last_updated_user":
                    returnValue = this.Last_updated_user;
                    break;
                case "locked":
                    returnValue = this.Locked;
                    break;
                case "locked_by":
                    returnValue = this.Locked_by;
                    break;
                case "locked_date":
                    returnValue = this.Locked_date;
                    break;
                case "status":
                    returnValue = this.Status;
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
        public static Configuration CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Configuration CreateEntity(bool applyDefaults)
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
        /// <returns>Configuration instance</returns>
        public static Configuration CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Configuration entity = new Configuration();

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
            return typeof(Configuration).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Configuration";
        }

        /// <summary>
        /// Retrieves entity information by Config_Id
        /// </summary>
        /// <param name="Config_Id">Config_Id</param>
        /// <returns>Entity</returns>
        public static Configuration GetByPrimaryKey(string Config_Id)
        {
        	    ConfigurationDataProvider provider = new ConfigurationDataProvider();
        	    Configuration configuration = provider.GetByPrimaryKey(Config_Id);

        	    if (configuration == null)
        	    {
        		    configuration = new Configuration();
        	    }

        	    return configuration;
         }

        /// <summary>
        /// Retrieves a list of all configuration data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            ConfigurationDataProvider provider = new ConfigurationDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of configuration data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            ConfigurationDataProvider provider = new ConfigurationDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration</returns>
        public static Configuration GetEntity(Hashtable parameters)
        {
            ConfigurationDataProvider provider = new ConfigurationDataProvider();
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
                    ConfigurationDataProvider provider = new ConfigurationDataProvider();
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

            ConfigurationDataProvider provider = new ConfigurationDataProvider();
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
             ConfigurationDataProvider provider = new ConfigurationDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Configuration</returns>
        public static Configuration DataBind(DataRow dr)
        {
             ConfigurationDataProvider provider = new ConfigurationDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Configuration</returns>
        public static Configuration DataBindCopy(DataRow dr)
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
