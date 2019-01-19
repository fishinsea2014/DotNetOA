



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQ.QA.Model;

namespace JQ.QA.IDal
{

	
	public partial interface IActionInfoDal :IBaseDal<ActionInfo>
    { 
	}	
	
	public partial interface IDepartmentDal :IBaseDal<Department>
    { 
	}	
	
	public partial interface IFileInfoDal :IBaseDal<FileInfo>
    { 
	}	
	
	public partial interface IMenuInfoDal :IBaseDal<MenuInfo>
    { 
	}	
	
	public partial interface IR_User_ActionInfoDal :IBaseDal<R_User_ActionInfo>
    { 
	}	
	
	public partial interface IRoleDal :IBaseDal<Role>
    { 
	}	
	
	public partial interface IUserInfoDal :IBaseDal<UserInfo>
    { 
	}	
	
	public partial interface IUserInfoMetaDal :IBaseDal<UserInfoMeta>
    { 
	}	
	
	public partial interface IWF_InstanceDal :IBaseDal<WF_Instance>
    { 
	}	
	
	public partial interface IWF_StepInfoDal :IBaseDal<WF_StepInfo>
    { 
	}	
	
	public partial interface IWF_TempDal :IBaseDal<WF_Temp>
    { 
	}	

}