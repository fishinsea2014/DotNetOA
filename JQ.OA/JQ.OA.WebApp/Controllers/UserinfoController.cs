using JQ.OA.Bll;
using JQ.OA.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class UserinfoController : BaseController
    {
        //IBll.IUserInfoService userInfoService { get; set; }
        IUserInfoService userInfoService = new UserInfoService();
        //IBll.IUserInfoService userInfoService = new Bll.UserInfoService();
        // GET: Userinfo
        public ActionResult Index()
        {
            var userinfoList = userInfoService.LoadEntities( u => true);
            ViewData.Model = userinfoList;
            
            return View();
        }

        //public ActionResult GetUserInfo()
        //{

        //}
    }
}