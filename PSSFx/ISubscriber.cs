using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSFx
{
    public interface ISubscriber
    {
        string subscriberName { get; set; }
        void receive(Message message);
    }
}
