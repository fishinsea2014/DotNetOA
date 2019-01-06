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
            #region Verifying the user has been logged in.
            LoginUserInfo = Session["LoginUser"] as QA.Model.UserInfo;

            //If the user has not logged in.
            if (LoginUserInfo == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login");
                return;
            }

            //For debugging the programm, a back door.
            if (LoginUserInfo.UserName.ToLower() == "admin")
            {
                return;
            }
            #endregion
            #region Filter the access priority of the user.

            //Verify whether the user has permission to to the action
            string urlStr = filterContext.HttpContext.Request.RawUrl.ToLower(); //e.g. /UserInfo/Index

            string httpMethod = filterContext.HttpContext.Request.HttpMethod.ToLower(); // get the method of "get", "post" ...

            IBll.IActionInfoService actionInfoService = new Bll.ActionInfoService();

            var currentUrlActions = actionInfoService.LoadEntities(a => a.Url.ToLower() == urlStr && a.HttpMethod.ToLower() == httpMethod)
                                                     .FirstOrDefault();

            //1. If the current URL is not in action table, then log the issue and go to error page.
            if (currentUrlActions == null)
            {
                Common.LogHelper.WriteLog(string.Format(
                    "An unauthority issue happend for user: {0}, at time: {1}, URL: {2}, request type: {3}, IP: {4} "
                    , LoginUserInfo.ID, DateTime.Now, urlStr, httpMethod, filterContext.HttpContext.Request.UserHostAddress 
                    ));
                filterContext.HttpContext.Response.Redirect("/Error.html");
                return;
            }


            short delNormal = (short)JQ.QA.Model.Enum.DelFlagEnum.Normal;

            Bll.R_User_ActionInfoService r_User_ActionInfoService = new Bll.R_User_ActionInfoService();

            var tempUserAction = (from a in r_User_ActionInfoService.LoadEntities(u => u.DelFlag == delNormal)
                                  where a.ActionInfoID == currentUrlActions.ID && a.UserInfoID == LoginUserInfo.ID
                                  select a).FirstOrDefault();

            //2. Is the current user assigned the action of the current URL?
            if (tempUserAction != null)
            {
                if (tempUserAction.IsPass)
                {
                    return; // Pass if allowed to  access the URL
                }

                //Log the issue if not allowed to access the URL
                Common.LogHelper.WriteLog(string.Format(
                    "An action access denied issue happend for user: {0}, at time: {1}, URL: {2}, request type: {3}, IP: {4} "
                    , LoginUserInfo.ID, DateTime.Now, urlStr, httpMethod, filterContext.HttpContext.Request.UserHostAddress                     
                    ));            
            }


            //3. Is the roles of the current user assigned the action of the current URL?
            IBll.IUserInfoService userInfoService = new Bll.UserInfoService();
            var user = userInfoService.LoadEntities(u => u.ID == LoginUserInfo.ID).FirstOrDefault();

            var tempRoleActions = (from role in user.Role
                                   from action in role.ActionInfo
                                   where action.ID == currentUrlActions.ID
                                   select action).Count();
            if (tempRoleActions <= 0)
            {
                Common.LogHelper.WriteLog(string.Format(
                    "A role access denied issue happend for user: {0}, at time: {1}, URL: {2}, request type: {3}, IP: {4} "
                    , LoginUserInfo.ID, DateTime.Now, urlStr, httpMethod, filterContext.HttpContext.Request.UserHostAddress
                    ));
                filterContext.HttpContext.Response.Redirect("/Error.html");
            }
            #endregion
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}