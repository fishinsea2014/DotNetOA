using JQ.QA.Model;
using JQ.QA.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.IBll
{
    public partial interface IDepartmentService:IBaseService<Department>
    {
        bool DeleteEntities(List<int> list);
        IQueryable<Department> LoadSearchEntities(SearchDepParam departmentParam);
    }
}
