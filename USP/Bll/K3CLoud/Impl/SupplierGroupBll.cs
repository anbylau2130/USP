using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Dal;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Impl
{
    public class SupplierGroupBll : ISupplierGroupBll
    {
        ISupplierGroupDal supplierGroupDal;

        public SupplierGroupBll(ISupplierGroupDal dal)
        {
            this.supplierGroupDal = dal;
        }

        public List<T_BD_SUPPLIERGROUP> GetAll()
        {
           return supplierGroupDal.GetAll();
        }
        public List<TreeNode> GetSupplierGroupsByPId(long id)
        {
            return supplierGroupDal.GetSupplierGroupsByPId(id);
        }

    }
}