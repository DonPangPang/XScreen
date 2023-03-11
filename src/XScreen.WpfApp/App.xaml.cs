using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.Versioning;
using System.Windows;
using XScreen.WpfApp.Helpers;

[assembly: SupportedOSPlatform("windows")]

namespace XScreen.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider? services;

        public IServiceProvider Services => services ?? throw new ArgumentNullException(nameof(services));

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            this.services = services.BuildServiceProvider();

            var notifyIcon = this.services.GetRequiredService<NotifyIcon>();
            Exit += (_, _) =>
            {
                notifyIcon.Dispose();
            };
            NotifyIconHelper.Init(notifyIcon, Shutdown);

            GlobalLoader.Instance(this.services);
        }

        /// <summary>
        /// </summary>
        /// <param name="services"> </param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(NotifyIcon), NotifyIcon.ImplType);
        }
    }
}