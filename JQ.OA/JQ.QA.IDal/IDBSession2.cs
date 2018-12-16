


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Here is QA, not OA
namespace JQ.QA.IDal
{
	public partial  interface  IDbSession
    {  
				
				IDepartmentDal DepartmentDal { get; }
		
				IRoleDal RoleDal { get; }
		
				IUserInfoDal UserInfoDal { get; }
	}	
}