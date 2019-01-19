


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
		
				IFileInfoDal FileInfoDal { get; }
		
				IMenuInfoDal MenuInfoDal { get; }
		
				IR_User_ActionInfoDal R_User_ActionInfoDal { get; }
		
				IRoleDal RoleDal { get; }
		
				IUserInfoDal UserInfoDal { get; }
		
				IUserInfoMetaDal UserInfoMetaDal { get; }
		
				IWF_InstanceDal WF_InstanceDal { get; }
		
				IWF_StepInfoDal WF_StepInfoDal { get; }
		
				IWF_TempDal WF_TempDal { get; }
	}	
}