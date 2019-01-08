using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Bll
{
    public partial class MenuInfoService: BaseService<JQ.QA.Model.MenuInfo>, IBll.IMenuInfoService
    {
        public bool DeleteEntities(List<int> delIds)
        {


            var menuList = GetCurrentDbSession.MenuInfoDal.LoadEntities(m => delIds.Contains(m.ID));
            foreach (var menu in menuList)
            {
                GetCurrentDbSession.MenuInfoDal.Delete(menu);
            }
            return GetCurrentDbSession.SaveChange();
        }
    }
}
