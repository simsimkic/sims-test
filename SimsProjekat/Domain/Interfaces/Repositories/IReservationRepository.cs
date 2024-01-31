using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        public List<Reservation> GetAll();

        public List<Reservation> GetAllByGuestJmbg(string guestJmbg);

        public List<Reservation> GetAllByReservationStatus(Status reservationStatus);

        public Reservation GetById(int id);

        public List<Reservation> GetByApartmentId(int apartmentId);

        public Reservation Save(Reservation reservation);

        public void Update(Reservation reservation);

        public void Delete(Reservation entity);
    }
}
