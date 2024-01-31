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
    public class ReservationRepository : IReservationRepository
    {
        private List<Reservation> reservations;

        private IDataHandler<Reservation> reservationDataHandler;

        public ReservationRepository()
        {
            reservationDataHandler = new ReservationDataHandler();
            reservations = reservationDataHandler.GetAll().ToList();
        }

        public List<Reservation> GetAll()
        {
            reservations = reservationDataHandler.GetAll().ToList();
            return reservations;
        }

        public List<Reservation> GetAllByGuestJmbg(string guestJmbg)
        {
            reservations = reservationDataHandler.GetAll().ToList();

            return reservations.Where(r => r.GuestJmbg.Equals(guestJmbg)).ToList();
        }

        public List<Reservation> GetAllByReservationStatus(Status reservationStatus)
        {
            reservations = reservationDataHandler.GetAll().ToList();

            return reservations.Where(r => r.Status.Equals(reservationStatus)).ToList();
        }

        public Reservation GetById(int id)
        {
            reservations = reservationDataHandler.GetAll().ToList();

            return reservations.FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> GetByApartmentId(int apartmentId)
        {
            reservationDataHandler = new ReservationDataHandler();

            reservations = reservationDataHandler.GetAll().ToList();

            return reservations.Where(r => r.ApartmentId == apartmentId).ToList();
        }

        public Reservation Save(Reservation reservation)
        {
            return reservationDataHandler.SaveOneEntity(reservation);
        }

        public void Update(Reservation reservation)
        {
            reservationDataHandler.Update(reservation);
        }

        public void Delete(Reservation entity)
        {
            reservationDataHandler.Delete(entity);
        }
    }
}
