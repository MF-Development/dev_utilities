
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/19/2019 4:49:17 PM
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
    #region Document_Template Entity

    /// <summary>
    /// Data object representation of the Document_Template database table
    /// </summary>
    [Serializable]
    public partial class Document_Template : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Template_Active,
           Template_Id,
           Template_Last_Updated,
           Template_name,
           Template_Parent_Id,
           Template_Parent_Type,
           Template_Skip,
           Template_Text,
           Template_Type,
        }
        #endregion

        #region Class Member Declarations
        private string _Template_Active = String.Empty;
        private string _Template_Id = String.Empty;
        private string _Template_Last_Updated = String.Empty;
        private string _Template_name = String.Empty;
        private string _Template_Parent_Id = String.Empty;
        private string _Template_Parent_Type = String.Empty;
        private string _Template_Skip = String.Empty;
        private string _Template_Text = String.Empty;
        private string _Template_Type = String.Empty;
        #endregion

        #region Constructors
        public Document_Template()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Document_Template( string Template_Active, string Template_Id, string Template_Last_Updated, string Template_name, string Template_Parent_Id, string Template_Parent_Type, string Template_Skip, string Template_Text, string Template_Type)
        {
            this._Template_Active = Template_Active;
            this._Template_Id = Template_Id;
            this._Template_Last_Updated = Template_Last_Updated;
            this._Template_name = Template_name;
            this._Template_Parent_Id = Template_Parent_Id;
            this._Template_Parent_Type = Template_Parent_Type;
            this._Template_Skip = Template_Skip;
            this._Template_Text = Template_Text;
            this._Template_Type = Template_Type;
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
                    return "Template_Id";
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
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Template_Active
        {
            get {  return _Template_Active; }
            set
            {
                    if (!_Template_Active.Equals(value))
                    {
                       _Template_Active = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Active.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Template_Id
        {
            get {  return _Template_Id; }
            set
            {
                    if (!_Template_Id.Equals(value))
                    {
                       _Template_Id = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(true)]
        public string Template_Last_Updated
        {
            get {  return _Template_Last_Updated; }
            set
            {
                    if (!_Template_Last_Updated.Equals(value))
                    {
                       _Template_Last_Updated = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Last_Updated.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(25)]
        [HasDatabaseDefault(false)]
        public string Template_name
        {
            get {  return _Template_name; }
            set
            {
                    if (!_Template_name.Equals(value))
                    {
                       _Template_name = value;
                       AddChangedField(Document_Template.DBFieldName.Template_name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Template_Parent_Id
        {
            get {  return _Template_Parent_Id; }
            set
            {
                    if (!_Template_Parent_Id.Equals(value))
                    {
                       _Template_Parent_Id = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Parent_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(25)]
        [HasDatabaseDefault(false)]
        public string Template_Parent_Type
        {
            get {  return _Template_Parent_Type; }
            set
            {
                    if (!_Template_Parent_Type.Equals(value))
                    {
                       _Template_Parent_Type = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Parent_Type.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Template_Skip
        {
            get {  return _Template_Skip; }
            set
            {
                    if (!_Template_Skip.Equals(value))
                    {
                       _Template_Skip = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Skip.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Template_Text
        {
            get {  return _Template_Text; }
            set
            {
                    if (!_Template_Text.Equals(value))
                    {
                       _Template_Text = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Text.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Template_Type
        {
            get {  return _Template_Type; }
            set
            {
                    if (!_Template_Type.Equals(value))
                    {
                       _Template_Type = value;
                       AddChangedField(Document_Template.DBFieldName.Template_Type.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "template_active":
                    this.Template_Active = value;
                    break;
                case "template_id":
                    this.Template_Id = value;
                    break;
                case "template_last_updated":
                    this.Template_Last_Updated = value;
                    break;
                case "template_name":
                    this.Template_name = value;
                    break;
                case "template_parent_id":
                    this.Template_Parent_Id = value;
                    break;
                case "template_parent_type":
                    this.Template_Parent_Type = value;
                    break;
                case "template_skip":
                    this.Template_Skip = value;
                    break;
                case "template_text":
                    this.Template_Text = value;
                    break;
                case "template_type":
                    this.Template_Type = value;
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
                case "template_active":
                    returnValue = this.Template_Active;
                    break;
                case "template_id":
                    returnValue = this.Template_Id;
                    break;
                case "template_last_updated":
                    returnValue = this.Template_Last_Updated;
                    break;
                case "template_name":
                    returnValue = this.Template_name;
                    break;
                case "template_parent_id":
                    returnValue = this.Template_Parent_Id;
                    break;
                case "template_parent_type":
                    returnValue = this.Template_Parent_Type;
                    break;
                case "template_skip":
                    returnValue = this.Template_Skip;
                    break;
                case "template_text":
                    returnValue = this.Template_Text;
                    break;
                case "template_type":
                    returnValue = this.Template_Type;
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
        public static Document_Template CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Document_Template CreateEntity(bool applyDefaults)
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
        /// <returns>Document_Template instance</returns>
        public static Document_Template CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Document_Template entity = new Document_Template();

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
            return typeof(Document_Template).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Document_Template";
        }

        /// <summary>
        /// Retrieves entity information by Template_Id
        /// </summary>
        /// <param name="Template_Id">Template_Id</param>
        /// <returns>Entity</returns>
        public static Document_Template GetByPrimaryKey(string Template_Id)
        {
        	    Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
        	    Document_Template document_Template = provider.GetByPrimaryKey(Template_Id);

        	    if (document_Template == null)
        	    {
        		    document_Template = new Document_Template();
        	    }

        	    return document_Template;
         }

        /// <summary>
        /// Retrieves a list of all document_Template data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of document_Template data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Document_Template</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Document_Template</returns>
        public static Document_Template GetEntity(Hashtable parameters)
        {
            Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
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
                    Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
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

            Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
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
             Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Document_Template</returns>
        public static Document_Template DataBind(DataRow dr)
        {
             Document_TemplateDataProvider provider = new Document_TemplateDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Document_Template</returns>
        public static Document_Template DataBindCopy(DataRow dr)
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
