using JQ.QA.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace JQ.OA.WebApp.Controllers
{
    public class FileManagementController : ApiController
    {
        // GET: api/FileManagement
        IBll.IUserInfoService userInfoService { get; set; }
        
        public IEnumerable<string> Get()
        {
            UserInfo user = userInfoService.LoadEntities(u => u.ID > 30).FirstOrDefault();
            return new string[] { user.UserName, user.Mail, user.Phone };
            //return new string[] { JsonConvert.SerializeObject(user) };
            
        }

        // GET: api/FileManagement/5
        
        public string Get(int id)
        {
            UserInfo user = userInfoService.LoadEntities(u => u.ID > 30).FirstOrDefault();

            return user.ToString();
        }

        // POST: api/FileManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FileManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FileManagement/5
        public void Delete(int id)
        {
        }
    }
}
