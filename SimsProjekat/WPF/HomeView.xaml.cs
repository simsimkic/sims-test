using SimsProjekat.Applications.Controllers;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window, INotifyPropertyChanged
    {
        private readonly HotelController hotelController;

        private ObservableCollection<Hotel> _hotels;

        public ObservableCollection<Hotel> Hotels
        {
            get { return _hotels; }
            set
            {
                _hotels = value;
                OnPropertyChanged(nameof(Hotels));
            }
        }

        private string _searchParam;

        public string SearchParam
        {
            get { return _searchParam; }
            set
            {
                _searchParam = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
                _searchParam = _searchParam.Replace("System.Windows.Controls.ComboBoxItem", "");
                OnPropertyChanged(nameof(SearchParam));
                if (SearchParam.Equals("Apartments"))
                {
                    ApartmentComboBox.Visibility = Visibility.Visible;
                }
                SearchText = "";
            }
        }

        private string _apartmentSearchParam;

        public string ApartmentSearchParam
        {
            get { return _apartmentSearchParam; }
            set
            {
                _apartmentSearchParam = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
                _apartmentSearchParam = _apartmentSearchParam.Replace("System.Windows.Controls.ComboBoxItem", "");
                OnPropertyChanged(nameof(ApartmentSearchParam));
                SearchText = "";
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
                _searchText = _searchText.Replace("System.Windows.Controls.ComboBoxItem", "");
                OnPropertyChanged(nameof(SearchText));
                RefreshHotels();
            }
        }

        public HomeWindow()
        {
            InitializeComponent();
            DataContext = this;
            hotelController = App.Services.GetService(typeof(HotelController)) as HotelController;


            List<Hotel> hotelList = hotelController.GetAll();
            Hotels = new ObservableCollection<Hotel>(hotelList);
            ApartmentComboBox.Visibility = Visibility.Collapsed;
            SearchText = "";
        }

        private void RefreshHotels()
        {
            List<Hotel> hotelList = hotelController.SearchBy(SearchParam, SearchText, ApartmentSearchParam);

            if(hotelList is null)
            {
                hotelList = hotelController.GetAll();

                Hotels = new ObservableCollection<Hotel>(hotelList);
            }
            else
            {
                Hotels = new ObservableCollection<Hotel>(hotelList);
            }
           
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = SearchTextBox.Text;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

    }
}
