using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Common
{
    public class LogHelper
    {
        public static Queue<string> LogTextQueue = new Queue<string>();

        public static void WriteLog(string txt)
        {
            ILog log = log4net.LogManager.GetLogger("log4netlogger");
            log.Error(txt);

            Console.WriteLine(txt);
        }
    }
}
