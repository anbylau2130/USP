//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace USP.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(USP.Models.ViewModel.T_ORG_ORGANIZATIONS_LMetaData))]
    public partial class T_ORG_ORGANIZATIONS_L
    {
        public int FPKID { get; set; }
        public int FORGID { get; set; }
        public int FLOCALEID { get; set; }
        public string FNAME { get; set; }
        public string FDESCRIPTION { get; set; }
        public string FADDRESS { get; set; }
    }
}
