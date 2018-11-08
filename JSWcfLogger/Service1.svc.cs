using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NLog;

namespace JSWcfLogger
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LogService : ILogService
    {
        public void PostLog(string appname, string logLevel, string value)
        {
            LogManager.Instance.HandleLog(appname,MapLogLevel(logLevel),value);
            throw new NotImplementedException();
        }

        private LogLevel MapLogLevel(string logLevel)
        {
            return (LogLevel) Enum.Parse(typeof(LogLevel), logLevel);
        }
    }
}
