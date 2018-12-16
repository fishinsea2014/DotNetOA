using JQ.QA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDbSession CreateDbSession()
        {
            IDbSession dbSession = (IDbSession)CallContext.GetData("dbSession");
            if (dbSession == null)
            {
                dbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}
