using System.ServiceModel;
using System.ServiceProcess;

namespace InterpressExam.Service.Windows.Downloader
{
    partial class DownloadRssService : ServiceBase
    {
        internal static ServiceHost MyServiceHost = null; 
        public DownloadRssService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyServiceHost?.Close();

            MyServiceHost = new ServiceHost(typeof(RssParser));
            MyServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (MyServiceHost == null) return;
            MyServiceHost.Close();
            MyServiceHost = null;
        }
    }
}
