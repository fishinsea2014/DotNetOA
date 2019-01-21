using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkFlow
{

    public sealed class Wait4NextStepBookmark<T> : NativeActivity
    {
        // Define an activity input argument of type string
        public InOutArgument<string> BookMarkName { get; set; }
        public OutArgument<int> StepId { get; set; }
        public OutArgument<T> Result { get; set; }
        // If your activity returns a value, derive from NativeActivity<TResult>
        // and return the value from the Execute method.

        protected override bool CanInduceIdle
        {
            get { return true; }
        }
        protected override void Execute(NativeActivityContext context)
        {
            string bookMark = context.GetValue(this.BookMarkName);
            context.CreateBookmark(bookMark, new BookmarkCallback(AfterContinue));
        }

        /// <summary>
        /// Execute when resume a bookmark
        /// Here set the values of the activity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public void AfterContinue(NativeActivityContext context, Bookmark bookmark, object value)
        {
            var data = (BookMarkObject<T>)value;
            context.SetValue(BookMarkName, data.BookMark);
            context.SetValue(StepId, data.StepId);
            context.SetValue(Result, data.Result);
        }
    }
}
