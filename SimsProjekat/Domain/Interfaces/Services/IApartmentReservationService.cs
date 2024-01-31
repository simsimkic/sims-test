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
    public interface IApartmentReservationService
    {
        public List<ReservationDTO> GetAllReservationsForGuest(string guestJmbg, string reservationStatus);

        public List<ReservationDTO> GetAllReservationsByStatus(string reservationStatus);

        public bool BookApartment(string guestJmbg, int apartmentId, DateTime reservationDate);

        public bool CancelReservation(int reservationId);

        public bool RejectReservation(int reservationId, string rejectionReason);

        public bool AcceptReservation(int reservationId);
    }
}
