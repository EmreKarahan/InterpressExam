using System;
using System.ServiceModel.PeerResolvers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using InterpressExam.Data.Contract;
using InterpressExam.Data.Impl;

namespace InterpressExam.Service.Wcf
{
    public class WindsorBootstrapper
    {
        public static void Register()
        {
            var container = new WindsorContainer();
            container.Register(
                Component
                    .For<IRssItemRepository>()
                    .ImplementedBy<RssItemRepository>()
                    .LifestyleTransient());

            container.Register(
                Component
                    .For<ICustomeRepository>()
                    .ImplementedBy<CustomerRepository>()
                    .LifestyleTransient());

         

            // show contents of container
            foreach (var handler in container.Kernel
                .GetAssignableHandlers(typeof(object)))
            {
                Console.WriteLine("{0} {1}",
                    handler.ComponentModel.Services,
                    handler.ComponentModel.Implementation);
            }
        }
    }
}