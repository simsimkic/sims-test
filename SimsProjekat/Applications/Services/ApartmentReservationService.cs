using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Services
{
    public class ApartmentReservationService : IApartmentReservationService
    {
        private readonly IApartmentRepository _apartmentRepository;

        private readonly IReservationRepository _reservationRepository;

        public ApartmentReservationService(IApartmentRepository apartmentRepository, IReservationRepository reservationRepository)
        {
            _apartmentRepository = apartmentRepository;
            _reservationRepository = reservationRepository;
        }
    
        public List<ReservationDTO> GetAllReservationsForGuest(string guestJmbg, string reservationStatus)
        {
            List<Reservation> reservations = _reservationRepository.GetAllByGuestJmbg(guestJmbg);

            List<ReservationDTO> reservationDTOs = reservations.Select(reservation => new ReservationDTO(reservation, _apartmentRepository.GetById(reservation.ApartmentId))).ToList();

            List<ReservationDTO> reservationsByReservationStatus = GetAllReservationsByStatus(reservationStatus);

            reservationDTOs = reservationDTOs.Join(
            reservationsByReservationStatus,
            res1 => res1.Id,
            res2 => res2.Id,
            (res1, res2) => res1
            ).ToList();

            return reservationDTOs;
        }

        public List<ReservationDTO> GetAllReservationsByStatus(string reservationStatus)
        {
            List<Reservation> reservations = new List<Reservation>();

            if (Enum.TryParse(reservationStatus, true, out Status parsedStatus) || string.IsNullOrEmpty(reservationStatus))
            {
                if (parsedStatus == Status.Confirmed || string.IsNullOrEmpty(reservationStatus))
                {
                    reservations.AddRange(_reservationRepository.GetAllByReservationStatus(Status.Confirmed));
                }

                if (parsedStatus == Status.Pending || string.IsNullOrEmpty(reservationStatus))
                {
                    reservations.AddRange(_reservationRepository.GetAllByReservationStatus(Status.Pending));
                }
            }

            List<ReservationDTO> reservationDTOs = reservations
                .Select(reservation => new ReservationDTO(reservation, _apartmentRepository.GetById(reservation.ApartmentId)))
                .ToList();

            return reservationDTOs;
        }

        public bool BookApartment(string guestJmbg, int apartmentId, DateTime reservationDate)
        {
            List<Reservation> reservations = _reservationRepository.GetAll();

            foreach (Reservation r in reservations)
            {
                if (r.ApartmentId == apartmentId && r.ReservationDate.Date.Equals(reservationDate.Date))
                {
                    return false;
                }
            }

            Reservation reservation = new Reservation(guestJmbg, apartmentId, reservationDate);

            return _reservationRepository.Save(reservation) != null;
        }
        public bool CancelReservation(int reservationId)
        {
            Reservation reservationToCancel = _reservationRepository.GetById(reservationId);

            if (reservationToCancel.Status.Equals(Status.Rejected))
            {
                return false;
            }

            try
            {
                _reservationRepository.Delete(reservationToCancel);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool RejectReservation(int reservationId, string rejectionReason)
        {
            Reservation reservationToCancel = _reservationRepository.GetById(reservationId);

            if (reservationToCancel.Status.Equals(Status.Rejected) || reservationToCancel.Status.Equals(Status.Confirmed))
            {
                return false;   
            }

            reservationToCancel.Status = Status.Rejected;
            reservationToCancel.RejectionReason = rejectionReason;
            try
            {
                _reservationRepository.Update(reservationToCancel);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool AcceptReservation(int reservationId)
        {
            Reservation reservationToCancel = _reservationRepository.GetById(reservationId);

            if (reservationToCancel.Status.Equals(Status.Rejected) || reservationToCancel.Status.Equals(Status.Confirmed))
            {
                return false;
            }

            reservationToCancel.Status = Status.Confirmed;
            try
            {
                _reservationRepository.Update(reservationToCancel);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
