using SimsProjekat.Applications.DTOs;
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
    public class ApartmentService : IApartmentService
    {
        private IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public bool CreateApartment(string name, string description, int roomCount, int maxGuestNumber, int hotelId)
        {
            Apartment newApartment = new Apartment(name, description, roomCount, maxGuestNumber, hotelId);

            return _apartmentRepository.Save(newApartment) != null;
        }

        public List<ApartmentDTO> GetAll()
        {
            List<Apartment> apartments = _apartmentRepository.GetAll();

            List<ApartmentDTO> apartmentDTOs = apartments.Select(apartment => new ApartmentDTO(apartment)).ToList();

            return apartmentDTOs;
        }
    }
}
