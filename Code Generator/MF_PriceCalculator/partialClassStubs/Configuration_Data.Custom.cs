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
    #region Configuration_Data Entity
        
    /// <summary>
    /// This class extends generated Configuration_Data
    /// </summary>                
    public partial class Configuration_Data
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Config_Id = KYSS_TODO!;
            this.Data_Value = KYSS_TODO!;
            this.Domain_Code_Id = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}