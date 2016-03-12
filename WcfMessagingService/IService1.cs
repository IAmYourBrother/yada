using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMessagingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        bool subscribe(string topic, string recipientName);
        [OperationContract]
        bool publish(string topic, string payload);
        [OperationContract]
        List<string> GetPublications(string topic, string subscriber);
    }

  
}
