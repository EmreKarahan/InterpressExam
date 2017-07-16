using System;
using System.ServiceProcess;
using InterpressExam.Service.Wcf.Service;
using Microsoft.Owin.Hosting;

namespace InterpressExam.Service.Wcf
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var servicesToRun = new ServiceBase[]
            {
                new ListenWcfService()
            };
            ServiceBase.Run(servicesToRun);
#endif
#if !DEBUG
            new ListenService().FireDatabaseEvents();
#endif


        }
    }
}
