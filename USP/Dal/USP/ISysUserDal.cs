using System;
using System.Collections.Generic;
using USP.Models.POCO;
using USP.Models.Entity;
using System.Web.Mvc;

namespace USP.Dal
{
    public interface ISysUserDal
    {
        SysOperator GetOperatorbyId(Int64 id);
        bool SaveOperator(long Corp, string LoginName, string RealName, string Password, string Mobile, string IdCard, string Email, long Creator, string Role);
        List<SysOperatorStatus> GetOperatorStatus();
        List<Operator_Extend> GetOperatorPage(string strGetFields, string strWhere, string strOrder, int page, int pageSize);
        int AlterStatus(SysOperator model, long status, long oprid, int type);
        int AlterPassword(long opid, string newPassword);
        SysOperator GetOperatorbyLoginName(string name);
        List<SysRole> GetRolesByOperator(long? opid);
        bool EditOperator(long iD, string loginName, string realName, string role, long creator);
    }
}