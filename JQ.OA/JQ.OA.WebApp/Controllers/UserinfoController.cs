using JQ.OA.Bll;
using JQ.OA.IBll;
using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    //public class UserinfoController : BaseController

    public class UserinfoController : Controller
    {
        IBll.IUserInfoService userInfoService { get; set; }
        //IUserInfoService userInfoService = new UserInfoService();
        //IUserInfoService userInfoService = new UserInfoService();
        // GET: Userinfo
        public ActionResult Index()
        {
            var userinfoList = userInfoService.LoadEntities( u => true);
            ViewData.Model = userinfoList;
            
            return View();
        }

        #region Add an user
        public ActionResult Add(UserInfo userInfo)
        {
            //userInfo.Init();

            ;
            if (userInfoService.AddEntity(userInfo) != null)
            {

                return Content("ok");
            }

            return Content("Fail to add an user.");
        }
        #endregion

        public ActionResult create()
        {
            return Content("create");
        }
    }
}