using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class HomeController : BaseController
    //public class HomeController : Controller
    {
        public IBll.IUserInfoService userInfoService { get; set; }
        public IBll.IActionInfoService actionInfoService { get; set; }
        public IBll.IRoleService roleService { get; set; }
        public IBll.IR_User_ActionInfoService r_User_ActionInfoService { get; set; }
        public IBll.IMenuInfoService menuInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadMenu()
        {
            short delNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;
            //Get current user
            QA.Model.UserInfo curUser = userInfoService.LoadEntities(u => u.ID == this.LoginUserInfo.ID)
                                          .FirstOrDefault();
            ViewBag.CurUserName = curUser.UserName;

            //Get current user's access permissions by user's role
            var allRoleActionIds = (from r in curUser.Role
                                    from a in r.ActionInfo
                                    where a.DelFlag == delNormal && r.DelFlag == delNormal
                                    select a.ID).ToList();

            //Get current user's access permissions of actions
            var allUserActionIsPass = (from r in curUser.R_User_ActionInfo
                                       where r.IsPass = true && r.DelFlag == delNormal
                                       select r.ActionInfoID).ToList();

            //Combine allRoleActionIds and allUserActionIsPass to get all access right
            allUserActionIsPass.AddRange(allRoleActionIds);

            //Remove the access permissions of denied
            var allUserActionIsDenied = (from r in curUser.R_User_ActionInfo
                                         where r.IsPass = false && r.DelFlag == delNormal
                                         select r.ActionInfoID).ToList();
            var result = (from a in allUserActionIsPass
                          where !allUserActionIsDenied.Contains(a)
                          select a).ToList();

            //Remove the duplicate data items
            result.Distinct().ToList();

            //Join the menu table
            var allMenus = menuInfoService.LoadEntities(m => true);
            var allActions = actionInfoService.LoadEntities(a => true);
            var allMenuData = from m in allMenus
                              from a in allActions
                              where result.Contains(m.ActionInfoId)
                              where a.ID == m.ActionInfoId
                              select new
                              {
                                  icon = m.IconUrl,
                                  title = m.MenuName,
                                  url = a.Url
                              };
            return Json(allMenuData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}