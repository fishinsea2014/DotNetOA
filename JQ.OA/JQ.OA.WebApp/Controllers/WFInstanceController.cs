﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Activities;
using WorkFlow;
using System.Activities.DurableInstancing;
using System.Configuration;
using WorkFlow;

namespace JQ.OA.WebApp.Controllers
{
    public class WFInstanceController : BaseController
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

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult StartFinancial(QA.Model.WF_Instance wFInstance)
        {           

            //Step1: Keep an instance data in the DB.
            wFInstance.ApplicationId = Guid.Empty; //The id of an instance
            wFInstance.Result = 0;
            wFInstance.WF_TempID = int.Parse(Request["hiddenTempId"]);           
            wFInstance.Status = 0;
            wFInstance.SubTime = DateTime.Now;
            wFInstance.StartedBy = LoginUserInfo.ID;
            wF_InstanceService.AddEntity(wFInstance);

            // Start workflow

            IDictionary<string, object> data = new Dictionary<string, object>();
            //data.Add("TempBookMarkName", "Project Manager");
            data.Add("FlowTo", int.Parse(Request["flowto"]));
            data.Add("Money", decimal.Parse(Request["Amount"]));
            data.Add("ProcessBy", wFInstance.StartedBy);
            data.Add("WFInstanceId", wFInstance.ID);

            //Start the worklfow
            //var app = Common.WorkFlowHelper.CreateApplicationAndRun(new FinancialActivity(), data);

            //var app = Common.WorkFlowHelper.CreateApplicationAndRun(new FinancialActivity(), data);

            #region Workflow

            var application = WorkflowApplicationHelper.CreateWorkflowApplication(new ClaimExpenseActivity(), data);
            wFInstance.ApplicationId = application.Id;
            wF_InstanceService.EditEntity(wFInstance); //Update the worflow instance id.

            //Start the first step, apply for expense claim
            //QA.Model.WF_StepInfo initStepInfo = new QA.Model.WF_StepInfo();
            //initStepInfo.ChildStepID = 0;
            //initStepInfo.Comment = "Start a expense claim";
            //initStepInfo.DelFlag = 0;
            //initStepInfo.IsEndStep = false;
            //initStepInfo.IsProcessed = true;
            //initStepInfo.IsStartStep = true;
            //initStepInfo.ParentStepID = -1;
            ////initStepInfo.ProcessBy = LoginUser.ID;
            //initStepInfo.ProcessBy = 2;
            //initStepInfo.ProcessTime = DateTime.Now;
            //initStepInfo.Remark = "Start an expense claim";
            //initStepInfo.StepName = "The begining initiate step";
            //initStepInfo.StepResult = 0;
            //initStepInfo.SubTime = DateTime.Now;
            //initStepInfo.Title = "Initiate an expense claim";
            //initStepInfo.WF_InstanceID = wFInstance.ID;
            //wF_StepInfoService.AddEntity(initStepInfo);

            ////Create project manager validating step and waiting for approving
            //QA.Model.WF_StepInfo pmStepInfo = new QA.Model.WF_StepInfo();
            //pmStepInfo.ChildStepID = 0;
            //pmStepInfo.Comment = string.Empty;
            //pmStepInfo.DelFlag = 0;
            //pmStepInfo.IsEndStep = false;
            //pmStepInfo.IsProcessed = false;
            //pmStepInfo.IsStartStep = false;
            //pmStepInfo.ParentStepID = initStepInfo.ID;
            ////pmStepInfo.ProcessBy = LoginUser.ID;
            //pmStepInfo.ProcessBy = 38;
            //pmStepInfo.ProcessTime = DateTime.Now;
            //pmStepInfo.Remark = string.Empty;
            //pmStepInfo.StepName = "Project manager validation";
            //pmStepInfo.StepResult = 0;
            //pmStepInfo.SubTime = DateTime.Now;
            //pmStepInfo.Title = string.Empty;
            //pmStepInfo.WF_InstanceID = wFInstance.ID;
            //wF_StepInfoService.AddEntity(pmStepInfo);
            #endregion

            //return Redirect("/WFInstance/StartFinancial?id=" + id);
            return Content("ok");
        }
        #endregion

