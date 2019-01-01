using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.IBll
{
    /// <summary>
    /// Specific methods for UserInfo
    /// </summary>
    public partial interface  IUserInfoService : IBaseService<UserInfo>
    {
        
        bool DeleteEntities(List<int> list);
        IQueryable<UserInfo> LoadSearchEntities(SearchUserParam param);
        bool SetUserRole(int userId, List<int> roleIds);

    }

}
