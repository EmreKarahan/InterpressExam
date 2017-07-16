namespace InterpressExam.Service.Wcf.Hub
{
    public class RssHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}