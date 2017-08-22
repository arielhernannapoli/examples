using System.Windows;

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
        #endregion
    }
}
