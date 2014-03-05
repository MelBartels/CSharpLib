using GenLib.Config;
using GenLib.ExceptionService;
using Ninject.Modules;

namespace GenLib.Startup
{
    public class StartupModule<T> : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IExceptionHandler>().To<ExceptionHandlerMessageBox>().InSingletonScope();
            Kernel.Bind<SettingsService>().To<SettingsService>().InSingletonScope();
            Kernel.Bind<ApplicationDataModel>().To<ApplicationDataModel>().InSingletonScope();
            Kernel.Bind<AboutScreen>().To<AboutScreen>().InSingletonScope();
            Kernel.Bind<ViewModel>().To<ViewModel>().WhenInjectedInto<AboutScreen>().InSingletonScope();
            Kernel.Bind<T>().To<T>().InSingletonScope();
        }
    }
}