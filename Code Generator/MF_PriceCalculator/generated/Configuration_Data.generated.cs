
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/17/2019 4:31:30 PM
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
    #region Configuration_Data Entity

    /// <summary>
    /// Data object representation of the Configuration_Data database table
    /// </summary>
    [Serializable]
    public partial class Configuration_Data : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Config_Data_Id,
           Config_Id,
           Data_Value,
           Domain_Code_Id,
        }
        #endregion

        #region Class Member Declarations
        private string _Config_Data_Id = String.Empty;
        private string _Config_Id = String.Empty;
        private string _Data_Value = String.Empty;
        private string _Domain_Code_Id = String.Empty;
        #endregion

        #region Constructors
        public Configuration_Data()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Configuration_Data( string Config_Data_Id, string Config_Id, string Data_Value, string Domain_Code_Id)
        {
            this._Config_Data_Id = Config_Data_Id;
            this._Config_Id = Config_Id;
            this._Data_Value = Data_Value;
            this._Domain_Code_Id = Domain_Code_Id;
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
                    return "Config_Data_Id";
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
        public string Config_Data_Id
        {
            get {  return _Config_Data_Id; }
            set
            {
                    if (!_Config_Data_Id.Equals(value))
                    {
                       _Config_Data_Id = value;
                       AddChangedField(Configuration_Data.DBFieldName.Config_Data_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
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
                       AddChangedField(Configuration_Data.DBFieldName.Config_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Data_Value
        {
            get {  return _Data_Value; }
            set
            {
                    if (!_Data_Value.Equals(value))
                    {
                       _Data_Value = value;
                       AddChangedField(Configuration_Data.DBFieldName.Data_Value.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Id
        {
            get {  return _Domain_Code_Id; }
            set
            {
                    if (!_Domain_Code_Id.Equals(value))
                    {
                       _Domain_Code_Id = value;
                       AddChangedField(Configuration_Data.DBFieldName.Domain_Code_Id.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "config_data_id":
                    this.Config_Data_Id = value;
                    break;
                case "config_id":
                    this.Config_Id = value;
                    break;
                case "data_value":
                    this.Data_Value = value;
                    break;
                case "domain_code_id":
                    this.Domain_Code_Id = value;
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
                case "config_data_id":
                    returnValue = this.Config_Data_Id;
                    break;
                case "config_id":
                    returnValue = this.Config_Id;
                    break;
                case "data_value":
                    returnValue = this.Data_Value;
                    break;
                case "domain_code_id":
                    returnValue = this.Domain_Code_Id;
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
        public static Configuration_Data CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Configuration_Data CreateEntity(bool applyDefaults)
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
        /// <returns>Configuration_Data instance</returns>
        public static Configuration_Data CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Configuration_Data entity = new Configuration_Data();

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
            return typeof(Configuration_Data).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Configuration_Data";
        }

        /// <summary>
        /// Retrieves entity information by Config_Data_Id
        /// </summary>
        /// <param name="Config_Data_Id">Config_Data_Id</param>
        /// <returns>Entity</returns>
        public static Configuration_Data GetByPrimaryKey(string Config_Data_Id)
        {
        	    Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
        	    Configuration_Data configuration_Data = provider.GetByPrimaryKey(Config_Data_Id);

        	    if (configuration_Data == null)
        	    {
        		    configuration_Data = new Configuration_Data();
        	    }

        	    return configuration_Data;
         }

        /// <summary>
        /// Retrieves a list of all configuration_Data data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of configuration_Data data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration_Data</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration_Data</returns>
        public static Configuration_Data GetEntity(Hashtable parameters)
        {
            Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
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
                    Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
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

            Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
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
             Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Configuration_Data</returns>
        public static Configuration_Data DataBind(DataRow dr)
        {
             Configuration_DataDataProvider provider = new Configuration_DataDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Configuration_Data</returns>
        public static Configuration_Data DataBindCopy(DataRow dr)
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
