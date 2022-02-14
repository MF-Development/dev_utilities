
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/12/2018 7:24:00 AM
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
    #region Domain_Master Entity

    /// <summary>
    /// Data object representation of the Domain_Master database table
    /// </summary>
    [Serializable]
    public partial class Domain_Master : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Domain_DateCreated,
           Domain_FldHdg_1,
           Domain_FldHdg_2,
           Domain_FldHdg_3,
           Domain_FldType_1,
           Domain_FldType_2,
           Domain_FldType_3,
           Domain_Id,
           Domain_LastUpdate_User,
           Domain_LastUpdated,
           Domain_Master_Code,
           Domain_Name,
        }
        #endregion

        #region Class Member Declarations
        private string _Domain_DateCreated = String.Empty;
        private string _Domain_FldHdg_1 = String.Empty;
        private string _Domain_FldHdg_2 = String.Empty;
        private string _Domain_FldHdg_3 = String.Empty;
        private string _Domain_FldType_1 = String.Empty;
        private string _Domain_FldType_2 = String.Empty;
        private string _Domain_FldType_3 = String.Empty;
        private string _Domain_Id = String.Empty;
        private string _Domain_LastUpdate_User = String.Empty;
        private string _Domain_LastUpdated = String.Empty;
        private string _Domain_Master_Code = String.Empty;
        private string _Domain_Name = String.Empty;
        #endregion

        #region Constructors
        public Domain_Master()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Domain_Master( string Domain_DateCreated, string Domain_FldHdg_1, string Domain_FldHdg_2, string Domain_FldHdg_3, string Domain_FldType_1, string Domain_FldType_2, string Domain_FldType_3, string Domain_Id, string Domain_LastUpdate_User, string Domain_LastUpdated, string Domain_Master_Code, string Domain_Name)
        {
            this._Domain_DateCreated = Domain_DateCreated;
            this._Domain_FldHdg_1 = Domain_FldHdg_1;
            this._Domain_FldHdg_2 = Domain_FldHdg_2;
            this._Domain_FldHdg_3 = Domain_FldHdg_3;
            this._Domain_FldType_1 = Domain_FldType_1;
            this._Domain_FldType_2 = Domain_FldType_2;
            this._Domain_FldType_3 = Domain_FldType_3;
            this._Domain_Id = Domain_Id;
            this._Domain_LastUpdate_User = Domain_LastUpdate_User;
            this._Domain_LastUpdated = Domain_LastUpdated;
            this._Domain_Master_Code = Domain_Master_Code;
            this._Domain_Name = Domain_Name;
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
                    return "Domain_Id";
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
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Domain_DateCreated
        {
            get {  return _Domain_DateCreated; }
            set
            {
                    if (!_Domain_DateCreated.Equals(value))
                    {
                       _Domain_DateCreated = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_DateCreated.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Domain_FldHdg_1
        {
            get {  return _Domain_FldHdg_1; }
            set
            {
                    if (!_Domain_FldHdg_1.Equals(value))
                    {
                       _Domain_FldHdg_1 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldHdg_1.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Domain_FldHdg_2
        {
            get {  return _Domain_FldHdg_2; }
            set
            {
                    if (!_Domain_FldHdg_2.Equals(value))
                    {
                       _Domain_FldHdg_2 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldHdg_2.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Domain_FldHdg_3
        {
            get {  return _Domain_FldHdg_3; }
            set
            {
                    if (!_Domain_FldHdg_3.Equals(value))
                    {
                       _Domain_FldHdg_3 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldHdg_3.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(1)]
        [HasDatabaseDefault(false)]
        public string Domain_FldType_1
        {
            get {  return _Domain_FldType_1; }
            set
            {
                    if (!_Domain_FldType_1.Equals(value))
                    {
                       _Domain_FldType_1 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldType_1.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(1)]
        [HasDatabaseDefault(false)]
        public string Domain_FldType_2
        {
            get {  return _Domain_FldType_2; }
            set
            {
                    if (!_Domain_FldType_2.Equals(value))
                    {
                       _Domain_FldType_2 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldType_2.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(1)]
        [HasDatabaseDefault(false)]
        public string Domain_FldType_3
        {
            get {  return _Domain_FldType_3; }
            set
            {
                    if (!_Domain_FldType_3.Equals(value))
                    {
                       _Domain_FldType_3 = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_FldType_3.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Domain_Id
        {
            get {  return _Domain_Id; }
            set
            {
                    if (!_Domain_Id.Equals(value))
                    {
                       _Domain_Id = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Domain_LastUpdate_User
        {
            get {  return _Domain_LastUpdate_User; }
            set
            {
                    if (!_Domain_LastUpdate_User.Equals(value))
                    {
                       _Domain_LastUpdate_User = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_LastUpdate_User.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Domain_LastUpdated
        {
            get {  return _Domain_LastUpdated; }
            set
            {
                    if (!_Domain_LastUpdated.Equals(value))
                    {
                       _Domain_LastUpdated = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_LastUpdated.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Domain_Master_Code
        {
            get {  return _Domain_Master_Code; }
            set
            {
                    if (!_Domain_Master_Code.Equals(value))
                    {
                       _Domain_Master_Code = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_Master_Code.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(250)]
        [HasDatabaseDefault(false)]
        public string Domain_Name
        {
            get {  return _Domain_Name; }
            set
            {
                    if (!_Domain_Name.Equals(value))
                    {
                       _Domain_Name = value;
                       AddChangedField(Domain_Master.DBFieldName.Domain_Name.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "domain_datecreated":
                    this.Domain_DateCreated = value;
                    break;
                case "domain_fldhdg_1":
                    this.Domain_FldHdg_1 = value;
                    break;
                case "domain_fldhdg_2":
                    this.Domain_FldHdg_2 = value;
                    break;
                case "domain_fldhdg_3":
                    this.Domain_FldHdg_3 = value;
                    break;
                case "domain_fldtype_1":
                    this.Domain_FldType_1 = value;
                    break;
                case "domain_fldtype_2":
                    this.Domain_FldType_2 = value;
                    break;
                case "domain_fldtype_3":
                    this.Domain_FldType_3 = value;
                    break;
                case "domain_id":
                    this.Domain_Id = value;
                    break;
                case "domain_lastupdate_user":
                    this.Domain_LastUpdate_User = value;
                    break;
                case "domain_lastupdated":
                    this.Domain_LastUpdated = value;
                    break;
                case "domain_master_code":
                    this.Domain_Master_Code = value;
                    break;
                case "domain_name":
                    this.Domain_Name = value;
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
                case "domain_datecreated":
                    returnValue = this.Domain_DateCreated;
                    break;
                case "domain_fldhdg_1":
                    returnValue = this.Domain_FldHdg_1;
                    break;
                case "domain_fldhdg_2":
                    returnValue = this.Domain_FldHdg_2;
                    break;
                case "domain_fldhdg_3":
                    returnValue = this.Domain_FldHdg_3;
                    break;
                case "domain_fldtype_1":
                    returnValue = this.Domain_FldType_1;
                    break;
                case "domain_fldtype_2":
                    returnValue = this.Domain_FldType_2;
                    break;
                case "domain_fldtype_3":
                    returnValue = this.Domain_FldType_3;
                    break;
                case "domain_id":
                    returnValue = this.Domain_Id;
                    break;
                case "domain_lastupdate_user":
                    returnValue = this.Domain_LastUpdate_User;
                    break;
                case "domain_lastupdated":
                    returnValue = this.Domain_LastUpdated;
                    break;
                case "domain_master_code":
                    returnValue = this.Domain_Master_Code;
                    break;
                case "domain_name":
                    returnValue = this.Domain_Name;
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
        public static Domain_Master CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Domain_Master CreateEntity(bool applyDefaults)
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
        /// <returns>Domain_Master instance</returns>
        public static Domain_Master CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Domain_Master entity = new Domain_Master();

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
            return typeof(Domain_Master).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Domain_Master";
        }

        /// <summary>
        /// Retrieves entity information by Domain_Id
        /// </summary>
        /// <param name="Domain_Id">Domain_Id</param>
        /// <returns>Entity</returns>
        public static Domain_Master GetByPrimaryKey(string Domain_Id)
        {
        	    Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
        	    Domain_Master domain_Master = provider.GetByPrimaryKey(Domain_Id);

        	    if (domain_Master == null)
        	    {
        		    domain_Master = new Domain_Master();
        	    }

        	    return domain_Master;
         }

        /// <summary>
        /// Retrieves a list of all domain_Master data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of domain_Master data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Domain_Master</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Domain_Master</returns>
        public static Domain_Master GetEntity(Hashtable parameters)
        {
            Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
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
                    Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
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

            Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
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
             Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Domain_Master</returns>
        public static Domain_Master DataBind(DataRow dr)
        {
             Domain_MasterDataProvider provider = new Domain_MasterDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Domain_Master</returns>
        public static Domain_Master DataBindCopy(DataRow dr)
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
