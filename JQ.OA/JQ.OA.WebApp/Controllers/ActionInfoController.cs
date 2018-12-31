﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class ActionInfoController : Controller
    {
        // GET: ActionInfo

        IBll.IActionInfoService actionInfoService { get; set; }
        IBll.IRoleService roleService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadActionInfos()
        {
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;

            //PageIndex should be first.
            var dpList = actionInfoService.LoadPageEntities(pageIndex, pageSize,  out total,
                            d => d.DelFlag == delNormal, d =>d.ID,true);

            var data = new
            {
                total = total,
                rows = from a in dpList
                       select new { a.ID, a.ActionName, a.HttpMethod, a.Remark, a.Url, a.SubTime, a.SubBy, a.Controoller, a.ActionMethod }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult AddAction(QA.Model.ActionInfo actionInfo)
        {
            actionInfo.ActionMethod = string.Empty;
            actionInfo.Controoller = string.Empty;
            actionInfo.SubBy = 1;
            actionInfo.SubTime = DateTime.Now;
            actionInfo.DelFlag = (short)QA.Model.Enum.DelFlagEnum.Normal;

            actionInfoService.AddEntity(actionInfo);

            return Content("ok");
        }

        public ActionResult AddAction()
        {
            return View();
        }


        #region Eidt
        public ActionResult Edit( int id)
        {
            QA.Model.ActionInfo actionInfo = actionInfoService.LoadEntities(action => action.ID == id).FirstOrDefault();

            return View(actionInfo);
        }

        [HttpPost]
        public ActionResult Edit(QA.Model.ActionInfo actionInfo)
        {
            bool result = actionInfoService.EditEntity(actionInfo);
            return Content("ok");
        }
        #endregion

        public ActionResult DeleteIds()
        {
            string strId = Request["ids"];
            string[] strIds = strId.Split(',');
            List<int> delIds = new List<int>();
            foreach (var id in strIds)
            {
                delIds.Add(Convert.ToInt32(id));
            }

            if (InfoService.DeleteEntities(delIds))
            {
                return Content("ok");
            }

            return Content("no");
        }


        //[HttpPost]
        //public ActionResult EditAction( QA.Model.ActionInfo action)
        //{            

        //    bool result = actionInfoService.EditEntity(action);
        //    if (result)
        //    {
        //        return Content("ok");
        //    }
        //    return Content("Failed to edit the action");

        //}

        //public ActionResult EditAction(int id)
        //{
        //    QA.Model.ActionInfo actionInfo = actionInfoService.LoadEntities(action => action.ID == id).FirstOrDefault();
        //    return View(actionInfo);
        //}

    }
}