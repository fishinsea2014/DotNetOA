﻿using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFWinFrmDemo
{
    public class WorkflowApplicationHelper
    {
        static AutoResetEvent _syncEvent = null;
        //private static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;
        public static WorkflowApplication CreateWorkflowApplication(Activity activity, IDictionary<string,object> data, AutoResetEvent synEvent)
        {
            _syncEvent = synEvent;
            string strCon = ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;
            SqlWorkflowInstanceStore store1 = new SqlWorkflowInstanceStore(strCon);
            WorkflowApplication application = new WorkflowApplication(activity, data)
            {
                InstanceStore = store1
            };
            
            application.Run();
            //application.Persist();

            application.Completed = delegate (WorkflowApplicationCompletedEventArgs args)
            {
                Console.WriteLine("The workflow completed");
                synEvent.Set();
            };
            application.Aborted = delegate (WorkflowApplicationAbortedEventArgs arg)
            {
                Console.WriteLine("Workflow aborted");
                synEvent.Set();
            };

            application.Idle = delegate (WorkflowApplicationIdleEventArgs args)
            {
                Console.WriteLine("Workflow is idle");
                synEvent.Set();
            };
            application.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs args)
            {
                Console.WriteLine("");
                synEvent.Set();
                return PersistableIdleAction.Unload;
            };

            application.Unloaded = delegate (WorkflowApplicationEventArgs eventArgs)
            {
                Console.WriteLine("Workflow {0} unloaded", eventArgs.InstanceId);
                synEvent.Set();
            };


            application.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs args)
            {
                Console.WriteLine("Workflow is on unhandled.");
                synEvent.Set();
                return UnhandledExceptionAction.Abort;
            };
            //application.Unloaded += OnUnloaded;
            //application.Aborted += OnAborted;
            //application.Completed += OnCompleted;
            //application.Idle += OnIdle;
            //application.OnUnhandledException += OnUnhandledException;
            //application.PersistableIdle += OnPersistableIdle;

            return application;

        }

        public static WorkflowApplication LoadWorkflowApplication (Activity activity, Guid guid, AutoResetEvent synEvent)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["workFlowDataBase"].ConnectionString;
            _syncEvent = synEvent;
            WorkflowApplication application = new WorkflowApplication(activity);
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(strCon);
            application.InstanceStore = store;
            application.Unloaded += OnUnloaded;
            application.Aborted += OnAborted;
            application.Completed += OnCompleted;
            application.Idle += OnIdle;
            application.OnUnhandledException += OnUnhandledException;
            application.PersistableIdle += OnPersistableIdle;


            application.Load(guid);
            //application.Run();
            return application;
        }
        

        private static UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs arg)
        {
            Console.WriteLine("Throw an exception");
            _syncEvent.Set();
            return UnhandledExceptionAction.Abort;
        }

        private static PersistableIdleAction OnPersistableIdle(WorkflowApplicationIdleEventArgs arg)
        {
            Console.WriteLine("Persistant the workflow...");
            return PersistableIdleAction.Unload;
        }

        private static void OnIdle(WorkflowApplicationIdleEventArgs obj)
        {
            _syncEvent.Set();
            Console.WriteLine("The worflow is idle!!");
        }

        private static void OnCompleted(WorkflowApplicationCompletedEventArgs obj)
        {
            _syncEvent.Set();
            Console.WriteLine("The workflow is completed!!");
        }

        private static void OnAborted(WorkflowApplicationAbortedEventArgs obj)
        {
            _syncEvent.Set();
            Console.WriteLine("The workflow is aborted!!");
        }

        private static void OnUnloaded(WorkflowApplicationEventArgs obj)
        {
            _syncEvent.Set();
            Console.WriteLine("Unload the workflow.");
        }
    }
}
