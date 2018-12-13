using JQ.OA.Common;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test for spring .net");
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //IUserInfoService lister = (IUserInfoService)ctx.GetObject("UserInfoService");
            //Console.WriteLine(lister.ShowMsg());
            ValidateCode v = new ValidateCode();
            Console.WriteLine(v.CreateValidateCode(4));
            Console.Read();
            
        }
    }
}
