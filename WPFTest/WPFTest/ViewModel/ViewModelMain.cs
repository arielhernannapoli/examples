using System.Collections.ObjectModel;
using WPFTest.Infraestructure;
using WPFTest.Servicios.Interfaces;

namespace WPFTest.ViewModel
{
    class ViewModelMain
    {
        public ObservableCollection<Model.Usuario> Usuarios { get; set; }
         
        private ITestService _testService;

        public RelayCommand AddUserCommand { get; set; }

        public ViewModelMain(ITestService testService)
        {
            _testService = testService;
            Usuarios = new ObservableCollection<Model.Usuario>();
            var usuarios = _testService.getUsuarios();
            foreach(var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }

            AddUserCommand = new RelayCommand(AddUser);
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            Usuarios.Add(new Model.Usuario { Id = 2, Nombre = parameter.ToString(), Apellido = parameter.ToString(), Activo = true });
        }
    }
}
