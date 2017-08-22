using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using WPFTest.ViewModel;
using WPFTest.View.Administration;
using WPFTest.ViewModel.Administration.Interfaces;

namespace WPFTest.View
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        #region Constructor
        public MenuControl()
        {
            InitializeComponent();
        } 
        #endregion

        #region Eventos de Menu
        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuReporteUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelReportingServices>();
            var window = new ReportingServicesWindow() { DataContext = viewModel };
            window.Show();
        }

        private void MenuAdminUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelUserAdmin>();
            var window = new UserAdminWindow() { DataContext = viewModel };
            window.Show();
        }
        #endregion
    }
}
