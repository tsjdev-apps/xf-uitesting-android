using CommonServiceLocator;
using MyAwesomeApp.Services;
using MyAwesomeApp.ViewModels;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace MyAwesomeApp.Init
{
    public static class Bootstrapper
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();


            // services
            container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());

            // viewmodels
            container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager());

            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
