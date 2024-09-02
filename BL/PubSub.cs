using PubSub.Interfaces;
using PubSub.Models;

namespace PubSub.BL
{
    public class PubSubBus : IPublisher<Message>, ISubscriber<Message>
    {
        private readonly Dictionary<Guid, IObserver<Message>> _subscribers = new Dictionary<Guid, IObserver<Message>>();

        public Task Publish(Message message, CancellationToken cancellationToken = default)
        {
            foreach (IObserver<Message> subscriber in _subscribers.Values)
            {
                subscriber.OnNext(message);
            }
            return Task.CompletedTask;
        }

        public IObservable<Message> MessageReceived
        {
            get { return new ObservableMessage(this); }
        }

        private class ObservableMessage : IObservable<Message>
        {
            private readonly PubSubBus _pubSubBus;

            public ObservableMessage(PubSubBus pubSubBus)
            {
                _pubSubBus = pubSubBus;
            }

            public IDisposable Subscribe(IObserver<Message> observer)
            {
                Guid subscriberID = Guid.NewGuid();
                _pubSubBus._subscribers.Add(subscriberID, observer);

                return new Unsubscriber(_pubSubBus._subscribers, subscriberID);
            }

        }

        private class Unsubscriber : IDisposable
        {
            private readonly Dictionary<Guid, IObserver<Message>> _subscribers = new Dictionary<Guid, IObserver<Message>>();
            private Guid _subscriberID;

            public Unsubscriber(Dictionary<Guid, IObserver<Message>> subscribers, Guid subscriberID)
            {
                _subscribers = subscribers;
                _subscriberID = subscriberID;
            }

            public void Dispose()
            {
                if (_subscribers != null && _subscribers.Keys.Contains(_subscriberID))
                    _subscribers.Remove(_subscriberID); 
            }
        }

    }
}
