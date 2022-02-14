
//------------------------------------------------------------------------------------//
// The following code has been generated using the KYSS Code Generator© (version 4.3.0).
// Generated on 2/14/2022 9:46:44 AM
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
    #region ReservationType Entity

    /// <summary>
    /// Data object representation of the ReservationType database table
    /// </summary>
    [Serializable]
    public partial class ReservationType : MFEntityBase
    {
        #region Field Enum Declarations
        public enum DBFieldName
        {
           ActivityCodes,
           AllowedAccessGroupID,
           AllowGuests,
           BannerMessage,
           CancellationsHoursPrior,
           Category,
           CheckInHoursPrior,
           CheckInMode,
           ClubId,
           CustomFieldLabel1,
           CustomFieldLabel2,
           CustomFieldLabel3,
           CustomFieldLabel4,
           CustomFieldLabel5,
           DaysInWindow,
           DisableMemberEdit,
           DisableTimeSlotContinuations,
           DisplaySequence,
           DurationLabel,
           DurationOptions,
           EmailNotificationAddress,
           EmailReplyToAddress,
           EnableMemberPopups,
           ForceAvailabilityBooking,
           FutureVisibleDays,
           HideRegisteredMembers,
           HolidayEndTime,
           HolidayInterval,
           HolidayStartTime,
           IsActive,
           LastUpdatedDateTime,
           LastUpdatedUserId,
           MaxDaysPrior,
           MaxReservationsPerWindow,
           MaxResourcesPerSlot,
           MemFac_ID,
           MinHoursGuestBooking,
           MinHoursPrior,
           Name,
           NavigationIcon,
           ParticipantLabel,
           ParticipantLabelPlural,
           PostReservationMinutes,
           PostReservationTitle,
           PrimaryResourcesLabel,
           RelatedMembersOnly,
           ReservationTypeCategoryID,
           ReservationTypeId,
           RestrictionType,
           RestrictionTypeValues,
           SeasonalDayEnd,
           SeasonalDayStart,
           SeasonalMonthEnd,
           SeasonalMonthStart,
           SecondaryResourcesLabel,
           SessionTypesLabel,
           ShowResourceNameAndTime,
           Slug,
           TimeBasedBookingHoursMinutes,
           TrackingCodes,
           UrlParameters,
           UseScheduledAvailability,
           Version,
           WeekdayEndTime,
           WeekdayInterval,
           WeekdayStartTime,
           WeekendEndTime,
           WeekendInterval,
           WeekendStartTime,
        }
        #endregion

        #region Class Member Declarations
        private string _ActivityCodes = String.Empty;
        private string _AllowedAccessGroupID = String.Empty;
        private string _AllowGuests = String.Empty;
        private string _BannerMessage = String.Empty;
        private string _CancellationsHoursPrior = String.Empty;
        private string _Category = String.Empty;
        private string _CheckInHoursPrior = String.Empty;
        private string _CheckInMode = String.Empty;
        private string _ClubId = String.Empty;
        private string _CustomFieldLabel1 = String.Empty;
        private string _CustomFieldLabel2 = String.Empty;
        private string _CustomFieldLabel3 = String.Empty;
        private string _CustomFieldLabel4 = String.Empty;
        private string _CustomFieldLabel5 = String.Empty;
        private string _DaysInWindow = String.Empty;
        private string _DisableMemberEdit = String.Empty;
        private string _DisableTimeSlotContinuations = String.Empty;
        private string _DisplaySequence = String.Empty;
        private string _DurationLabel = String.Empty;
        private string _DurationOptions = String.Empty;
        private string _EmailNotificationAddress = String.Empty;
        private string _EmailReplyToAddress = String.Empty;
        private string _EnableMemberPopups = String.Empty;
        private string _ForceAvailabilityBooking = String.Empty;
        private string _FutureVisibleDays = String.Empty;
        private string _HideRegisteredMembers = String.Empty;
        private string _HolidayEndTime = String.Empty;
        private string _HolidayInterval = String.Empty;
        private string _HolidayStartTime = String.Empty;
        private string _IsActive = String.Empty;
        private string _LastUpdatedDateTime = String.Empty;
        private string _LastUpdatedUserId = String.Empty;
        private string _MaxDaysPrior = String.Empty;
        private string _MaxReservationsPerWindow = String.Empty;
        private string _MaxResourcesPerSlot = String.Empty;
        private string _MemFac_ID = String.Empty;
        private string _MinHoursGuestBooking = String.Empty;
        private string _MinHoursPrior = String.Empty;
        private string _Name = String.Empty;
        private string _NavigationIcon = String.Empty;
        private string _ParticipantLabel = String.Empty;
        private string _ParticipantLabelPlural = String.Empty;
        private string _PostReservationMinutes = String.Empty;
        private string _PostReservationTitle = String.Empty;
        private string _PrimaryResourcesLabel = String.Empty;
        private string _RelatedMembersOnly = String.Empty;
        private string _ReservationTypeCategoryID = String.Empty;
        private string _ReservationTypeId = String.Empty;
        private string _RestrictionType = String.Empty;
        private string _RestrictionTypeValues = String.Empty;
        private string _SeasonalDayEnd = String.Empty;
        private string _SeasonalDayStart = String.Empty;
        private string _SeasonalMonthEnd = String.Empty;
        private string _SeasonalMonthStart = String.Empty;
        private string _SecondaryResourcesLabel = String.Empty;
        private string _SessionTypesLabel = String.Empty;
        private string _ShowResourceNameAndTime = String.Empty;
        private string _Slug = String.Empty;
        private string _TimeBasedBookingHoursMinutes = String.Empty;
        private string _TrackingCodes = String.Empty;
        private string _UrlParameters = String.Empty;
        private string _UseScheduledAvailability = String.Empty;
        private string _Version = String.Empty;
        private string _WeekdayEndTime = String.Empty;
        private string _WeekdayInterval = String.Empty;
        private string _WeekdayStartTime = String.Empty;
        private string _WeekendEndTime = String.Empty;
        private string _WeekendInterval = String.Empty;
        private string _WeekendStartTime = String.Empty;
        #endregion

        #region Constructors
        public ReservationType()
        {
        }

        /// <summary>
        /// Full constructor to be used to create and populate entity
        /// </summary>
        public ReservationType( string ActivityCodes, string AllowedAccessGroupID, string AllowGuests, string BannerMessage, string CancellationsHoursPrior, string Category, string CheckInHoursPrior, string CheckInMode, string ClubId, string CustomFieldLabel1, string CustomFieldLabel2, string CustomFieldLabel3, string CustomFieldLabel4, string CustomFieldLabel5, string DaysInWindow, string DisableMemberEdit, string DisableTimeSlotContinuations, string DisplaySequence, string DurationLabel, string DurationOptions, string EmailNotificationAddress, string EmailReplyToAddress, string EnableMemberPopups, string ForceAvailabilityBooking, string FutureVisibleDays, string HideRegisteredMembers, string HolidayEndTime, string HolidayInterval, string HolidayStartTime, string IsActive, string LastUpdatedDateTime, string LastUpdatedUserId, string MaxDaysPrior, string MaxReservationsPerWindow, string MaxResourcesPerSlot, string MemFac_ID, string MinHoursGuestBooking, string MinHoursPrior, string Name, string NavigationIcon, string ParticipantLabel, string ParticipantLabelPlural, string PostReservationMinutes, string PostReservationTitle, string PrimaryResourcesLabel, string RelatedMembersOnly, string ReservationTypeCategoryID, string ReservationTypeId, string RestrictionType, string RestrictionTypeValues, string SeasonalDayEnd, string SeasonalDayStart, string SeasonalMonthEnd, string SeasonalMonthStart, string SecondaryResourcesLabel, string SessionTypesLabel, string ShowResourceNameAndTime, string Slug, string TimeBasedBookingHoursMinutes, string TrackingCodes, string UrlParameters, string UseScheduledAvailability, string Version, string WeekdayEndTime, string WeekdayInterval, string WeekdayStartTime, string WeekendEndTime, string WeekendInterval, string WeekendStartTime)
        {
            this._ActivityCodes = ActivityCodes;
            this._AllowedAccessGroupID = AllowedAccessGroupID;
            this._AllowGuests = AllowGuests;
            this._BannerMessage = BannerMessage;
            this._CancellationsHoursPrior = CancellationsHoursPrior;
            this._Category = Category;
            this._CheckInHoursPrior = CheckInHoursPrior;
            this._CheckInMode = CheckInMode;
            this._ClubId = ClubId;
            this._CustomFieldLabel1 = CustomFieldLabel1;
            this._CustomFieldLabel2 = CustomFieldLabel2;
            this._CustomFieldLabel3 = CustomFieldLabel3;
            this._CustomFieldLabel4 = CustomFieldLabel4;
            this._CustomFieldLabel5 = CustomFieldLabel5;
            this._DaysInWindow = DaysInWindow;
            this._DisableMemberEdit = DisableMemberEdit;
            this._DisableTimeSlotContinuations = DisableTimeSlotContinuations;
            this._DisplaySequence = DisplaySequence;
            this._DurationLabel = DurationLabel;
            this._DurationOptions = DurationOptions;
            this._EmailNotificationAddress = EmailNotificationAddress;
            this._EmailReplyToAddress = EmailReplyToAddress;
            this._EnableMemberPopups = EnableMemberPopups;
            this._ForceAvailabilityBooking = ForceAvailabilityBooking;
            this._FutureVisibleDays = FutureVisibleDays;
            this._HideRegisteredMembers = HideRegisteredMembers;
            this._HolidayEndTime = HolidayEndTime;
            this._HolidayInterval = HolidayInterval;
            this._HolidayStartTime = HolidayStartTime;
            this._IsActive = IsActive;
            this._LastUpdatedDateTime = LastUpdatedDateTime;
            this._LastUpdatedUserId = LastUpdatedUserId;
            this._MaxDaysPrior = MaxDaysPrior;
            this._MaxReservationsPerWindow = MaxReservationsPerWindow;
            this._MaxResourcesPerSlot = MaxResourcesPerSlot;
            this._MemFac_ID = MemFac_ID;
            this._MinHoursGuestBooking = MinHoursGuestBooking;
            this._MinHoursPrior = MinHoursPrior;
            this._Name = Name;
            this._NavigationIcon = NavigationIcon;
            this._ParticipantLabel = ParticipantLabel;
            this._ParticipantLabelPlural = ParticipantLabelPlural;
            this._PostReservationMinutes = PostReservationMinutes;
            this._PostReservationTitle = PostReservationTitle;
            this._PrimaryResourcesLabel = PrimaryResourcesLabel;
            this._RelatedMembersOnly = RelatedMembersOnly;
            this._ReservationTypeCategoryID = ReservationTypeCategoryID;
            this._ReservationTypeId = ReservationTypeId;
            this._RestrictionType = RestrictionType;
            this._RestrictionTypeValues = RestrictionTypeValues;
            this._SeasonalDayEnd = SeasonalDayEnd;
            this._SeasonalDayStart = SeasonalDayStart;
            this._SeasonalMonthEnd = SeasonalMonthEnd;
            this._SeasonalMonthStart = SeasonalMonthStart;
            this._SecondaryResourcesLabel = SecondaryResourcesLabel;
            this._SessionTypesLabel = SessionTypesLabel;
            this._ShowResourceNameAndTime = ShowResourceNameAndTime;
            this._Slug = Slug;
            this._TimeBasedBookingHoursMinutes = TimeBasedBookingHoursMinutes;
            this._TrackingCodes = TrackingCodes;
            this._UrlParameters = UrlParameters;
            this._UseScheduledAvailability = UseScheduledAvailability;
            this._Version = Version;
            this._WeekdayEndTime = WeekdayEndTime;
            this._WeekdayInterval = WeekdayInterval;
            this._WeekdayStartTime = WeekdayStartTime;
            this._WeekendEndTime = WeekendEndTime;
            this._WeekendInterval = WeekendInterval;
            this._WeekendStartTime = WeekendStartTime;
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
                    return "ReservationTypeId";
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
        [MaxLength(1000)]
        [HasDatabaseDefault(false)]
        public string ActivityCodes
        {
            get {  return _ActivityCodes; }
            set
            {
                    if (!_ActivityCodes.Equals(value))
                    {
                       _ActivityCodes = value;
                       AddChangedField(ReservationType.DBFieldName.ActivityCodes.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string AllowedAccessGroupID
        {
            get {  return _AllowedAccessGroupID; }
            set
            {
                    if (!_AllowedAccessGroupID.Equals(value))
                    {
                       _AllowedAccessGroupID = value;
                       AddChangedField(ReservationType.DBFieldName.AllowedAccessGroupID.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string AllowGuests
        {
            get {  return _AllowGuests; }
            set
            {
                    if (!_AllowGuests.Equals(value))
                    {
                       _AllowGuests = value;
                       AddChangedField(ReservationType.DBFieldName.AllowGuests.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(-1)]
        [HasDatabaseDefault(false)]
        public string BannerMessage
        {
            get {  return _BannerMessage; }
            set
            {
                    if (!_BannerMessage.Equals(value))
                    {
                       _BannerMessage = value;
                       AddChangedField(ReservationType.DBFieldName.BannerMessage.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string CancellationsHoursPrior
        {
            get {  return _CancellationsHoursPrior; }
            set
            {
                    if (!_CancellationsHoursPrior.Equals(value))
                    {
                       _CancellationsHoursPrior = value;
                       AddChangedField(ReservationType.DBFieldName.CancellationsHoursPrior.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(true)]
        public string Category
        {
            get {  return _Category; }
            set
            {
                    if (!_Category.Equals(value))
                    {
                       _Category = value;
                       AddChangedField(ReservationType.DBFieldName.Category.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(true)]
        public string CheckInHoursPrior
        {
            get {  return _CheckInHoursPrior; }
            set
            {
                    if (!_CheckInHoursPrior.Equals(value))
                    {
                       _CheckInHoursPrior = value;
                       AddChangedField(ReservationType.DBFieldName.CheckInHoursPrior.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(true)]
        public string CheckInMode
        {
            get {  return _CheckInMode; }
            set
            {
                    if (!_CheckInMode.Equals(value))
                    {
                       _CheckInMode = value;
                       AddChangedField(ReservationType.DBFieldName.CheckInMode.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string ClubId
        {
            get {  return _ClubId; }
            set
            {
                    if (!_ClubId.Equals(value))
                    {
                       _ClubId = value;
                       AddChangedField(ReservationType.DBFieldName.ClubId.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string CustomFieldLabel1
        {
            get {  return _CustomFieldLabel1; }
            set
            {
                    if (!_CustomFieldLabel1.Equals(value))
                    {
                       _CustomFieldLabel1 = value;
                       AddChangedField(ReservationType.DBFieldName.CustomFieldLabel1.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string CustomFieldLabel2
        {
            get {  return _CustomFieldLabel2; }
            set
            {
                    if (!_CustomFieldLabel2.Equals(value))
                    {
                       _CustomFieldLabel2 = value;
                       AddChangedField(ReservationType.DBFieldName.CustomFieldLabel2.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string CustomFieldLabel3
        {
            get {  return _CustomFieldLabel3; }
            set
            {
                    if (!_CustomFieldLabel3.Equals(value))
                    {
                       _CustomFieldLabel3 = value;
                       AddChangedField(ReservationType.DBFieldName.CustomFieldLabel3.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string CustomFieldLabel4
        {
            get {  return _CustomFieldLabel4; }
            set
            {
                    if (!_CustomFieldLabel4.Equals(value))
                    {
                       _CustomFieldLabel4 = value;
                       AddChangedField(ReservationType.DBFieldName.CustomFieldLabel4.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string CustomFieldLabel5
        {
            get {  return _CustomFieldLabel5; }
            set
            {
                    if (!_CustomFieldLabel5.Equals(value))
                    {
                       _CustomFieldLabel5 = value;
                       AddChangedField(ReservationType.DBFieldName.CustomFieldLabel5.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string DaysInWindow
        {
            get {  return _DaysInWindow; }
            set
            {
                    if (!_DaysInWindow.Equals(value))
                    {
                       _DaysInWindow = value;
                       AddChangedField(ReservationType.DBFieldName.DaysInWindow.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string DisableMemberEdit
        {
            get {  return _DisableMemberEdit; }
            set
            {
                    if (!_DisableMemberEdit.Equals(value))
                    {
                       _DisableMemberEdit = value;
                       AddChangedField(ReservationType.DBFieldName.DisableMemberEdit.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(false)]
        public string DisableTimeSlotContinuations
        {
            get {  return _DisableTimeSlotContinuations; }
            set
            {
                    if (!_DisableTimeSlotContinuations.Equals(value))
                    {
                       _DisableTimeSlotContinuations = value;
                       AddChangedField(ReservationType.DBFieldName.DisableTimeSlotContinuations.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Byte)]
        [NumericPrecision(3)]
        [HasDatabaseDefault(false)]
        public string DisplaySequence
        {
            get {  return _DisplaySequence; }
            set
            {
                    if (!_DisplaySequence.Equals(value))
                    {
                       _DisplaySequence = value;
                       AddChangedField(ReservationType.DBFieldName.DisplaySequence.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string DurationLabel
        {
            get {  return _DurationLabel; }
            set
            {
                    if (!_DurationLabel.Equals(value))
                    {
                       _DurationLabel = value;
                       AddChangedField(ReservationType.DBFieldName.DurationLabel.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(500)]
        [HasDatabaseDefault(false)]
        public string DurationOptions
        {
            get {  return _DurationOptions; }
            set
            {
                    if (!_DurationOptions.Equals(value))
                    {
                       _DurationOptions = value;
                       AddChangedField(ReservationType.DBFieldName.DurationOptions.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(200)]
        [HasDatabaseDefault(false)]
        public string EmailNotificationAddress
        {
            get {  return _EmailNotificationAddress; }
            set
            {
                    if (!_EmailNotificationAddress.Equals(value))
                    {
                       _EmailNotificationAddress = value;
                       AddChangedField(ReservationType.DBFieldName.EmailNotificationAddress.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string EmailReplyToAddress
        {
            get {  return _EmailReplyToAddress; }
            set
            {
                    if (!_EmailReplyToAddress.Equals(value))
                    {
                       _EmailReplyToAddress = value;
                       AddChangedField(ReservationType.DBFieldName.EmailReplyToAddress.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string EnableMemberPopups
        {
            get {  return _EnableMemberPopups; }
            set
            {
                    if (!_EnableMemberPopups.Equals(value))
                    {
                       _EnableMemberPopups = value;
                       AddChangedField(ReservationType.DBFieldName.EnableMemberPopups.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string ForceAvailabilityBooking
        {
            get {  return _ForceAvailabilityBooking; }
            set
            {
                    if (!_ForceAvailabilityBooking.Equals(value))
                    {
                       _ForceAvailabilityBooking = value;
                       AddChangedField(ReservationType.DBFieldName.ForceAvailabilityBooking.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string FutureVisibleDays
        {
            get {  return _FutureVisibleDays; }
            set
            {
                    if (!_FutureVisibleDays.Equals(value))
                    {
                       _FutureVisibleDays = value;
                       AddChangedField(ReservationType.DBFieldName.FutureVisibleDays.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(false)]
        public string HideRegisteredMembers
        {
            get {  return _HideRegisteredMembers; }
            set
            {
                    if (!_HideRegisteredMembers.Equals(value))
                    {
                       _HideRegisteredMembers = value;
                       AddChangedField(ReservationType.DBFieldName.HideRegisteredMembers.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string HolidayEndTime
        {
            get {  return _HolidayEndTime; }
            set
            {
                    if (!_HolidayEndTime.Equals(value))
                    {
                       _HolidayEndTime = value;
                       AddChangedField(ReservationType.DBFieldName.HolidayEndTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string HolidayInterval
        {
            get {  return _HolidayInterval; }
            set
            {
                    if (!_HolidayInterval.Equals(value))
                    {
                       _HolidayInterval = value;
                       AddChangedField(ReservationType.DBFieldName.HolidayInterval.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string HolidayStartTime
        {
            get {  return _HolidayStartTime; }
            set
            {
                    if (!_HolidayStartTime.Equals(value))
                    {
                       _HolidayStartTime = value;
                       AddChangedField(ReservationType.DBFieldName.HolidayStartTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(false)]
        public string IsActive
        {
            get {  return _IsActive; }
            set
            {
                    if (!_IsActive.Equals(value))
                    {
                       _IsActive = value;
                       AddChangedField(ReservationType.DBFieldName.IsActive.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.DateTime)]
        [HasDatabaseDefault(false)]
        public string LastUpdatedDateTime
        {
            get {  return _LastUpdatedDateTime; }
            set
            {
                    if (!_LastUpdatedDateTime.Equals(value))
                    {
                       _LastUpdatedDateTime = value;
                       AddChangedField(ReservationType.DBFieldName.LastUpdatedDateTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string LastUpdatedUserId
        {
            get {  return _LastUpdatedUserId; }
            set
            {
                    if (!_LastUpdatedUserId.Equals(value))
                    {
                       _LastUpdatedUserId = value;
                       AddChangedField(ReservationType.DBFieldName.LastUpdatedUserId.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string MaxDaysPrior
        {
            get {  return _MaxDaysPrior; }
            set
            {
                    if (!_MaxDaysPrior.Equals(value))
                    {
                       _MaxDaysPrior = value;
                       AddChangedField(ReservationType.DBFieldName.MaxDaysPrior.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Byte)]
        [NumericPrecision(3)]
        [HasDatabaseDefault(false)]
        public string MaxReservationsPerWindow
        {
            get {  return _MaxReservationsPerWindow; }
            set
            {
                    if (!_MaxReservationsPerWindow.Equals(value))
                    {
                       _MaxReservationsPerWindow = value;
                       AddChangedField(ReservationType.DBFieldName.MaxReservationsPerWindow.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string MaxResourcesPerSlot
        {
            get {  return _MaxResourcesPerSlot; }
            set
            {
                    if (!_MaxResourcesPerSlot.Equals(value))
                    {
                       _MaxResourcesPerSlot = value;
                       AddChangedField(ReservationType.DBFieldName.MaxResourcesPerSlot.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string MemFac_ID
        {
            get {  return _MemFac_ID; }
            set
            {
                    if (!_MemFac_ID.Equals(value))
                    {
                       _MemFac_ID = value;
                       AddChangedField(ReservationType.DBFieldName.MemFac_ID.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(true)]
        public string MinHoursGuestBooking
        {
            get {  return _MinHoursGuestBooking; }
            set
            {
                    if (!_MinHoursGuestBooking.Equals(value))
                    {
                       _MinHoursGuestBooking = value;
                       AddChangedField(ReservationType.DBFieldName.MinHoursGuestBooking.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(true)]
        public string MinHoursPrior
        {
            get {  return _MinHoursPrior; }
            set
            {
                    if (!_MinHoursPrior.Equals(value))
                    {
                       _MinHoursPrior = value;
                       AddChangedField(ReservationType.DBFieldName.MinHoursPrior.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string Name
        {
            get {  return _Name; }
            set
            {
                    if (!_Name.Equals(value))
                    {
                       _Name = value;
                       AddChangedField(ReservationType.DBFieldName.Name.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string NavigationIcon
        {
            get {  return _NavigationIcon; }
            set
            {
                    if (!_NavigationIcon.Equals(value))
                    {
                       _NavigationIcon = value;
                       AddChangedField(ReservationType.DBFieldName.NavigationIcon.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string ParticipantLabel
        {
            get {  return _ParticipantLabel; }
            set
            {
                    if (!_ParticipantLabel.Equals(value))
                    {
                       _ParticipantLabel = value;
                       AddChangedField(ReservationType.DBFieldName.ParticipantLabel.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(150)]
        [HasDatabaseDefault(false)]
        public string ParticipantLabelPlural
        {
            get {  return _ParticipantLabelPlural; }
            set
            {
                    if (!_ParticipantLabelPlural.Equals(value))
                    {
                       _ParticipantLabelPlural = value;
                       AddChangedField(ReservationType.DBFieldName.ParticipantLabelPlural.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string PostReservationMinutes
        {
            get {  return _PostReservationMinutes; }
            set
            {
                    if (!_PostReservationMinutes.Equals(value))
                    {
                       _PostReservationMinutes = value;
                       AddChangedField(ReservationType.DBFieldName.PostReservationMinutes.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(200)]
        [HasDatabaseDefault(false)]
        public string PostReservationTitle
        {
            get {  return _PostReservationTitle; }
            set
            {
                    if (!_PostReservationTitle.Equals(value))
                    {
                       _PostReservationTitle = value;
                       AddChangedField(ReservationType.DBFieldName.PostReservationTitle.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string PrimaryResourcesLabel
        {
            get {  return _PrimaryResourcesLabel; }
            set
            {
                    if (!_PrimaryResourcesLabel.Equals(value))
                    {
                       _PrimaryResourcesLabel = value;
                       AddChangedField(ReservationType.DBFieldName.PrimaryResourcesLabel.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(false)]
        public string RelatedMembersOnly
        {
            get {  return _RelatedMembersOnly; }
            set
            {
                    if (!_RelatedMembersOnly.Equals(value))
                    {
                       _RelatedMembersOnly = value;
                       AddChangedField(ReservationType.DBFieldName.RelatedMembersOnly.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(true)]
        public string ReservationTypeCategoryID
        {
            get {  return _ReservationTypeCategoryID; }
            set
            {
                    if (!_ReservationTypeCategoryID.Equals(value))
                    {
                       _ReservationTypeCategoryID = value;
                       AddChangedField(ReservationType.DBFieldName.ReservationTypeCategoryID.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsPrimaryKeyField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string ReservationTypeId
        {
            get {  return _ReservationTypeId; }
            set
            {
                    if (!_ReservationTypeId.Equals(value))
                    {
                       _ReservationTypeId = value;
                       AddChangedField(ReservationType.DBFieldName.ReservationTypeId.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string RestrictionType
        {
            get {  return _RestrictionType; }
            set
            {
                    if (!_RestrictionType.Equals(value))
                    {
                       _RestrictionType = value;
                       AddChangedField(ReservationType.DBFieldName.RestrictionType.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(2000)]
        [HasDatabaseDefault(false)]
        public string RestrictionTypeValues
        {
            get {  return _RestrictionTypeValues; }
            set
            {
                    if (!_RestrictionTypeValues.Equals(value))
                    {
                       _RestrictionTypeValues = value;
                       AddChangedField(ReservationType.DBFieldName.RestrictionTypeValues.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string SeasonalDayEnd
        {
            get {  return _SeasonalDayEnd; }
            set
            {
                    if (!_SeasonalDayEnd.Equals(value))
                    {
                       _SeasonalDayEnd = value;
                       AddChangedField(ReservationType.DBFieldName.SeasonalDayEnd.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string SeasonalDayStart
        {
            get {  return _SeasonalDayStart; }
            set
            {
                    if (!_SeasonalDayStart.Equals(value))
                    {
                       _SeasonalDayStart = value;
                       AddChangedField(ReservationType.DBFieldName.SeasonalDayStart.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string SeasonalMonthEnd
        {
            get {  return _SeasonalMonthEnd; }
            set
            {
                    if (!_SeasonalMonthEnd.Equals(value))
                    {
                       _SeasonalMonthEnd = value;
                       AddChangedField(ReservationType.DBFieldName.SeasonalMonthEnd.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string SeasonalMonthStart
        {
            get {  return _SeasonalMonthStart; }
            set
            {
                    if (!_SeasonalMonthStart.Equals(value))
                    {
                       _SeasonalMonthStart = value;
                       AddChangedField(ReservationType.DBFieldName.SeasonalMonthStart.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string SecondaryResourcesLabel
        {
            get {  return _SecondaryResourcesLabel; }
            set
            {
                    if (!_SecondaryResourcesLabel.Equals(value))
                    {
                       _SecondaryResourcesLabel = value;
                       AddChangedField(ReservationType.DBFieldName.SecondaryResourcesLabel.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string SessionTypesLabel
        {
            get {  return _SessionTypesLabel; }
            set
            {
                    if (!_SessionTypesLabel.Equals(value))
                    {
                       _SessionTypesLabel = value;
                       AddChangedField(ReservationType.DBFieldName.SessionTypesLabel.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string ShowResourceNameAndTime
        {
            get {  return _ShowResourceNameAndTime; }
            set
            {
                    if (!_ShowResourceNameAndTime.Equals(value))
                    {
                       _ShowResourceNameAndTime = value;
                       AddChangedField(ReservationType.DBFieldName.ShowResourceNameAndTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(true)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(100)]
        [HasDatabaseDefault(false)]
        public string Slug
        {
            get {  return _Slug; }
            set
            {
                    if (!_Slug.Equals(value))
                    {
                       _Slug = value;
                       AddChangedField(ReservationType.DBFieldName.Slug.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string TimeBasedBookingHoursMinutes
        {
            get {  return _TimeBasedBookingHoursMinutes; }
            set
            {
                    if (!_TimeBasedBookingHoursMinutes.Equals(value))
                    {
                       _TimeBasedBookingHoursMinutes = value;
                       AddChangedField(ReservationType.DBFieldName.TimeBasedBookingHoursMinutes.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(1000)]
        [HasDatabaseDefault(false)]
        public string TrackingCodes
        {
            get {  return _TrackingCodes; }
            set
            {
                    if (!_TrackingCodes.Equals(value))
                    {
                       _TrackingCodes = value;
                       AddChangedField(ReservationType.DBFieldName.TrackingCodes.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(50)]
        [HasDatabaseDefault(false)]
        public string UrlParameters
        {
            get {  return _UrlParameters; }
            set
            {
                    if (!_UrlParameters.Equals(value))
                    {
                       _UrlParameters = value;
                       AddChangedField(ReservationType.DBFieldName.UrlParameters.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Bool)]
        [HasDatabaseDefault(true)]
        public string UseScheduledAvailability
        {
            get {  return _UseScheduledAvailability; }
            set
            {
                    if (!_UseScheduledAvailability.Equals(value))
                    {
                       _UseScheduledAvailability = value;
                       AddChangedField(ReservationType.DBFieldName.UseScheduledAvailability.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Int)]
        [NumericPrecision(10)]
        [HasDatabaseDefault(false)]
        public string Version
        {
            get {  return _Version; }
            set
            {
                    if (!_Version.Equals(value))
                    {
                       _Version = value;
                       AddChangedField(ReservationType.DBFieldName.Version.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string WeekdayEndTime
        {
            get {  return _WeekdayEndTime; }
            set
            {
                    if (!_WeekdayEndTime.Equals(value))
                    {
                       _WeekdayEndTime = value;
                       AddChangedField(ReservationType.DBFieldName.WeekdayEndTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string WeekdayInterval
        {
            get {  return _WeekdayInterval; }
            set
            {
                    if (!_WeekdayInterval.Equals(value))
                    {
                       _WeekdayInterval = value;
                       AddChangedField(ReservationType.DBFieldName.WeekdayInterval.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string WeekdayStartTime
        {
            get {  return _WeekdayStartTime; }
            set
            {
                    if (!_WeekdayStartTime.Equals(value))
                    {
                       _WeekdayStartTime = value;
                       AddChangedField(ReservationType.DBFieldName.WeekdayStartTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string WeekendEndTime
        {
            get {  return _WeekendEndTime; }
            set
            {
                    if (!_WeekendEndTime.Equals(value))
                    {
                       _WeekendEndTime = value;
                       AddChangedField(ReservationType.DBFieldName.WeekendEndTime.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.Short)]
        [NumericPrecision(5)]
        [HasDatabaseDefault(false)]
        public string WeekendInterval
        {
            get {  return _WeekendInterval; }
            set
            {
                    if (!_WeekendInterval.Equals(value))
                    {
                       _WeekendInterval = value;
                       AddChangedField(ReservationType.DBFieldName.WeekendInterval.ToString(), value);
                    }
            }
        }

        [IsDatabaseField(true)]
        [IsRequiredField(false)]
        [FieldType(CommonDataProvider.FieldTypes.String)]
        [MaxLength(4)]
        [HasDatabaseDefault(false)]
        public string WeekendStartTime
        {
            get {  return _WeekendStartTime; }
            set
            {
                    if (!_WeekendStartTime.Equals(value))
                    {
                       _WeekendStartTime = value;
                       AddChangedField(ReservationType.DBFieldName.WeekendStartTime.ToString(), value);
                    }
            }
        }

        #endregion

        #region Entity Specific Loading
        public override void SetProperty(string propertyName, string value)
        {
            switch(propertyName.ToLower())
            {
                case "activitycodes":
                    this.ActivityCodes = value;
                    break;
                case "allowedaccessgroupid":
                    this.AllowedAccessGroupID = value;
                    break;
                case "allowguests":
                    this.AllowGuests = value;
                    break;
                case "bannermessage":
                    this.BannerMessage = value;
                    break;
                case "cancellationshoursprior":
                    this.CancellationsHoursPrior = value;
                    break;
                case "category":
                    this.Category = value;
                    break;
                case "checkinhoursprior":
                    this.CheckInHoursPrior = value;
                    break;
                case "checkinmode":
                    this.CheckInMode = value;
                    break;
                case "clubid":
                    this.ClubId = value;
                    break;
                case "customfieldlabel1":
                    this.CustomFieldLabel1 = value;
                    break;
                case "customfieldlabel2":
                    this.CustomFieldLabel2 = value;
                    break;
                case "customfieldlabel3":
                    this.CustomFieldLabel3 = value;
                    break;
                case "customfieldlabel4":
                    this.CustomFieldLabel4 = value;
                    break;
                case "customfieldlabel5":
                    this.CustomFieldLabel5 = value;
                    break;
                case "daysinwindow":
                    this.DaysInWindow = value;
                    break;
                case "disablememberedit":
                    this.DisableMemberEdit = value;
                    break;
                case "disabletimeslotcontinuations":
                    this.DisableTimeSlotContinuations = value;
                    break;
                case "displaysequence":
                    this.DisplaySequence = value;
                    break;
                case "durationlabel":
                    this.DurationLabel = value;
                    break;
                case "durationoptions":
                    this.DurationOptions = value;
                    break;
                case "emailnotificationaddress":
                    this.EmailNotificationAddress = value;
                    break;
                case "emailreplytoaddress":
                    this.EmailReplyToAddress = value;
                    break;
                case "enablememberpopups":
                    this.EnableMemberPopups = value;
                    break;
                case "forceavailabilitybooking":
                    this.ForceAvailabilityBooking = value;
                    break;
                case "futurevisibledays":
                    this.FutureVisibleDays = value;
                    break;
                case "hideregisteredmembers":
                    this.HideRegisteredMembers = value;
                    break;
                case "holidayendtime":
                    this.HolidayEndTime = value;
                    break;
                case "holidayinterval":
                    this.HolidayInterval = value;
                    break;
                case "holidaystarttime":
                    this.HolidayStartTime = value;
                    break;
                case "isactive":
                    this.IsActive = value;
                    break;
                case "lastupdateddatetime":
                    this.LastUpdatedDateTime = value;
                    break;
                case "lastupdateduserid":
                    this.LastUpdatedUserId = value;
                    break;
                case "maxdaysprior":
                    this.MaxDaysPrior = value;
                    break;
                case "maxreservationsperwindow":
                    this.MaxReservationsPerWindow = value;
                    break;
                case "maxresourcesperslot":
                    this.MaxResourcesPerSlot = value;
                    break;
                case "memfac_id":
                    this.MemFac_ID = value;
                    break;
                case "minhoursguestbooking":
                    this.MinHoursGuestBooking = value;
                    break;
                case "minhoursprior":
                    this.MinHoursPrior = value;
                    break;
                case "name":
                    this.Name = value;
                    break;
                case "navigationicon":
                    this.NavigationIcon = value;
                    break;
                case "participantlabel":
                    this.ParticipantLabel = value;
                    break;
                case "participantlabelplural":
                    this.ParticipantLabelPlural = value;
                    break;
                case "postreservationminutes":
                    this.PostReservationMinutes = value;
                    break;
                case "postreservationtitle":
                    this.PostReservationTitle = value;
                    break;
                case "primaryresourceslabel":
                    this.PrimaryResourcesLabel = value;
                    break;
                case "relatedmembersonly":
                    this.RelatedMembersOnly = value;
                    break;
                case "reservationtypecategoryid":
                    this.ReservationTypeCategoryID = value;
                    break;
                case "reservationtypeid":
                    this.ReservationTypeId = value;
                    break;
                case "restrictiontype":
                    this.RestrictionType = value;
                    break;
                case "restrictiontypevalues":
                    this.RestrictionTypeValues = value;
                    break;
                case "seasonaldayend":
                    this.SeasonalDayEnd = value;
                    break;
                case "seasonaldaystart":
                    this.SeasonalDayStart = value;
                    break;
                case "seasonalmonthend":
                    this.SeasonalMonthEnd = value;
                    break;
                case "seasonalmonthstart":
                    this.SeasonalMonthStart = value;
                    break;
                case "secondaryresourceslabel":
                    this.SecondaryResourcesLabel = value;
                    break;
                case "sessiontypeslabel":
                    this.SessionTypesLabel = value;
                    break;
                case "showresourcenameandtime":
                    this.ShowResourceNameAndTime = value;
                    break;
                case "slug":
                    this.Slug = value;
                    break;
                case "timebasedbookinghoursminutes":
                    this.TimeBasedBookingHoursMinutes = value;
                    break;
                case "trackingcodes":
                    this.TrackingCodes = value;
                    break;
                case "urlparameters":
                    this.UrlParameters = value;
                    break;
                case "usescheduledavailability":
                    this.UseScheduledAvailability = value;
                    break;
                case "version":
                    this.Version = value;
                    break;
                case "weekdayendtime":
                    this.WeekdayEndTime = value;
                    break;
                case "weekdayinterval":
                    this.WeekdayInterval = value;
                    break;
                case "weekdaystarttime":
                    this.WeekdayStartTime = value;
                    break;
                case "weekendendtime":
                    this.WeekendEndTime = value;
                    break;
                case "weekendinterval":
                    this.WeekendInterval = value;
                    break;
                case "weekendstarttime":
                    this.WeekendStartTime = value;
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
                case "activitycodes":
                    returnValue = this.ActivityCodes;
                    break;
                case "allowedaccessgroupid":
                    returnValue = this.AllowedAccessGroupID;
                    break;
                case "allowguests":
                    returnValue = this.AllowGuests;
                    break;
                case "bannermessage":
                    returnValue = this.BannerMessage;
                    break;
                case "cancellationshoursprior":
                    returnValue = this.CancellationsHoursPrior;
                    break;
                case "category":
                    returnValue = this.Category;
                    break;
                case "checkinhoursprior":
                    returnValue = this.CheckInHoursPrior;
                    break;
                case "checkinmode":
                    returnValue = this.CheckInMode;
                    break;
                case "clubid":
                    returnValue = this.ClubId;
                    break;
                case "customfieldlabel1":
                    returnValue = this.CustomFieldLabel1;
                    break;
                case "customfieldlabel2":
                    returnValue = this.CustomFieldLabel2;
                    break;
                case "customfieldlabel3":
                    returnValue = this.CustomFieldLabel3;
                    break;
                case "customfieldlabel4":
                    returnValue = this.CustomFieldLabel4;
                    break;
                case "customfieldlabel5":
                    returnValue = this.CustomFieldLabel5;
                    break;
                case "daysinwindow":
                    returnValue = this.DaysInWindow;
                    break;
                case "disablememberedit":
                    returnValue = this.DisableMemberEdit;
                    break;
                case "disabletimeslotcontinuations":
                    returnValue = this.DisableTimeSlotContinuations;
                    break;
                case "displaysequence":
                    returnValue = this.DisplaySequence;
                    break;
                case "durationlabel":
                    returnValue = this.DurationLabel;
                    break;
                case "durationoptions":
                    returnValue = this.DurationOptions;
                    break;
                case "emailnotificationaddress":
                    returnValue = this.EmailNotificationAddress;
                    break;
                case "emailreplytoaddress":
                    returnValue = this.EmailReplyToAddress;
                    break;
                case "enablememberpopups":
                    returnValue = this.EnableMemberPopups;
                    break;
                case "forceavailabilitybooking":
                    returnValue = this.ForceAvailabilityBooking;
                    break;
                case "futurevisibledays":
                    returnValue = this.FutureVisibleDays;
                    break;
                case "hideregisteredmembers":
                    returnValue = this.HideRegisteredMembers;
                    break;
                case "holidayendtime":
                    returnValue = this.HolidayEndTime;
                    break;
                case "holidayinterval":
                    returnValue = this.HolidayInterval;
                    break;
                case "holidaystarttime":
                    returnValue = this.HolidayStartTime;
                    break;
                case "isactive":
                    returnValue = this.IsActive;
                    break;
                case "lastupdateddatetime":
                    returnValue = this.LastUpdatedDateTime;
                    break;
                case "lastupdateduserid":
                    returnValue = this.LastUpdatedUserId;
                    break;
                case "maxdaysprior":
                    returnValue = this.MaxDaysPrior;
                    break;
                case "maxreservationsperwindow":
                    returnValue = this.MaxReservationsPerWindow;
                    break;
                case "maxresourcesperslot":
                    returnValue = this.MaxResourcesPerSlot;
                    break;
                case "memfac_id":
                    returnValue = this.MemFac_ID;
                    break;
                case "minhoursguestbooking":
                    returnValue = this.MinHoursGuestBooking;
                    break;
                case "minhoursprior":
                    returnValue = this.MinHoursPrior;
                    break;
                case "name":
                    returnValue = this.Name;
                    break;
                case "navigationicon":
                    returnValue = this.NavigationIcon;
                    break;
                case "participantlabel":
                    returnValue = this.ParticipantLabel;
                    break;
                case "participantlabelplural":
                    returnValue = this.ParticipantLabelPlural;
                    break;
                case "postreservationminutes":
                    returnValue = this.PostReservationMinutes;
                    break;
                case "postreservationtitle":
                    returnValue = this.PostReservationTitle;
                    break;
                case "primaryresourceslabel":
                    returnValue = this.PrimaryResourcesLabel;
                    break;
                case "relatedmembersonly":
                    returnValue = this.RelatedMembersOnly;
                    break;
                case "reservationtypecategoryid":
                    returnValue = this.ReservationTypeCategoryID;
                    break;
                case "reservationtypeid":
                    returnValue = this.ReservationTypeId;
                    break;
                case "restrictiontype":
                    returnValue = this.RestrictionType;
                    break;
                case "restrictiontypevalues":
                    returnValue = this.RestrictionTypeValues;
                    break;
                case "seasonaldayend":
                    returnValue = this.SeasonalDayEnd;
                    break;
                case "seasonaldaystart":
                    returnValue = this.SeasonalDayStart;
                    break;
                case "seasonalmonthend":
                    returnValue = this.SeasonalMonthEnd;
                    break;
                case "seasonalmonthstart":
                    returnValue = this.SeasonalMonthStart;
                    break;
                case "secondaryresourceslabel":
                    returnValue = this.SecondaryResourcesLabel;
                    break;
                case "sessiontypeslabel":
                    returnValue = this.SessionTypesLabel;
                    break;
                case "showresourcenameandtime":
                    returnValue = this.ShowResourceNameAndTime;
                    break;
                case "slug":
                    returnValue = this.Slug;
                    break;
                case "timebasedbookinghoursminutes":
                    returnValue = this.TimeBasedBookingHoursMinutes;
                    break;
                case "trackingcodes":
                    returnValue = this.TrackingCodes;
                    break;
                case "urlparameters":
                    returnValue = this.UrlParameters;
                    break;
                case "usescheduledavailability":
                    returnValue = this.UseScheduledAvailability;
                    break;
                case "version":
                    returnValue = this.Version;
                    break;
                case "weekdayendtime":
                    returnValue = this.WeekdayEndTime;
                    break;
                case "weekdayinterval":
                    returnValue = this.WeekdayInterval;
                    break;
                case "weekdaystarttime":
                    returnValue = this.WeekdayStartTime;
                    break;
                case "weekendendtime":
                    returnValue = this.WeekendEndTime;
                    break;
                case "weekendinterval":
                    returnValue = this.WeekendInterval;
                    break;
                case "weekendstarttime":
                    returnValue = this.WeekendStartTime;
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
        public static ReservationType CreateEntity()
        {
            return CreateEntity(CreateEntityFactoryMethodOptionsEnum.WithoutDefaultValues);
        }

        /// <summary>
        /// Default factory for creating an entity instance with or without default values based
        /// on the applyDefaults paremeter
        /// </summary>
        /// <param name="applyDefaults">Determines whether to call ApplyDefaults()</param>
        /// <returns></returns>
        public static ReservationType CreateEntity(bool applyDefaults)
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
        /// <returns>ReservationType instance</returns>
        public static ReservationType CreateEntity(CreateEntityFactoryMethodOptionsEnum options)
        {
            ReservationType entity = new ReservationType();

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
            return typeof(ReservationType).Name;
        }

        /// <summary>
        /// Returns the actual table name of the entity
        /// </summary>
        /// <returns>Table Name</returns>
        public static string GetTableName()
        {
            return "ReservationType";
        }

        /// <summary>
        /// Retrieves entity information by ReservationTypeId
        /// </summary>
        /// <param name="ReservationTypeId">ReservationTypeId</param>
        /// <returns>Entity</returns>
        public static ReservationType GetByPrimaryKey(string ReservationTypeId)
        {
        	    ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
        	    ReservationType reservationType = provider.GetByPrimaryKey(ReservationTypeId);

        	    if (reservationType == null)
        	    {
        		    reservationType = new ReservationType();
        	    }

        	    return reservationType;
         }

        /// <summary>
        /// Retrieves a list of all reservationType data
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable()
        {
            ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
            return provider.GetDataTable();
        }

        /// <summary>
        /// Retrieves a list of reservationType data by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type ReservationType</returns>
        public static DataTable GetDataTable(Hashtable parameters)
        {
            ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
            return provider.GetDataTable(parameters);
        }

        /// <summary>
        /// Retrieves an entity by parameters
        /// </summary>
        /// <param name="parameters">Collection of parameters to search by</param>
        /// <returns>Entity of type ReservationType</returns>
        public static ReservationType GetEntity(Hashtable parameters)
        {
            ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
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
                    ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
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

            ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
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
             ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
             return provider.DataBind(this);
        }

        /// <summary>
        /// Creates a datatable with Entity data
        /// </summary>
        /// <returns>ReservationType</returns>
        public static ReservationType DataBind(DataRow dr)
        {
             ReservationTypeDataProvider provider = new ReservationTypeDataProvider();
             return provider.DataBind(dr);
        }

        /// <summary>
        /// Creates an Entity using a copy of the provided data row
        /// </summary>
        /// <returns>ReservationType</returns>
        public static ReservationType DataBindCopy(DataRow dr)
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
