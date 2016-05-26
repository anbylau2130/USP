using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Dal;
using USP.Models.Entity;

namespace USP.Bll.Impl
{
    public class SupplierBll : ISupplierBll
    {
        ISupplierDal supplierDal;

        public SupplierBll(ISupplierDal dal)
        {
            this.supplierDal = dal;
        }
        public List<T_BD_SUPPLIER> GetAll()
        {
            return supplierDal.GetAll();
        }
    }
}