using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Context;
using USP.Models.Entity;

namespace USP.Dal.Impl
{
    public class SupplierDal : ISupplierDal
    {
        K3CloudEntities db = new K3CloudEntities();

        public List<Models.Entity.T_BD_SUPPLIER> GetAll()
        {
            return db.T_BD_SUPPLIER.ToList();
        }
    }
}