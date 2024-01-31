using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Resources.DBAccess
{
    public class ApartmentDataHandler : IDataHandler<Apartment>
    {
        private readonly DataContext dataContext = new DataContext();

        public void Delete(Apartment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Apartment> GetAll()
        {
            return dataContext.Apartments.ToList();
        }

        public void Save(IEnumerable<Apartment> entities)
        {
            dataContext.Apartments.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Apartment SaveOneEntity(Apartment entity)
        {
            dataContext.Apartments.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Apartment entity)
        {
            throw new NotImplementedException();
        }
    }
}
