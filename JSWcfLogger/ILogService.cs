using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JSWcfLogger
{
    [ServiceContract]
    public interface ILogService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "postlog/new")]
        void PostLog(string appname, string logLevel, string value);
    }
}
