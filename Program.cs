using PubSub.BL;
using PubSub.Models;

namespace PubSub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                PubSubBus bus = new PubSubBus();
                Requester requester = new Requester(bus);
                   
                int accountID = 300;
                Request request = new Request() { Content = "{\"AccountID\" : " + accountID + "}" };

                Console.WriteLine("Terminal says - Get me deposit of account: " + accountID);

                Func<Request, Reply> getDepositHandler = (h) => 
                {
                    return AccountManager.GetDeposit(request);
                };

                Replier replier = new Replier(bus, getDepositHandler);
                Reply reply = await requester.Request(request);

                Console.WriteLine("Bank says - Status:" + reply.Success + ", Deposit:" + reply.Content);
            }
            catch (Exception)
            {
                Console.WriteLine("Oops");
            }
            
        }


    }

     
}




