using System.Windows;
using ToDoApp.Helpers;
using ToDoApp.Models;
using ToDoApp.Views;
using System.Linq;

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

            using (AppDBContext context = new AppDBContext())
            {
                var user = context.Users.Find(1);

                authHelper = new AuthHelper(user);
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null || Login.Text == "Login:" || Password.Text == null || Password.Text == "Password:")
            {
                MessageBox.Show("Bad login or password!");
                return;
            }

            using (AppDBContext context = new AppDBContext())
            {
                var user = context.Users.Where(user => user.Login == Login.Text && user.Password == Password.Text).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Bad login or password!");
                    return;
                }

                authHelper = new AuthHelper(user);
            }

            var window = new ToDoView(this.authHelper);

            window.Owner = this;
            window.ShowDialog();
        }
    }
}