        #region Project Manager validating
        public ActionResult PMValidate()
        {
            return View();

        }

        public ActionResult GetPMWorkFlow()
        {
            //TODO: should change to current userid
            //int userId = LoginUser.ID;
            int userId = 2;
            //short isNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;
            var stepList = wF_StepInfoService.LoadEntities(s => s.ProcessBy == userId && s.IsProcessed == false).ToList();
            var userList = userInfoService.LoadEntities(u => true).ToList();
            var allInstanceList = (from s in stepList
                                   select s.WF_Instance).ToList();
            var allInstance = (from step in allInstanceList
                               join user in userList
                               on step.StartedBy equals user.ID
                               select new
                               {
                                   step.ID,
                                   step.SubTime,
                                   step.Level,
                                   step.InstanceName,
                                   user.UserName
                               }).ToList();
            return Json(allInstance, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PMCheck()
        {
            //var instance = wF_InstanceService.LoadEntities(i => i.ID == instanceID).FirstOrDefault();
            //ViewBag.AllSteps = instance.WF_StepInfo.ToList();
            //return View(instance);

            int instanceID = int.Parse(Request["id"]);
            var instance = wF_InstanceService.LoadEntities(i => i.ID == instanceID).FirstOrDefault();
            ViewBag.Instance = instance;
            var steps = wF_StepInfoService.LoadEntities(s => s.WF_InstanceID == instanceID).ToList();
            ViewBag.Steps = steps;
            short isNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;
            var userInfoList = from u in userInfoService.LoadEntities(u => u.DelFlag == isNormal).ToList()
                               select new SelectListItem()
                               {
                                   Selected = false,
                                   Text = u.UserName,
                                   Value = u.ID.ToString()
                               };
            ViewData["ProcessBy"] = userInfoList;// If the name of viewdata is same as DropDownList,
                                                 // then the users info will fill by default.
            return View();
        }

        [HttpPost]
        public ActionResult PMDecision(int insId, bool isPass, string Comment, int FlowTo)
        {
            var instance = wF_InstanceService.LoadEntities(i => i.ID == insId).FirstOrDefault();
            var step = (from s in instance.WF_StepInfo
                        where s.IsProcessed == false
                        select s).FirstOrDefault();

            step.IsProcessed = true;
            step.Comment = Comment;
            step.FlowTo = FlowTo;
            wF_StepInfoService.DeteachEntities(step);

            ActivityResult activityResult = new ActivityResult();
            activityResult.Data = step;
            activityResult.NextStepBookMarkName = step.StepName;
            activityResult.Result = isPass ? (short)WorkFlow.WFEnum.WFEnum.IsPass 
                                           : (short)WorkFlow.WFEnum.WFEnum.IsReject;

            WorkflowApplicationHelper.LoadWorkflowApplication(new ClaimExpenseActivity(),
                instance.ApplicationId, new Bookmark(step.StepName), activityResult);
            return Content("ok");

        } 
        #endregion

        public ActionResult GetMyWorkflows()
        {
            //int userId = LoginUser.ID;
            int userId = 2;
            short isNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;
            var stepList = wF_StepInfoService.LoadEntities(s => s.ID == userId && s.IsProcessed == false && s.DelFlag == isNormal).ToList();
            var allInstanceList = (from s in stepList
                                  select s.WF_Instance).ToList();
            return View(allInstanceList);
        }

        public ActionResult CheckWorkFlow()
        {
            int id = int.Parse(Request["id"]);
            var instance = wF_InstanceService.LoadEntities(i => i.ID == id).FirstOrDefault();
            ViewBag.Instance = instance;
            var steps = wF_StepInfoService.LoadEntities(s => s.WF_InstanceID == id).ToList();
            ViewBag.Steps = steps;
            short isNormal = (short)QA.Model.Enum.DelFlagEnum.Normal;
            var userInfoList = from u in userInfoService.LoadEntities(u => u.DelFlag == isNormal).ToList()
                               select new SelectListItem()
                               {
                                   Selected = false,
                                   Text = u.UserName,
                                   Value = u.ID.ToString()
                               };
            ViewData["ProcessBy"] = userInfoList;// If the name of viewdata is same as DropDownList,
                                                 // then the users info will fill by default.
            return View();
        }
    }
}