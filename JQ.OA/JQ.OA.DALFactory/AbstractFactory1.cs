


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
	


			
	}
}