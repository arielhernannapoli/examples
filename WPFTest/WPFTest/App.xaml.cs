using System.Windows;
using Microsoft.Practices.Unity;
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
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelMain>();
            var window = new MainWindow { DataContext = viewModel };
            window.Show();
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
