


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
			
		private IFileInfoDal _FileInfoDal;
		public IFileInfoDal FileInfoDal {
			get {
				if (_FileInfoDal == null)
				{
				_FileInfoDal = AbstractFactory.CreateFileInfoDal();
					//_FileInfoDal =new FileInfoDal();
				}
				return _FileInfoDal;
			}
		}
			
		private IMenuInfoDal _MenuInfoDal;
		public IMenuInfoDal MenuInfoDal {
			get {
				if (_MenuInfoDal == null)
				{
				_MenuInfoDal = AbstractFactory.CreateMenuInfoDal();
					//_MenuInfoDal =new MenuInfoDal();
				}
				return _MenuInfoDal;
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
			
		private IWF_InstanceDal _WF_InstanceDal;
		public IWF_InstanceDal WF_InstanceDal {
			get {
				if (_WF_InstanceDal == null)
				{
				_WF_InstanceDal = AbstractFactory.CreateWF_InstanceDal();
					//_WF_InstanceDal =new WF_InstanceDal();
				}
				return _WF_InstanceDal;
			}
		}
			
		private IWF_StepInfoDal _WF_StepInfoDal;
		public IWF_StepInfoDal WF_StepInfoDal {
			get {
				if (_WF_StepInfoDal == null)
				{
				_WF_StepInfoDal = AbstractFactory.CreateWF_StepInfoDal();
					//_WF_StepInfoDal =new WF_StepInfoDal();
				}
				return _WF_StepInfoDal;
			}
		}
			
		private IWF_TempDal _WF_TempDal;
		public IWF_TempDal WF_TempDal {
			get {
				if (_WF_TempDal == null)
				{
				_WF_TempDal = AbstractFactory.CreateWF_TempDal();
					//_WF_TempDal =new WF_TempDal();
				}
				return _WF_TempDal;
			}
		}
			
	}
}