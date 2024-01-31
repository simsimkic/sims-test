using SimsProjekat.Applications.Controllers;
using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window, INotifyPropertyChanged
    {
        private readonly LoginController loginController;

        private readonly UserController userController;

        private ObservableCollection<UserDisplayDTO> _users;

        public ObservableCollection<UserDisplayDTO> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private UserDisplayDTO _selectedUser;

        public UserDisplayDTO SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private string _selectedType;

        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
                _selectedType = _selectedType.Replace("System.Windows.Controls.ComboBoxItem", "");
                OnPropertyChanged(nameof(SelectedType));
                RefreshUsers();
            }
        }

        public AdminView()
        {
            InitializeComponent();

            DataContext = this;

            userController = App.Services.GetService(typeof(UserController)) as UserController;
            loginController = App.Services.GetService(typeof(LoginController)) as LoginController;

            SelectedType = "";

            RefreshUsers();
        }

        private void RefreshUsers()
        {
            List<UserDisplayDTO> users = userController.GetAll(SelectedType, UserSession.User.Jmbg);

            Users = new ObservableCollection<UserDisplayDTO>(users);
        }

        private void registerOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Navigate(new RegistrationForm(this));
            navigationWindow.Show();
            this.Hide();
        }

        private void blockButton_Click(object sender, RoutedEventArgs e)
        {
            userController.BlockUnblockUser(SelectedUser.Jmbg);
            RefreshUsers();
        }

        private void createHotelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Navigate(new HotelCreationForm(this));
            navigationWindow.Show();
            this.Hide();
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = loginController.Logout();

            if (result)
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You already logged out!");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
