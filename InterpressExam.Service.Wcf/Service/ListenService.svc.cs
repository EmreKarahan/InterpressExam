using System.Collections.Generic;
using System.Linq;
using InterpressExam.Data;
using InterpressExam.Entity;
using InterpressExam.Service.Wcf.Hub;
using Microsoft.AspNet.SignalR;

namespace InterpressExam.Service.Wcf.Service
{
    public class ListenService : IListenService
    {
        private readonly IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<RssHub>();

        public void FireDatabaseEvents()
        {
            RssContext context = new RssContext();
            var rss = context.RssItem.ToList();

            BroadcastToClients(rss);
            Mailer.Mailer mailer = new Mailer.Mailer();

        }

        private void BroadcastToClients(List<RssItem> rss)
        {
            
            _context.Clients.All.addMessage(rss);
        }
    }
}
