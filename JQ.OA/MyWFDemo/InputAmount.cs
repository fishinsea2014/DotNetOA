using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace MyWFDemo
{

    public sealed class InputAmount : CodeActivity
    {
        // Define an activity input argument of type string
        public OutArgument<int> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            int readAmount = 0;
            string strAmount = Console.ReadLine();
            readAmount = int.Parse(strAmount);

            context.SetValue(Text, readAmount);
        }
    }
}
