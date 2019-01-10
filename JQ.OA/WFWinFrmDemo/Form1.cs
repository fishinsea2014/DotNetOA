using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            application = new WorkflowApplication(new DemoActivity());
            application.Idle = (a) => { Console.WriteLine("Workflow halting..."); };
            application.Run();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            application.ResumeBookmark("UserFinancial", new object[] { "Website", 100000 });
        }
    }
}
