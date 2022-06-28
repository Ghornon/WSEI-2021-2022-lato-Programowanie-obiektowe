using System.Linq;
using System.Windows;
using ToDoApp.Helpers;
using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml of ToDo App
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthHelper authHelper;

        /// <summary>Initializes a new instance of the <see cref="MainWindow" /> class.</summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SignInButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
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

        /// <summary>Handles the Click event of the SignUpButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SignUpView();

            window.Owner = this;
            this.Hide();
            window.ShowDialog();
        }
    }
}