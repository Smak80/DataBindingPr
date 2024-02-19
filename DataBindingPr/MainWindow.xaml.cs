using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBindingPr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filename = "User.info";
        public User user = new User();
        public MainWindow()
        {
            user.Login = "Somebody";
            user.Password = "Pass";
            user.Age = 20;
            InitializeComponent();
            Binding bLogin = new Binding();
            bLogin.Source = user;
            bLogin.Path = new PropertyPath(nameof(User.Login));
            TbLogin.SetBinding(TextBox.TextProperty, bLogin);
            Binding bAge = new Binding();
            bAge.Source = user;
            bAge.Path = new PropertyPath(nameof(User.Age));
            TbAge.SetBinding(TextBox.TextProperty, bAge);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new(filename, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, user);
            }
        }

        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            user.Password = ((PasswordBox)sender).Password;
        }
    }
}