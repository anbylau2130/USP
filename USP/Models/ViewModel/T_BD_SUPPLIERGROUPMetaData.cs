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
    
    
    public class T_BD_SUPPLIERGROUPMetaData
    {
        [Required] 
        public virtual int FID
        {
            get;
            set;
        }
    	
        [StringLength(100, ErrorMessage="最多可输入100个字符")]
        [Required] 
        public virtual string FNUMBER
        {
            get;
            set;
        }
    	
        [StringLength(36, ErrorMessage="最多可输入36个字符")]
        [Required] 
        public virtual string FGROUPID
        {
            get;
            set;
        }
        [Required] 
        public virtual int FPARENTID
        {
            get;
            set;
        }
    	
        [StringLength(500, ErrorMessage="最多可输入500个字符")]
        [Required] 
        public virtual string FFULLPARENTID
        {
            get;
            set;
        }
        [Required] 
        public virtual int FLEFT
        {
            get;
            set;
        }
        [Required] 
        public virtual int FRIGHT
        {
            get;
            set;
        }
    }
}