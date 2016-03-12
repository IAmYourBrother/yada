using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSSFx;
namespace ConsoleApplication1
{
    class Program : ISubscriber
    {
        static void Main(string[] args)
        {

        }
    }
    class Subscriber : ISubscriber
    {

        public string subscriberName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void receive(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
