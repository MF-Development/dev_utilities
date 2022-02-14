
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/19/2019 4:04:16 PM
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
    #region Document Entity

    /// <summary>
    /// Data object representation of the Document database table
    /// </summary>
    [Serializable]
    public partial class Document : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Document_Client_Id,
           Document_Config_Id,
           Document_Created_Date,
           Document_Id,
           Document_Text,
           Document_Type,
        }
        #endregion

        #region Class Member Declarations
        private string _Document_Client_Id = String.Empty;
        private string _Document_Config_Id = String.Empty;
        private string _Document_Created_Date = String.Empty;
        private string _Document_Id = String.Empty;
        private string _Document_Text = String.Empty;
        private string _Document_Type = String.Empty;
        #endregion

        #region Constructors
        public Document()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Document( string Document_Client_Id, string Document_Config_Id, string Document_Created_Date, string Document_Id, string Document_Text, string Document_Type)
        {
            this._Document_Client_Id = Document_Client_Id;
            this._Document_Config_Id = Document_Config_Id;
            this._Document_Created_Date = Document_Created_Date;
            this._Document_Id = Document_Id;
            this._Document_Text = Document_Text;
            this._Document_Type = Document_Type;
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
                    return "Document_Id";
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
        public string Document_Client_Id
        {
            get {  return _Document_Client_Id; }
            set
            {
                    if (!_Document_Client_Id.Equals(value))
                    {
                       _Document_Client_Id = value;
                       AddChangedField(Document.DBFieldName.Document_Client_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Document_Config_Id
        {
            get {  return _Document_Config_Id; }
            set
            {
                    if (!_Document_Config_Id.Equals(value))
                    {
                       _Document_Config_Id = value;
                       AddChangedField(Document.DBFieldName.Document_Config_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string Document_Created_Date
        {
            get {  return _Document_Created_Date; }
            set
            {
                    if (!_Document_Created_Date.Equals(value))
                    {
                       _Document_Created_Date = value;
                       AddChangedField(Document.DBFieldName.Document_Created_Date.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Document_Id
        {
            get {  return _Document_Id; }
            set
            {
                    if (!_Document_Id.Equals(value))
                    {
                       _Document_Id = value;
                       AddChangedField(Document.DBFieldName.Document_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Document_Text
        {
            get {  return _Document_Text; }
            set
            {
                    if (!_Document_Text.Equals(value))
                    {
                       _Document_Text = value;
                       AddChangedField(Document.DBFieldName.Document_Text.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Document_Type
        {
            get {  return _Document_Type; }
            set
            {
                    if (!_Document_Type.Equals(value))
                    {
                       _Document_Type = value;
                       AddChangedField(Document.DBFieldName.Document_Type.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "document_client_id":
                    this.Document_Client_Id = value;
                    break;
                case "document_config_id":
                    this.Document_Config_Id = value;
                    break;
                case "document_created_date":
                    this.Document_Created_Date = value;
                    break;
                case "document_id":
                    this.Document_Id = value;
                    break;
                case "document_text":
                    this.Document_Text = value;
                    break;
                case "document_type":
                    this.Document_Type = value;
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
                case "document_client_id":
                    returnValue = this.Document_Client_Id;
                    break;
                case "document_config_id":
                    returnValue = this.Document_Config_Id;
                    break;
                case "document_created_date":
                    returnValue = this.Document_Created_Date;
                    break;
                case "document_id":
                    returnValue = this.Document_Id;
                    break;
                case "document_text":
                    returnValue = this.Document_Text;
                    break;
                case "document_type":
                    returnValue = this.Document_Type;
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
        public static Document CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Document CreateEntity(bool applyDefaults)
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
        /// <returns>Document instance</returns>
        public static Document CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Document entity = new Document();

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
            return typeof(Document).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Document";
        }

        /// <summary>
        /// Retrieves entity information by Document_Id
        /// </summary>
        /// <param name="Document_Id">Document_Id</param>
        /// <returns>Entity</returns>
        public static Document GetByPrimaryKey(string Document_Id)
        {
        	    DocumentDataProvider provider = new DocumentDataProvider();
        	    Document document = provider.GetByPrimaryKey(Document_Id);

        	    if (document == null)
        	    {
        		    document = new Document();
        	    }

        	    return document;
         }

        /// <summary>
        /// Retrieves a list of all document data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            DocumentDataProvider provider = new DocumentDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of document data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Document</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            DocumentDataProvider provider = new DocumentDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Document</returns>
        public static Document GetEntity(Hashtable parameters)
        {
            DocumentDataProvider provider = new DocumentDataProvider();
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
                    DocumentDataProvider provider = new DocumentDataProvider();
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

            DocumentDataProvider provider = new DocumentDataProvider();
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
             DocumentDataProvider provider = new DocumentDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Document</returns>
        public static Document DataBind(DataRow dr)
        {
             DocumentDataProvider provider = new DocumentDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Document</returns>
        public static Document DataBindCopy(DataRow dr)
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
