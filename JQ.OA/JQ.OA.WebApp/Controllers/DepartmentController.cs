﻿using JQ.OA.Bll;
using JQ.OA.IBll;
using JQ.QA.Model;
using JQ.QA.Model.Enum;
using JQ.QA.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQ.OA.WebApp.Controllers
{

    public class DepartmentController : Controller
    {
        //IBll.DepartmentService departmentService { get; set; }
        IBll.IDepartmentService departmentService = new Bll.DepartmentService();
       
        // GET: Department
        public ActionResult Index()
        {
            var departmentList = departmentService.LoadEntities(u => true);
            ViewData.Model = departmentList;

            return View();
        }

        /// <summary>
        /// Get users according to the search criteria
        /// </summary>
        /// <param name="SName">Searching string of user name</param>
        /// <param name="SMail">Searching string of user user email</param>
        /// <returns></returns>
        public ActionResult GetAllDepartments()
        {
            //Get the page size and page index from front end.
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            short delNormal = (short)DelFlagEnum.Normal;

            SearchDepParam depParam = new SearchDepParam();
            depParam.PageSize = pageSize;
            depParam.PageIndex = pageIndex;
            depParam.SName = Request["name"];
            var pagedData = departmentService.LoadSearchEntities(depParam);

            //Assembe the data into EasyUI table data, like : {total: 10; rows:[]}
            //Sovle the issue of loop dependency caused by navigation properties when serialising the data to Json
            var data = new
            {
                total = depParam.Total,
                rows = (from u in pagedData
                        select
                            new
                            {
                                u.ID,
                                u.DepName,
                                u.DepMasterId,
                                u.DepNo                                
                            }
                        ).ToList()
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Delete users
        public ActionResult DeleteDepartment()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> delIds = new List<int>();
            foreach (var id in strIds)
            {
                delIds.Add(Convert.ToInt32(id));
            }

            if (departmentService.DeleteEntities(delIds))
            {
                return Content("ok");
            }

            return Content("no");

        }
        #endregion

        #region  Retrive a user's info by ID
        public ActionResult GetDepartmentModel()
        {
            int id = int.Parse(Request["id"]);
            Department department = departmentService.LoadEntities(u => u.ID == id).FirstOrDefault();
            if (department != null)
            {
                return Json(new { serverData = department, msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "no" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Update a user's info
        public ActionResult EditDepartment(Department department)
        {
            department.SubTime = DateTime.Now;
            if (departmentService.EditEntity(department))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region Add an user
        public ActionResult Add(Department department)
        {
            department.DelFlag = 0;
            department.SubBy = 1;
            department.SubTime = DateTime.Now;
            //int i = 8;
            //department = new Department()
            //{
            //    UserName = "1Jason" + i,
            //    Pwd = "123" + i,
            //    Phone = "1233" + i,
            //    SubBy = 1,
            //    DelFlag = 0,
            //    SubTime = DateTime.Now,
            //    Remark = "this is remark" + i
            //};

            departmentService.AddEntity(department);
            //if ( departmentService.SaveChanges())
            //{

            //    return Content("ok");
            //}

            //return Content("Fail to add an user.");
            return Content("Ok");
        }
        #endregion

        public ActionResult create()
        {
            return Content("create");
        }
    }
}