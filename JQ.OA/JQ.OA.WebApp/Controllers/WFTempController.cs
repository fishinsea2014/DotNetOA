using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class WFTempController : Controller
    {
        // GET: WFTemp

        private IBll.IWF_TempService wF_TempService { get; set; }
        public ActionResult Index()
        {
            short DelFlag = (short)QA.Model.Enum.DelFlagEnum.Normal;
            List<QA.Model.WF_Temp> wf_TempList = wF_TempService.LoadEntities(w => w.DelFlag == DelFlag).ToList();
            ViewData["list"] = wf_TempList;
            return View();
        }

        //public ActionResult LoadTemp()
        //{
        //int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
        //int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

        //int total = 0;
        //var dpList = wF_TempService.LoadPageEntities(pageIndex, pageSize, out total, d => true, d => d.ID, true);

        //var data = new
        //{
        //    total = total,
        //    rows = from a in dpList
        //           select new { a.ID, a.ActivityType, a.Description, a.FormTemp, a.TempName, a.SubTime, a.State }
        //};
        //return Json(data, JsonRequestBehavior.AllowGet);
        //}
        #region Add a new model

        public ActionResult Add()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(QA.Model.WF_Temp wF_Temp)
        {
            wF_Temp.DelFlag = 0;
            wF_Temp.ModfiedOn = DateTime.Now;
            //For test
            wF_Temp.SubBy = 28;
            //wF_Temp.SubBy = LoginUser.ID;
            wF_Temp.SubTime = DateTime.Now;
            wF_Temp.TempStatus = 0;
            wF_TempService.AddEntity(wF_Temp);
            //return Content("ok");
            return RedirectToAction("Index");
        }
        #endregion
    }
}