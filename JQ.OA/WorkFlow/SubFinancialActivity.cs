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
        public InArgument<string> FinancialText { get; set; }
        public InArgument<int>  Money { get; set; }
        public InArgument<Guid> InstanceId { get; set; }
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
            //Put the info of the step of initiating an application into step table
            WF_Step step = new WF_Step()
            {
                Comment = string.Empty,
                FlowTo = context.GetValue<int>(FlowTo),
                InstanceId = context.GetValue<Guid>(InstanceId),
                IsEnd = false,
                IsStart = true,
                ParentStepId = -1,
                ProcessBy = context.GetValue<int>(ProcessBy),
                ProcessTime = DateTime.Now,
                Sort = 1,
                State = 0,
                StepName = "Initiate Application",
                SubTime = DateTime.Now,
                IsProcessed = true,
                WF_InstanceID = context.GetValue<int>(WF_InstanceID)
            };

            IWF_StepService stepService = new WF_StepService();
            stepService.AddEntity(step); 
            #endregion



        }
    }
}
