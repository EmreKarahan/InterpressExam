using System.ServiceProcess;

namespace InterpressExam.Service.Windows.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {

           

#if !DEBUG

            var servicesToRun = new ServiceBase[]
            {
                new DownloadRssService()
            };
            ServiceBase.Run(servicesToRun);
#endif
#if DEBUG
            new DownloadRssService().RegisterJobs();
#endif
        }
    }
}
