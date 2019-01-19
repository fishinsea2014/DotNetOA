using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFWinFrmDemo
{

    public sealed class BookMarkCodeActivity : NativeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> BookMarkName { get; set; }
        public OutArgument<int> ReturnResult { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.


        /// <summary>
        /// Create a bookmark
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            //throw new NotImplementedException();
            string bookMarkName = context.GetValue(BookMarkName); // get the name of the bookmark
            context.CreateBookmark(bookMarkName, ExecuteContinueBookMark);
        }

        protected override bool CanInduceIdle { get { return true; } }
        

        /// <summary>
        /// Execute the method when the workflow is waken up.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value">Keep the parameters when wake the workflow up.</param>
        public void ExecuteContinueBookMark (NativeActivityContext context, Bookmark bookmark, object value)
        {
            int result = Convert.ToInt32(value);
            context.SetValue(ReturnResult, result);
        }
    }
}
