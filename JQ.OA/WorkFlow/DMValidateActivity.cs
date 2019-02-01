using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using JQ.OA.Bll;
using JQ.OA.IBll;

namespace WorkFlow
{

    public sealed class DMValidateActivity : NativeActivity
    {
        // Define an activity input argument of type string
        //public InArgument<string> FinancialText { get; set; }
        //public InArgument<Guid> InstanceId { get; set; }
        //public InArgument<int> FlowTo { get; set; }
        //public InArgument<int> ProcessBy { get; set; }
        //public InArgument<int> WF_InstanceID { get; set; }
        public InArgument<int> Money { get; set; }
        public InArgument<object> StepInfo { get; set; }

        public OutArgument<ActivityResult> StepNodeResult { get; set; }
        public OutArgument<string> NextStepBookMarkName { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(NativeActivityContext context)
        {
            //Get the result of the last step and update its state.
            ActivityResult result = (ActivityResult)context.GetValue<object>(StepInfo);
            var step = (JQ.QA.Model.WF_StepInfo)result.Data;
            step.State = 1; //Set the state as an active workflow.
            step.IsProcessed = true;
            step.SubTime = DateTime.Now;
            IWF_StepInfoService stepService = new WF_StepInfoService();
            stepService.EditEntity(step);

            //Create next step
            JQ.QA.Model.WF_StepInfo nextStep = new JQ.QA.Model.WF_StepInfo()
            {
                Comment = string.Empty,
                FlowTo = 0,
                InstanceId = Guid.Empty,
                IsStartStep = false,
                ParentStepID = step.ID,
                ProcessBy = (int)step.FlowTo,
                State = 0,
                SubTime = DateTime.Now,
                IsEndStep = false,
                ProcessTime = DateTime.Now,
                WF_InstanceID = step.WF_InstanceID
            };

            if (result.Result == (short)WFEnum.WFEnum.IsPass)
            {
                nextStep.StepName = "End of the workflow";
                nextStep.IsEndStep = true;
                nextStep.IsProcessed = true;

                //Set the instance status as finished.
                step.WF_Instance.Status = 1;
                stepService.EditEntity(step);

            }
            else
            {
                nextStep.StepName = "Initiate Application";
                nextStep.IsStartStep = true;
                nextStep.IsProcessed = false;
            }

            result.Data = nextStep;
            result.NextStepBookMarkName = nextStep.StepName;

        }
    }
}
