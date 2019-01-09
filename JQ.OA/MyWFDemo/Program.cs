using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace MyWFDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //Activity workflow1 = new Workflow1();
            //WorkflowInvoker.Invoke(workflow1);
            //WorkflowInvoker.Invoke(new Activity1());
            //FlowChart flowChart = new FlowChart();
            //WorkflowInvoker.Invoke(flowChart);

            WorkflowInvoker.Invoke(new FlowDemoActivity());
            Console.Read();
        }
    }
}
