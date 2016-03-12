using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMessagingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        static Dictionary<string, Dictionary<string, List<string>>> subscriptions = new Dictionary<string, Dictionary<string, List<string>>>();
       
        public List<string> GetPublications(string topic, string subscriber)
        {
            List<string> publications = new List<string>();
            foreach (string publication in subscriptions[topic][subscriber])
            {
                publications.Add(publication);
            }
            subscriptions[topic][subscriber].Clear();
            return publications;
        }

        public bool publish(string topic, string payload)
        {
            foreach (string subscriber in subscriptions[topic].Keys)
            {
                subscriptions[topic][subscriber].Add(payload);
            }
            return true;
        }

        public bool subscribe(string topic, string recipientName)
        {
            if (!subscriptions.ContainsKey(topic))
            {
                subscriptions.Add(topic, new Dictionary<string, List<string>>());
            }
            if (!subscriptions[topic].ContainsKey(recipientName))
            {
                subscriptions[topic].Add(recipientName, new List<string>());
            }
            return true;
        }
    }
}
