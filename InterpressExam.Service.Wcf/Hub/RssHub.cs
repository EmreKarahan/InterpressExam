using System.Linq;
using InterpressExam.Entity;

namespace InterpressExam.Service.Wcf.Hub
{
    public class RssHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Fetch()
        {
            RssContext context = new RssContext();
            var rss = context.RssItem.ToList();
            Clients.All.addMessage(rss);
        }
    }
}