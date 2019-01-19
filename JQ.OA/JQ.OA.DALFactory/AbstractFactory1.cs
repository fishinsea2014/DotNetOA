


using System.Linq;
using System.Text;
using JQ.QA.Dal;
using JQ.QA.IDal;

namespace JQ.OA.DALFactory
{
	
	public partial class AbstractFactory
    {

		/// <summary>
        /// Create an Userinfo instance
        /// </summary>
        /// <returns></returns>
			

        public static IActionInfoDal CreateActionInfoDal()
        {
            string fullClassName = NameSpace + ".ActionInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IActionInfoDal;

        }
	


			

        public static IDepartmentDal CreateDepartmentDal()
        {
            string fullClassName = NameSpace + ".DepartmentDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IDepartmentDal;

        }
	


			

        public static IFileInfoDal CreateFileInfoDal()
        {
            string fullClassName = NameSpace + ".FileInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IFileInfoDal;

        }
	


			

        public static IMenuInfoDal CreateMenuInfoDal()
        {
            string fullClassName = NameSpace + ".MenuInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IMenuInfoDal;

        }
	


			

        public static IR_User_ActionInfoDal CreateR_User_ActionInfoDal()
        {
            string fullClassName = NameSpace + ".R_User_ActionInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IR_User_ActionInfoDal;

        }
	


			

        public static IRoleDal CreateRoleDal()
        {
            string fullClassName = NameSpace + ".RoleDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IRoleDal;

        }
	


			

        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IUserInfoDal;

        }
	


			

        public static IUserInfoMetaDal CreateUserInfoMetaDal()
        {
            string fullClassName = NameSpace + ".UserInfoMetaDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IUserInfoMetaDal;

        }
	


			

        public static IWF_InstanceDal CreateWF_InstanceDal()
        {
            string fullClassName = NameSpace + ".WF_InstanceDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IWF_InstanceDal;

        }
	


			

        public static IWF_StepInfoDal CreateWF_StepInfoDal()
        {
            string fullClassName = NameSpace + ".WF_StepInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IWF_StepInfoDal;

        }
	


			

        public static IWF_TempDal CreateWF_TempDal()
        {
            string fullClassName = NameSpace + ".WF_TempDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IWF_TempDal;

        }
	


			
	}
}