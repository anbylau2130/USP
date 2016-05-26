using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Models.POCO;
using USP.Models.Entity;

namespace USP.Bll
{
    public interface ISysOperatorBll
    {
        //bool Login(Login login, HttpContextBase httpContext);
        AjaxResult Login(Login login, HttpContextBase httpContext);

        AjaxResult CheckSso(HttpContextBase httpContext);

        #region libei
        USP.Models.Entity.SysOperator GetModel(long @operator);
        int Add(USP.Models.Entity.SysOperator model);
        AjaxResult Edit(USP.Models.Entity.SysOperator model);
        #endregion

        List<SysRole> GetRoleList(Int64 corpid);
        SysOperator GetOperatorbyId(Int64 id);
        bool SaveOperator(OperaterAddEdit operators);
        List<SysOperatorStatus> GetOperatorStatus();
        DataGrid<Operator_Extend> GetOperatorGrid(int page, int pagesize, string order, string orderType, string userName, string RealName, long role, long status, long corp, long operatorID);
        int AlterStatus(SysOperator model, long status, long oprid, int type);
        int AlterPassword(long opid, string newPassword);
        SysOperator GetOperatorbyLoginName(string name);
        List<TreeNode> GetUserRoleTree(long corp, long? opid);
        bool EditOperator(OperaterAddEdit model);
    }
}