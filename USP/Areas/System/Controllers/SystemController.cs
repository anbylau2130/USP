using System.Web.Mvc;
using USP.Bll;
using USP.Attributes;

namespace USP.Areas.System.Controllers
{
    [Menu(Name = "系统数据", Icon = "glyphicon glyphicon-th")]
    public class SystemController : Controller
    {
        ISystemBll systemBll;

        public SystemController(ISystemBll systemBll)
        {
            this.systemBll = systemBll;
        }


        // GET: System/System
        public ActionResult Index()
        {
            return View();
        }



        //[MenuItem(Parent = "系统数据", Name = "控制器数据", Icon = "glyphicon glyphicon-info-sign")]
        public ActionResult Controller()
        {
            return View();
        }


        public ActionResult Controllers()
        {
            return Json(systemBll.getControllerGrid(), JsonRequestBehavior.AllowGet);
        }

        //[MenuItem(Parent = "系统数据", Name = "菜单数据", Icon = "glyphicon glyphicon-list")]
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return Json(systemBll.getMenuGrid(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Privileges()
        {
            return Json(systemBll.getPrivilegeGrid(), JsonRequestBehavior.AllowGet);
        }
    }
}