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
    public interface IApartmentService
    {
        public bool CreateApartment(string name, string description, int roomCount, int maxGuestNumber, int hotelId);
        public List<ApartmentDTO> GetAll();
    }
}
