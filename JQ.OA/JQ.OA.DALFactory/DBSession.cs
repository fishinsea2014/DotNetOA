using JQ.QA.Dal;
using JQ.QA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JQ.QA.Model;
using System.Data.Entity;

namespace JQ.OA.DALFactory
{
    /// <summary>
    /// Create data access instance
    /// The Bll 
    /// </summary>
    public partial class DBSession : IDbSession
    {
        //JasonExerEntities Db = new JasonExerEntities();
        public DbContext Db
        {
            get { return DbContextFactory.CreateDbContext(); }
        }
        //private IUserInfoDal _UserInfoDal;
        ////DbContext
        //public IUserInfoDal UserInfoDal
        //{
        //    get
        //    {
        //        if (_UserInfoDal == null)
        //        {
        //            //_UserInfoDal = new UserInfoDal();                    
        //            _UserInfoDal = AbstractFactory.CreateUserInfoDal();

        //        }
        //        return _UserInfoDal;
        //    }

        //    set { _UserInfoDal = value;  }
        //}

        /// <summary>
        /// When handle multiple table in one action, then:
        /// 1. Tag the data in DAL
        /// 2. Call this method to access the database, avoiding unncessarily access database 
        /// </summary>
        /// <returns></returns>
        public bool SaveChange()
        {
            return Db.SaveChanges() > 0 ;
            //return true;
        }
    }
}
