using JQ.OA.Bll;
using JQ.QA.Model;
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
        #region Retrive user info
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

            
            var userInfoList = userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.ID, true);
            //var userInfoList=UserInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.ID, true);

            var temp = from u in userInfoList
                       select new { ID = u.ID, UserName = u.UName, UserPass = u.UPwd, Remark = u.Remark, RegTime = u.SubTime };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
            //return Json(new { rows = temp, total = 100 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete users
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> delIds = new List<int>();
            foreach (var id in strIds)
            {
                delIds.Add(Convert.ToInt32(id));
            }

            if (userInfoService.DeleteEntities(delIds))
            {
                return Content("ok");
            }

            return Content("no");
                 
        }
        #endregion

        #region Add a user
        public ActionResult AddUserInfo(UserInfo userInfo)
        {
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfoService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion
    }
}