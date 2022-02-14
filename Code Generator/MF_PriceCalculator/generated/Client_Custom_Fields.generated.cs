
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 5/9/2019 2:44:45 PM
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
    #region Client_Custom_Fields Entity

    /// <summary>
    /// Data object representation of the Client_Custom_Fields database table
    /// </summary>
    [Serializable]
    public partial class Client_Custom_Fields : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           Client_Custom_Field_Domain_Code_id,
           Client_Custom_Field_Id,
           Client_Custom_Field_Val_1,
           Client_Custom_Field_Val_2,
           Client_Custom_Field_Val_3,
           Client_id,
        }
        #endregion

        #region Class Member Declarations
        private string _Client_Custom_Field_Domain_Code_id = String.Empty;
        private string _Client_Custom_Field_Id = String.Empty;
        private string _Client_Custom_Field_Val_1 = String.Empty;
        private string _Client_Custom_Field_Val_2 = String.Empty;
        private string _Client_Custom_Field_Val_3 = String.Empty;
        private string _Client_id = String.Empty;
        #endregion

        #region Constructors
        public Client_Custom_Fields()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public Client_Custom_Fields( string Client_Custom_Field_Domain_Code_id, string Client_Custom_Field_Id, string Client_Custom_Field_Val_1, string Client_Custom_Field_Val_2, string Client_Custom_Field_Val_3, string Client_id)
        {
            this._Client_Custom_Field_Domain_Code_id = Client_Custom_Field_Domain_Code_id;
            this._Client_Custom_Field_Id = Client_Custom_Field_Id;
            this._Client_Custom_Field_Val_1 = Client_Custom_Field_Val_1;
            this._Client_Custom_Field_Val_2 = Client_Custom_Field_Val_2;
            this._Client_Custom_Field_Val_3 = Client_Custom_Field_Val_3;
            this._Client_id = Client_id;
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
                    return "Client_Custom_Field_Id";
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
        public string Client_Custom_Field_Domain_Code_id
        {
            get {  return _Client_Custom_Field_Domain_Code_id; }
            set
            {
                    if (!_Client_Custom_Field_Domain_Code_id.Equals(value))
                    {
                       _Client_Custom_Field_Domain_Code_id = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_Custom_Field_Domain_Code_id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Client_Custom_Field_Id
        {
            get {  return _Client_Custom_Field_Id; }
            set
            {
                    if (!_Client_Custom_Field_Id.Equals(value))
                    {
                       _Client_Custom_Field_Id = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_Custom_Field_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Client_Custom_Field_Val_1
        {
            get {  return _Client_Custom_Field_Val_1; }
            set
            {
                    if (!_Client_Custom_Field_Val_1.Equals(value))
                    {
                       _Client_Custom_Field_Val_1 = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_Custom_Field_Val_1.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Client_Custom_Field_Val_2
        {
            get {  return _Client_Custom_Field_Val_2; }
            set
            {
                    if (!_Client_Custom_Field_Val_2.Equals(value))
                    {
                       _Client_Custom_Field_Val_2 = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_Custom_Field_Val_2.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string Client_Custom_Field_Val_3
        {
            get {  return _Client_Custom_Field_Val_3; }
            set
            {
                    if (!_Client_Custom_Field_Val_3.Equals(value))
                    {
                       _Client_Custom_Field_Val_3 = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_Custom_Field_Val_3.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Client_id
        {
            get {  return _Client_id; }
            set
            {
                    if (!_Client_id.Equals(value))
                    {
                       _Client_id = value;
                       AddChangedField(Client_Custom_Fields.DBFieldName.Client_id.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "client_custom_field_domain_code_id":
                    this.Client_Custom_Field_Domain_Code_id = value;
                    break;
                case "client_custom_field_id":
                    this.Client_Custom_Field_Id = value;
                    break;
                case "client_custom_field_val_1":
                    this.Client_Custom_Field_Val_1 = value;
                    break;
                case "client_custom_field_val_2":
                    this.Client_Custom_Field_Val_2 = value;
                    break;
                case "client_custom_field_val_3":
                    this.Client_Custom_Field_Val_3 = value;
                    break;
                case "client_id":
                    this.Client_id = value;
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
                case "client_custom_field_domain_code_id":
                    returnValue = this.Client_Custom_Field_Domain_Code_id;
                    break;
                case "client_custom_field_id":
                    returnValue = this.Client_Custom_Field_Id;
                    break;
                case "client_custom_field_val_1":
                    returnValue = this.Client_Custom_Field_Val_1;
                    break;
                case "client_custom_field_val_2":
                    returnValue = this.Client_Custom_Field_Val_2;
                    break;
                case "client_custom_field_val_3":
                    returnValue = this.Client_Custom_Field_Val_3;
                    break;
                case "client_id":
                    returnValue = this.Client_id;
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
        public static Client_Custom_Fields CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static Client_Custom_Fields CreateEntity(bool applyDefaults)
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
        /// <returns>Client_Custom_Fields instance</returns>
        public static Client_Custom_Fields CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            Client_Custom_Fields entity = new Client_Custom_Fields();

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
            return typeof(Client_Custom_Fields).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "Client_Custom_Fields";
        }

        /// <summary>
        /// Retrieves entity information by Client_Custom_Field_Id
        /// </summary>
        /// <param name="Client_Custom_Field_Id">Client_Custom_Field_Id</param>
        /// <returns>Entity</returns>
        public static Client_Custom_Fields GetByPrimaryKey(string Client_Custom_Field_Id)
        {
        	    Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
        	    Client_Custom_Fields client_Custom_Fields = provider.GetByPrimaryKey(Client_Custom_Field_Id);

        	    if (client_Custom_Fields == null)
        	    {
        		    client_Custom_Fields = new Client_Custom_Fields();
        	    }

        	    return client_Custom_Fields;
         }

        /// <summary>
        /// Retrieves a list of all client_Custom_Fields data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of client_Custom_Fields data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Client_Custom_Fields</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type Client_Custom_Fields</returns>
        public static Client_Custom_Fields GetEntity(Hashtable parameters)
        {
            Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
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
                    Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
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

            Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
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
             Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>Client_Custom_Fields</returns>
        public static Client_Custom_Fields DataBind(DataRow dr)
        {
             Client_Custom_FieldsDataProvider provider = new Client_Custom_FieldsDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>Client_Custom_Fields</returns>
        public static Client_Custom_Fields DataBindCopy(DataRow dr)
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
