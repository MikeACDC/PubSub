using PubSub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class Requester : IRequester<TRequest, TReply>
    {
        public Task<TReply> Request(TRequest message, CancellationToken cancellationToken = default)
        {
            BankReplier replier = new BankReplier();
            TReply reply = replier.ProcessRequest(message);

            return Task.FromResult(reply);
            
        }
    }
}
