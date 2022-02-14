
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 7/12/2018 7:33:20 AM
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
    #region Product Entity

    /// <summary>
    /// Data object representation of the Product database table
    /// </summary>
    [Serializable]
    public partial class Product : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Active,
           Custom_Script,
           Custom_Style,
           Display_Seq,
           Display_Text,
           Display_Title,
           Product_Id,
           Product_Name,
           Tab_Icon,
           Tab_Title,
        }
        #endregion

        #region Class Member Declarations
        private string _Active = String.Empty;
        private string _Custom_Script = String.Empty;
        private string _Custom_Style = String.Empty;
        private string _Display_Seq = String.Empty;
        private string _Display_Text = String.Empty;
        private string _Display_Title = String.Empty;
        private string _Product_Id = String.Empty;
        private string _Product_Name = String.Empty;
        private string _Tab_Icon = String.Empty;
        private string _Tab_Title = String.Empty;
        #endregion

        #region Constructors
        public Product()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Product( string Active, string Custom_Script, string Custom_Style, string Display_Seq, string Display_Text, string Display_Title, string Product_Id, string Product_Name, string Tab_Icon, string Tab_Title)
        {
            this._Active = Active;
            this._Custom_Script = Custom_Script;
            this._Custom_Style = Custom_Style;
            this._Display_Seq = Display_Seq;
            this._Display_Text = Display_Text;
            this._Display_Title = Display_Title;
            this._Product_Id = Product_Id;
            this._Product_Name = Product_Name;
            this._Tab_Icon = Tab_Icon;
            this._Tab_Title = Tab_Title;
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
                    return "Product_Id";
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
                       AddChangedField(Product.DBFieldName.Active.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Custom_Script
        {
            get {  return _Custom_Script; }
            set
            {
                    if (!_Custom_Script.Equals(value))
                    {
                       _Custom_Script = value;
                       AddChangedField(Product.DBFieldName.Custom_Script.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Custom_Style
        {
            get {  return _Custom_Style; }
            set
            {
                    if (!_Custom_Style.Equals(value))
                    {
                       _Custom_Style = value;
                       AddChangedField(Product.DBFieldName.Custom_Style.ToString(), value);
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
                       AddChangedField(Product.DBFieldName.Display_Seq.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Display_Text
        {
            get {  return _Display_Text; }
            set
            {
                    if (!_Display_Text.Equals(value))
                    {
                       _Display_Text = value;
                       AddChangedField(Product.DBFieldName.Display_Text.ToString(), value);
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
                       AddChangedField(Product.DBFieldName.Display_Title.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
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
                       AddChangedField(Product.DBFieldName.Product_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Product_Name
        {
            get {  return _Product_Name; }
            set
            {
                    if (!_Product_Name.Equals(value))
                    {
                       _Product_Name = value;
                       AddChangedField(Product.DBFieldName.Product_Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(250)]
        [HasDatabaseDefault(false)]
        public string Tab_Icon
        {
            get {  return _Tab_Icon; }
            set
            {
                    if (!_Tab_Icon.Equals(value))
                    {
                       _Tab_Icon = value;
                       AddChangedField(Product.DBFieldName.Tab_Icon.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(250)]
        [HasDatabaseDefault(false)]
        public string Tab_Title
        {
            get {  return _Tab_Title; }
            set
            {
                    if (!_Tab_Title.Equals(value))
                    {
                       _Tab_Title = value;
                       AddChangedField(Product.DBFieldName.Tab_Title.ToString(), value);
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
                case "custom_script":
                    this.Custom_Script = value;
                    break;
                case "custom_style":
                    this.Custom_Style = value;
                    break;
                case "display_seq":
                    this.Display_Seq = value;
                    break;
                case "display_text":
                    this.Display_Text = value;
                    break;
                case "display_title":
                    this.Display_Title = value;
                    break;
                case "product_id":
                    this.Product_Id = value;
                    break;
                case "product_name":
                    this.Product_Name = value;
                    break;
                case "tab_icon":
                    this.Tab_Icon = value;
                    break;
                case "tab_title":
                    this.Tab_Title = value;
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
                case "custom_script":
                    returnValue = this.Custom_Script;
                    break;
                case "custom_style":
                    returnValue = this.Custom_Style;
                    break;
                case "display_seq":
                    returnValue = this.Display_Seq;
                    break;
                case "display_text":
                    returnValue = this.Display_Text;
                    break;
                case "display_title":
                    returnValue = this.Display_Title;
                    break;
                case "product_id":
                    returnValue = this.Product_Id;
                    break;
                case "product_name":
                    returnValue = this.Product_Name;
                    break;
                case "tab_icon":
                    returnValue = this.Tab_Icon;
                    break;
                case "tab_title":
                    returnValue = this.Tab_Title;
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
        public static Product CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Product CreateEntity(bool applyDefaults)
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
        /// <returns>Product instance</returns>
        public static Product CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Product entity = new Product();

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
            return typeof(Product).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Product";
        }

        /// <summary>
        /// Retrieves entity information by Product_Id
        /// </summary>
        /// <param name="Product_Id">Product_Id</param>
        /// <returns>Entity</returns>
        public static Product GetByPrimaryKey(string Product_Id)
        {
        	    ProductDataProvider provider = new ProductDataProvider();
        	    Product product = provider.GetByPrimaryKey(Product_Id);

        	    if (product == null)
        	    {
        		    product = new Product();
        	    }

        	    return product;
         }

        /// <summary>
        /// Retrieves a list of all product data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            ProductDataProvider provider = new ProductDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of product data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Product</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            ProductDataProvider provider = new ProductDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Product</returns>
        public static Product GetEntity(Hashtable parameters)
        {
            ProductDataProvider provider = new ProductDataProvider();
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
                    ProductDataProvider provider = new ProductDataProvider();
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

            ProductDataProvider provider = new ProductDataProvider();
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
             ProductDataProvider provider = new ProductDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Product</returns>
        public static Product DataBind(DataRow dr)
        {
             ProductDataProvider provider = new ProductDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Product</returns>
        public static Product DataBindCopy(DataRow dr)
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
