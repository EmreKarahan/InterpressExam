using System;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace InterpressExam.Service.Windows.Downloader
{
    partial class DownloadRssService : ServiceBase
    {
        internal static ServiceHost MyServiceHost = null;
        public DownloadRssService()
        {
            InitializeComponent();
        }

        public void RegisterJobs()
        {
            try
            {
                new Thread(delegate ()
                {
                    IScheduler scheduler = new StdSchedulerFactory().GetScheduler();

                    JobDetailImpl jobdetailLiveScore = new JobDetailImpl("rssJob", null, typeof(RssParserService));
                    SimpleTriggerImpl triggerLiveScore = new SimpleTriggerImpl(string.Format("{0}Trigger_", "rssJob"), DateTime.Now.AddSeconds(1), null, SimpleTriggerImpl.RepeatIndefinitely, TimeSpan.FromMinutes(1));
                    scheduler.ScheduleJob(jobdetailLiveScore, triggerLiveScore);


                    scheduler.Start();
                    var resetEvent = new ManualResetEvent(false);
                    resetEvent.WaitOne();
                }).Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Newspaper.Service.Windows.ScheduleJobs",
                    $"{ex.Message} - {ex.StackTrace}", System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }


        protected override void OnStart(string[] args)
        {
            RegisterJobs();
        }

        protected override void OnStop()
        {
            if (MyServiceHost == null) return;
            MyServiceHost.Close();
            MyServiceHost = null;
        }
    }
}
