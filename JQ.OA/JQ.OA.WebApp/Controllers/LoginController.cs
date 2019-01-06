using JQ.OA.Bll;
using JQ.OA.Common;
using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        //IBll.IUserInfoService userInfoService { get; set; }

        IBll.IUserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string pwd, string name, string vcode)
        {
            return RedirectToAction("Index", "UserInfo");
        }

        public ActionResult CheckLogin()
        {
            //Validate the captcha code
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no: Captcha code is empty");
            }

            Session["validateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no: Capture code is error");
            }

            //Validate the user name and password
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            //UserInfo userInfo = UserInfoService.LoadEntities(u => u.UserName == userName && u.Pwd == userPwd).FirstOrDefault();
            UserInfo userInfo = userInfoService.LoadEntities(u => u.UserName == userName && u.Pwd == userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                //Session["userInfo"] = userInfo;

                //Keep the users' session to memcache server
                string sessionId = Guid.NewGuid().ToString(); //Take the guid as the memcache key

                //Keep an userInfo object in memcache by the key of sessionId
                //Serialize the userInfo object to string before put it into memcache

                //MemcacheHelper.Set(sessionId, SerializerHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));
                Session["LoginUser"] = userInfo;
                return Content("Ok: Login succeed");
            }

            return Content("No: Error of user name or password");
        }

        public ActionResult ShowValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] vCodeGraph = vCode.CreateValidateGraphic(code);
            return File(vCodeGraph, @"image/jpeg");
        }
    }
}