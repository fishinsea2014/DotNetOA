using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Models
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        //Create a queue to keep the exceptions
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //Add a exception into queue
            ExceptionQueue.Enqueue(filterContext.Exception);

            //Redirect the url to an error page
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }

    }
}