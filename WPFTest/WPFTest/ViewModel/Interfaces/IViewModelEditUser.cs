using WPFTest.Infraestructure;

namespace WPFTest.ViewModel
{
    public interface IViewModelEditUser
    {
        RelayCommand SaveChangesCommand { get; set; }
    }
}