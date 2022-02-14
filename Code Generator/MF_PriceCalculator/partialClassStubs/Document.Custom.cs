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
    #region Document Entity
        
    /// <summary>
    /// This class extends generated Document
    /// </summary>                
    public partial class Document
    {
        #region Custom Methods

        #endregion
 

        #region Plugins Instance Custom Methods


        public override void ApplyDefaults()        
        {
            this.Document_Client_Id = KYSS_TODO!;
            this.Document_Config_Id = KYSS_TODO!;
            this.Document_Created_Date = KYSS_TODO!;
            this.Document_Text = KYSS_TODO!;
            this.Document_Type = KYSS_TODO!;

        }

        #endregion

    }

    #endregion
}