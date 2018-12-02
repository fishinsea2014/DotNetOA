﻿using JQ.OA.Bll;
using JQ.QA.Model.Enum;
using JQ.QA.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class UserinfoController : Controller
    {
        //IBll.IUserInfoService userInfoService { get; set; }
        IBll.IUserInfoService userInfoService = new Bll.UserInfoService();
        //IBll.IUserInfoService UserInfoService { get; set; }
        // GET: Userinfo
        public ActionResult Index()
        {
            var userinfoList = userInfoService.LoadEntities( u => true);
            ViewData.Model = userinfoList;
            return View();
        }

        public ActionResult GetUserInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            string name = Request["name"];
            string remark = Request["remark"];
            //Construct searching conditions
            int totalCount = 0;
            UserInfoParam userInfoParam = new UserInfoParam()
            {

                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                UserName = name,
                Remark = remark
            };

            short delFlag = (short) DelFlagEnum.Normal;
            //var userInfoList=UserInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.ID, true);

            //var userInfoList = UserInfoService.LoadSearchEntities(userInfoParam);
            //userInfoService.LoadPageEntities
            //var userInfoList = userInfoService.LoadEntities (u => true);
            var userInfoList = userInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.ID, true);
            var temp = from u in userInfoList
                       select new { ID = u.ID, UserName = u.UName, UserPass = u.UPwd, Remark = u.Remark, RegTime = u.SubTime };
            return Json(new { rows = temp, total = userInfoParam.TotalCount }, JsonRequestBehavior.AllowGet);
        }
    }
}