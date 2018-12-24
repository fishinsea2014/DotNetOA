using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQ.QA.Model;
using JQ.QA.Model.Params;

namespace JQ.OA.IBll
{
	public partial interface IActionInfoService : IBaseService<ActionInfo>{}


	public partial interface IDepartmentService : IBaseService<Department>{}


	public partial interface IR_User_ActionInfoService : IBaseService<R_User_ActionInfo>{}


	public partial interface IRoleService : IBaseService<Role>{}


    public partial interface DepartmentService : IBaseService<UserInfo>
    {
        bool DeleteEntities(List<int> delIds);
        object LoadSearchEntities(SearchDepParam depParam);
    }


    public partial interface IUserInfoMetaService : IBaseService<UserInfoMeta>{}





}

