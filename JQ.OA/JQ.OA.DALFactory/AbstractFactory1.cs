


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
			

        public static IDepartmentDal CreateDepartmentDal()
        {
            string fullClassName = NameSpace + ".DepartmentDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IDepartmentDal;

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
	


			
	}
}