using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.IBll
{
    public partial interface IRoleService
    {
        bool DeleteIDs(List<int> ids);
        
    }
}
