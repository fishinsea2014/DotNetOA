using JQ.OA.Bll;
using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    //public class UserinfoController : BaseController

    public class UserinfoController : Controller
    {
        IBll.IUserInfoService userInfoService { get; set; }
        //IUserInfoService userInfoService = new UserInfoService();
        //IUserInfoService userInfoService = new UserInfoService();
        // GET: Userinfo
        public ActionResult Index()
        {
            var userinfoList = userInfoService.LoadEntities( u => true);
            ViewData.Model = userinfoList;
            
            return View();
        }

        /// <summary>
        /// Get users according to the search criteria
        /// </summary>
        /// <param name="SName">Searching string of user name</param>
        /// <param name="SMail">Searching string of user user email</param>
        /// <returns></returns>
        public ActionResult GetAllUserInfos()
        {
            //Get the page size and page index from front end.
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            short delNormal = (short)DelFlagEnum.Normal;

            SearchUserParam userParam = new SearchUserParam();
            userParam.PageSize = pageSize;
            userParam.PageIndex = pageIndex;
            userParam.SName = Request["name"];
            userParam.SPhone = Request["phone"];
            var pagedData = userInfoService.LoadSearchEntities(userParam);

            //Assembe the data into EasyUI table data, like : {total: 10; rows:[]}
            //Sovle the issue of loop dependency caused by navigation properties when serialising the data to Json
            var data = new
            {
                total = userParam.Total,
                rows = (from u in pagedData
                        select
                            new { u.ID, u.UserName, u.Pwd, u.Remark, u.DelFlag, u.Mail
                                  , u.Phone, u.SubTime, u.SubBy, SubName = u.Department.Count }
                        ).ToList()
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

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

        #region  Retrive a user's info by ID
        public ActionResult GetUserInfoModel()
        {
            int id = int.Parse(Request["id"]);
            UserInfo userInfo = userInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            if (userInfo != null)
            {
                return Json(new { serverData = userInfo, msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "no" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Update a user's info
        public ActionResult EditUserinfo(UserInfo userInfo)
        {
            userInfo.SubTime = DateTime.Now;
            if (userInfoService.EditEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region Add an user
        public ActionResult Add(UserInfo userInfo)
        {
            //userInfo.Init();
            userInfo.DelFlag = 0;
            userInfo.SubBy = 1;
            userInfo.SubTime = DateTime.Now;
            //int i = 8;
            //userInfo = new UserInfo()
            //{
            //    UserName = "1Jason" + i,
            //    Pwd = "123" + i,
            //    Phone = "1233" + i,
            //    SubBy = 1,
            //    DelFlag = 0,
            //    SubTime = DateTime.Now,
            //    Remark = "this is remark" + i
            //};

            userInfoService.AddEntity(userInfo);
            //if ( userInfoService.SaveChanges())
            //{

            //    return Content("ok");
            //}

            //return Content("Fail to add an user.");
            return Content("Ok");
        }
        #endregion

        public ActionResult create()
        {
            return Content("create");
        }
    }
}