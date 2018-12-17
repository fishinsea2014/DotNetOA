




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQ.OA.IBll;
using JQ.QA.Model;

namespace JQ.OA.Bll
{
	//public partial interface IDepartmentService : IBaseService<Department>{}

	public partial class DepartmentService : BaseService<Department>, IDepartmentService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.DepartmentDal;
        }
	}


	//public partial interface IRoleService : IBaseService<Role>{}

	public partial class RoleService : BaseService<Role>, IRoleService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.RoleDal;
        }
	}


	//public partial interface IUserInfoService : IBaseService<UserInfo>{}

	public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserInfoDal;
        }
	}





}