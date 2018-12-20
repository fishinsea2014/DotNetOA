


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Here is QA, not OA
namespace JQ.QA.IDal
{
	public partial  interface  IDbSession
    {  
				
				IActionInfoDal ActionInfoDal { get; }
		
				IDepartmentDal DepartmentDal { get; }
		
				IR_User_ActionDal R_User_ActionDal { get; }
		
				IRoleDal RoleDal { get; }
		
				IUserInfoDal UserInfoDal { get; }
		
				IUserInfoMetaDal UserInfoMetaDal { get; }
	}	
}