using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Services
{
    public interface IHotelSearchService
    {
        public List<Hotel> FilterById(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByName(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByConstructionYear(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByRating(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByRooms(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByGuestNumber(List<Hotel> hotels, string searchText);

        public List<Hotel> FilterByBoth(List<Hotel> hotels, string searchText);

        public List<Hotel> SearchBy(string searchParam, string searchText, string apartmentSearchParam);
    }
}
