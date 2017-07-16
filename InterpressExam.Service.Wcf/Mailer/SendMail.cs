using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace InterpressExam.Service.Wcf.Mailer
{
    public class Mailer
    {

        private const int _clientcount = 1000;
        private readonly SmtpClient[] _smtpClients = new SmtpClient[_clientcount + 1];
        private CancellationTokenSource _cancelToken;
        private readonly BlockingCollection<string> _mailList;


        public Mailer()
        {
            _mailList = new BlockingCollection<string>();
            for (var i = 0; i < 1000; i++)
            {
                _mailList.Add("sampleEmail" + 1 + "@gmail.com");
            }

            SetupSmtpClients();
        }

        public void StartEmailRun(List<object> data)
        {
            try
            {
                ParallelOptions po = new ParallelOptions();
                //Create a cancellation token so you can cancel the task.
                _cancelToken = new CancellationTokenSource();
                po.CancellationToken = _cancelToken.Token;
                //Manage the MaxDegreeOfParallelism instead of .NET Managing this. We dont need 500 threads spawning for this.
                po.MaxDegreeOfParallelism = System.Environment.ProcessorCount * 2;
                try
                {
                    Parallel.For(0, 100, index =>
                    {
                        var aaa = _mailList.Take();

                        try
                        {
                            MailMessage msg = new MailMessage("gonderen@gmail.com", aaa);
                            msg.Subject ="Subject";
                            msg.Body = "Body";
                            msg.Priority = MailPriority.Normal;
                            //SendEmail(msg);
                        }
                        catch (Exception ex)
                        {
                            //Log error
                        }
                    });

             
                }
                catch (OperationCanceledException e)
                {
                    //User has cancelled this request.
                }
            }
            finally
            {
                disposeSMTPClients();
            }
        }

        public void CancelEmailRun()
        {
            _cancelToken.Cancel();
        }

        private void SendEmail(MailMessage msg)
        {
            try
            {
                bool _gotlocked = false;
                while (!_gotlocked)
                {
                    //Keep looping through all smtp client connections until one becomes available
                    for (int i = 0; i <= _clientcount; i++)
                    {
                        if (System.Threading.Monitor.TryEnter(_smtpClients[i]))
                        {
                            try
                            {
                                _smtpClients[i].Send(msg);
                            }
                            finally
                            {
                                Monitor.Exit(_smtpClients[i]);
                            }
                            _gotlocked = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    //Do this to make sure CPU doesn't ramp up to 100%
                    System.Threading.Thread.Sleep(1);
                }
            }
            finally
            {
                msg.Dispose();
            }
        }

        private void SetupSmtpClients()
        {
            for (int i = 0; i <= _clientcount; i++)
            {
                try
                {
                    SmtpClient _client = new SmtpClient("127.0.0.1", 25);
                    //If your SMTP server requires authentication do the following below
                    _client.Credentials = new System.Net.NetworkCredential("yourusername", "yourpassword", "yourdomain");
                    _smtpClients[i] = _client;
                }
                catch (Exception ex)
                {
                    //Log Exception
                }
            }
        }

        private void disposeSMTPClients()
        {
            for (int i = 0; i <= _clientcount; i++)
            {
                try
                {
                    _smtpClients[i].Dispose();
                }
                catch (Exception ex)
                {
                    //Log Exception
                }
            }
        }
    }
}