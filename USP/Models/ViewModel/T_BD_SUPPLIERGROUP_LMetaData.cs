//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template made by Louis-Guillaume Morand.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace USP.Models.ViewModel
{
    
    
    public class T_BD_SUPPLIERGROUP_LMetaData
    {
        [Required] 
        public virtual int FPKID
        {
            get;
            set;
        }
        [Required] 
        public virtual int FID
        {
            get;
            set;
        }
        [Required] 
        public virtual int FLOCALEID
        {
            get;
            set;
        }
    	
        [StringLength(100, ErrorMessage="最多可输入100个字符")]
        [Required] 
        public virtual string FNAME
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="最多可输入255个字符")]
        [Required] 
        public virtual string FDESCRIPTION
        {
            get;
            set;
        }
    }
}
