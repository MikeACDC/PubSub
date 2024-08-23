using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub.Models
{
    public class Terminal
    {
        public async void SendRequest(TRequest request)
        {
            Requester requester = new Requester();

            TReply replyTask = await requester.Request(request);

            Console.WriteLine("Status:" + replyTask.Success +", Deposit:" + replyTask.ReplyBody);

        }
    }
}
