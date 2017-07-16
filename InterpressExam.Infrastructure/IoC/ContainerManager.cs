using Castle.Windsor;

namespace InterpressExam.Infrastructure.IoC
{
    public static class ContainerManager
    {
        public static IWindsorContainer Container = new WindsorContainer();
    }
}