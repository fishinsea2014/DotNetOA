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
            
            //{
            //    SqlConnection myConn = new SqlConnection(strCon);
            //    myConn.Open();
            //    string sql = "insert into OAData.dbo.test1(id,name) values (40,5) ";
            //    try
            //    {
            //        SqlCommand comm = new SqlCommand(sql, myConn);
            //        if (comm.ExecuteNonQuery() != 0)
            //        {
            //            Console.WriteLine("插入成功");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("插入失败");
            //    } 
            //}

            WorkflowApplication application = new WorkflowApplication(new DemoActivity());
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.

            //When workflow is idle, serialize and unload the workflow, store in the database.
            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            
             
            application.Idle = (a) => { Console.WriteLine("Workflow is halting..."); };
            application.Run();
            this.richTextBox1.Text = application.Id.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            application.ResumeBookmark("UserFinancial", new object[] { "Website", 100000 });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkflowApplication application = new WorkflowApplication(new DemoActivity());
            SqlWorkflowInstanceStore sqlWorkflowInstanceStore = new SqlWorkflowInstanceStore(strCon);

            //Connecting current application instance to database.
            application.InstanceStore = sqlWorkflowInstanceStore; //Here must ref system.runtime.durableinstancing.
                                                                  //When workflow is idle, serialize and unload the workflow, store in the database.
            application.PersistableIdle = arg => { return PersistableIdleAction.Unload; };

            application.Load(Guid.Parse(this.textBox1.Text));

            application.ResumeBookmark("UserFinancial", new object[] { "Website", 100000 });
        }
    }
}
