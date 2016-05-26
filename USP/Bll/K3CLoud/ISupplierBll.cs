using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Models.Entity;

namespace USP.Bll
{
    public interface ISupplierBll
    {
         List<T_BD_SUPPLIER> GetAll();
        
    }
}