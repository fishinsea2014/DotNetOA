using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFWinFrmDemo
{

    //public sealed class Wait4InputDataActivity<T> : NativeActivity
    public sealed class Wait4InputDataActivity : NativeActivity
    {
        // Define an activity input argument of type string
        public OutArgument<string> Text { get; set; }
        public OutArgument<int> Money { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        

        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("Create a bookmark: start");
            context.CreateBookmark("UserFinancial", new BookmarkCallback(ContinueExcuteWorkflow));
        }

        private void ContinueExcuteWorkflow(NativeActivityContext context, Bookmark bookmark, object value)
        {
            //context.SetValue(Text, (T)value);
            object[] objs = (object[])value;
            context.SetValue(Text, objs[0].ToString());
            //context.SetValue(Money, (int)objs[1]);
            context.SetValue(Money, (int)objs[1]);
            Console.WriteLine("Bookmark complete, continue...");
            //context.SetValue(Text, (int)value);
        }
    }
}
