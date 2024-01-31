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
    public class HotelSearchService : IHotelSearchService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelSearchService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> FilterById(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.Id.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Hotel> FilterByName(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Hotel> FilterByConstructionYear(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.ConstructionYear.ToString().StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Hotel> FilterByRating(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.Rating.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Hotel> FilterByRooms(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.Apartments.Any(apartment => apartment.RoomCount.ToString().Equals(searchText))).ToList();
        }

        public List<Hotel> FilterByGuestNumber(List<Hotel> hotels, string searchText)
        {
            return hotels.Where(hotel => hotel.Apartments.Any(apartment => apartment.MaxGuestNumber.ToString().Equals(searchText))).ToList();
        }

        public List<Hotel> FilterByBoth(List<Hotel> hotels, string searchText)
        {
            if (searchText.Contains('&'))
            {
                string roomNum = searchText.Split(" & ")[0];
                string guestNum = "";

                try
                {
                    guestNum = searchText.Split(" & ")[1];
                }
                catch (Exception e)
                {
                    return null;
                }

                return hotels
                    .Where(hotel => hotel.Apartments.Any(apartment => apartment.MaxGuestNumber.ToString().Equals(guestNum) && apartment.RoomCount.ToString().Equals(roomNum)))
                    .ToList();
            }
            else if (searchText.Contains('|'))
            {
                string roomNum = searchText.Split(" | ")[0];
                string guestNum = "";

                try
                {
                    guestNum = searchText.Split(" | ")[1];
                }
                catch (Exception e)
                {
                    return null;
                }

                return hotels
                    .Where(hotel => hotel.Apartments.Any(apartment => apartment.MaxGuestNumber.ToString().Equals(guestNum) || apartment.RoomCount.ToString().Equals(roomNum)))
                    .ToList();
            }
            else
            {
                return hotels;
            }
        }

        public List<Hotel> SearchBy(string searchParam, string searchText, string apartmentSearchParam)
        {
            List<Hotel> hotels = _hotelRepository.GetAll();
            List<Hotel> filteredList = new List<Hotel>();

            if (string.IsNullOrEmpty(searchText))
            {
                filteredList = hotels;

                return filteredList;
            }

            switch (searchParam)
            {
                case "ID":
                    filteredList = FilterById(hotels, searchText);
                    break;
                case "Name":
                    filteredList = FilterByName(hotels, searchText);
                    break;
                case "Construction Year":
                    filteredList = FilterByConstructionYear(hotels, searchText);
                    break;
                case "Rating":
                    filteredList = FilterByRating(hotels, searchText);
                    break;
                case "Apartments":
                    if (string.IsNullOrEmpty(apartmentSearchParam))
                    {
                        filteredList = hotels;

                        return filteredList;
                    }

                    if (apartmentSearchParam.Equals("Rooms"))
                    {
                        filteredList = FilterByRooms(hotels, searchText);
                    }

                    if (apartmentSearchParam.Equals("Guest Number"))
                    {
                        filteredList = FilterByGuestNumber(hotels, searchText);
                    }

                    if (apartmentSearchParam.Equals("Both")) {
                        filteredList = FilterByBoth(hotels, searchText);
                    }
                    break;
                default:
                    filteredList = hotels;
                    break;
            }
            return filteredList;
        }
    }
}
