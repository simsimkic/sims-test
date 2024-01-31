using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class CreateApartmentDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string RoomCount { get; set; }

        public string MaxGuestNumber { get; set; }

        public CreateApartmentDTO()
        {

        }
    }
}
