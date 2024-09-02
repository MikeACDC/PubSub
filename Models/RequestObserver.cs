using PubSub.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class RequestObserver : IObserver<Message>
    {
        private readonly PubSubBus _pubSubBus;
        private readonly Func<Request, Reply> _handler;

        public RequestObserver(PubSubBus pubSubBus, Func<Request, Reply> handler)
        {
            _pubSubBus = pubSubBus;
            _handler = handler;
        }

        public void OnNext(Message message)
        {
            if (message is Request)
            {
                Reply reply = _handler((Request)message);
                reply.RequestID = ((Request)message).RequestID;
                // Publish reply
                _pubSubBus.Publish(reply);
            }
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
    }
}
