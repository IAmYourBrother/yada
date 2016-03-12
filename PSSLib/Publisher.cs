using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSSFx;

namespace PSSLib
{
    public class Publisher : IPublisher
    {
        public void publish(Message message)
        {
            Service1Client client = new Service1Client();
            client.publish(message.Topic, message.Payload.ToString());
            client.Close(); 
        }
    }
}
