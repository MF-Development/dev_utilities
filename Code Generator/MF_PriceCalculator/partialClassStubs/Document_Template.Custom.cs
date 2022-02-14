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
    #region Document_Template Entity
        
    /// <summary>
    /// This class extends generated Document_Template
    /// </summary>                
    public partial class Document_Template
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Template_Type = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}