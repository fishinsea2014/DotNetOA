using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Activities;
using WorkFlow;
using System.Activities.DurableInstancing;
using System.Configuration;

namespace JQ.OA.WebApp.Controllers
{
    public class WFInstanceController : Controller
    {
        //string strCon = ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;
        //private const string strCon = "Data Source=JASON\\SQLEXPRESS; initial catalog=OAData;  Integrated Security = TRUE";
        // GET: WFInstance
        IBll.IWF_InstanceService wF_InstanceService { get; set; }
        IBll.IWF_StepInfoService wF_StepInfoService { get; set; }
        IBll.IWF_TempService wF_TempService { get; set; }
        IBll.IUserInfoService userInfoService { get; set; }

        public ActionResult Index()
        {
            short DelFlag = (short)QA.Model.Enum.DelFlagEnum.Normal;
            List<QA.Model.WF_Temp> wf_TempList = wF_TempService.LoadEntities(w => w.DelFlag == DelFlag).ToList();
            ViewData["list"] = wf_TempList;
            return View();
        }
        #region Start a expense claim  workflow
        
        public ActionResult StartFinancial()
        {
            int id = int.Parse(Request["id"]);
            var currentTemp = wF_TempService.LoadEntities(t => t.ID == id).FirstOrDefault();
            ViewBag.Temp = currentTemp;
            short DelFlag = (short)QA.Model.Enum.DelFlagEnum.Normal;
            var userInfoList = from u in userInfoService.LoadEntities(u => u.DelFlag == DelFlag)
                               select new SelectListItem()
                               {
                                   Selected = false,
                                   Text = u.UserName,
                                   Value = u.ID.ToString()
                               };
            ViewData["FlowTo"] = userInfoList;
            return View();
        } 

        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult StartFinancial (QA.Model.WF_Instance instance, int hidTempId)
        //{

           
        //    return Content("ok");

            //Step1: Keep an instance data in the DB.
            //instance.Level = 0;
            //instance.Result = 0;
            //instance.State = 0;
            //instance.SubBy = 38;
            ////instance.SubBy = this.LoginUserInfo.ID;
            //instance.SubTime = DateTime.Now;
            //instance.WF_TempID = hidTempId;
            //instance.Field = 0;
            //instance.InstanceId = Guid.Empty;

            //wF_InstanceService.AddEntity(instance);

            //Dictionary<string, object> data = new Dictionary<string, object>();
            //data.Add("AskText", instance.Title);
            ////data.Add("FlowTo", int.Parse(Request["flowto"]));
            //data.Add("Money", int.Parse(Request["Money"]));
            ////data.Add("ProcessBy", instance.SubBy);
            ////data.Add("WFInstanceId", instance.ID);

            ////Start the worklfow
            ////var app = Common.WorkFlowHelper.CreateApplicationAndRun(new FinancialActivity(), data);

            ////var app = Common.WorkFlowHelper.CreateApplicationAndRun(new FinancialActivity(), data);

            //#region Workflow
            //WorkflowApplication app = new WorkflowApplication(new DirectorFinancialActivity(), data);
            //SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);
            //app.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.

            ////4. When workflow is idle, serialize and unload the workflow, store in the database.
            //app.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            //app.Idle = (a) => { Console.WriteLine("Workflow is halting..."); };
            ////5. Run application and store the workflow in db
            //app.Run();

            //#endregion



            //instance.InstanceId = app.Id;
            //wF_InstanceService.EditEntity(instance);
        //}
        #endregion
    }
}