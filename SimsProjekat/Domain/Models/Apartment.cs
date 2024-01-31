using Microsoft.EntityFrameworkCore;
using SimsProjekat.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("Apartment")]
    [Index(nameof(Name), IsUnique = true)]
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RoomCount { get; set; }
        
        public int MaxGuestNumber {  get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }

        public Apartment()
        {
        }

        public Apartment(int id, string name, string description, int roomCount, int maxGuestNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomCount = roomCount;
            MaxGuestNumber = maxGuestNumber;
        }

        public Apartment(CreateApartmentDTO apartmentDTO)
        {
            Name = apartmentDTO.Name;
            Description = apartmentDTO.Description;

            if (int.TryParse(apartmentDTO.RoomCount, out int parsedRoomCount))
            {
                RoomCount = parsedRoomCount;
            }
            else
            {
                throw new ArgumentException("Invalid room count format");
            }

            if (int.TryParse(apartmentDTO.MaxGuestNumber, out int parsedMaxGuestNumber))
            {
                MaxGuestNumber = parsedMaxGuestNumber;
            }
            else
            {
                throw new ArgumentException("Invalid max guest number format");
            }
        }
        public Apartment(string name, string description, int roomCount, int maxGuestNumber, int hotelId)
        {
            Name = name;
            Description = description;
            RoomCount = roomCount;
            MaxGuestNumber = maxGuestNumber;
            HotelId = hotelId;
        }
    }
}
