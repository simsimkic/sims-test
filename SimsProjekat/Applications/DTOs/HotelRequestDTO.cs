using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class HotelRequestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ConstructionYear { get; set; }

        public int Rating { get; set; }

        public string OwnerJmbg { get; set; }

        public Status Status { get; set; }

        public HotelRequestDTO()
        {
        }

        public HotelRequestDTO(Hotel hotel)
        {
            Id = hotel.Id;
            Name = hotel.Name;
            ConstructionYear = hotel.ConstructionYear;
            Rating = hotel.Rating;
            OwnerJmbg = hotel.OwnerJmbg;
            Status = hotel.Status;
        }
    }
}
