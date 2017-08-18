using WPFTest.Infraestructure;
using WPFTest.View;
using Microsoft.Practices.Unity;

namespace WPFTest.ViewModel
{
    public class ViewModelReportingServices : IViewModelReportingServices
    {
        #region Metodos Privados
        public RelayCommand ReturnCommand { get; set; }

        void Return(object parameter)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelMain>();
            var window = new MainWindow() { DataContext = viewModel };
            window.Show();
            ((ReportingServicesWindow)parameter).Close();
        }
        #endregion

        #region Constructor con IoC
        public ViewModelReportingServices()
        {
            ReturnCommand = new RelayCommand(Return);
        }
        #endregion
    }
}
