﻿using PubSub.Interfaces;
using PubSub.Models;


namespace PubSub.BL
{
    public class Requester : IRequester<Request, Reply>
    {
        private readonly PubSubBus _PubSubBus;
        private Dictionary<Guid, TaskCompletionSource<Reply>> _pendingRequests = new Dictionary<Guid, TaskCompletionSource<Reply>>();

        public Requester(PubSubBus PubSubBus)
        {
            _PubSubBus = PubSubBus;

            //Subscribe to reply
            ReplyObserver replyObserver = new ReplyObserver(this, _pendingRequests);
            _PubSubBus.MessageReceived.Subscribe(replyObserver);

        }

        public async Task<Reply> Request(Request message, CancellationToken cancellationToken = default)
        {
            message.RequestID = Guid.NewGuid();
            TaskCompletionSource<Reply> tcs = new TaskCompletionSource<Reply>();

            _pendingRequests.Add(message.RequestID, tcs);

            // Publish request
            await _PubSubBus.Publish(message, cancellationToken);

            return await tcs.Task;
        }

    }
}
