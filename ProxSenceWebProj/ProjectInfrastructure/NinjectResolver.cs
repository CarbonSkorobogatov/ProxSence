using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc; // IDependencyResolver
using ProxSence.Library.InterfacesLibrary;
using ProxSence.Library.EFBase;
using System.Configuration;

namespace ProxSenceWebProj.ProjectInfrastructure
{
    public class NinjectResolver : IDependencyResolver  // System.Web.Mvc
    {
        private IKernel kernel;  //Ядро

        public NinjectResolver(IKernel CreateKernelParameters) // Параметры ядра
        {
            kernel = CreateKernelParameters;
            AddBindings();
        }
        public object GetService(Type serviceType) // Тип сервиса
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()  // Добавляем привязки
        {
            kernel.Bind<IPortfolioAdding>().To<EFPortfolioList>();
            kernel.Bind<IAutorization>().To<AutorizationForms>();
            MailSettings mailSettings = new MailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Mail.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IMailSender>().To<MailContactForm>().WithConstructorArgument("settings", mailSettings);

        }

       
        
        
    }
}