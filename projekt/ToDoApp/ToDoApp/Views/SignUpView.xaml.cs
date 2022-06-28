using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using ToDoApp.Models;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        /// <summary>Initializes a new instance of the <see cref="SignUpView" /> class.</summary>
        public SignUpView()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SignUpButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null || Login.Text == "Login:" || Password.Password == null || Password.Password == "Password:" || Password.Password != Repeat.Password || Username.Text == null || Username.Text == "Name:" || Email.Text == null || Email.Text == "Email:")
            {
                MessageBox.Show("Please make sure all data has been entered!");
                return;
            }

            if (!new EmailAddressAttribute().IsValid(Email.Text))
            {
                MessageBox.Show("Incorrect email!");
                return;
            }

            using (var context = new AppDBContext())
            {
                var user = context.Users.Where(user => user.Login == Login.Text).FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show("Login is taken!");
                    return;
                }

                var newUser = new User
                {
                    Login = Login.Text,
                    Password = Password.Password,
                    Name = Username.Text,
                    Email = Email.Text
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("User signed up! You can sign in now to your account!");
            }
        }

        /// <summary>Handles the Click event of the CancelButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Window.Closed">Closed</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            this.Owner.Show();
            base.OnClosed(e);
        }
    }
}