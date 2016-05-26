using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages;
using USP.Bll;
using USP.Attributes;
using USP.Models.POCO;
using USP.Common;
using USP.Controllers;
using USP.Models.Entity;
using USP.Utility;

namespace USP.Areas.System.Controllers
{
    //[Menu(Name = "系统维护", Icon = "glyphicon glyphicon-cog")]
    public class OperatorController : SysPrivilegeController
    {
        ISysOperatorBll operatorBll;

        public OperatorController(ISysOperatorBll operatorBll)
        {
            this.operatorBll = operatorBll;
        }

        [MenuItem(Parent = "系统维护", Name = "操作员管理", Icon = "glyphicon glyphicon-info-sign")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string actionName)
        {
            return OtherAction(actionName);
        }

        private ActionResult OtherAction(string ac)
        {
            switch (ac)
            {
                case "datagrid":
                    return GetDataGrid();//列表页数据
                case "Combobox":
                    return GetStatusComboBox();//列表页状态combotree
                case "menutree":
                    return GetRoleTree();//加载添加管理员页面的角色tree
                case "checkname":
                    return CheckName();
                default:
                    return Content("");
            }
        }

        private ActionResult GetDataGrid()
        {
            string userName = null;
            string RealName = null;

            int page;
            if (!int.TryParse(Request["page"], out page))
            {
                page = 1;
            }
            int rows;
            if (!int.TryParse(Request["rows"], out rows))
            {
                rows = 10;
            }
            long status = Convert.ToInt64(Request["status"]);
            string type = Request["type"];
            if (type.ToLower() == "loginname")
            {
                userName = Request["name"];
            }
            else if (type.ToLower() == "realname")
            {
                RealName = Request["name"];
            }
            var operator1 = (User)HttpContext.Session[Common.Constants.USER_KEY];
            var corp = operator1.SysCorp.ID;
            var operatorID = operator1.SysOperator.ID;
            var result = operatorBll.GetOperatorGrid(page, rows, "", "", userName, RealName, -1, status, corp, operatorID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private ActionResult GetStatusComboBox()
        {
            var status = operatorBll.GetOperatorStatus();
            List<SelectOption> list = new List<SelectOption>();
            var all = new SelectOption()
            {
                id = "-1",
                text = "全部",
                selected = true
            };
            list.Add(all);
            foreach (var v in status)
            {
                var temp = new SelectOption()
                {
                    id = v.ID.ToString(),
                    text = v.Name,
                    selected = false
                };
                list.Add(temp);
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        private ActionResult GetRoleTree()
        {
            var stropid = Request["opid"];
            long? opid = null;
            long temp;
            if (long.TryParse(stropid, out temp))
            {
                opid = temp;
            }
            var user = Session[Constants.USER_KEY] as User;
            var tree = operatorBll.GetUserRoleTree(user.SysCorp.ID, opid);
            return Json(tree, JsonRequestBehavior.AllowGet);
        }

        private ActionResult CheckName()
        {
            var loginname= Request["name"];
            var result = new AjaxResult();
            if (operatorBll.GetOperatorbyLoginName(loginname) != null)
            {
                result.flag = false;
                result.message = "登录名已存在";
                return Json(result);
            }
            result.flag = true;
            result.message = "";
            return Json(result);
        }

        [Privilege(Menu = "操作员管理", Name = "新增")]
        public ActionResult Create()
        {
            var operator1 = (User)HttpContext.Session[Common.Constants.USER_KEY];
            var corp = operator1.SysCorp.ID;
            return View();
        }

        [HttpPost]
        public ActionResult Create(OperaterAddEdit operators)
        {
            var ac = Request["actionName"] ?? "";
            if (ac != "")
                return OtherAction(ac);
            if (ModelState.IsValid)
            {
                var user = Session[Constants.USER_KEY] as User;
                operators.Corp = user.SysCorp.ID;
                operators.Creator = user.SysOperator.ID;
                operators.Password = Util.GetPassword(operators.LoginName, operators.Password.Trim());
                operators.Email = operators.LoginName;
                operators.IdCard = operators.LoginName;
                operators.Mobile = operators.LoginName;
                operators.Role = operators.Role;
                //if (operatorBll.GetOperatorbyLoginName(operators.LoginName) != null)
                //{
                //    ModelState.AddModelError("LoginName", "当前用户已存在");
                //    return View(operators);
                //}
                if (!operatorBll.SaveOperator(operators))
                {
                    ModelState.AddModelError("errorresult", "添加失败");
                    TempData["resultMsgType"] = "error";
                    TempData["resultMsg"] = "添加失败";
                    return View(operators);
                }
                TempData["resultMsgType"] = "success";
                TempData["resultMsg"] = "添加成功";
                return RedirectToAction("Index");
            }
            return View(operators);
        }

        [Privilege(Menu = "操作员管理", Name = "修改")]
        public ActionResult Edit()
        {
            var opid = Convert.ToInt64(Request["id"]);
            var operators = operatorBll.GetOperatorbyId(opid);
            if (operators != null)
            {
                var model = new OperaterAddEdit();
                model.ID = operators.ID;
                model.LoginName = operators.LoginName;
                model.RealName = operators.RealName;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(OperaterAddEdit model)
        {
            var ac = Request["actionName"] ?? "";
            if (ac != "")
                return OtherAction(ac);
            //if (ModelState.IsValid)
            //{
            var operators = operatorBll.GetOperatorbyId(model.ID);
            model.Creator = ((User)Session[Constants.USER_KEY]).SysOperator.ID;
            if (operators == null)
            {
                RedirectToAction("Index", "Operator");
            }
            //if (model.LoginName.Trim() != operators.LoginName.Trim())
            //{
            //    if (operatorBll.GetOperatorbyLoginName(model.LoginName.Trim()) != null)
            //    {
            //        ModelState.AddModelError("Name", "登录名已存在");
            //        return View(model);
            //    }
            //}
            if (!operatorBll.EditOperator(model))
            {
                TempData["returnMsgType"] = "error";
                TempData["returnMsg"] = "修改失败";
                return View(model);
            }
            TempData["resultMsgType"] = "success";
            TempData["resultMsg"] = "修改成功";
            return RedirectToAction("Index");
            //}
            //return View();
        }

        [HttpPost]
        public ActionResult InitRole()
        {
            var user = Session[Constants.USER_KEY] as User;
            var result = new List<SysRole>();
            result = operatorBll.GetRoleList(Convert.ToInt64(user.SysCorp.ID));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //审核
        [HttpPost]
        [Privilege(Menu = "操作员管理", Name = "审核")]
        public ActionResult Auditor(long opid)
        {
            var result = new AjaxResult();
            int status = 0;
            int type = 3;
            var operatorModel = operatorBll.GetOperatorbyId(opid);
            if (operatorModel == null)
            {
                result.flag = false;
                result.message = "未找到操作员信息";
                return Json(result);
            }
            if (operatorModel.Auditor != null)
            {
                result.flag = false;
                result.message = "操作员已通过审核，无需重复操作！";
                return Json(result);
            }
            var user = Session[Constants.USER_KEY] as User;
            if (operatorBll.AlterStatus(operatorModel, status, user.SysOperator.ID, type) > 0)
            {
                result.flag = true;
                return Json(result);
            }
            result.flag = false;
            result.message = "审核通过失败";
            return Json(result);
        }

        //注销
        [HttpPost]
        [Privilege(Menu = "操作员管理", Name = "注销")]
        public ActionResult Cancel(long opid)
        {
            var result = new AjaxResult();
            int status = 2;
            int type = 2;
            var operatorModel = operatorBll.GetOperatorbyId(opid);
            if (operatorModel == null)
            {
                result.flag = false;
                result.message = "未找到操作员信息";
                return Json(result);
            }
            if (operatorModel.Canceler != null)
            {
                result.flag = false;
                result.message = "操作员已注销，无需重复操作！";
                return Json(result);
            }
            var user = Session[Constants.USER_KEY] as User;
            if (operatorBll.AlterStatus(operatorModel, status, user.SysOperator.ID, type) > 0)
            {
                result.flag = true;
                return Json(result);
            }
            result.flag = false;
            result.message = "注销失败";
            return Json(result);
        }

        //激活
        [HttpPost]
        [Privilege(Menu = "操作员管理", Name = "激活")]
        public ActionResult Active(long opid)
        {
            var result = new AjaxResult();
            int status = 0;
            int type = 0;
            var operatorModel = operatorBll.GetOperatorbyId(opid);
            if (operatorModel == null)
            {
                result.flag = false;
                result.message = "未找到操作员信息";
                return Json(result);
            }
            if (operatorModel.Canceler == null)
            {
                result.flag = false;
                result.message = "操作员已激活，无需重复操作！";
                return Json(result);
            }
            var user = Session[Constants.USER_KEY] as User;
            if (operatorBll.AlterStatus(operatorModel, status, user.SysOperator.ID, type) > 0)
            {
                result.flag = true;
                return Json(result);
            }
            result.flag = false;
            result.message = "激活失败";
            return Json(result);

        }

        [Privilege(Menu = "操作员管理", Name = "重置密码")]
        public ActionResult ResetPassword(long opid, string newpwd)
        {
            var result = new AjaxResult();
            var operatorModel = operatorBll.GetOperatorbyId(opid);
            if (operatorModel == null)
            {
                result.flag = false;
                result.message = "未找到操作员信息";
                return Json(result);
            }
            var user = Session[Constants.USER_KEY] as User;
            if (operatorBll.AlterPassword(opid, Util.GetPassword(operatorModel.LoginName, newpwd.Trim())) > 0)
            {
                result.flag = true;
                return Json(result);
            }
            result.flag = false;
            result.message = "重置密码失败";
            return Json(result);

        }
    }

}