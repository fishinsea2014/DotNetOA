using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkFlow
{

    public sealed class Wait4InputDataActivity<T> : NativeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> BookMarkName { get; set; }
        public OutArgument<T> OutData { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        
        protected override void Execute(NativeActivityContext context)
        {
            string text = context.GetValue(this.BookMarkName);
            context.CreateBookmark(text, new BookmarkCallback(AfterContinue));
        }

        public void AfterContinue(NativeActivityContext context, Bookmark bookmark, Object value)
        {
            context.SetValue(OutData, (T)value);
        }
    }
}
