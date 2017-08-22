using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFTest.Infraestructure;
using WPFTest.Model;

namespace WPFTest.ViewModel.Administration.Interfaces
{
    public interface IViewModelUserAdmin
    {
        RelayCommand AddUserCommand { get; set; }
        ObservableCollection<Usuario> Usuarios { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}
