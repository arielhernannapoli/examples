using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFTest.Infraestructure;
using WPFTest.Model;

namespace WPFTest.ViewModel
{
    public interface IViewModelMain
    {
        RelayCommand AddUserCommand { get; set; }
        RelayCommand EditUserCommand { get; set; }
        ObservableCollection<string> Sexo { get; set; }
        string SexoSelected { get; set; }
        ObservableCollection<Usuario> Usuarios { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}