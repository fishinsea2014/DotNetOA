using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Activities;
using WorkFlow;

namespace JQ.OA.WebApp.Controllers
{
    public class WFInstanceController : Controller
    {
        // GET: WFInstance
        public IBll.IWF_InstanceService wF_InstanceService { get; set; }
        public IBll.IWF_StepService wF_StepService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region Initiate a expense claim 

        public ActionResult StartFinancial(int tempId)
        {
            ViewBag.TempId = tempId;
            return View();
        } 

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult StartFinancial (QA.Model.WF_Instance instance, int hidTempId)
        {
            //Step1: Keep an instance data in the DB.
            instance.Level = 0;
            instance.Result = 0;
            instance.State = 0;
            instance.SubBy = 38;
            //instance.SubBy = this.LoginUserInfo.ID;
            instance.SubTime = DateTime.Now;
            instance.WF_TempID = hidTempId;
            instance.Field = 0;
            instance.InstanceId = Guid.Empty;

            wF_InstanceService.AddEntity(instance);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("AskText", instance.Title);
            data.Add("FlowTo", int.Parse(Request["flowto"]));
            data.Add("Money", int.Parse(Request["Money"]));
            data.Add("ProcessBy", instance.SubBy);
            data.Add("WFInstanceId", instance.ID);

            //Start the worklfow
            var app = Common.WorkFlowHelper.CreateApplicationAndRun(new FinancialActivity(), data);

            instance.InstanceId = app.Id;
            wF_InstanceService.EditEntity(instance);
            return Content("ok");
        }
        #endregion
    }
}