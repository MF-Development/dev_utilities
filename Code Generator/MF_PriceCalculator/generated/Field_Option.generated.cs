
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 5/29/2019 8:46:05 AM
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
    #region Field_Option Entity

    /// <summary>
    /// Data object representation of the Field_Option database table
    /// </summary>
    [Serializable]
    public partial class Field_Option : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Active,
           Display_Seq,
           Display_Title,
           Field_Id,
           Modal_Content,
           Monthly_Cost,
           Option_Id,
           Option_Name,
           Option_Type,
           Setup_Cost,
        }
        #endregion

        #region Class Member Declarations
        private string _Active = String.Empty;
        private string _Display_Seq = String.Empty;
        private string _Display_Title = String.Empty;
        private string _Field_Id = String.Empty;
        private string _Modal_Content = String.Empty;
        private string _Monthly_Cost = String.Empty;
        private string _Option_Id = String.Empty;
        private string _Option_Name = String.Empty;
        private string _Option_Type = String.Empty;
        private string _Setup_Cost = String.Empty;
        #endregion

        #region Constructors
        public Field_Option()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Field_Option( string Active, string Display_Seq, string Display_Title, string Field_Id, string Modal_Content, string Monthly_Cost, string Option_Id, string Option_Name, string Option_Type, string Setup_Cost)
        {
            this._Active = Active;
            this._Display_Seq = Display_Seq;
            this._Display_Title = Display_Title;
            this._Field_Id = Field_Id;
            this._Modal_Content = Modal_Content;
            this._Monthly_Cost = Monthly_Cost;
            this._Option_Id = Option_Id;
            this._Option_Name = Option_Name;
            this._Option_Type = Option_Type;
            this._Setup_Cost = Setup_Cost;
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
                    return "Option_Id";
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
                       AddChangedField(Field_Option.DBFieldName.Active.ToString(), value);
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
                       AddChangedField(Field_Option.DBFieldName.Display_Seq.ToString(), value);
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
                       AddChangedField(Field_Option.DBFieldName.Display_Title.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
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
                       AddChangedField(Field_Option.DBFieldName.Field_Id.ToString(), value);
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
                       AddChangedField(Field_Option.DBFieldName.Modal_Content.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Monthly_Cost
        {
            get {  return _Monthly_Cost; }
            set
            {
                    if (!_Monthly_Cost.Equals(value))
                    {
                       _Monthly_Cost = value;
                       AddChangedField(Field_Option.DBFieldName.Monthly_Cost.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Option_Id
        {
            get {  return _Option_Id; }
            set
            {
                    if (!_Option_Id.Equals(value))
                    {
                       _Option_Id = value;
                       AddChangedField(Field_Option.DBFieldName.Option_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Option_Name
        {
            get {  return _Option_Name; }
            set
            {
                    if (!_Option_Name.Equals(value))
                    {
                       _Option_Name = value;
                       AddChangedField(Field_Option.DBFieldName.Option_Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string Option_Type
        {
            get {  return _Option_Type; }
            set
            {
                    if (!_Option_Type.Equals(value))
                    {
                       _Option_Type = value;
                       AddChangedField(Field_Option.DBFieldName.Option_Type.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Setup_Cost
        {
            get {  return _Setup_Cost; }
            set
            {
                    if (!_Setup_Cost.Equals(value))
                    {
                       _Setup_Cost = value;
                       AddChangedField(Field_Option.DBFieldName.Setup_Cost.ToString(), value);
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
                case "display_seq":
                    this.Display_Seq = value;
                    break;
                case "display_title":
                    this.Display_Title = value;
                    break;
                case "field_id":
                    this.Field_Id = value;
                    break;
                case "modal_content":
                    this.Modal_Content = value;
                    break;
                case "monthly_cost":
                    this.Monthly_Cost = value;
                    break;
                case "option_id":
                    this.Option_Id = value;
                    break;
                case "option_name":
                    this.Option_Name = value;
                    break;
                case "option_type":
                    this.Option_Type = value;
                    break;
                case "setup_cost":
                    this.Setup_Cost = value;
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
                case "display_seq":
                    returnValue = this.Display_Seq;
                    break;
                case "display_title":
                    returnValue = this.Display_Title;
                    break;
                case "field_id":
                    returnValue = this.Field_Id;
                    break;
                case "modal_content":
                    returnValue = this.Modal_Content;
                    break;
                case "monthly_cost":
                    returnValue = this.Monthly_Cost;
                    break;
                case "option_id":
                    returnValue = this.Option_Id;
                    break;
                case "option_name":
                    returnValue = this.Option_Name;
                    break;
                case "option_type":
                    returnValue = this.Option_Type;
                    break;
                case "setup_cost":
                    returnValue = this.Setup_Cost;
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
        public static Field_Option CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Field_Option CreateEntity(bool applyDefaults)
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
        /// <returns>Field_Option instance</returns>
        public static Field_Option CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Field_Option entity = new Field_Option();

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
            return typeof(Field_Option).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Field_Option";
        }

        /// <summary>
        /// Retrieves entity information by Option_Id
        /// </summary>
        /// <param name="Option_Id">Option_Id</param>
        /// <returns>Entity</returns>
        public static Field_Option GetByPrimaryKey(string Option_Id)
        {
        	    Field_OptionDataProvider provider = new Field_OptionDataProvider();
        	    Field_Option field_Option = provider.GetByPrimaryKey(Option_Id);

        	    if (field_Option == null)
        	    {
        		    field_Option = new Field_Option();
        	    }

        	    return field_Option;
         }

        /// <summary>
        /// Retrieves a list of all field_Option data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Field_OptionDataProvider provider = new Field_OptionDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of field_Option data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Field_Option</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Field_OptionDataProvider provider = new Field_OptionDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Field_Option</returns>
        public static Field_Option GetEntity(Hashtable parameters)
        {
            Field_OptionDataProvider provider = new Field_OptionDataProvider();
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
                    Field_OptionDataProvider provider = new Field_OptionDataProvider();
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

            Field_OptionDataProvider provider = new Field_OptionDataProvider();
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
             Field_OptionDataProvider provider = new Field_OptionDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Field_Option</returns>
        public static Field_Option DataBind(DataRow dr)
        {
             Field_OptionDataProvider provider = new Field_OptionDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Field_Option</returns>
        public static Field_Option DataBindCopy(DataRow dr)
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
