using PubSub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class Subscriber : ISubscriber<TMessage>
    {
        public IObservable<TMessage> MessageReceived => throw new NotImplementedException();
    }
}
