using PubSub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Numerics;
using PubSub.BL;

namespace PubSub.Models
{
    public class BankReplier : IReplier<TRequest, TReply>
    {
        public IDisposable SubscribeRequests(Func<TRequest, TReply> handler)
        {
            throw new NotImplementedException();
        }

        public TReply ProcessRequest(TRequest request)
        {
            return AccountManager.GetDeposit(request);

        }

    }
}
