using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class ApartmentDTO
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RoomCount { get; set; }

        public int MaxGuestNumber { get; set; }

        public ApartmentDTO()
        {
        }

        public ApartmentDTO(Apartment apartment) {
            Id = apartment.Id;
            HotelName = apartment.Hotel.Name;
            Name = apartment.Name;
            Description = apartment.Description;
            RoomCount = apartment.RoomCount;
            MaxGuestNumber = apartment.MaxGuestNumber;
        }
    }
}
