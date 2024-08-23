using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Interfaces
{
    public interface IRequester<in TRequest, TReply> where TRequest : class where TReply : class
    {
        Task<TReply> Request(TRequest message, CancellationToken cancellationToken = default);
    }
}
