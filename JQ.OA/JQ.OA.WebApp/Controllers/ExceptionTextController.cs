using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class ExceptionTextController : Controller
    {
        // GET: ExceptionText
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult TestException()
        {
            int a = 4;
            int b = 0;
            var c = a / b;
            return Content(c.ToString());
        }
    }
}