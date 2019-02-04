using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using JQ.QA.Model;
using JQ.OA.IBll;
using JQ.OA.Bll;

namespace WorkFlow
{
    /// <summary>
    /// Submit financial application, store in database.
    /// </summary>
    public sealed class SubFinancialActivity : CodeActivity
    {
        // Define an activity input argument of type string
        //public InArgument<string> FinancialText { get; set; }
        //public InArgument<WF_StepInfo> LastStepInfo { get; set; }
        public InArgument<decimal>  Money { get; set; }
        //public InArgument<Guid> InstanceId { get; set; }
        public InArgument<int> FlowTo { get; set; }
        public InArgument<int> ProcessBy { get; set; }
        public InArgument<int> WF_InstanceID { get; set; }
        public OutArgument<string> NextStepBookMarkName { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            //string text = context.GetValue(this.Text);

            #region Initiate an application
            ////Put the info of the step of initiating an application into step table
            WF_StepInfo initStep = new WF_StepInfo()
            {
                Title= string.Empty,
                Comment = string.Empty,                
                FlowTo = context.GetValue<int>(FlowTo),
                InstanceId = Guid.Empty,                
                IsEndStep = false,
                IsStartStep = true,
                ParentStepID = -1,
                ProcessBy = context.GetValue<int>(ProcessBy),
                ProcessTime = DateTime.Now,
                StepName = "Initiate Application",
                SubTime = DateTime.Now,
                IsProcessed = true,
                WF_InstanceID = context.GetValue<int>(WF_InstanceID)                
            };

            IWF_StepInfoService stepService = new WF_StepInfoService();
            stepService.AddEntity(initStep);
            #endregion

            WF_StepInfo pmStep = new WF_StepInfo()
            {
                Comment = string.Empty,
                FlowTo = 0,
                InstanceId = Guid.Empty,                
                IsEndStep = false,
                IsStartStep = true,
                ParentStepID = initStep.ID,
                ProcessBy = (int)initStep.FlowTo,
                ProcessTime = DateTime.Now,
                WF_InstanceID = initStep.WF_InstanceID,
                SubTime = DateTime.Now,
                StepName = "PM Validation",                
                IsProcessed = false,
                StepResult = (short)WFEnum.WFEnum.IsContinue 
            };
            stepService.AddEntity(pmStep);
            context.SetValue(NextStepBookMarkName, pmStep.StepName);
        }
    }
}
