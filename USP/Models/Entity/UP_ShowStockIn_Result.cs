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
    
    public partial class UP_ShowStockIn_Result
    {
        public Nullable<long> RowNo { get; set; }
        public Nullable<long> RowCnt { get; set; }
        public string 单据类型 { get; set; }
        public string 单据编号 { get; set; }
        public System.DateTime 入库日期 { get; set; }
        public string 供应商 { get; set; }
        public string 单据状态 { get; set; }
        public Nullable<int> 批号 { get; set; }
        public string 物料编号 { get; set; }
        public string 物料名称 { get; set; }
        public string 单位 { get; set; }
        public Nullable<decimal> 实收数量 { get; set; }
        public Nullable<decimal> 应收数量 { get; set; }
        public Nullable<decimal> 单价 { get; set; }
        public Nullable<decimal> 含税单价 { get; set; }
        public Nullable<decimal> 金额 { get; set; }
        public Nullable<decimal> 价税合计 { get; set; }
        public Nullable<decimal> 税率_ { get; set; }
        public Nullable<decimal> 税额 { get; set; }
        public string 仓库 { get; set; }
        public string 是否赠品 { get; set; }
        public string 库存状态 { get; set; }
        public string 备注 { get; set; }
        public Nullable<decimal> 金额_本位币_ { get; set; }
        public Nullable<decimal> 成本价 { get; set; }
        public Nullable<decimal> 总成本 { get; set; }
        public string 采购部门 { get; set; }
        public string 采购组织 { get; set; }
        public string 采购组 { get; set; }
        public string 采购员 { get; set; }
        public int FSUPPLIERID { get; set; }
    }
}