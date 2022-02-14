
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/24/2019 12:41:49 PM
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
    #region Field Entity

    /// <summary>
    /// Data object representation of the Field database table
    /// </summary>
    [Serializable]
    public partial class Field : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Active,
           CAP_Eligible,
           Default_value,
           Discount_Eligible,
           Display_Seq,
           Display_Title,
           Display_zero,
           Field_Id,
           Field_Name,
           Field_Type,
           Footer_Text,
           Header_Text,
           Linked_field,
           Modal_Content,
           Sub_Category_id,
        }
        #endregion

        #region Class Member Declarations
        private string _Active = String.Empty;
        private string _CAP_Eligible = String.Empty;
        private string _Default_value = String.Empty;
        private string _Discount_Eligible = String.Empty;
        private string _Display_Seq = String.Empty;
        private string _Display_Title = String.Empty;
        private string _Display_zero = String.Empty;
        private string _Field_Id = String.Empty;
        private string _Field_Name = String.Empty;
        private string _Field_Type = String.Empty;
        private string _Footer_Text = String.Empty;
        private string _Header_Text = String.Empty;
        private string _Linked_field = String.Empty;
        private string _Modal_Content = String.Empty;
        private string _Sub_Category_id = String.Empty;
        #endregion

        #region Constructors
        public Field()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Field( string Active, string CAP_Eligible, string Default_value, string Discount_Eligible, string Display_Seq, string Display_Title, string Display_zero, string Field_Id, string Field_Name, string Field_Type, string Footer_Text, string Header_Text, string Linked_field, string Modal_Content, string Sub_Category_id)
        {
            this._Active = Active;
            this._CAP_Eligible = CAP_Eligible;
            this._Default_value = Default_value;
            this._Discount_Eligible = Discount_Eligible;
            this._Display_Seq = Display_Seq;
            this._Display_Title = Display_Title;
            this._Display_zero = Display_zero;
            this._Field_Id = Field_Id;
            this._Field_Name = Field_Name;
            this._Field_Type = Field_Type;
            this._Footer_Text = Footer_Text;
            this._Header_Text = Header_Text;
            this._Linked_field = Linked_field;
            this._Modal_Content = Modal_Content;
            this._Sub_Category_id = Sub_Category_id;
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
                    return "Field_Id";
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
                       AddChangedField(Field.DBFieldName.Active.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string CAP_Eligible
        {
            get {  return _CAP_Eligible; }
            set
            {
                    if (!_CAP_Eligible.Equals(value))
                    {
                       _CAP_Eligible = value;
                       AddChangedField(Field.DBFieldName.CAP_Eligible.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Default_value
        {
            get {  return _Default_value; }
            set
            {
                    if (!_Default_value.Equals(value))
                    {
                       _Default_value = value;
                       AddChangedField(Field.DBFieldName.Default_value.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Discount_Eligible
        {
            get {  return _Discount_Eligible; }
            set
            {
                    if (!_Discount_Eligible.Equals(value))
                    {
                       _Discount_Eligible = value;
                       AddChangedField(Field.DBFieldName.Discount_Eligible.ToString(), value);
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
                       AddChangedField(Field.DBFieldName.Display_Seq.ToString(), value);
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
                       AddChangedField(Field.DBFieldName.Display_Title.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string Display_zero
        {
            get {  return _Display_zero; }
            set
            {
                    if (!_Display_zero.Equals(value))
                    {
                       _Display_zero = value;
                       AddChangedField(Field.DBFieldName.Display_zero.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Field_Id
        {
            get {  return _Field_Id; }
            set
            {
                    if (!_Field_Id.Equals(value))
                    {
                       _Field_Id = value;
                       AddChangedField(Field.DBFieldName.Field_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Field_Name
        {
            get {  return _Field_Name; }
            set
            {
                    if (!_Field_Name.Equals(value))
                    {
                       _Field_Name = value;
                       AddChangedField(Field.DBFieldName.Field_Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Field_Type
        {
            get {  return _Field_Type; }
            set
            {
                    if (!_Field_Type.Equals(value))
                    {
                       _Field_Type = value;
                       AddChangedField(Field.DBFieldName.Field_Type.ToString(), value);
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
                       AddChangedField(Field.DBFieldName.Footer_Text.ToString(), value);
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
                       AddChangedField(Field.DBFieldName.Header_Text.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Linked_field
        {
            get {  return _Linked_field; }
            set
            {
                    if (!_Linked_field.Equals(value))
                    {
                       _Linked_field = value;
                       AddChangedField(Field.DBFieldName.Linked_field.ToString(), value);
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
                       AddChangedField(Field.DBFieldName.Modal_Content.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
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
                       AddChangedField(Field.DBFieldName.Sub_Category_id.ToString(), value);
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
                case "cap_eligible":
                    this.CAP_Eligible = value;
                    break;
                case "default_value":
                    this.Default_value = value;
                    break;
                case "discount_eligible":
                    this.Discount_Eligible = value;
                    break;
                case "display_seq":
                    this.Display_Seq = value;
                    break;
                case "display_title":
                    this.Display_Title = value;
                    break;
                case "display_zero":
                    this.Display_zero = value;
                    break;
                case "field_id":
                    this.Field_Id = value;
                    break;
                case "field_name":
                    this.Field_Name = value;
                    break;
                case "field_type":
                    this.Field_Type = value;
                    break;
                case "footer_text":
                    this.Footer_Text = value;
                    break;
                case "header_text":
                    this.Header_Text = value;
                    break;
                case "linked_field":
                    this.Linked_field = value;
                    break;
                case "modal_content":
                    this.Modal_Content = value;
                    break;
                case "sub_category_id":
                    this.Sub_Category_id = value;
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
                case "cap_eligible":
                    returnValue = this.CAP_Eligible;
                    break;
                case "default_value":
                    returnValue = this.Default_value;
                    break;
                case "discount_eligible":
                    returnValue = this.Discount_Eligible;
                    break;
                case "display_seq":
                    returnValue = this.Display_Seq;
                    break;
                case "display_title":
                    returnValue = this.Display_Title;
                    break;
                case "display_zero":
                    returnValue = this.Display_zero;
                    break;
                case "field_id":
                    returnValue = this.Field_Id;
                    break;
                case "field_name":
                    returnValue = this.Field_Name;
                    break;
                case "field_type":
                    returnValue = this.Field_Type;
                    break;
                case "footer_text":
                    returnValue = this.Footer_Text;
                    break;
                case "header_text":
                    returnValue = this.Header_Text;
                    break;
                case "linked_field":
                    returnValue = this.Linked_field;
                    break;
                case "modal_content":
                    returnValue = this.Modal_Content;
                    break;
                case "sub_category_id":
                    returnValue = this.Sub_Category_id;
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
        public static Field CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Field CreateEntity(bool applyDefaults)
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
        /// <returns>Field instance</returns>
        public static Field CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Field entity = new Field();

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
            return typeof(Field).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Field";
        }

        /// <summary>
        /// Retrieves entity information by Field_Id
        /// </summary>
        /// <param name="Field_Id">Field_Id</param>
        /// <returns>Entity</returns>
        public static Field GetByPrimaryKey(string Field_Id)
        {
        	    FieldDataProvider provider = new FieldDataProvider();
        	    Field field = provider.GetByPrimaryKey(Field_Id);

        	    if (field == null)
        	    {
        		    field = new Field();
        	    }

        	    return field;
         }

        /// <summary>
        /// Retrieves a list of all field data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            FieldDataProvider provider = new FieldDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of field data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Field</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            FieldDataProvider provider = new FieldDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Field</returns>
        public static Field GetEntity(Hashtable parameters)
        {
            FieldDataProvider provider = new FieldDataProvider();
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
                    FieldDataProvider provider = new FieldDataProvider();
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

            FieldDataProvider provider = new FieldDataProvider();
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
             FieldDataProvider provider = new FieldDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Field</returns>
        public static Field DataBind(DataRow dr)
        {
             FieldDataProvider provider = new FieldDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Field</returns>
        public static Field DataBindCopy(DataRow dr)
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
