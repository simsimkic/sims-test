using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        private readonly IReservationRepository _reservationRepository;

        public HotelService(IHotelRepository hotelRepository, IReservationRepository reservationRepository)
        {
            _hotelRepository = hotelRepository;
            _reservationRepository = reservationRepository;
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public List<HotelReservationsDTO> GetHotelReservations(string ownerJmbg, string resStatus)
        {
            var hotels = _hotelRepository.GetByOwnerJmbg(ownerJmbg);

            List<HotelReservationsDTO> hotelReservationDTOs = new List<HotelReservationsDTO>();

            if (Enum.TryParse(resStatus, out Status parsedStatus))
            {
               hotelReservationDTOs = hotels
               .Where(hotel => hotel.Status == Status.Confirmed)
               .Select(hotel => new HotelReservationsDTO(
                   hotel,
                   hotel.Apartments
                       .SelectMany(apartment =>
                           _reservationRepository.GetByApartmentId(apartment.Id)
                               .Where(reservation => reservation != null && reservation.Status == parsedStatus)
                               .Select(reservation => new ReservationDTO(reservation, apartment))
                       )
                       .ToList()
               ))
               .ToList();
            }
            else
            {
                hotelReservationDTOs = hotels
               .Where(hotel => hotel.Status == Status.Confirmed)
               .Select(hotel => new HotelReservationsDTO(
                   hotel,
                   hotel.Apartments
                       .SelectMany(apartment =>
                           _reservationRepository.GetByApartmentId(apartment.Id)
                               .Where(reservation => reservation != null && (reservation.Status == Status.Pending || reservation.Status == Status.Confirmed))
                               .Select(reservation => new ReservationDTO(reservation, apartment))
                       )
                       .ToList()
               ))
               .ToList();
            }

            return hotelReservationDTOs;
        }

        public bool CreateHotel(CreateHotelDTO newHotel, List<CreateApartmentDTO> newApartments)
        {
            Hotel hotel = new Hotel(newHotel);

            hotel.Apartments = newApartments.Select(a => new Apartment(a)).ToList();

            return _hotelRepository.Save(hotel) != null;
        }

        public List<HotelRequestDTO> GetHotelRequests(string ownerJmbg)
        {
            List<Hotel> hotels = _hotelRepository.GetByOwnerJmbg(ownerJmbg);

            List<HotelRequestDTO> hotelRequests = hotels.Select(a => new HotelRequestDTO(a)).ToList();

            hotelRequests = hotelRequests.Where(a => a.Status == Status.Confirmed || a.Status == Status.Pending).ToList();

            return hotelRequests;
        }

        public bool AcceptHotelRequest(int hotelId, Status newStatus)
        {
            Hotel hotel = _hotelRepository.GetById(hotelId);

            if (hotel != null && hotel.Status != newStatus)
            {
                hotel.Status = newStatus;

                _hotelRepository.Update(hotel);

                return true;
            }

            return false;
        }
    }
}
