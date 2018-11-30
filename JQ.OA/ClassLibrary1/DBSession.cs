using JQ.QA.IDal;
using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace JQ.OA.DALFactory
{
    /// <summary>
    /// This is a factory for database session layer
    /// The purpose is to encapsulates the database connections. 
    /// It create the instances of data manipulation
    /// and the Bll use the DBSession to use relavent instances of data operation class to query the database,
    /// which decouple the business layer from database access layer
    /// 
    /// </summary>
    public class DBSession
    {
        //JasonExerEntities Db = new JasonExerEntities();

        private IUserInfoDal  DbContext db
        {

        }
    }
}
