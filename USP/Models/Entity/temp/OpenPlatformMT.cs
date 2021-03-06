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
    [MetadataType(typeof(USP.Models.ViewModel.OpenPlatformMTMetaData))]
    public partial class OpenPlatformMT
    {
        public long ID { get; set; }
        public string PlatformType { get; set; }
        public long Mo { get; set; }
        public long Msg { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string MsgType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Content { get; set; }
        public string Children { get; set; }
        public byte Priority { get; set; }
        public System.DateTime SendTime { get; set; }
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public string Reserve { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> PerformTime { get; set; }
        public System.DateTime PresentTime { get; set; }
        public long Presenter { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
        public Nullable<long> Auditor { get; set; }
    }
}
