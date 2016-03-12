using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSSFx;
using System.Timers;

namespace PSSLib
{
    public class Messenger : IMessenger
    {
        ISubscriber subscriber;
        string topic;
        public void subscribe(string topic, ISubscriber subscriber)
        {
            this.topic = topic;
            this.subscriber = subscriber;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            Service1Client client = new Service1Client();
            client.subscribe(topic, subscriber.subscriberName);
            client.Close();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Service1Client client = new Service1Client();
            string[] publications = client.GetPublications(topic, subscriber.subscriberName);
            client.Close();
            foreach (string publication in publications) 
            {
                Message message = new Message();
                message.Payload = publication;
                subscriber.receive(message);
            }
        }
    }
}
