using System;
using System.ComponentModel;

namespace WPFTest.Model
{
    public class Usuario : INotifyPropertyChanged
    {
        private int _id;
        private String _nombre;
        private String _apellido;
        private String _nombreUsuario;
        private bool _activo;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("Id"); 
                }
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    RaisePropertyChanged("Nombre"); 
                }
            }
        }

        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                    RaisePropertyChanged("Apellido"); 
                }
            }
        }

        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }

            set
            {
                if (_nombreUsuario != value)
                {
                    _nombreUsuario = value;
                    RaisePropertyChanged("NombreUsuario");
                }
            }
        }

        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                if (_activo != value)
                {
                    _activo = value;
                    RaisePropertyChanged("Activo"); 
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

    }
}
