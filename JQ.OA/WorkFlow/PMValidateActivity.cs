using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using JQ.OA.Bll;
using JQ.OA.IBll;

namespace WorkFlow
{

    public sealed class PMValidateActivity : NativeActivity
    {
        // Define an activity input argument of type string
        public InArgument<decimal> Money { get; set; }
        public InArgument<Object> stepInfo { get; set; }

        public OutArgument<ActivityResult> StepNodeResult { get; set; }
        public OutArgument<string> NextStepName { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        
        protected override void Execute(NativeActivityContext context)
        {
            ActivityResult result = (ActivityResult)context.GetValue<Object>(stepInfo);

            var step = (JQ.QA.Model.WF_StepInfo)result.Data;
            step.State = 1;
            step.IsProcessed = true;
            IWF_StepInfoService stepInfoService = new WF_StepInfoService();
            stepInfoService.EditEntity(step);

            //Create next step
            JQ.QA.Model.WF_StepInfo nextStep = new JQ.QA.Model.WF_StepInfo()
            {
                Comment = string.Empty,
                FlowTo = -1,
                
                State = (short)WFEnum.WFStateEnum.IsComplete,
                InstanceId = Guid.Empty,
                IsStartStep = false,
                ParentStepID = step.ID,
                ProcessBy = (int)step.FlowTo,
                ProcessTime = DateTime.Now,
                WF_InstanceID = step.WF_InstanceID,
                SubTime = DateTime.Now,
                StepResult = (short)WFEnum.WFEnum.IsPass
            };

            if (result.Result == (short)WFEnum.WFEnum.IsPass)
            {
                nextStep.StepName = "To Finance Dep, end of workflow.";
                nextStep.IsEndStep = true;
                nextStep.IsProcessed = true;
                step.WF_Instance.Status = (short)WFEnum.WFStateEnum.IsComplete;
                stepInfoService.AddEntity(nextStep);
                stepInfoService.EditEntity(step);

                result.Result = (short)WFEnum.WFEnum.IsPass;
                result.NextStepBookMarkName = nextStep.StepName;
            }
            else
            {
                step.IsProcessed = true;
                result.Data = step;
                result.Result = (short)WFEnum.WFEnum.IsReject;
                result.NextStepBookMarkName = "";
            }

            context.SetValue(NextStepName, result.NextStepBookMarkName);
            context.SetValue(StepNodeResult, result);


        }
    }
}
