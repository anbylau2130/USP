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
    
    public partial class UP_ShowOperatorInfo_Result
    {
        public long ID { get; set; }
        public long Corp { get; set; }
        public string LoginName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string IdCard { get; set; }
        public string Email { get; set; }
        public string WechatOpenid { get; set; }
        public string AlipayOpenid { get; set; }
        public string Weibo { get; set; }
        public string AvailableIP { get; set; }
        public string WeatherCode { get; set; }
        public long VirtualIntegral { get; set; }
        public long RealIntegral { get; set; }
        public decimal Balance { get; set; }
        public decimal FrozenBalance { get; set; }
        public decimal IncomingBalance { get; set; }
        public decimal Commission { get; set; }
        public decimal Discount { get; set; }
        public string Province { get; set; }
        public string Area { get; set; }
        public string County { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }
        public long Status { get; set; }
        public long Skin { get; set; }
        public Nullable<long> Grade { get; set; }
        public Nullable<long> Star { get; set; }
        public string Session { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public string LoginIP { get; set; }
        public string LoginAgent { get; set; }
        public Nullable<long> LoginCount { get; set; }
        public Nullable<long> LoginErrorCount { get; set; }
        public Nullable<System.DateTime> FrozenStartTime { get; set; }
        public Nullable<System.DateTime> FrozenEndTime { get; set; }
        public string Reserve { get; set; }
        public string Remark { get; set; }
        public long Creator { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<long> Auditor { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
        public Nullable<long> Canceler { get; set; }
        public Nullable<System.DateTime> CancelTime { get; set; }
        public long RowCnt { get; set; }
        public long RowNo { get; set; }
        public Nullable<long> Supplier { get; set; }
        public string SupplierName { get; set; }
    }
}
