using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Services;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Controllers
{
    public class ApartmentReservationController
    {
        private readonly IApartmentReservationService _apartmentReservationService;

        public ApartmentReservationController(IApartmentReservationService apartmentReservationService)
        {
            _apartmentReservationService = apartmentReservationService;
        }

        public List<ReservationDTO> GetAllReservations(string guestJmbg, string reservationStatus)
        {
            return _apartmentReservationService.GetAllReservationsForGuest(guestJmbg, reservationStatus);
        }

        public List<ReservationDTO> GetAllReservationsByStatus(string reservationStatus)
        {
            return _apartmentReservationService.GetAllReservationsByStatus(reservationStatus);
        }

        public bool BookApartment(string guestJmbg, int apartmentId, DateTime reservationDate)
        {
            return _apartmentReservationService.BookApartment(guestJmbg, apartmentId, reservationDate);
        }

        public bool CancelReservation(int reservationId)
        {
            return _apartmentReservationService.CancelReservation(reservationId);
        }

        public bool RejectReservation(int reservationId, string rejectionReason)
        {
            return _apartmentReservationService.RejectReservation(reservationId, rejectionReason);
        }

        public bool AcceptReservation(int reservationId)
        {
            return _apartmentReservationService.AcceptReservation(reservationId);
        }
    }
}
