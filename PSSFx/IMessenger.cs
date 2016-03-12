using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSFx
{
    public interface IMessenger
    {
        void subscribe(string topic, ISubscriber subscriber);
    }
}
