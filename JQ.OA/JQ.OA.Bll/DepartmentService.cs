using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using JQ.QA.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public partial class DepartmentService:BaseService<Department>, IDepartmentService
    {
        public bool DeleteEntities(List<int> list)
        {
            var departmentList = this.GetCurrentDbSession.DepartmentDal.LoadEntities(c => list.Contains(c.ID));
            foreach (var department in departmentList)
            {
                this.GetCurrentDbSession.DepartmentDal.Delete(department);
            }
            return this.GetCurrentDbSession.SaveChange();
        }

        public IQueryable<Department> LoadSearchEntities(SearchDepParam searchDepParam)
        {
            short delNormal = (short)DelFlagEnum.Normal;
            var temp = GetCurrentDbSession.DepartmentDal.LoadEntities(u => u.DelFlag == delNormal);

            //Fileter by username search criteria
            if (!string.IsNullOrEmpty(searchDepParam.SName))
            {
                temp = temp.Where(u => u.DepName.Contains(searchDepParam.SName));
            }


            searchDepParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(searchDepParam.PageSize * (searchDepParam.PageIndex - 1))
                                          .Take(searchDepParam.PageSize).AsQueryable();
        }
    }
}
