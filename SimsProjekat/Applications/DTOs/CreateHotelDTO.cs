using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class CreateHotelDTO
    {
        public string Name { get; set; }

        public string ConstructionYear { get; set; }

        public string Rating { get; set; }

        public string OwnerJmbg { get; set; }

        public CreateHotelDTO()
        {

        }
    }
}
