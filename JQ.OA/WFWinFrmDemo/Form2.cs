using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFWinFrmDemo
{
    public partial class Form2 : Form
    {
       
        //WorkflowApplication application = null;
        //string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoResetEvent synEvent = new AutoResetEvent(false);
            Console.WriteLine("Main thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString());
            DateTime tempDateTime = DateTime.Now;
            IDictionary<string, object> paraData = new Dictionary<string, object>();
            paraData["TempDateTime"] = tempDateTime;
            paraData["TempBookMarkName"] = this.txtBookMarkName.Text;
            //Another way to initiate the dictionary
            //IDictionary<string, object> paraData1 = new Dictionary<string, object>
            //{
            //    {"TempDateTime", paraData }
            //};

            //Persistant the workflow in SQL
            //SqlWorkflowInstanceStore sqlStore = new SqlWorkflowInstanceStore(strCon);

            //WorkflowApplication application = new WorkflowApplication(new StateWorkFlow(), paraData);
            //application.InstanceStore = sqlStore; //Persistant the workflow in SQL
            //application.Run();
            //this.textBox1.Text = application.Id.ToString();


            //application.Completed = delegate (WorkflowApplicationCompletedEventArgs args)
            //{
            //    Console.WriteLine("The workflow completed");
            //    synEvent.Set();
            //};
            //application.Aborted = delegate (WorkflowApplicationAbortedEventArgs arg)
            //{
            //    Console.WriteLine("Workflow aborted");
            //    synEvent.Set();
            //};

            //application.Idle = delegate (WorkflowApplicationIdleEventArgs args)
            //{
            //    Console.WriteLine("Workflow is idle");
            //    synEvent.Set();
            //};
            //application.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs args)
            //{
            //    Console.WriteLine("");
            //    synEvent.Set();
            //    return PersistableIdleAction.Unload;
            //};

            //application.Unloaded = delegate (WorkflowApplicationEventArgs eventArgs)
            //{
            //    Console.WriteLine("Workflow {0} unloaded", eventArgs.InstanceId);
            //    synEvent.Set();
            //};


            //application.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs args)
            //{
            //    Console.WriteLine("Workflow is on unhandled.");
            //    synEvent.Set();
            //    return UnhandledExceptionAction.Abort;
            //};

            WorkflowApplication application = WorkflowApplicationHelper.CreateWorkflowApplication(new StateWorkFlow(), paraData, synEvent);

            synEvent.WaitOne();
            this.textBox1.Text = application.Id.ToString();
            Console.WriteLine("Main thread continue working....");
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            WorkflowApplication application = null;
            application.ResumeBookmark(this.txtBookMarkName.Text, this.txtValue.Text);
            application.Run();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //SqlWorkflowInstanceStore sqlStore = new SqlWorkflowInstanceStore(strCon);

            //WorkflowApplication application = new WorkflowApplication(new StateWorkFlow());
            //application.InstanceStore = sqlStore; //Persistant the workflow in SQL            

            //application.Completed = delegate (WorkflowApplicationCompletedEventArgs args)
            //{
            //    Console.WriteLine("The workflow completed");
            //    synEvent.Set();
            //};
            //application.Aborted = delegate (WorkflowApplicationAbortedEventArgs arg)
            //{
            //    Console.WriteLine("Workflow aborted");
            //    synEvent.Set();
            //};

            //application.Idle = delegate (WorkflowApplicationIdleEventArgs args)
            //{
            //    Console.WriteLine("Workflow is idle");
            //    synEvent.Set();
            //};
            //application.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs args)
            //{
            //    Console.WriteLine("");
            //    synEvent.Set();
            //    return PersistableIdleAction.Unload;
            //};

            //application.Unloaded = delegate (WorkflowApplicationEventArgs eventArgs)
            //{
            //    Console.WriteLine("Workflow {0} unloaded", eventArgs.InstanceId);
            //    synEvent.Set();
            //};


            //application.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs args)
            //{
            //    Console.WriteLine("Workflow is on unhandled.");
            //    synEvent.Set();
            //    return UnhandledExceptionAction.Abort;
            //};
            AutoResetEvent synEvent = new AutoResetEvent(false);
            WorkflowApplication application = WorkflowApplicationHelper.LoadWorkflowApplication(new StateWorkFlow(), Guid.Parse(this.textBox1.Text),synEvent);
            //application.Load(Guid.Parse(this.textBox1.Text));
            application.ResumeBookmark(this.txtBookMarkName.Text, this.txtValue.Text);
            application.Run();
            synEvent.WaitOne(); //Stop the main thread
        }
    }
}
