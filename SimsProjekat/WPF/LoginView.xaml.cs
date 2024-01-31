using SimsProjekat.Applications.Controllers;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimsProjekat.WPF
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly LoginController loginController;

        private int invalidLoginCounter { get; set; }
        public LoginView()
        {
            InitializeComponent();
            loginController = App.Services.GetService(typeof(LoginController)) as LoginController;
            invalidLoginCounter = 0;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            User user = loginController.Login(email, password);

            if (user != null)
            {
                if (user.IsBlocked)
                {
                    MessageBox.Show("You are blocked, you can't log in!");
                    return;
                }

                if(user.UserType == UserType.Admin)
                {
                    AdminView adminView = new AdminView();
                    adminView.Show();
                    this.Close();
                }

                if(user.UserType == UserType.Owner)
                {
                    OwnerView ownerView = new OwnerView();
                    ownerView.Show();
                    this.Close();
                }

                if(user.UserType == UserType.Guest)
                {
                    GuestView guestView = new GuestView();
                    guestView.Show();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Invalid Email or Password. Please try again.");

                if(++invalidLoginCounter == 3)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeView = new HomeWindow();
            homeView.Show();
            this.Close();
        }
    }
}
