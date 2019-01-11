using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Common
{
    public class WorkFlowHelper
    {
        string strCon = ConfigurationManager.
        public WorkflowApplication CreateApplicationAndRun(Activity activity)
        {
            //Using SQL persistence for Workflows and workflow service
            //1. Install data tables with sql file of : SqlWorkflowInstanceStoreSchema.sql
            //,  SqlWorkflowInstanceStoreLogic.sql and SqlWorkflowInstanceStoreSchemaUpgrade.sql	
            //2. Ref workflowapplication: System.Activities.DurableInstancing, System.Activities;


            WorkflowApplication application = new WorkflowApplication(activity);
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //3. Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.

            //4. When workflow is idle, serialize and unload the workflow, store in the database.
            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            application.Idle = (a) => { Console.WriteLine("Workflow is halting..."); };
            //5. Run application and store the workflow in db
            application.Run();
        }
    }
}
