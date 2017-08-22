using System;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;
using WPFTest.View;

namespace WPFTest.ViewModel
{
    public class ViewModelMain : IViewModelMain
    {
        #region Collecciones observables
        public ObservableCollection<String> Sexo { get; set; }
        public ObservableCollection<Model.Usuario> Usuarios { get; set; }
        #endregion

        #region Servicios
        private IUsuarioService _usuarioService; 
        #endregion

        #region Propiedades
        private String _SexoSelected;
        public string SexoSelected
        {
            get
            {
                return _SexoSelected;
            }

            set
            {
                _SexoSelected = value;
                RaisePropertyChanged("SexoSelected");
            }
        }
        #endregion

        #region Metodos Privados
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand EditUserCommand { get; set; }
        public RelayCommand ViewReportCommand { get; set; }

        void EditUser(object parameter)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelEditUser>();
            var window = new EditUserWindow() { DataContext = viewModel };
            window.Show();
            ((MainWindow)parameter).Close();       
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            Usuarios.Add(new Model.Usuario { Id = 2, Nombre = parameter.ToString(), Apellido = parameter.ToString(), Activo = true });
        }

        void ViewReport(object parameter)
        {
            var viewModel = UnityContainerHelper.GetContainer().Resolve<IViewModelReportingServices>();
            var window = new ReportingServicesWindow() { DataContext = viewModel };
            window.Show();
            ((MainWindow)parameter).Close();
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        } 
        #endregion

        #region Constructor con IoC
        public ViewModelMain(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            Usuarios = new ObservableCollection<Model.Usuario>();
            Sexo = new ObservableCollection<string>();
            Sexo.Add("Masculino");
            Sexo.Add("Femenino");
            var usuarios = _usuarioService.getUsuarios();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }

            AddUserCommand = new RelayCommand(AddUser);
            EditUserCommand = new RelayCommand(EditUser);
            ViewReportCommand = new RelayCommand(ViewReport);
        } 
        #endregion
    }
}
