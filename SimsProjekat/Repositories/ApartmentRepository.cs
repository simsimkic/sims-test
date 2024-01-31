using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private List<Apartment> apartments;

        private readonly IDataHandler<Apartment> apartmentDataHandler;

        public ApartmentRepository()
        {
            apartmentDataHandler = new ApartmentDataHandler();
            apartments = apartmentDataHandler.GetAll().ToList();
        }

        public List<Apartment> GetAll()
        {
            apartments = apartmentDataHandler.GetAll().ToList();

            return apartments;
        }

        public Apartment GetById(int id)
        {
            apartments = apartmentDataHandler.GetAll().ToList();

            return apartments.FirstOrDefault(a => a.Id == id);
        }

        public Apartment Save(Apartment newApartment)
        {
            return apartmentDataHandler.SaveOneEntity(newApartment);
        }
    }
}
