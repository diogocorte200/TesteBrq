using CommonServiceLocator;
using System.Web.Http;
using TesteApplication;
using TesteApplication.Interface;
using TesteData.Repositories;
using TesteDomain.Interfaces.Repositories;
using TesteDomain.Interfaces.Services;
using TesteDomain.Services;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace TesteApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // Application 
            container.RegisterType<IOperacaoAppService, OperacaoAppService>();

            // Domain
            container.RegisterType<IOperacaoServices, OperacaoService>();

            // Repository
            container.RegisterType<IOperacoesRepository, OperacaoRepository>();

            // Bases
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>))
            .RegisterType(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));

            //var unityServiceLocator = new UnityServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}