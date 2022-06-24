﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.Models;
using System.Linq;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null || Login.Text == "Login:" || Password.Text == null || Password.Text == "Password:" || Password.Text != Repeat.Text || Username.Text == null || Username.Text == "Name:" || Email.Text == null || Email.Text == "Email:")
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
                    Password = Password.Text,
                    Name = Username.Text,
                    Email = Email.Text
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("User signed up! You can sign in now to your account!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}