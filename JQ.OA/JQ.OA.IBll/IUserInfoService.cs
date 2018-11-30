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
    public interface  IUserInfoService : IBaseService<UserInfo>
    {
        
        bool DeleteEntities(List<int> list);
        
        
    }

}
