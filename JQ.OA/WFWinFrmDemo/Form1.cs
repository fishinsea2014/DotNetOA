using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFWinFrmDemo
{
    public partial class Form1 : Form
    {
        private WorkflowApplication application;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkflowInvoker.Invoke(new Activity1());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Using SQL persistence for Workflows and workflow service
            //1. Install data tables with sql file of : SqlWorkflowInstanceStoreSchema.sql
            //,  SqlWorkflowInstanceStoreLogic.sql and SqlWorkflowInstanceStoreSchemaUpgrade.sql	
            //2. Ref workflowapplication: System.Activities.DurableInstancing, System.Activities;
             

            WorkflowApplication application = new WorkflowApplication(new DemoActivity());
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //3. Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.

            //4. When workflow is idle, serialize and unload the workflow, store in the database.
            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };           
             
            application.Idle = (a) => { Console.WriteLine("Workflow is halting..."); };
            //5. Run application and store the workflow in db
            application.Run();
            this.richTextBox1.Text = application.Id.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            application.ResumeBookmark("UserFinancial", new object[] { "Website", 100000 });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //6. Retrive a workflow in database
            WorkflowApplication application = new WorkflowApplication(new DemoActivity());
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; 

            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            // 7 load the retrived workflow.
            application.Load(Guid.Parse(this.textBox1.Text));

            application.ResumeBookmark("UserFinancial", new object[] { "Website", 100000 });
        }
    }
}
