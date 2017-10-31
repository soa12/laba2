using System.Web.Mvc;
using DomainModel;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace WebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            //var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //UnityContainer c = new UnityContainer();
            //c.RegisterType<IPhoneBookRepository, PostgreSQLRepository.PostgreSQLRepository>(new InjectionConstructor("PostgreSQL"));
            //IPhoneBookRepository n = c.Resolve<IPhoneBookRepository>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(c));


            UnityContainer container = new UnityContainer();
            container.LoadConfiguration();
            
            
            
            
            
            
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //UnityConfigurationSection s = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //s.Configure(c);
            //IPaymentProvider n = c.Resolve<IPaymentProvider>();

        }
    }
}