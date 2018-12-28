using JQ.OA.Bll;
using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{
    public class RoleController : Controller
    {
        IRoleService roleService { get; set; }
        IUserInfoService userInfoService { get; set; }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllRoleInfos()
        {
            //Get the page size and page index from front end.
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;

            short delNormal = (short)DelFlagEnum.Normal;

            var rolesList = roleService.LoadPageEntities(pageIndex, pageSize,  out total
                                                         , d => d.DelFlag == delNormal, d => d.ID, true );
            var allUsers = userInfoService.LoadEntities(u => u.DelFlag == delNormal);

            var data = from r in rolesList
                       join u in allUsers on r.SubBy equals u.ID
                       select new { r.RoleName, r.ID, u.UserName, r.SubBy,r.SubTime };
            //Assembe the data into EasyUI table data, like : {total: 10; rows:[]}
            //Sovle the issue of loop dependency caused by navigation properties when serialising the data to Json
            //var data = new
            //{
            //    total = total,
            //    rows = (from u in rolesList
            //            select
            //                new
            //                {
            //                    u.ID,
            //                    u.RoleName,
            //                    u.DelFlag,
            //                    u.SubTime,
            //                    u.SubBy,
            //                }
            //            ).ToList()
            //};

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(Role role)
        {
            short delNormal = (short)DelFlagEnum.Normal;
            //role.SubBy = this.LoginUserInfo.ID; 
            role.SubBy = 0; //Just for the convinient of the coding
            role.SubTime = DateTime.Now;
            role.DelFlag = delNormal;

            roleService.AddEntity(role);

            return Content("ok");
        }

        public ActionResult DeleteRoles ()
        {
            string strIds = Request["strId"];
            string[] listIds = strIds.Split(',');
            List<int> delIds = new List<int>();
            foreach (var id in listIds)
            {
                delIds.Add(Convert.ToInt32(id));
            }
            if (roleService.DeleteIDs(delIds))
            {
                return Content("ok");
            }
            return Content("Failed to delete these roles.");
        }

        public ActionResult GetARole()
        {
            int id = Convert.ToInt32(Request["id"]);
            Role role = roleService.LoadEntities(r => r.ID == id).FirstOrDefault();
            object result;
            if (role != null)
            {
                result = new { serverData = role, msg = "ok" };
            }
            else
            {
                result = new { msg = "Failed to get the role" };
            }

            return Json(result, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult EditRole(Role role)
        {
            role.SubTime = DateTime.Now;
            if (roleService.EditEntity(role))
            {
                return Content("ok");
            }
            
            return Content("Fail to edit the role.");
            
        }


    }
}