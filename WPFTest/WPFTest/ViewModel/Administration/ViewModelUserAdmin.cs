using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;
using WPFTest.ViewModel.Administration.Interfaces;

namespace WPFTest.ViewModel.Administration
{
    public class ViewModelUserAdmin : IViewModelUserAdmin, INotifyPropertyChanged
    {
        #region Propiedades
        private int _idUsuario;
        private String _nombreUsuario;
        private String _apellidoUsuario;
        private String _usuario;
        private bool _usuarioActivo;
        private Model.Usuario _usuarioSeleccionado;

        public Model.Usuario UsuarioSeleccionado
        {
            get
            {
                return _usuarioSeleccionado;
            }
            set
            {
                _usuarioSeleccionado = value;
                RaisePropertyChanged("UsuarioSeleccionado");
            }
        }

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
                RaisePropertyChanged("IdUsuario");
            }
        }

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
        public RelayCommand UpdateUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }
        public RelayCommand SaveUserCommand { get; set; }

        void AddUser(object parameter)
        {
            this.IdUsuario = 0;
            this.NombreUsuario = String.Empty;
            this.ApellidoUsuario = String.Empty;
            this.Usuario = String.Empty;
            this.UsuarioActivo = false;
            ((StackPanel)parameter).Visibility = System.Windows.Visibility.Visible;
        }

        void UpdateUser(object parameter)
        {
            if (this.UsuarioSeleccionado != null)
            {
                this.IdUsuario = this.UsuarioSeleccionado.Id;
                this.NombreUsuario = this.UsuarioSeleccionado.Nombre;
                this.ApellidoUsuario = this.UsuarioSeleccionado.Apellido;
                this.Usuario = this.UsuarioSeleccionado.NombreUsuario;
                this.UsuarioActivo = this.UsuarioSeleccionado.Activo;
                ((StackPanel)parameter).Visibility = System.Windows.Visibility.Visible;
            }
        }

        void DeleteUser(object parameter)
        {
            if (this.UsuarioSeleccionado != null)
            {
                _usuarioService.deleteUsuario(this.UsuarioSeleccionado);
                this.GetUsuarios();
                ((StackPanel)parameter).Visibility = System.Windows.Visibility.Hidden;
            }
        }

        void SaveUser(object parameter)
        {
            if (this.IdUsuario > 0)
            {
                _usuarioService.updateUsuario(new Model.Usuario
                {
                    Id = this.IdUsuario,
                    Nombre = this.NombreUsuario,
                    Apellido = this.ApellidoUsuario,
                    NombreUsuario = this.Usuario,
                    Activo = this.UsuarioActivo
                });
            }
            else
            {
                _usuarioService.insertUsuario(new Model.Usuario
                {
                    Nombre = this.NombreUsuario,
                    Apellido = this.ApellidoUsuario,
                    NombreUsuario = this.Usuario,
                    Activo = this.UsuarioActivo
                });
            } 


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
            UpdateUserCommand = new RelayCommand(UpdateUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
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
            RaisePropertyChanged("Usuarios");
        } 
        #endregion
    }
}
