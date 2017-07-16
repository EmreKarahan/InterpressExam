using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using InterpressExam.Data.Contract;
using InterpressExam.Data.Impl;
using InterpressExam.Infrastructure.IoC;

namespace InterpressExam.Service.Windows.Downloader
{
    public class WindsorBootstrapper
    {
        public static void Register()
        {


            ContainerManager.Container.Register(
                Component
                    .For<IRssItemRepository>()
                    .ImplementedBy<RssItemRepository>()
                    .LifestyleTransient());

            ContainerManager.Container.Register(
                Component
                    .For<ICustomeRepository>()
                    .ImplementedBy<CustomerRepository>()
                    .LifestyleTransient());

         

            // show contents of container
            foreach (var handler in ContainerManager.Container.Kernel
                .GetAssignableHandlers(typeof(object)))
            {
                Console.WriteLine("{0} {1}",
                    handler.ComponentModel.Services,
                    handler.ComponentModel.Implementation);
            }
        }
    }
}