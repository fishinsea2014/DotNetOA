




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQ.QA.Model;
using JQ.OA.IBll;

namespace JQ.OA.Bll
{
	//public partial interface IActionInfoService : IBaseService<ActionInfo>{}

	public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.ActionInfoDal;
        }
	}


	//public partial interface IDepartmentService : IBaseService<Department>{}

	public partial class DepartmentService : BaseService<Department>, IDepartmentService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.DepartmentDal;
        }
	}


	//public partial interface IMenuInfoService : IBaseService<MenuInfo>{}

	public partial class MenuInfoService : BaseService<MenuInfo>, IMenuInfoService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.MenuInfoDal;
        }
	}


	//public partial interface IR_User_ActionInfoService : IBaseService<R_User_ActionInfo>{}

	public partial class R_User_ActionInfoService : BaseService<R_User_ActionInfo>, IR_User_ActionInfoService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.R_User_ActionInfoDal;
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


	//public partial interface IUserInfoMetaService : IBaseService<UserInfoMeta>{}

	public partial class UserInfoMetaService : BaseService<UserInfoMeta>, IUserInfoMetaService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserInfoMetaDal;
        }
	}





}