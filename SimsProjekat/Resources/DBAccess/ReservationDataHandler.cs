using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Resources.DBAccess
{
    public class ReservationDataHandler : IDataHandler<Reservation>
    {
        private readonly DataContext dataContext = new DataContext();

        public void Delete(Reservation entity)
        {
            dataContext.Reservations.Remove(entity);

            dataContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return dataContext.Reservations.ToList();
        }

        public void Save(IEnumerable<Reservation> entities)
        {
            dataContext.Reservations.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Reservation SaveOneEntity(Reservation entity)
        {
            dataContext.Reservations.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Reservation entity)
        {
            var existingReservation = dataContext.Reservations.Find(entity.Id);

            if (existingReservation != null)
            {
                existingReservation.Status = entity.Status;
                existingReservation.RejectionReason = entity.RejectionReason;

                dataContext.SaveChanges();
            }
        }
    }
}
