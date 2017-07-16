using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace InterpressExam.Service.Wcf
{
    class Program
    {
        static void Main(string[] args)
        {


            var servicesToRun = new ServiceBase[]
            {
                new ListenWcfService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
