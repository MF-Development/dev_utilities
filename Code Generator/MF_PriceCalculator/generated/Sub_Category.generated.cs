
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator¬© (version 4.3.0).
// Generated on 6/6/2019 11:36:39 PM
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
    #region Sub_Category Entity

    /// <summary>
    /// Data object representation of the Sub_Category database table
    /// </summary>
    [Serializable]
    public partial class Sub_Category : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Active,
           Category_id,
           Display_seq,
           Display_Title,
           Footer_Text,
           Header_Text,
           Modal_Content,
           Sub_Category_id,
           Sub_Category_Name,
        }
        #endregion

        #region Class Member Declarations
        private string _Active = String.Empty;
        private string _Category_id = String.Empty;
        private string _Display_seq = String.Empty;
        private string _Display_Title = String.Empty;
        private string _Footer_Text = String.Empty;
        private string _Header_Text = String.Empty;
        private string _Modal_Content = String.Empty;
        private string _Sub_Category_id = String.Empty;
        private string _Sub_Category_Name = String.Empty;
        #endregion

        #region Constructors
        public Sub_Category()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Sub_Category( string Active, string Category_id, string Display_seq, string Display_Title, string Footer_Text, string Header_Text, string Modal_Content, string Sub_Category_id, string Sub_Category_Name)
        {
            this._Active = Active;
            this._Category_id = Category_id;
            this._Display_seq = Display_seq;
            this._Display_Title = Display_Title;
            this._Footer_Text = Footer_Text;
            this._Header_Text = Header_Text;
            this._Modal_Content = Modal_Content;
            this._Sub_Category_id = Sub_Category_id;
            this._Sub_Category_Name = Sub_Category_Name;
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
                    return "Sub_Category_id";
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
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(false)]
        public string Active
        {
            get {  return _Active; }
            set
            {
                    if (!_Active.Equals(value))
                    {
                       _Active = value;
                       AddChangedField(Sub_Category.DBFieldName.Active.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Category_id
        {
            get {  return _Category_id; }
            set
            {
                    if (!_Category_id.Equals(value))
                    {
                       _Category_id = value;
                       AddChangedField(Sub_Category.DBFieldName.Category_id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Display_seq
        {
            get {  return _Display_seq; }
            set
            {
                    if (!_Display_seq.Equals(value))
                    {
                       _Display_seq = value;
                       AddChangedField(Sub_Category.DBFieldName.Display_seq.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(250)]
        [HasDatabaseDefault(false)]
        public string Display_Title
        {
            get {  return _Display_Title; }
            set
            {
                    if (!_Display_Title.Equals(value))
                    {
                       _Display_Title = value;
                       AddChangedField(Sub_Category.DBFieldName.Display_Title.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Footer_Text
        {
            get {  return _Footer_Text; }
            set
            {
                    if (!_Footer_Text.Equals(value))
                    {
                       _Footer_Text = value;
                       AddChangedField(Sub_Category.DBFieldName.Footer_Text.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Header_Text
        {
            get {  return _Header_Text; }
            set
            {
                    if (!_Header_Text.Equals(value))
                    {
                       _Header_Text = value;
                       AddChangedField(Sub_Category.DBFieldName.Header_Text.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Modal_Content
        {
            get {  return _Modal_Content; }
            set
            {
                    if (!_Modal_Content.Equals(value))
                    {
                       _Modal_Content = value;
                       AddChangedField(Sub_Category.DBFieldName.Modal_Content.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Sub_Category_id
        {
            get {  return _Sub_Category_id; }
            set
            {
                    if (!_Sub_Category_id.Equals(value))
                    {
                       _Sub_Category_id = value;
                       AddChangedField(Sub_Category.DBFieldName.Sub_Category_id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(250)]
        [HasDatabaseDefault(false)]
        public string Sub_Category_Name
        {
            get {  return _Sub_Category_Name; }
            set
            {
                    if (!_Sub_Category_Name.Equals(value))
                    {
                       _Sub_Category_Name = value;
                       AddChangedField(Sub_Category.DBFieldName.Sub_Category_Name.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "active":
                    this.Active = value;
                    break;
                case "category_id":
                    this.Category_id = value;
                    break;
                case "display_seq":
                    this.Display_seq = value;
                    break;
                case "display_title":
                    this.Display_Title = value;
                    break;
                case "footer_text":
                    this.Footer_Text = value;
                    break;
                case "header_text":
                    this.Header_Text = value;
                    break;
                case "modal_content":
                    this.Modal_Content = value;
                    break;
                case "sub_category_id":
                    this.Sub_Category_id = value;
                    break;
                case "sub_category_name":
                    this.Sub_Category_Name = value;
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
                case "active":
                    returnValue = this.Active;
                    break;
                case "category_id":
                    returnValue = this.Category_id;
                    break;
                case "display_seq":
                    returnValue = this.Display_seq;
                    break;
                case "display_title":
                    returnValue = this.Display_Title;
                    break;
                case "footer_text":
                    returnValue = this.Footer_Text;
                    break;
                case "header_text":
                    returnValue = this.Header_Text;
                    break;
                case "modal_content":
                    returnValue = this.Modal_Content;
                    break;
                case "sub_category_id":
                    returnValue = this.Sub_Category_id;
                    break;
                case "sub_category_name":
                    returnValue = this.Sub_Category_Name;
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
        public static Sub_Category CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Sub_Category CreateEntity(bool applyDefaults)
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
        /// <returns>Sub_Category instance</returns>
        public static Sub_Category CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Sub_Category entity = new Sub_Category();

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
            return typeof(Sub_Category).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Sub_Category";
        }

        /// <summary>
        /// Retrieves entity information by Sub_Category_id
        /// </summary>
        /// <param name="Sub_Category_id">Sub_Category_id</param>
        /// <returns>Entity</returns>
        public static Sub_Category GetByPrimaryKey(string Sub_Category_id)
        {
        	    Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
        	    Sub_Category sub_Category = provider.GetByPrimaryKey(Sub_Category_id);

        	    if (sub_Category == null)
        	    {
        		    sub_Category = new Sub_Category();
        	    }

        	    return sub_Category;
         }

        /// <summary>
        /// Retrieves a list of all sub_Category data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of sub_Category data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Sub_Category</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Sub_Category</returns>
        public static Sub_Category GetEntity(Hashtable parameters)
        {
            Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
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
                    Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
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

            Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
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
             Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Sub_Category</returns>
        public static Sub_Category DataBind(DataRow dr)
        {
             Sub_CategoryDataProvider provider = new Sub_CategoryDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Sub_Category</returns>
        public static Sub_Category DataBindCopy(DataRow dr)
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
