﻿using JQ.OA.DALFactory;
using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {

        //public override void SetCurrentDal()
        //{
        //    CurrentDal = this.GetCurrentDbSession.UserInfoDal;
        //}

        /// <summary>
        /// Batch delete users
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            var userInfoList = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => list.Contains(c.ID));
            foreach (var userInfo in userInfoList)
            {
                this.GetCurrentDbSession.UserInfoDal.Delete(userInfo);
            }
            return this.GetCurrentDbSession.SaveChange();
        }

        public IQueryable<UserInfo> LoadSearchEntities(SearchUserParam searchUserParam)
        {
            short delNormal = (short)DelFlagEnum.Normal;
            var temp = GetCurrentDbSession.UserInfoDal.LoadEntities(u => u.DelFlag == delNormal);

            //Fileter by username search criteria
            if (!string.IsNullOrEmpty(searchUserParam.SName))
            {
                temp = temp.Where(u => u.UserName.Contains(searchUserParam.SName));
            }

            //Fileter by email search criteria
            if (!string.IsNullOrEmpty(searchUserParam.SMail))
            {
                temp = temp.Where(u => u.Mail.Contains(searchUserParam.SMail));
            }

            searchUserParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(searchUserParam.PageSize * (searchUserParam.PageIndex - 1))
                                          .Take(searchUserParam.PageSize).AsQueryable();
        }
       
    }

}
