using PubSub.Interfaces;
using PubSub.Models;


namespace PubSub.BL
{
    public class Replier : IReplier<Request, Reply>
    {
        private readonly PubSubBus _pubSubBus;

        public Replier(PubSubBus PubSubBus, Func<Request, Reply> handler)
        {
            _pubSubBus = PubSubBus;
            // Subscribe to request
            SubscribeRequests(handler);
        }
        public IDisposable SubscribeRequests(Func<Request, Reply> handler)
        {
            RequestObserver requestObserver = new RequestObserver(_pubSubBus, handler);
            return _pubSubBus.MessageReceived.Subscribe(requestObserver);

        }
    }
}
