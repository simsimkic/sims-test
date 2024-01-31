using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Services;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Controllers
{
    public class ApartmentController
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public List<ApartmentDTO> GetAll()
        {
            return _apartmentService.GetAll();
        }

        public bool CreateApartment(string name, string description, int roomCount, int maxGuestNumber, int hotelId)
        {
            return _apartmentService.CreateApartment(name, description, roomCount, maxGuestNumber, hotelId);
        }
    }
}
