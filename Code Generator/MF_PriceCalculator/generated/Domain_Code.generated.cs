
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
    #region Domain_Code Entity

    /// <summary>
    /// Data object representation of the Domain_Code database table
    /// </summary>
    [Serializable]
    public partial class Domain_Code : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Domain_Code_Code,
           Domain_Code_DateCreated,
           Domain_Code_Desc,
           Domain_Code_Display_Seq,
           Domain_Code_Fld1_Val,
           Domain_Code_Fld2_Val,
           Domain_Code_Fld3_Val,
           Domain_Code_Id,
           Domain_Code_LastUpdate_User,
           Domain_Code_LastUpdated,
           Domain_Id,
        }
        #endregion

        #region Class Member Declarations
        private string _Domain_Code_Code = String.Empty;
        private string _Domain_Code_DateCreated = String.Empty;
        private string _Domain_Code_Desc = String.Empty;
        private string _Domain_Code_Display_Seq = String.Empty;
        private string _Domain_Code_Fld1_Val = String.Empty;
        private string _Domain_Code_Fld2_Val = String.Empty;
        private string _Domain_Code_Fld3_Val = String.Empty;
        private string _Domain_Code_Id = String.Empty;
        private string _Domain_Code_LastUpdate_User = String.Empty;
        private string _Domain_Code_LastUpdated = String.Empty;
        private string _Domain_Id = String.Empty;
        #endregion

        #region Constructors
        public Domain_Code()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Domain_Code( string Domain_Code_Code, string Domain_Code_DateCreated, string Domain_Code_Desc, string Domain_Code_Display_Seq, string Domain_Code_Fld1_Val, string Domain_Code_Fld2_Val, string Domain_Code_Fld3_Val, string Domain_Code_Id, string Domain_Code_LastUpdate_User, string Domain_Code_LastUpdated, string Domain_Id)
        {
            this._Domain_Code_Code = Domain_Code_Code;
            this._Domain_Code_DateCreated = Domain_Code_DateCreated;
            this._Domain_Code_Desc = Domain_Code_Desc;
            this._Domain_Code_Display_Seq = Domain_Code_Display_Seq;
            this._Domain_Code_Fld1_Val = Domain_Code_Fld1_Val;
            this._Domain_Code_Fld2_Val = Domain_Code_Fld2_Val;
            this._Domain_Code_Fld3_Val = Domain_Code_Fld3_Val;
            this._Domain_Code_Id = Domain_Code_Id;
            this._Domain_Code_LastUpdate_User = Domain_Code_LastUpdate_User;
            this._Domain_Code_LastUpdated = Domain_Code_LastUpdated;
            this._Domain_Id = Domain_Id;
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
                    return "Domain_Code_Id";
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
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(10)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Code
        {
            get {  return _Domain_Code_Code; }
            set
            {
                    if (!_Domain_Code_Code.Equals(value))
                    {
                       _Domain_Code_Code = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Code.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_DateCreated
        {
            get {  return _Domain_Code_DateCreated; }
            set
            {
                    if (!_Domain_Code_DateCreated.Equals(value))
                    {
                       _Domain_Code_DateCreated = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_DateCreated.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Desc
        {
            get {  return _Domain_Code_Desc; }
            set
            {
                    if (!_Domain_Code_Desc.Equals(value))
                    {
                       _Domain_Code_Desc = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Desc.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Display_Seq
        {
            get {  return _Domain_Code_Display_Seq; }
            set
            {
                    if (!_Domain_Code_Display_Seq.Equals(value))
                    {
                       _Domain_Code_Display_Seq = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Display_Seq.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Fld1_Val
        {
            get {  return _Domain_Code_Fld1_Val; }
            set
            {
                    if (!_Domain_Code_Fld1_Val.Equals(value))
                    {
                       _Domain_Code_Fld1_Val = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Fld1_Val.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Fld2_Val
        {
            get {  return _Domain_Code_Fld2_Val; }
            set
            {
                    if (!_Domain_Code_Fld2_Val.Equals(value))
                    {
                       _Domain_Code_Fld2_Val = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Fld2_Val.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_Fld3_Val
        {
            get {  return _Domain_Code_Fld3_Val; }
            set
            {
                    if (!_Domain_Code_Fld3_Val.Equals(value))
                    {
                       _Domain_Code_Fld3_Val = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Fld3_Val.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
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
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_LastUpdate_User
        {
            get {  return _Domain_Code_LastUpdate_User; }
            set
            {
                    if (!_Domain_Code_LastUpdate_User.Equals(value))
                    {
                       _Domain_Code_LastUpdate_User = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_LastUpdate_User.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Domain_Code_LastUpdated
        {
            get {  return _Domain_Code_LastUpdated; }
            set
            {
                    if (!_Domain_Code_LastUpdated.Equals(value))
                    {
                       _Domain_Code_LastUpdated = value;
                       AddChangedField(Domain_Code.DBFieldName.Domain_Code_LastUpdated.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
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
                       AddChangedField(Domain_Code.DBFieldName.Domain_Id.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "domain_code_code":
                    this.Domain_Code_Code = value;
                    break;
                case "domain_code_datecreated":
                    this.Domain_Code_DateCreated = value;
                    break;
                case "domain_code_desc":
                    this.Domain_Code_Desc = value;
                    break;
                case "domain_code_display_seq":
                    this.Domain_Code_Display_Seq = value;
                    break;
                case "domain_code_fld1_val":
                    this.Domain_Code_Fld1_Val = value;
                    break;
                case "domain_code_fld2_val":
                    this.Domain_Code_Fld2_Val = value;
                    break;
                case "domain_code_fld3_val":
                    this.Domain_Code_Fld3_Val = value;
                    break;
                case "domain_code_id":
                    this.Domain_Code_Id = value;
                    break;
                case "domain_code_lastupdate_user":
                    this.Domain_Code_LastUpdate_User = value;
                    break;
                case "domain_code_lastupdated":
                    this.Domain_Code_LastUpdated = value;
                    break;
                case "domain_id":
                    this.Domain_Id = value;
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
                case "domain_code_code":
                    returnValue = this.Domain_Code_Code;
                    break;
                case "domain_code_datecreated":
                    returnValue = this.Domain_Code_DateCreated;
                    break;
                case "domain_code_desc":
                    returnValue = this.Domain_Code_Desc;
                    break;
                case "domain_code_display_seq":
                    returnValue = this.Domain_Code_Display_Seq;
                    break;
                case "domain_code_fld1_val":
                    returnValue = this.Domain_Code_Fld1_Val;
                    break;
                case "domain_code_fld2_val":
                    returnValue = this.Domain_Code_Fld2_Val;
                    break;
                case "domain_code_fld3_val":
                    returnValue = this.Domain_Code_Fld3_Val;
                    break;
                case "domain_code_id":
                    returnValue = this.Domain_Code_Id;
                    break;
                case "domain_code_lastupdate_user":
                    returnValue = this.Domain_Code_LastUpdate_User;
                    break;
                case "domain_code_lastupdated":
                    returnValue = this.Domain_Code_LastUpdated;
                    break;
                case "domain_id":
                    returnValue = this.Domain_Id;
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
        public static Domain_Code CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Domain_Code CreateEntity(bool applyDefaults)
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
        /// <returns>Domain_Code instance</returns>
        public static Domain_Code CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Domain_Code entity = new Domain_Code();

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
            return typeof(Domain_Code).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Domain_Code";
        }

        /// <summary>
        /// Retrieves entity information by Domain_Code_Id
        /// </summary>
        /// <param name="Domain_Code_Id">Domain_Code_Id</param>
        /// <returns>Entity</returns>
        public static Domain_Code GetByPrimaryKey(string Domain_Code_Id)
        {
        	    Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
        	    Domain_Code domain_Code = provider.GetByPrimaryKey(Domain_Code_Id);

        	    if (domain_Code == null)
        	    {
        		    domain_Code = new Domain_Code();
        	    }

        	    return domain_Code;
         }

        /// <summary>
        /// Retrieves a list of all domain_Code data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of domain_Code data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Domain_Code</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Domain_Code</returns>
        public static Domain_Code GetEntity(Hashtable parameters)
        {
            Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
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
                    Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
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

            Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
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
             Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Domain_Code</returns>
        public static Domain_Code DataBind(DataRow dr)
        {
             Domain_CodeDataProvider provider = new Domain_CodeDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Domain_Code</returns>
        public static Domain_Code DataBindCopy(DataRow dr)
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
