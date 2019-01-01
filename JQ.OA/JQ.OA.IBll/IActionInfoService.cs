using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.IBll
{
    public partial interface IActionInfoService : IBaseService<QA.Model.ActionInfo> 
    {
         bool DeleteEntities(List<int> delIds);

    }
}
