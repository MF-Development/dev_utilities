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
    #region Configuration_Field Entity
        
    /// <summary>
    /// This class extends generated Configuration_Field
    /// </summary>                
    public partial class Configuration_Field
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Calc_Field_Id = KYSS_TODO!;
            this.Calc_Product_Id = KYSS_TODO!;
            this.Config_Id = KYSS_TODO!;
            this.Field_Option_Id = KYSS_TODO!;
            this.Field_Value = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}