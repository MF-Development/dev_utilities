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
    #region Client_Custom_Fields Entity
        
    /// <summary>
    /// This class extends generated Client_Custom_Fields
    /// </summary>                
    public partial class Client_Custom_Fields
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Client_Custom_Field_Domain_Code_id = KYSS_TODO!;
            this.Client_id = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}