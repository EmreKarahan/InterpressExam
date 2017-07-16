using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace InterpressExam.UI
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        ContainerBootstrapper(IWindsorContainer container)
        {
            this.Container = container;
        }

        public IWindsorContainer Container { get; }

        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().
                Install(FromAssembly.This());
            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}