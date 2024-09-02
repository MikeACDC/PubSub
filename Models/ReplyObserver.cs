using PubSub.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class ReplyObserver : IObserver<Message>
    {
        private readonly Requester _requester;
        Dictionary<Guid, TaskCompletionSource<Reply>> _pendingRequests;

        public ReplyObserver(Requester requester, Dictionary<Guid, TaskCompletionSource<Reply>> pendingRequests)
        {
            _requester = requester;
            _pendingRequests = pendingRequests;
        }

        public void OnNext(Message message)
        {
            if (message is Reply)
            {
                if (_pendingRequests.Remove(((Reply)message).RequestID, out TaskCompletionSource<Reply> tcs))
                {
                    ((Reply)message).Success = true;
                    tcs.SetResult((Reply)message);
                }
            }
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
    }
}
