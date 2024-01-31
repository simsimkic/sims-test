using SimsProjekat.Applications.Controllers;
using SimsProjekat.Applications.DTOs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimsProjekat.WPF
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Page
    {
        private readonly Window parentWindow;

        private readonly UserController userController; 
        public CreateUserDTO NewUser { get; set; }

        public RegistrationForm(Window parentWindow)
        {
            InitializeComponent();

            this.parentWindow = parentWindow;

            DataContext = this;

            userController = App.Services.GetService(typeof(UserController)) as UserController;

            NewUser = new CreateUserDTO();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { 
                NewUser.Password = PasswordBox.Password; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewUser.UserType = "Owner";

            bool IsCreated = userController.CreateOwner(NewUser);
            
            if (IsCreated)
            {
                MessageBox.Show("Owner created!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        private void NavigateBack_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.Show();
            NavigationService?.Navigate(null);
        }
    }
}
