using JQ.QA.Model;
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
        public UserInfo LoginUser { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);           
            if (Session["userInfo"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
                return;
            } 
        }

    }
}