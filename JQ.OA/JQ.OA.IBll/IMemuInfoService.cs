using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.IBll
{
    public partial interface IMenuInfoService : IBaseService<QA.Model.MenuInfo>
    {
        bool DeleteEntities(List<int> delIds);
    }
}
