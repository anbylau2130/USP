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
    [MetadataType(typeof(USP.Models.ViewModel.T_BD_SUPPLIERMetaData))]
    public partial class T_BD_SUPPLIER
    {
        public int FSUPPLIERID { get; set; }
        public int FMASTERID { get; set; }
        public int FCREATEORGID { get; set; }
        public int FUSEORGID { get; set; }
        public int FCREATORID { get; set; }
        public Nullable<System.DateTime> FCREATEDATE { get; set; }
        public int FMODIFIERID { get; set; }
        public Nullable<System.DateTime> FMODIFYDATE { get; set; }
        public string FDOCUMENTSTATUS { get; set; }
        public string FFORBIDSTATUS { get; set; }
        public int FAUDITORID { get; set; }
        public Nullable<System.DateTime> FAUDITDATE { get; set; }
        public int FFORBIDERID { get; set; }
        public Nullable<System.DateTime> FFORBIDDATE { get; set; }
        public string FNUMBER { get; set; }
        public string FSHORTNUMBER { get; set; }
        public Nullable<int> FPRIMARYGROUP { get; set; }
        public int FCORRESPONDORGID { get; set; }
    }
}
