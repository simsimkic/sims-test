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
    /// Interaction logic for OwnerView.xaml
    /// </summary>
    public partial class OwnerView : Window, INotifyPropertyChanged
    {
        private readonly ApartmentReservationController apartmentReservationController;

        private readonly HotelController hotelController;

        private readonly LoginController loginController;

        private ObservableCollection<HotelRequestDTO> _hotelRequests;

        public ObservableCollection<HotelRequestDTO> HotelRequests
        {
            get { return _hotelRequests; }
            set
            {
                _hotelRequests = value;
                OnPropertyChanged(nameof(HotelRequests));
            }
        }

        private HotelRequestDTO _selectedRequest;

        public HotelRequestDTO SelectedRequest
        {
            get { return _selectedRequest; }
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        private ReservationDTO _selectedReservation;

        public ReservationDTO SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;

                if (_selectedReservation.Status == Domain.Models.Status.Pending)
                {
                    AcceptReservation.Visibility = Visibility.Visible;
                    RejectReservation.Visibility = Visibility.Visible;
                }
                else
                {
                    AcceptReservation.Visibility = Visibility.Collapsed;
                    RejectReservation.Visibility = Visibility.Collapsed;
                }

                OnPropertyChanged(nameof(SelectedReservation));
            }
        }

        private string _selectedStatus;

        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
                _selectedStatus = _selectedStatus.Replace("System.Windows.Controls.ComboBoxItem", "");
                OnPropertyChanged(nameof(SelectedStatus));
                RefreshHotelReservations();
            }
        }

        private string _rejectionReason;

        public string RejectionReason
        {
            get { return _rejectionReason; }
            set
            {
                _rejectionReason = value;
                OnPropertyChanged(nameof(RejectionReason));
            }
        }

        private ObservableCollection<HotelReservationsDTO> _hotels;

        public ObservableCollection<HotelReservationsDTO> Hotels
        {
            get { return _hotels; }
            set
            {
                _hotels = value;
                OnPropertyChanged(nameof(Hotels));
            }
        }

        private HotelReservationsDTO _selectedHotel;

        public HotelReservationsDTO SelectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                _selectedHotel = value;
                OnPropertyChanged(nameof(SelectedHotel));
            }
        }

        public OwnerView()
        {
            InitializeComponent();

            DataContext = this;

            apartmentReservationController = App.Services.GetService(typeof(ApartmentReservationController)) as ApartmentReservationController;
            hotelController = App.Services.GetService(typeof(HotelController)) as HotelController;
            loginController = App.Services.GetService(typeof(LoginController)) as LoginController;

            SelectedStatus = "";

            RefreshHotelRequests();
            RefreshHotelReservations();

            AcceptReservation.Visibility = Visibility.Collapsed;
            RejectReservation.Visibility = Visibility.Collapsed;
        }

        private void RefreshHotelRequests()
        {
            List<HotelRequestDTO> hotelRequests = hotelController.GetHotelRequests(UserSession.User.Jmbg);

            HotelRequests = new ObservableCollection<HotelRequestDTO>(hotelRequests);
        }
        private void RefreshHotelReservations()
        {
            List<HotelReservationsDTO> reservationDTOs = hotelController.GetHotelReservations(UserSession.User.Jmbg, SelectedStatus);

            Hotels = new ObservableCollection<HotelReservationsDTO>(reservationDTOs);
        }

        private void AcceptReservation_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedReservation.Status == Domain.Models.Status.Pending)
            {
                bool isAccepted = apartmentReservationController.AcceptReservation(SelectedReservation.Id);

                if(isAccepted)
                {
                    MessageBox.Show("Reservation confirmed!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
                RefreshHotelReservations();
            }
        }

        private void InputTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RejectionReason = RejectionTextBox.Text;
                if (SelectedReservation.Status == Domain.Models.Status.Pending)
                {
                    bool isRejected = apartmentReservationController.RejectReservation(SelectedReservation.Id, RejectionReason);

                    if (isRejected)
                    {
                        MessageBox.Show("Reservation rejected!");
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }

                RejectionTextBox.Visibility = Visibility.Collapsed;
                RejectionTextBox.Text = string.Empty;
                RefreshHotelReservations();
            }
        }

        private void RejectReservation_Click(object sender, RoutedEventArgs e)
        {
            RejectionTextBox.Visibility = Visibility.Visible;
            RejectionTextBox.Focus();
        }

        private void AddApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Navigate(new ApartmentForm(this, SelectedHotel.HotelId));
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

        private void AcceptRequestButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAccepted = hotelController.Update(SelectedRequest.Id, Domain.Models.Status.Confirmed);

            if (isAccepted)
            {
                MessageBox.Show("Request accepted!");
            }
            else
            {
                MessageBox.Show("Error!");
            }

            RefreshHotelRequests();
        }

        private void RejectRequestButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAccepted = hotelController.Update(SelectedRequest.Id, Domain.Models.Status.Rejected);

            if (isAccepted)
            {
                MessageBox.Show("Request rejected!");
            }
            else
            {
                MessageBox.Show("Error!");
            }

            RefreshHotelRequests();
        }
    }
}
