using PubSub.BO;
using PubSub.Models;
using System.Text.Json;

namespace PubSub.BL
{
    public static class AccountManager
    {
        public static Reply GetDeposit(Request request)
        {
            try
            {
                string accounts = File.ReadAllText(@"../../../Account.json");

                TerminalRequest terminalRequest = JsonSerializer.Deserialize<TerminalRequest>(request.Content);

                List<BankAccount>? accountsList = JsonSerializer.Deserialize<List<BankAccount>>(accounts);
                var account = accountsList.FirstOrDefault(l => l.AccountID == terminalRequest.AccountID);

                Task.Delay(2000).Wait();

                if (account != null)
                {
                    return new Reply { Success = true, Content = account.Deposit.ToString() };
                }
                else
                    return new Reply { Success = false, Content = "Not found" };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
