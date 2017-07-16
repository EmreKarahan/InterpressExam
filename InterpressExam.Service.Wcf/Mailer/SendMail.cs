using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using InterpressExam.Entity;
using InterpressExam.Service.Wcf.Hub;
using Microsoft.AspNet.SignalR;

namespace InterpressExam.Service.Wcf.Mailer
{
    public class Mailer
    {
        private readonly IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<RssHub>();
        private CancellationTokenSource _cancelToken;
        private readonly BlockingCollection<string> _mailList;
        private readonly RssItem _item;

        public Mailer(BlockingCollection<string> mailList, RssItem item)
        {
            _mailList = mailList;
            _item = item;
        }

        public void StartEmailRun()
        {
            var t = Task.Run(() =>
            {
                try
                {
                    ParallelOptions po = new ParallelOptions();
                    _cancelToken = new CancellationTokenSource();
                    po.CancellationToken = _cancelToken.Token;
                    po.MaxDegreeOfParallelism = Environment.ProcessorCount * 2;
                    try
                    {
                        Parallel.For(0, 100, index =>
                        {
                            SemaphoreSlim maxThread = new SemaphoreSlim(10);
                            for (int i = 0; i < 10; i++)
                            {
                                var email = _mailList.Take();
                                maxThread.Wait(_cancelToken.Token);
                                Task.Factory.StartNew(() =>
                                        {
                                            try
                                            {
                                                MailMessage msg = new MailMessage("gonderen@gmail.com", email)
                                                {
                                                    Subject = _item.Title,
                                                    Body = _item.Description,
                                                    Priority = MailPriority.Normal
                                                };

                                                _context.Clients.All.getMailLog(
                                                    $"Process: {index}, Task:{i}, Email:{email}");

                                                Console.WriteLine($"Process: {index}, Task:{i}, Email:{email}");
                                            }
                                            catch (Exception ex)
                                            {
                                                //Log error
                                            }
                                        }
                                        , TaskCreationOptions.LongRunning)
                                    .ContinueWith((task) => maxThread.Release(), _cancelToken.Token);
                            }
                        });
                    }
                    catch (OperationCanceledException e)
                    {

                    }
                }
                finally
                {

                }
            });

            t.Wait();
        }
    }
}