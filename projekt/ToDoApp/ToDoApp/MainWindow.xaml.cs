using System.Linq;
using System.Windows;
using ToDoApp.Helpers;
using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthHelper authHelper;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null || Login.Text == "Login:" || Password.Password == null || Password.Password == "Password:")
            {
                MessageBox.Show("Bad login or password!");
                return;
            }

            using (AppDBContext context = new AppDBContext())
            {
                var user = context.Users.Where(user => user.Login == Login.Text && user.Password == Password.Password).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Bad login or password!");
                    return;
                }

                authHelper = new AuthHelper(user);
            }

            var window = new ToDoView(this.authHelper);

            window.Owner = this;
            this.Hide();
            window.ShowDialog();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SignUpView();

            window.Owner = this;
            this.Hide();
            window.ShowDialog();
        }
    }
}