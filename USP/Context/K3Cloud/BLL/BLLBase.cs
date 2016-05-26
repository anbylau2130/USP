using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace COM.XXXX.BLLBase
{
    public class BLLBase<R, M> 
        where R : Repository<M>, new()
        where M : class, new()
    {
        public R Repository;
        protected IUnitOfWork UnitOfWork { get; set; }
        protected K3CloudContext DbContext { get; set; }

        /// <summary>
        /// 构建DbContext，UnitOfWork
        /// </summary>
        public BLLBase()
        {
            DbContext = new K3CloudContext();
            UnitOfWork = new UnitOfWork(DbContext);
        }

        /// <summary>
        /// 初始化Repository类
        /// </summary>
        public void SetRepository()
        {
            Repository = new R();
            Repository.SetDBContext(DbContext);
        }

    }
}