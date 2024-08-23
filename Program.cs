

using PubSub.Models;

Terminal terminal = new Terminal();

TRequest request = new TRequest()
{
    AccountID = 200,
    RequestBody = "Get me deposit of account"
};


Console.WriteLine(request.RequestBody + ": " + request.AccountID);

terminal.SendRequest(request);



