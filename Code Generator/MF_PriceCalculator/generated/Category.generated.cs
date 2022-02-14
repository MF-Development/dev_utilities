
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
    #region Category Entity

    /// <summary>
    /// Data object representation of the Category database table
    /// </summary>
    [Serializable]
    public partial class Category : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Active,
           Category_Id,
           Category_Name,
           Display_Seq,
           Display_Title,
           Footer_Text,
           Header_Text,
           Modal_Content,
           Product_Id,
        }
        #endregion

        #region Class Member Declarations
        private string _Active = String.Empty;
        private string _Category_Id = String.Empty;
        private string _Category_Name = String.Empty;
        private string _Display_Seq = String.Empty;
        private string _Display_Title = String.Empty;
        private string _Footer_Text = String.Empty;
        private string _Header_Text = String.Empty;
        private string _Modal_Content = String.Empty;
        private string _Product_Id = String.Empty;
        #endregion

        #region Constructors
        public Category()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Category( string Active, string Category_Id, string Category_Name, string Display_Seq, string Display_Title, string Footer_Text, string Header_Text, string Modal_Content, string Product_Id)
        {
            this._Active = Active;
            this._Category_Id = Category_Id;
            this._Category_Name = Category_Name;
            this._Display_Seq = Display_Seq;
            this._Display_Title = Display_Title;
            this._Footer_Text = Footer_Text;
            this._Header_Text = Header_Text;
            this._Modal_Content = Modal_Content;
            this._Product_Id = Product_Id;
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
                    return "Category_Id";
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
                       AddChangedField(Category.DBFieldName.Active.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Category_Id
        {
            get {  return _Category_Id; }
            set
            {
                    if (!_Category_Id.Equals(value))
                    {
                       _Category_Id = value;
                       AddChangedField(Category.DBFieldName.Category_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Category_Name
        {
            get {  return _Category_Name; }
            set
            {
                    if (!_Category_Name.Equals(value))
                    {
                       _Category_Name = value;
                       AddChangedField(Category.DBFieldName.Category_Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Display_Seq
        {
            get {  return _Display_Seq; }
            set
            {
                    if (!_Display_Seq.Equals(value))
                    {
                       _Display_Seq = value;
                       AddChangedField(Category.DBFieldName.Display_Seq.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Display_Title
        {
            get {  return _Display_Title; }
            set
            {
                    if (!_Display_Title.Equals(value))
                    {
                       _Display_Title = value;
                       AddChangedField(Category.DBFieldName.Display_Title.ToString(), value);
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
                       AddChangedField(Category.DBFieldName.Footer_Text.ToString(), value);
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
                       AddChangedField(Category.DBFieldName.Header_Text.ToString(), value);
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
                       AddChangedField(Category.DBFieldName.Modal_Content.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Product_Id
        {
            get {  return _Product_Id; }
            set
            {
                    if (!_Product_Id.Equals(value))
                    {
                       _Product_Id = value;
                       AddChangedField(Category.DBFieldName.Product_Id.ToString(), value);
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
                    this.Category_Id = value;
                    break;
                case "category_name":
                    this.Category_Name = value;
                    break;
                case "display_seq":
                    this.Display_Seq = value;
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
                case "product_id":
                    this.Product_Id = value;
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
                    returnValue = this.Category_Id;
                    break;
                case "category_name":
                    returnValue = this.Category_Name;
                    break;
                case "display_seq":
                    returnValue = this.Display_Seq;
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
                case "product_id":
                    returnValue = this.Product_Id;
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
        public static Category CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Category CreateEntity(bool applyDefaults)
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
        /// <returns>Category instance</returns>
        public static Category CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Category entity = new Category();

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
            return typeof(Category).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Category";
        }

        /// <summary>
        /// Retrieves entity information by Category_Id
        /// </summary>
        /// <param name="Category_Id">Category_Id</param>
        /// <returns>Entity</returns>
        public static Category GetByPrimaryKey(string Category_Id)
        {
        	    CategoryDataProvider provider = new CategoryDataProvider();
        	    Category category = provider.GetByPrimaryKey(Category_Id);

        	    if (category == null)
        	    {
        		    category = new Category();
        	    }

        	    return category;
         }

        /// <summary>
        /// Retrieves a list of all category data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            CategoryDataProvider provider = new CategoryDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of category data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Category</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            CategoryDataProvider provider = new CategoryDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Category</returns>
        public static Category GetEntity(Hashtable parameters)
        {
            CategoryDataProvider provider = new CategoryDataProvider();
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
                    CategoryDataProvider provider = new CategoryDataProvider();
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

            CategoryDataProvider provider = new CategoryDataProvider();
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
             CategoryDataProvider provider = new CategoryDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Category</returns>
        public static Category DataBind(DataRow dr)
        {
             CategoryDataProvider provider = new CategoryDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Category</returns>
        public static Category DataBindCopy(DataRow dr)
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
