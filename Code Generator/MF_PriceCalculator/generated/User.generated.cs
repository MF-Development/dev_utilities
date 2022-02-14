
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 6/17/2019 4:45:43 PM
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
    #region tbl_User Entity

    /// <summary>
    /// Data object representation of the tbl_User database table
    /// </summary>
    [Serializable]
    public partial class tbl_User : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           User_Firstname,
           User_Id,
           User_Lastname,
           User_MRM_Id,
           User_Role,
        }
        #endregion

        #region Class Member Declarations
        private string _User_Firstname = String.Empty;
        private string _User_Id = String.Empty;
        private string _User_Lastname = String.Empty;
        private string _User_MRM_Id = String.Empty;
        private string _User_Role = String.Empty;
        #endregion

        #region Constructors
        public tbl_User()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public tbl_User( string User_Firstname, string User_Id, string User_Lastname, string User_MRM_Id, string User_Role)
        {
            this._User_Firstname = User_Firstname;
            this._User_Id = User_Id;
            this._User_Lastname = User_Lastname;
            this._User_MRM_Id = User_MRM_Id;
            this._User_Role = User_Role;
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
                    return "User_Id";
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
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string User_Firstname
        {
            get {  return _User_Firstname; }
            set
            {
                    if (!_User_Firstname.Equals(value))
                    {
                       _User_Firstname = value;
                       AddChangedField(tbl_User.DBFieldName.User_Firstname.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string User_Id
        {
            get {  return _User_Id; }
            set
            {
                    if (!_User_Id.Equals(value))
                    {
                       _User_Id = value;
                       AddChangedField(tbl_User.DBFieldName.User_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string User_Lastname
        {
            get {  return _User_Lastname; }
            set
            {
                    if (!_User_Lastname.Equals(value))
                    {
                       _User_Lastname = value;
                       AddChangedField(tbl_User.DBFieldName.User_Lastname.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string User_MRM_Id
        {
            get {  return _User_MRM_Id; }
            set
            {
                    if (!_User_MRM_Id.Equals(value))
                    {
                       _User_MRM_Id = value;
                       AddChangedField(tbl_User.DBFieldName.User_MRM_Id.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string User_Role
        {
            get {  return _User_Role; }
            set
            {
                    if (!_User_Role.Equals(value))
                    {
                       _User_Role = value;
                       AddChangedField(tbl_User.DBFieldName.User_Role.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "user_firstname":
                    this.User_Firstname = value;
                    break;
                case "user_id":
                    this.User_Id = value;
                    break;
                case "user_lastname":
                    this.User_Lastname = value;
                    break;
                case "user_mrm_id":
                    this.User_MRM_Id = value;
                    break;
                case "user_role":
                    this.User_Role = value;
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
                case "user_firstname":
                    returnValue = this.User_Firstname;
                    break;
                case "user_id":
                    returnValue = this.User_Id;
                    break;
                case "user_lastname":
                    returnValue = this.User_Lastname;
                    break;
                case "user_mrm_id":
                    returnValue = this.User_MRM_Id;
                    break;
                case "user_role":
                    returnValue = this.User_Role;
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
        public static tbl_User CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static tbl_User CreateEntity(bool applyDefaults)
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
        /// <returns>tbl_User instance</returns>
        public static tbl_User CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            tbl_User entity = new tbl_User();

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
            return typeof(tbl_User).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "tbl_User";
        }

        /// <summary>
        /// Retrieves entity information by User_Id
        /// </summary>
        /// <param name="User_Id">User_Id</param>
        /// <returns>Entity</returns>
        public static tbl_User GetByPrimaryKey(string User_Id)
        {
        	    tbl_UserDataProvider provider = new tbl_UserDataProvider();
        	    tbl_User tbl_User = provider.GetByPrimaryKey(User_Id);

        	    if (tbl_User == null)
        	    {
        		    tbl_User = new tbl_User();
        	    }

        	    return tbl_User;
         }

        /// <summary>
        /// Retrieves a list of all tbl_User data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            tbl_UserDataProvider provider = new tbl_UserDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of tbl_User data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type tbl_User</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            tbl_UserDataProvider provider = new tbl_UserDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type tbl_User</returns>
        public static tbl_User GetEntity(Hashtable parameters)
        {
            tbl_UserDataProvider provider = new tbl_UserDataProvider();
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
                    tbl_UserDataProvider provider = new tbl_UserDataProvider();
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

            tbl_UserDataProvider provider = new tbl_UserDataProvider();
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
             tbl_UserDataProvider provider = new tbl_UserDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>tbl_User</returns>
        public static tbl_User DataBind(DataRow dr)
        {
             tbl_UserDataProvider provider = new tbl_UserDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>tbl_User</returns>
        public static tbl_User DataBindCopy(DataRow dr)
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
