using SimsProjekat.Applications.Controllers;
using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ApartmentForm.xaml
    /// </summary>
    public partial class ApartmentForm : Page, INotifyPropertyChanged
    {
        private readonly Window parentWindow;

        private readonly ApartmentController apartmentController;

        private CreateApartmentDTO _apartmentCreateDTO;

        public CreateApartmentDTO ApartmentCreateDTO 
        { 
            get
            {
                return _apartmentCreateDTO;
            }
            set
            {
                _apartmentCreateDTO = value;
                OnPropertyChanged(nameof(_apartmentCreateDTO));
            }
        }

        public int HotelId { get; set; }

        public ApartmentForm(Window parentWindow, int hotelId)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;

            DataContext = this;

            apartmentController = App.Services.GetService(typeof(ApartmentController)) as ApartmentController;
            ApartmentCreateDTO = new CreateApartmentDTO();
            HotelId = hotelId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = ApartmentCreateDTO.Name;
            string desc = ApartmentCreateDTO.Description;
            int roomCount = int.TryParse(RoomCountTextBox.Text, out int parsedRoomCount) ? parsedRoomCount : 0;
            int maxGuestNumber = int.TryParse(MaxGuestNumberTextBox.Text, out int parsedMaxGuest) ? parsedMaxGuest : 0;

            bool isCreated = apartmentController.CreateApartment(name, desc, roomCount, maxGuestNumber, HotelId);

            if (isCreated) 
            {
                MessageBox.Show("New apartment created!");
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
