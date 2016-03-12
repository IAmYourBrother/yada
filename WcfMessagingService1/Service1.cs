using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfMessagingService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
       

        static Dictionary<string, Dictionary<string, List<string>>> subscriptions = new Dictionary<string, Dictionary<string, List<string>>>();
        Mutex mutex = new Mutex(false, "subscriptionMutex");

        public List<string> GetPublications(string topic, string subscriber)
        {
            mutex.WaitOne();
            List<string> publications = new List<string>();
            foreach (string publication in subscriptions[topic][subscriber])
            {
                publications.Add(publication);
            }
            subscriptions[topic][subscriber].Clear();
            mutex.ReleaseMutex();

            return publications;
        }

        public bool publish(string topic, string payload)
        {
            mutex.WaitOne();
            foreach (string subscriber in subscriptions[topic].Keys)
            {
                subscriptions[topic][subscriber].Add(payload);
            }
            mutex.ReleaseMutex();

            return true;
        }

        public bool subscribe(string topic, string recipientName)
        {
            mutex.WaitOne();
            if (!subscriptions.ContainsKey(topic))
            {
                subscriptions.Add(topic, new Dictionary<string, List<string>>());
            }
            if (!subscriptions[topic].ContainsKey(recipientName))
            {
                subscriptions[topic].Add(recipientName, new List<string>());
            }
            mutex.ReleaseMutex();

            return true;
        }
    }
}
