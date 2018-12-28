using JQ.OA.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public partial class RoleService : BaseService<QA.Model.Role>, IRoleService
    {
        public bool DeleteIDs(List<int> ids)
        {
            var roleList = this.GetCurrentDbSession.RoleDal.LoadEntities(r => ids.Contains(r.ID));
            foreach (QA.Model.Role role in roleList)
            {
                this.GetCurrentDbSession.RoleDal.Delete(role);
            }
            return GetCurrentDbSession.SaveChange();
        }
    }
}
