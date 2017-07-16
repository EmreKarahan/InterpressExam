using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using InterpressExam.Data;
using InterpressExam.Entity;
using InterpressExam.Infrastructure.IoC;
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
   
            BlockingCollection <string> mailList = new BlockingCollection<string>();
            context.Customer.Select(s => s.Email).ToList().ForEach(f => mailList.Add(f));

            foreach (RssItem item in rss)
            {
                var mailer = new Mailer.Mailer(mailList, item);
                mailer.StartEmailRun();
            }
            BroadcastToClients(rss);

        }

        private void BroadcastToClients(List<RssItem> rss)
        {
            
            _context.Clients.All.addMessage(rss);
        }
    }
}
