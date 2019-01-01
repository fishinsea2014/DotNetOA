using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public partial class ActionInfoService: BaseService<QA.Model.ActionInfo>, IBll.IActionInfoService
    {
        public bool DeleteEntities(List<int> delIds)
        {
            var actionInfoList = this.GetCurrentDbSession.ActionInfoDal.LoadEntities(item => delIds.Contains(item.ID));
            foreach (var item in actionInfoList)
            {
                this.GetCurrentDbSession.ActionInfoDal.Delete(item);                
            }
            return this.GetCurrentDbSession.SaveChange();
        }
    }
}
