using JQ.QA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JQ.QA.Dal
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContextFactory
    {
        /// <summary>
        /// Make sure the EF context is unique in a thread.
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null){
                dbContext = new JasonExerEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
