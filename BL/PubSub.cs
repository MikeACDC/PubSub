using PubSub.Interfaces;
using PubSub.Models;
using System.Collections.Concurrent;

namespace PubSub.BL
{
    public class PubSubBus : IPublisher<Message>, ISubscriber<Message>
    {
        private readonly ConcurrentDictionary<Guid, IObserver<Message>> _subscribers = new ConcurrentDictionary<Guid, IObserver<Message>>();

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
                _pubSubBus._subscribers.TryAdd(subscriberID, observer);

                return new Unsubscriber(_pubSubBus._subscribers, subscriberID);
            }

        }

        private class Unsubscriber : IDisposable
        {
            private readonly ConcurrentDictionary<Guid, IObserver<Message>> _subscribers = new ConcurrentDictionary<Guid, IObserver<Message>>();
            private Guid _subscriberID;

            public Unsubscriber(ConcurrentDictionary<Guid, IObserver<Message>> subscribers, Guid subscriberID)
            {
                _subscribers = subscribers;
                _subscriberID = subscriberID;
            }

            public void Dispose()
            {
                if (_subscribers != null && _subscribers.Keys.Contains(_subscriberID))
                    _subscribers.TryRemove(_subscriberID, out _); 
            }
        }

    }
}
