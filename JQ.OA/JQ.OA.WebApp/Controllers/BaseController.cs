using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        /// <summary>
        /// For the controller is also an ActionFilter, we can override the OnActionExcuting method in the 
        /// base class to verify that the user has logged in before all actions are executed.
        /// </summary>
        /// <returns></returns>
        public QA.Model.UserInfo LoginUserInfo { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            LoginUserInfo = Session["LoginUser"] as QA.Model.UserInfo;

            //If the user has not logged in.
            if (LoginUserInfo == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login");
                return;
            }

            //TODO: Verify whether the user has 

        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}