using System.ServiceProcess;

namespace InterpressExam.Service.Windows.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicesToRun = new ServiceBase[]
            {
                new DownloadRssService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
