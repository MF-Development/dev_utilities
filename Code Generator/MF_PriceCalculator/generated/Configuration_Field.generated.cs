
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 8/5/2019 11:16:27 AM
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
    #region Configuration_Field Entity

    /// <summary>
    /// Data object representation of the Configuration_Field database table
    /// </summary>
    [Serializable]
    public partial class Configuration_Field : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Calc_Field_Id,
           Calc_Product_Id,
           CAP_Discount,
           Config_Field_Id,
           Config_Id,
           Discount,
           Field_Option_Id,
           Field_Value,
           Monthly_Discount,
           Notes,
           Skip_setup,
           Waive_setup,
        }
        #endregion

        #region Class Member Declarations
        private string _Calc_Field_Id = String.Empty;
        private string _Calc_Product_Id = String.Empty;
        private string _CAP_Discount = String.Empty;
        private string _Config_Field_Id = String.Empty;
        private string _Config_Id = String.Empty;
        private string _Discount = String.Empty;
        private string _Field_Option_Id = String.Empty;
        private string _Field_Value = String.Empty;
        private string _Monthly_Discount = String.Empty;
        private string _Notes = String.Empty;
        private string _Skip_setup = String.Empty;
        private string _Waive_setup = String.Empty;
        #endregion

        #region Constructors
        public Configuration_Field()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Configuration_Field( string Calc_Field_Id, string Calc_Product_Id, string CAP_Discount, string Config_Field_Id, string Config_Id, string Discount, string Field_Option_Id, string Field_Value, string Monthly_Discount, string Notes, string Skip_setup, string Waive_setup)
        {
            this._Calc_Field_Id = Calc_Field_Id;
            this._Calc_Product_Id = Calc_Product_Id;
            this._CAP_Discount = CAP_Discount;
            this._Config_Field_Id = Config_Field_Id;
            this._Config_Id = Config_Id;
            this._Discount = Discount;
            this._Field_Option_Id = Field_Option_Id;
            this._Field_Value = Field_Value;
            this._Monthly_Discount = Monthly_Discount;
            this._Notes = Notes;
            this._Skip_setup = Skip_setup;
            this._Waive_setup = Waive_setup;
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
                    return "Config_Field_Id";
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
        public string Calc_Field_Id
        {
            get {  return _Calc_Field_Id; }
            set
            {
                    if (!_Calc_Field_Id.Equals(value))
                    {
                       _Calc_Field_Id = value;
                       AddChangedField(Configuration_Field.DBFieldName.Calc_Field_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Calc_Product_Id
        {
            get {  return _Calc_Product_Id; }
            set
            {
                    if (!_Calc_Product_Id.Equals(value))
                    {
                       _Calc_Product_Id = value;
                       AddChangedField(Configuration_Field.DBFieldName.Calc_Product_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string CAP_Discount
        {
            get {  return _CAP_Discount; }
            set
            {
                    if (!_CAP_Discount.Equals(value))
                    {
                       _CAP_Discount = value;
                       AddChangedField(Configuration_Field.DBFieldName.CAP_Discount.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Config_Field_Id
        {
            get {  return _Config_Field_Id; }
            set
            {
                    if (!_Config_Field_Id.Equals(value))
                    {
                       _Config_Field_Id = value;
                       AddChangedField(Configuration_Field.DBFieldName.Config_Field_Id.ToString(), value);
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
                       AddChangedField(Configuration_Field.DBFieldName.Config_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Discount
        {
            get {  return _Discount; }
            set
            {
                    if (!_Discount.Equals(value))
                    {
                       _Discount = value;
                       AddChangedField(Configuration_Field.DBFieldName.Discount.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Field_Option_Id
        {
            get {  return _Field_Option_Id; }
            set
            {
                    if (!_Field_Option_Id.Equals(value))
                    {
                       _Field_Option_Id = value;
                       AddChangedField(Configuration_Field.DBFieldName.Field_Option_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Field_Value
        {
            get {  return _Field_Value; }
            set
            {
                    if (!_Field_Value.Equals(value))
                    {
                       _Field_Value = value;
                       AddChangedField(Configuration_Field.DBFieldName.Field_Value.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Monthly_Discount
        {
            get {  return _Monthly_Discount; }
            set
            {
                    if (!_Monthly_Discount.Equals(value))
                    {
                       _Monthly_Discount = value;
                       AddChangedField(Configuration_Field.DBFieldName.Monthly_Discount.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Notes
        {
            get {  return _Notes; }
            set
            {
                    if (!_Notes.Equals(value))
                    {
                       _Notes = value;
                       AddChangedField(Configuration_Field.DBFieldName.Notes.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Skip_setup
        {
            get {  return _Skip_setup; }
            set
            {
                    if (!_Skip_setup.Equals(value))
                    {
                       _Skip_setup = value;
                       AddChangedField(Configuration_Field.DBFieldName.Skip_setup.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Waive_setup
        {
            get {  return _Waive_setup; }
            set
            {
                    if (!_Waive_setup.Equals(value))
                    {
                       _Waive_setup = value;
                       AddChangedField(Configuration_Field.DBFieldName.Waive_setup.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "calc_field_id":
                    this.Calc_Field_Id = value;
                    break;
                case "calc_product_id":
                    this.Calc_Product_Id = value;
                    break;
                case "cap_discount":
                    this.CAP_Discount = value;
                    break;
                case "config_field_id":
                    this.Config_Field_Id = value;
                    break;
                case "config_id":
                    this.Config_Id = value;
                    break;
                case "discount":
                    this.Discount = value;
                    break;
                case "field_option_id":
                    this.Field_Option_Id = value;
                    break;
                case "field_value":
                    this.Field_Value = value;
                    break;
                case "monthly_discount":
                    this.Monthly_Discount = value;
                    break;
                case "notes":
                    this.Notes = value;
                    break;
                case "skip_setup":
                    this.Skip_setup = value;
                    break;
                case "waive_setup":
                    this.Waive_setup = value;
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
                case "calc_field_id":
                    returnValue = this.Calc_Field_Id;
                    break;
                case "calc_product_id":
                    returnValue = this.Calc_Product_Id;
                    break;
                case "cap_discount":
                    returnValue = this.CAP_Discount;
                    break;
                case "config_field_id":
                    returnValue = this.Config_Field_Id;
                    break;
                case "config_id":
                    returnValue = this.Config_Id;
                    break;
                case "discount":
                    returnValue = this.Discount;
                    break;
                case "field_option_id":
                    returnValue = this.Field_Option_Id;
                    break;
                case "field_value":
                    returnValue = this.Field_Value;
                    break;
                case "monthly_discount":
                    returnValue = this.Monthly_Discount;
                    break;
                case "notes":
                    returnValue = this.Notes;
                    break;
                case "skip_setup":
                    returnValue = this.Skip_setup;
                    break;
                case "waive_setup":
                    returnValue = this.Waive_setup;
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
        public static Configuration_Field CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Configuration_Field CreateEntity(bool applyDefaults)
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
        /// <returns>Configuration_Field instance</returns>
        public static Configuration_Field CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Configuration_Field entity = new Configuration_Field();

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
            return typeof(Configuration_Field).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Configuration_Field";
        }

        /// <summary>
        /// Retrieves entity information by Config_Field_Id
        /// </summary>
        /// <param name="Config_Field_Id">Config_Field_Id</param>
        /// <returns>Entity</returns>
        public static Configuration_Field GetByPrimaryKey(string Config_Field_Id)
        {
        	    Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
        	    Configuration_Field configuration_Field = provider.GetByPrimaryKey(Config_Field_Id);

        	    if (configuration_Field == null)
        	    {
        		    configuration_Field = new Configuration_Field();
        	    }

        	    return configuration_Field;
         }

        /// <summary>
        /// Retrieves a list of all configuration_Field data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of configuration_Field data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration_Field</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Configuration_Field</returns>
        public static Configuration_Field GetEntity(Hashtable parameters)
        {
            Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
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
                    Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
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

            Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
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
             Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Configuration_Field</returns>
        public static Configuration_Field DataBind(DataRow dr)
        {
             Configuration_FieldDataProvider provider = new Configuration_FieldDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Configuration_Field</returns>
        public static Configuration_Field DataBindCopy(DataRow dr)
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
