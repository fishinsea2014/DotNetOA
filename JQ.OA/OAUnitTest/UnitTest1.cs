using System;
using JQ.OA.Bll;
using JQ.QA.Dal;
using JQ.QA.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OAUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private UserInfoDal userInfoDal = new UserInfoDal();
        JQ.OA.IBll.IUserInfoService UserInfoService { get; set; }
        [TestMethod]
        public void TestAdd()
        {

            
            UserInfo user1 = new UserInfo() {
                UserName = "Jason",
                Pwd = "123"
            };

            userInfoDal.Add(user1);
            userInfoDal.SaveChange();
            Assert.AreEqual(true, user1.ID > 0);
        }

        [TestMethod]
        public void TestLoad()
        {
            var users = userInfoDal.LoadEntities(u => true);
            //Console.WriteLine(users.ToString());
            var u1 = users.GetEnumerator();
            int i = 0;
            foreach(var item in users)
            {
                i++;
            }
            Assert.AreEqual(true, i> 0);
        }

        [TestMethod]
        public void TestLoadEntitiesService()
        {
            string userName = "Jason";
            string pwd = "123";
            UserInfo userInfo = UserInfoService.LoadEntities(u => u.UserName == userName && u.Pwd == pwd).FirstOrDefault();
        }
    }
}
