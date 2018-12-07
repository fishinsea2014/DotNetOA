using JQ.OA.IBll;
using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserInfoDal;
        }

        /// <summary>
        /// Batch delete users
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            var userInfoList1 = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => true);
            Console.WriteLine(userInfoList1.Count());
            var userInfoList = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => list.Contains(c.ID));
            Console.WriteLine(userInfoList.Count());
            foreach (var userInfo in userInfoList)
            {
                this.GetCurrentDbSession.UserInfoDal.DeleteEntity(userInfo);
            }
            return this.GetCurrentDbSession.SaveChange();
        }
       
    }

}
