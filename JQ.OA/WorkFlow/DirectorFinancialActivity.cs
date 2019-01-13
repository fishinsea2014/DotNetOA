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

    public sealed class DirectorFinancialActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> FinancialText { get; set; }
        public InArgument<int> Money { get; set; }
        

        public InArgument<Object> StepInfo { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            
            #region Approve an application
            //Put the info of the step of initiating an application into step table
            WF_Step step = (WF_Step)context.GetValue<object> (StepInfo);
            IWF_StepService stepService = new WF_StepService();
            stepService.AddEntity(step);
            #endregion



        }
    }
}
