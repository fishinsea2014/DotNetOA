﻿using JQ.OA.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionAttribute());
        }
    }
}
