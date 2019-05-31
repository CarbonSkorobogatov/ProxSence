[assembly: WebActivator.PreApplicationStartMethod(typeof(ProxSenceWebProj.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ProxSenceWebProj.App_Start.NinjectWebCommon), "Stop")]

namespace ProxSenceWebProj.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using ProxSenceWebProj.ProjectInfrastructure;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(kernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel kernel()
        {
            var CreateKernel = new StandardKernel();
            CreateKernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            CreateKernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(CreateKernel);
            return CreateKernel;
        }

        private static void RegisterServices(IKernel kernel) // Создание шлюза
        {
            DependencyResolver.SetResolver(new ProxSenceWebProj.ProjectInfrastructure.NinjectResolver(kernel));
        }        
    }
}
