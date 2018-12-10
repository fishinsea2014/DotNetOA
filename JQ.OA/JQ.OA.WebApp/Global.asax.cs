using JQ.OA.WebApp.Models;
using log4net;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JQ.OA.WebApp
{
    public class MvcApplication : SpringMvcApplication //Inheritate spring instead of System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//Here register myException 
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Write the errors into log file
            string fileLogPath = Server.MapPath("/Log/"); 
            //Get a thread from thread pool to monitor the exceptions
            ThreadPool.QueueUserWorkItem((waitCallBack) =>  //The parameter is a lambda function
            { 
                while (true)
                {
                    if (MyExceptionAttribute.ExceptionQueue.Count > 0)
                    {
                        Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue(); //Dequeue an item
                        //string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                        //File.AppendAllText(fileLogPath + fileName, ex.ToString(), System.Text.Encoding.Default);
                        ILog logger = LogManager.GetLogger("errorMsg");
                        logger.Error(ex.ToString());
                        Console.WriteLine(logger.GetType());
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            }, fileLogPath);

        }
    }
}
