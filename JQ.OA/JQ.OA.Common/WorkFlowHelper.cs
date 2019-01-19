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
        static string strCon = ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;

        /// <summary>
        /// Create a workflow and store it.
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        //public static WorkflowApplication CreateApplicationAndRun(Activity activity)
        public static WorkflowApplication CreateApplicationAndRun(Activity activity, IDictionary<string, object> paramsData)

        {
            //Using SQL persistence for Workflows and workflow service
            //1. Install data tables with sql file of : SqlWorkflowInstanceStoreSchema.sql
            //,  SqlWorkflowInstanceStoreLogic.sql and SqlWorkflowInstanceStoreSchemaUpgrade.sql	
            //2. Ref workflowapplication: System.Activities.DurableInstancing, System.Activities;



            WorkflowApplication application = new WorkflowApplication(activity, paramsData);
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //3. Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.

            //4. When workflow is idle, serialize and unload the workflow, store in the database.
            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            application.Idle = (a) => { Console.WriteLine("Workflow is halting..."); };
            //5. Run application and store the workflow in db
            application.Run();
            return application;
        }



        /// <summary>
        /// Continue a workflow by data stored in SQL server
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="instanceId"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public static WorkflowApplication ContinueWorkFlow(Activity activity, Guid instanceId, Bookmark bookmark, Object value )
        {
            //6. Retrive a workflow in database
            WorkflowApplication application = new WorkflowApplication(activity);
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore;

            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            // 7 load the retrived workflow.
            application.Load(instanceId);

            application.ResumeBookmark(bookmark, value);
            return application;
        }
    }
}
