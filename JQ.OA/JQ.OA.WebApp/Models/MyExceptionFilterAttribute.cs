﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Models
{
    public class MyExceptionFilterAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
            Common.LogHelper.WriteLog("======================End of the log=================");

            filterContext.HttpContext.Response.Redirect("/Error.html");
            
        }
    }
} 