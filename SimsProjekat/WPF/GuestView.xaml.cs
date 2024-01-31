using SimsProjekat.Applications.Controllers;
using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Util;
using SimsProjekat.Domain.Models;
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
using System.Windows.Shapes;

namespace SimsProjekat.WPF
{
    /// <summary>
    /// Interaction logic for GuestView.xaml
    /// </summary>
    public partial class GuestView : Window, INotifyPropertyChanged
    {
        private readonly ApartmentReservationController apartmentReservationController;

        private readonly ApartmentController apartmentController;

        private readonly LoginController loginController;

        private ObservableCollection<ApartmentDTO> _apartment;

        public ObservableCollection<ApartmentDTO> Apartments
        {
            get { return _apartment; }
            set
            {
                _apartment = value;
                OnPropertyChanged(nameof(Apartments));
            }
        }

        private ApartmentDTO _selectedApartment;

        public ApartmentDTO SelectedApartment
        {
            get { return _selectedApartment; }
            set
            {
                _selectedApartment = value;
                OnPropertyChanged(nameof(SelectedApartment));
            }
        }

        private ObservableCollection<ReservationDTO> _reservations;

        public ObservableCollection<ReservationDTO> Reservations
        {
            get { return _reservations; }
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        private ReservationDTO _selectedReservation;

        public ReservationDTO SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
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
                RefreshReservations();
            }
        }

        public GuestView()
        {
            InitializeComponent();
            DataContext = this;
            apartmentReservationController = App.Services.GetService(typeof(ApartmentReservationController)) as ApartmentReservationController;
            loginController = App.Services.GetService(typeof(LoginController)) as LoginController;
            apartmentController = App.Services.GetService(typeof(ApartmentController)) as ApartmentController;

            RefreshApartments();

            SelectedApartment = new ApartmentDTO();

            RefreshReservations();
            
            SelectedReservation = new ReservationDTO();
        }

        private void RefreshApartments()
        {
            List<ApartmentDTO> apartmentList = apartmentController.GetAll();
            Apartments = new ObservableCollection<ApartmentDTO>(apartmentList);
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedApartment != null)
            {
                myCalendar.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Select an apartment to book!");
            }
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = myCalendar.SelectedDate.GetValueOrDefault();

            bool isSuccessfull = apartmentReservationController.BookApartment(UserSession.User.Jmbg, SelectedApartment.Id, selectedDate);

            if (isSuccessfull)
            {
                MessageBox.Show("Apartment booked succesfully!");
            }
            else
            {
                MessageBox.Show("Apartment already booked for that day!");
            }

            myCalendar.Visibility = Visibility.Collapsed;

            RefreshReservations();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccessfull = apartmentReservationController.CancelReservation(SelectedReservation.Id);

            if (isSuccessfull)
            {
                MessageBox.Show("Reservation canceled successfully!");
            }
            else
            {
                MessageBox.Show("Reservation already rejected!");
            }

            RefreshReservations();
        }

        private void RefreshReservations()
        {
            List<ReservationDTO> reservationList = apartmentReservationController.GetAllReservations(UserSession.User.Jmbg, SelectedStatus);

            Reservations = new ObservableCollection<ReservationDTO>(reservationList);
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
