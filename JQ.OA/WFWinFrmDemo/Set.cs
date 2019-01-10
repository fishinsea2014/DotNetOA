using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFWinFrmDemo
{

    public sealed class Set : CodeActivity
    {
        // Define an activity input argument of type string
        public OutArgument<int> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            //string text = context.GetValue(this.Text);
            int a = new Random().Next(1, 10);

            context.SetValue(Text, a ); 
        }
    }
}
