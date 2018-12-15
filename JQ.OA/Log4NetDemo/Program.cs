using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            log4net.Config.XmlConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger("hello");
            log.Debug("shitle");
            log.Fatal("50 ...");
            int a = 4, b = 0;
            int c = a / b;

        }
    }
}
