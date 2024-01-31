using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Services;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Controllers
{
    public class HotelController
    {
        private readonly IHotelService _hotelService;

        private readonly IHotelSearchService _hotelSearchService;

        public HotelController(IHotelService hotelService, IHotelSearchService hotelSearchService)
        {
            _hotelService = hotelService;
            _hotelSearchService = hotelSearchService;
        }

        public List<Hotel> GetAll()
        {
            return _hotelService.GetAll();
        }

        public List<Hotel> SearchBy(string searchParam, string searchText, string apartmentSearchParam)
        {
            return _hotelSearchService.SearchBy(searchParam, searchText, apartmentSearchParam);
        }

        public List<HotelReservationsDTO> GetHotelReservations(string ownerJmbg, string resStatus)
        {
            return _hotelService.GetHotelReservations(ownerJmbg, resStatus);
        }

        public List<HotelRequestDTO> GetHotelRequests(string ownerJmbg)
        {
            return _hotelService.GetHotelRequests(ownerJmbg);
        }

        public bool CreateHotel(CreateHotelDTO newHotel, List<CreateApartmentDTO> newApartments)
        {
            return _hotelService.CreateHotel(newHotel, newApartments);
        }

        public bool Update(int hotelId, Status newStatus)
        {
            return _hotelService.AcceptHotelRequest(hotelId, newStatus);
        }
    }
}
