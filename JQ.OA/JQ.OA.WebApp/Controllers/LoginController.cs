﻿using JQ.OA.Common;
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

        IBll.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
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
            UserInfo userInfo = UserInfoService.LoadEntities(u => u.UName == userName && u.UPwd == userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                //Session["userInfo"] = userInfo;

                //Keep the users' session to memcache server
                string sessionId = Guid.NewGuid().ToString(); //Take the guid as the memcache key

                //Keep an userInfo object in memcache by the key of sessionId
                //Serialize the userInfo object to string before put it into memcache

                MemcacheHelper.Set(sessionId, SerializerHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));
                return Content("Ok: Login succeed");
            }

            return Content("No: Error of user name or password");

        }

        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
    }
}