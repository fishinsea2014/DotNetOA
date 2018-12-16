


using System.Linq;
using System.Text;
using JQ.QA.Dal;
using JQ.QA.IDal;

namespace JQ.OA.DALFactory
{
	/// <summary>
    /// DbSession:This is a simple factory, which is the unified entry for entire DAL
    /// </summary>
	 public partial class DBSession :IDbSession
    {  
			
		private IDepartmentDal _DepartmentDal;
		public IDepartmentDal DepartmentDal {
			get {
				if (_DepartmentDal == null)
				{
				_DepartmentDal = AbstractFactory.CreateDepartmentDal();
					//_DepartmentDal =new DepartmentDal();
				}
				return _DepartmentDal;
			}
		}
			
		private IRoleDal _RoleDal;
		public IRoleDal RoleDal {
			get {
				if (_RoleDal == null)
				{
				_RoleDal = AbstractFactory.CreateRoleDal();
					//_RoleDal =new RoleDal();
				}
				return _RoleDal;
			}
		}
			
		private IUserInfoDal _UserInfoDal;
		public IUserInfoDal UserInfoDal {
			get {
				if (_UserInfoDal == null)
				{
				_UserInfoDal = AbstractFactory.CreateUserInfoDal();
                    //_UserInfoDal =new UserInfoDal();
                }
				return _UserInfoDal;
			}
		}
			
	}
}