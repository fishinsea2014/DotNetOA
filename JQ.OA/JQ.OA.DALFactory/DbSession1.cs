


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
			
		private IActionInfoDal _ActionInfoDal;
		public IActionInfoDal ActionInfoDal {
			get {
				if (_ActionInfoDal == null)
				{
				_ActionInfoDal = AbstractFactory.CreateActionInfoDal();
					//_ActionInfoDal =new ActionInfoDal();
				}
				return _ActionInfoDal;
			}
		}
			
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
			
		private IR_User_ActionInfoDal _R_User_ActionInfoDal;
		public IR_User_ActionInfoDal R_User_ActionInfoDal {
			get {
				if (_R_User_ActionInfoDal == null)
				{
				_R_User_ActionInfoDal = AbstractFactory.CreateR_User_ActionInfoDal();
					//_R_User_ActionInfoDal =new R_User_ActionInfoDal();
				}
				return _R_User_ActionInfoDal;
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
			
		private IUserInfoMetaDal _UserInfoMetaDal;
		public IUserInfoMetaDal UserInfoMetaDal {
			get {
				if (_UserInfoMetaDal == null)
				{
				_UserInfoMetaDal = AbstractFactory.CreateUserInfoMetaDal();
					//_UserInfoMetaDal =new UserInfoMetaDal();
				}
				return _UserInfoMetaDal;
			}
		}
			
	}
}