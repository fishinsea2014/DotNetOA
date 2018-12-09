using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using JQ.QA.Model.SearchParam;
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

        /// <summary>
        /// Load users' info by searching parameters.
        /// </summary>
        /// <param name="userInSearchfoParam"></param>
        /// <returns></returns>
        public  IQueryable<UserInfo> LoadSearchEntities(UserInfoParam userInSearchfoParam)
        {
            short delFlag = (short)DelFlagEnum.Normal;
            var temp = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => c.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(userInSearchfoParam.UserName))
            {
                temp = temp.Where<UserInfo>(u => u.UName.Contains(userInSearchfoParam.UserName));
            }
            if (!string.IsNullOrEmpty(userInSearchfoParam.Remark))
            {
                temp = temp.Where<UserInfo>(u => u.Remark.Contains(userInSearchfoParam.Remark));
            }

            userInSearchfoParam.TotalCount = temp.Count();
            return temp.OrderBy<UserInfo, int>(u => u.ID)
                .Skip<UserInfo>((userInSearchfoParam.PageIndex - 1) * userInSearchfoParam.PageSize)
                .Take<UserInfo>(userInSearchfoParam.PageSize);
        }
    }

}
