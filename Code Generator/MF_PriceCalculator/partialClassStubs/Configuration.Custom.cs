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
    #region Configuration Entity
        
    /// <summary>
    /// This class extends generated Configuration
    /// </summary>                
    public partial class Configuration
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Client_Id = KYSS_TODO!;
            this.Config_Desc = KYSS_TODO!;
            this.Created_date = KYSS_TODO!;
            this.Last_updated_date = KYSS_TODO!;
            this.Status = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}