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
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ConstructionYear { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public int Rating { get; set; }

        public string OwnerJmbg { get; set; }

        [ForeignKey("OwnerJmbg")]
        public virtual Owner Owner { get; set; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public Hotel() { }

        public Hotel(int id, string name, int constructionYear, ICollection<Apartment> apartments, int rating, string ownerJmbg, Owner owner)
        {
            Id = id;
            Name = name;
            ConstructionYear = constructionYear;
            Apartments = apartments;
            Rating = rating;
            OwnerJmbg = ownerJmbg;
            Owner = owner;
            Status = Status.Confirmed;
        }

        public Hotel(CreateHotelDTO hotelDTO)
        {
            Name = hotelDTO.Name;
            if (int.TryParse(hotelDTO.ConstructionYear, out int parsedConstructionYear))
            {
                ConstructionYear = parsedConstructionYear;
            }
            else
            {
                throw new ArgumentException("Invalid construction year format");
            }

            if (int.TryParse(hotelDTO.Rating, out int parsedRating))
            {
                Rating = parsedRating;
            }
            else
            {
                throw new ArgumentException("Invalid rating format");
            }

            OwnerJmbg = hotelDTO.OwnerJmbg;

            Status = Status.Pending;
        }
    }
}
