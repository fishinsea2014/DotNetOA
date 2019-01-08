using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Menu
        IBll.IMenuInfoService menuInfoService { get; set; }
        IBll.IActionInfoService actionInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region Load all items with paging info
        public ActionResult LoadMenuInfos()
        {
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;


            //PageIndex should be first.
            var menuList = menuInfoService.LoadPageEntities(pageIndex, pageSize, out total,
                            d => d.DelFlag == delNormal, d => d.ID, true);
            var actionList = actionInfoService.LoadEntities(a => a.DelFlag == delNormal);


            var data = new
            {
                total = total,
                rows = from a in menuList
                       from act in actionList
                       where a.ActionInfoId == act.ID
                       select new
                       {
                           a.ID,
                           a.MenuName,
                           act.ActionName,
                           act.Url,
                           a.Remark,
                           a.Sort,
                           a.SubTime,
                           a.SubBy,
                           a.IsVisable,
                           a.DialogHeight,
                           a.DialogWidth,
                           a.IconUrl,
                           a.ParentId
                       }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add a new menu item
        [HttpPost]
        public ActionResult AddMenu(QA.Model.MenuInfo menuInfo)
        {

            menuInfo.SubBy = this.LoginUserInfo.ID;
            menuInfo.SubTime = DateTime.Now;
            menuInfo.DelFlag = (short)QA.Model.Enum.DelFlagEnum.Normal;
            menuInfo.DialogHeight = 500;
            menuInfo.DialogWidth = 500;
            menuInfo.IsVisable = true;
            menuInfo.ParentId = 1;

            menuInfoService.AddEntity(menuInfo);

            return Content("ok");
        }

        public ActionResult AddMenu()
        {
            return View();
        } 

        public ActionResult UploadIconImg()
        {
            var requestFile = Request.Files["iconImg"];
            if ( requestFile!= null)
            {
                string imagePath = "/Upload/Images/";
                string fileName = imagePath + Guid.NewGuid().ToString() + requestFile.FileName;
                requestFile.SaveAs(Server.MapPath(fileName));
                return Content(fileName);
            }

            return Content("Error: Failed to upload icon.");
        }
        #endregion
        #region Delete menu items

        public ActionResult DeleteMenus()
        {
            string strIds = Request["strId"];
            string[] listStrIds = strIds.Split(',');
            List<int> listIds = new List<int>();
            foreach (string id in listStrIds)
            {
                listIds.Add(Convert.ToInt32(id));
            }
            if (menuInfoService.DeleteEntities(listIds))
            {
                return Content("ok");
            }
            else
            {
                return Content("Error : Failed to delete menus");
            };
        }
        #endregion
        #region Edit a menu item
        public ActionResult Edit(int id)
        {
            //int itemId = Request[""]
            QA.Model.MenuInfo menuItem = menuInfoService.LoadEntities(m => m.ID == id).FirstOrDefault();

            return View(menuItem);
        } 
        [HttpPost]
        public ActionResult Edit(QA.Model.MenuInfo menuInfo)
        {
            bool result = menuInfoService.EditEntity(menuInfo);
            if (result)
            {
                return Content("ok");
            }

            return Content("failed to update a menu item");
        }
        #endregion

    }
}