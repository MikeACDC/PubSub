using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Interfaces
{
    public interface IPublisher<in TMessage> where TMessage : class
    {
        Task Publish(TMessage message, CancellationToken cancellationToken = default);
    }
}
