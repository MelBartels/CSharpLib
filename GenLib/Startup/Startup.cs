using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using GenLib.Config;
using GenLib.ExceptionService;
using GenLib.Extensions;
using Ninject;

namespace GenLib.Startup
{
    public class Startup : IDisposable
    {
        public Startup(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IKernel Kernel { get; set; }
        private IDisposable MainFormActivatedDisp { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            MainFormActivatedDisp.Dispose();
        }

        #endregion

        public void StartForm<T>(string cultureInfo, string image, Func<EventArgs> mainFormVisible)
            where T : Form
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Kernel.DoWhenNull(() => Kernel = new StandardKernel(new NinjectSettings {LoadExtensions = true}));
            Kernel.Load<StartupModule<T>>();
            Kernel.Bind<Startup>().ToConstant(this).InSingletonScope();

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureInfo);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cultureInfo);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            Application.ThreadException += FormThreadException;

            Kernel.Get<PreLoadConfig>();
            Kernel.Get<AboutScreen>().ViewModel.SetProperties(image, Color.Black);

            var mainForm = Kernel.Get<T>();
            MainFormActivatedDisp = mainForm.GetVisibleChanged().Subscribe(_ => mainFormVisible());
            Application.Run(mainForm);
        }

        private void FormThreadException(object sender, ThreadExceptionEventArgs t)
        {
            Kernel.Get<IExceptionHandler>().Notify(t.Exception, "An exception has occurred.");
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Kernel.Get<IExceptionHandler>().Notify(e.ExceptionObject as Exception, "An exception has occurred.");
        }
    }
}