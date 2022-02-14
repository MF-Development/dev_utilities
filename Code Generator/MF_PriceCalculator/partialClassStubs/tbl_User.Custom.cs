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
    #region tbl_User Entity
        
    /// <summary>
    /// This class extends generated tbl_User
    /// </summary>                
    public partial class tbl_User
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.User_Role = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}