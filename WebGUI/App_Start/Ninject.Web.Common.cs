[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebGUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebGUI.App_Start.NinjectWebCommon), "Stop")]

namespace WebGUI.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using WebGUI.Repository;
    using WebGUI.Repository.Concreate;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel Kernel)
        {
            Kernel.Bind<IMailConfirmation>().To<MailConfirmation>();
            Kernel.Bind<IProductRepository>().To<ProductRepository>();
            Kernel.Bind<IImageRepository>().To<ImageRepository>();
            Kernel.Bind<IOrderRepository>().To<OrderRepository>();
            Kernel.Bind<IContactRepository>().To<ContactRepository>();
        }
    }
}