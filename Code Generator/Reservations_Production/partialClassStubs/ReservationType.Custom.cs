//----------------------------------------------------------------------------------------//
// The following code has been generated using the Code Generator (version 4.3.0).
//---------------------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Text;
            
using MFEntity.Entity.Data;
using MFDataAccess.Data;
using MFEntity.Core.Entity;

using MFUtility.Utility.StringExtensions;


namespace MFEntity.Entity
{
    #region ReservationType Entity
        
    /// <summary>
    /// This class extends generated ReservationType
    /// </summary>                
    public partial class ReservationType
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.CancellationsHoursPrior = KYSS_TODO!;
            this.ClubId = KYSS_TODO!;
            this.DaysInWindow = KYSS_TODO!;
            this.DisplaySequence = KYSS_TODO!;
            this.HideRegisteredMembers = KYSS_TODO!;
            this.IsActive = KYSS_TODO!;
            this.MaxDaysPrior = KYSS_TODO!;
            this.MaxReservationsPerWindow = KYSS_TODO!;
            this.Name = KYSS_TODO!;
            this.Slug = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}