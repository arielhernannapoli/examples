using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;
using WPFTest.ViewModel.Administration.Interfaces;

namespace WPFTest.ViewModel.Administration
{
    public class ViewModelUserAdmin : IViewModelUserAdmin
    {
        #region Propiedades
        private String _nombreUsuario;
        private String _apellidoUsuario;
        private String _usuario;
        private bool _usuarioActivo;

        public String NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
                RaisePropertyChanged("NombreUsuario");
            }
        }

        public String ApellidoUsuario
        {
            get
            {
                return _apellidoUsuario;
            }
            set
            {
                _apellidoUsuario = value;
                RaisePropertyChanged("ApellidoUsuario");
            }
        }

        public String Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
                RaisePropertyChanged("Usuario");
            }
        }

        public bool UsuarioActivo
        {
            get
            {
                return _usuarioActivo;
            }
            set
            {
                _usuarioActivo = value;
                RaisePropertyChanged("UsuarioActivo");
            }
        } 
        #endregion

        #region Collecciones observables
        public ObservableCollection<Model.Usuario> Usuarios { get; set; }
        #endregion

        #region Servicios
        private IUsuarioService _usuarioService;
        #endregion

        #region Metodos Privados
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand SaveUserCommand { get; set; }

        void AddUser(object parameter)
        {
            ((StackPanel)parameter).Visibility = System.Windows.Visibility.Visible;
        }

        void SaveUser(object parameter)
        {
            _usuarioService.insertUsuario(new Model.Usuario {
                Nombre = this.NombreUsuario,
                Apellido = this.ApellidoUsuario,
                NombreUsuario = this.Usuario,
                Activo = this.UsuarioActivo
            });

            this.GetUsuarios();
            ((StackPanel)parameter).Visibility = System.Windows.Visibility.Hidden;
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
            this.GetUsuarios();
            AddUserCommand = new RelayCommand(AddUser);
            SaveUserCommand = new RelayCommand(SaveUser);
        }
        #endregion

        #region Miembros Privados
        private void GetUsuarios()
        {
            Usuarios = new ObservableCollection<Model.Usuario>();
            var usuarios = _usuarioService.getUsuarios();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }
        } 
        #endregion
    }
}
