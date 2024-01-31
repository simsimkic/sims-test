using SimsProjekat.Applications.Controllers;
using SimsProjekat.Applications.DTOs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimsProjekat.WPF
{
    /// <summary>
    /// Interaction logic for HotelCreationForm.xaml
    /// </summary>
    public partial class HotelCreationForm : Page, INotifyPropertyChanged
    {
        private readonly Window parentWindow;

        private readonly HotelController hotelController;

        private readonly LoginController loginController;   
        public CreateHotelDTO HotelDTO {  get; set; }


        private ObservableCollection<CreateApartmentDTO> _apartmentDTOs;
        public ObservableCollection<CreateApartmentDTO> ApartmentDTOs
        {
            get
            {
                return _apartmentDTOs;
            }
            set
            {
                _apartmentDTOs = value;
                OnPropertyChanged(nameof(ApartmentDTOs));
            }
        }

        private CreateApartmentDTO _apartmentCreateDTO;
        public CreateApartmentDTO ApartmentCreateDTO 
        {  get
           {
                return _apartmentCreateDTO;
           }
           set
           {
                _apartmentCreateDTO = value;
                OnPropertyChanged(nameof(ApartmentCreateDTO));
           }
        }

        private CreateApartmentDTO _selectedApartment;

        public CreateApartmentDTO SelectedApartment
        {
            get
            {
                return _selectedApartment;
            }
            set
            {
                _selectedApartment = value;
                OnPropertyChanged(nameof(SelectedApartment));
            }
        }
        
        public HotelCreationForm(Window parentWindow)
        {
            InitializeComponent();

            this.parentWindow = parentWindow;

            DataContext = this;

            HotelDTO = new CreateHotelDTO();
            hotelController = App.Services.GetService(typeof(HotelController)) as HotelController;
            loginController = App.Services.GetService(typeof(LoginController)) as LoginController;

            ApartmentDTOs = new ObservableCollection<CreateApartmentDTO>();
            ApartmentCreateDTO = new CreateApartmentDTO();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddApartment_Click(object sender, RoutedEventArgs e)
        {
            ApartmentDTOs.Add(ApartmentCreateDTO);
            ApartmentCreateDTO = new CreateApartmentDTO();

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ApartmentDTOs.Remove(SelectedApartment);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<CreateApartmentDTO> apartments = new List<CreateApartmentDTO>(ApartmentDTOs);

            bool result = hotelController.CreateHotel(HotelDTO, apartments);

            if (result)
            {
                MessageBox.Show("Hotel created!");
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
