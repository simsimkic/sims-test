using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Resources.DBAccess
{
    public class HotelDataHandler : IDataHandler<Hotel>
    {
        private readonly DataContext dataContext = new DataContext();

        public void Delete(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetAll()
        {
            return dataContext.Hotels.ToList();
        }

        public void Save(IEnumerable<Hotel> entities)
        {
            dataContext.Hotels.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Hotel SaveOneEntity(Hotel entity)
        {
            dataContext.Hotels.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Hotel entity)
        {
            var existingHotel = dataContext.Hotels.Find(entity.Id);

            if (existingHotel != null)
            {
                existingHotel.Status = entity.Status;

                dataContext.SaveChanges();
            }
        }
    }
}
