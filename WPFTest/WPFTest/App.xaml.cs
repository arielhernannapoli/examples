using System.Windows;
using Microsoft.Practices.Unity;
using WPFTest.Servicios;
using WPFTest.Servicios.Interfaces;
using WPFTest.ViewModel;
using AutoMapper;
using System;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ConfigurarMappings();
            var viewModel = ConfigurarIoC().Resolve<ViewModelMain>();
            var window = new MainWindow { DataContext = viewModel };
            window.Show();
        }

        private UnityContainer ConfigurarIoC()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ITestService, TestService>();
            return container;
        }

        private void ConfigurarMappings()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                                "WPFTest.Services",
                                "WPFTest"
                })
            );
        }
    }
}
