using System.Windows;
using System.Windows.Input;

namespace WPFTest.View.Administration
{
    /// <summary>
    /// Interaction logic for UserAdminWindow.xaml
    /// </summary>
    public partial class UserAdminWindow : Window
    {
        #region Constructor
        public UserAdminWindow()
        {
            InitializeComponent();
        } 
        #endregion

        #region Eventos
        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        } 
        #endregion
    }
}
