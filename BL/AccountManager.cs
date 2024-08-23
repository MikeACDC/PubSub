using PubSub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PubSub.BL
{
    public static class AccountManager
    {
        public static TReply GetDeposit(TRequest request)
        {
            string text = File.ReadAllText(@"../../../Account.json");

            List<BankAccount>? list = JsonSerializer.Deserialize<List<BankAccount>>(text);
            var listItem = list.FirstOrDefault(l => l.AccountID == request.AccountID);

            Task.Delay(2000).Wait();

            if (listItem != null)
            {
                return new TReply { Success = true, ReplyBody = listItem.Deposit.ToString() };
            }
            else
                return new TReply { Success = false, ReplyBody = "Not found" };

        }
    }
}
