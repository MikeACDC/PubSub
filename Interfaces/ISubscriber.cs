using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Interfaces
{
    public interface ISubscriber<out TMessage> where TMessage : class
    {
        IObservable<TMessage> MessageReceived { get; }
    }
}
