using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;
using WPFTest.ViewModel.Administration.Interfaces;

namespace WPFTest.ViewModel.Administration
{
    public class ViewModelUserAdmin : IViewModelUserAdmin
    {
        #region Collecciones observables
        public ObservableCollection<Model.Usuario> Usuarios { get; set; }
        #endregion

        #region Servicios
        private IUsuarioService _usuarioService;
        #endregion

        #region Metodos Privados
        public RelayCommand AddUserCommand { get; set; }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            Usuarios.Add(new Model.Usuario { Id = 2, Nombre = parameter.ToString(), Apellido = parameter.ToString(), Activo = true });
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
        public ViewModelUserAdmin(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            Usuarios = new ObservableCollection<Model.Usuario>();
            var usuarios = _usuarioService.getUsuarios();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }

            AddUserCommand = new RelayCommand(AddUser);
        }
        #endregion
    }
}
