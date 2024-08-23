using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Interfaces
{
    public interface IReplier<out TRequest, in TReply> where TRequest : class where TReply : class
    {
        IDisposable SubscribeRequests(Func<TRequest, TReply> handler);
    }
}
