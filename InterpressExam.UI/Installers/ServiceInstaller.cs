using Castle.MicroKernel.Registration;
using InterpressExam.Data.Contract;
using InterpressExam.Data.Impl;

namespace InterpressExam.UI.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                 Component
                 .For<IRssItemRepository>()
                 .ImplementedBy<RssItemRepository>()
                 .LifestyleTransient());
        }
    }
}