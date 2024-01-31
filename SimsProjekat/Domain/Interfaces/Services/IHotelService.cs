using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Services
{
    public interface IHotelService
    {
        public List<Hotel> GetAll();

        public List<HotelReservationsDTO> GetHotelReservations(string ownerJmbg, string resStatus);

        public bool CreateHotel(CreateHotelDTO newHotel, List<CreateApartmentDTO> newApartments);

        public List<HotelRequestDTO> GetHotelRequests(string ownerJmbg);

        public bool AcceptHotelRequest(int hotelId, Status newStatus);
    }
}
