



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQ.QA.Model;

namespace JQ.QA.IDal
{

	
	public partial interface IDepartmentDal :IBaseDal<Department>
    { 
	}	
	
	public partial interface IRoleDal :IBaseDal<Role>
    { 
	}	
	
	public partial interface IUserInfoDal :IBaseDal<UserInfo>
    { 
	}	

}