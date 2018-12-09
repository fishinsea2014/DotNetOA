using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNet
{
    public class UserInfoservice : IUserInfoService
    {
        public string UserName { get; set; }
        public Person Person { get; set; }

        public string ShowMsg()
        {
            return "Hello : " + UserName + " and the age is : " + Person.Age;
        }
    }
}
