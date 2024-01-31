using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Repositories
{
    public interface IApartmentRepository
    {
        public List<Apartment> GetAll();

        public Apartment GetById(int id);

        public Apartment Save(Apartment newApartment);
    }
}
