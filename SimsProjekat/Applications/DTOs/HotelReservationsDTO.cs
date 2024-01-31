using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class HotelReservationsDTO : INotifyPropertyChanged
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }

        public int HotelRating { get; set; }

        private ObservableCollection<ReservationDTO> _reservations;

        public ObservableCollection<ReservationDTO> Reservations
        {
            get { return _reservations; }
            set
            {
                if (_reservations != value)
                {
                    _reservations = value;
                    OnPropertyChanged(nameof(Reservations));
                }
            }
        }

        public HotelReservationsDTO()
        {
            Reservations = new ObservableCollection<ReservationDTO>();
        }

        public HotelReservationsDTO(Hotel hotel, List<ReservationDTO> reservations)
        {
            HotelId = hotel.Id;
            HotelName = hotel.Name;
            HotelRating = hotel.Rating;
            Reservations = new ObservableCollection<ReservationDTO>(reservations);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
