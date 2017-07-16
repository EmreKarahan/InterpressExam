using System.ServiceModel;
using System.ServiceProcess;
using InterpressExam.Service.Wcf.Service;
using Microsoft.Owin.Hosting;

namespace InterpressExam.Service.Wcf
{
    partial class ListenWcfService : ServiceBase
    {
        internal static ServiceHost MyServiceHost = null; 
        public ListenWcfService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyServiceHost?.Close();

            MyServiceHost = new ServiceHost(typeof(ListenService));

            //string url = "http://localhost:1454";
            //WebApp.Start(url);
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
