using Microsoft.EntityFrameworkCore.Proxies.Internal;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public ApartmentDTO Apartment { get; set; }

        public string ReservationDate { get; set; }

        public Status Status { get; set; }

        public string RejectionReason { get; set; }

        public ReservationDTO(Reservation reservation, Apartment apartment)
        {
            Id = reservation.Id;
            Apartment = new ApartmentDTO(apartment);
            ReservationDate = reservation.ReservationDate.Date.ToString("dd.MM.yyyy");
            Status = reservation.Status;
            RejectionReason = reservation.RejectionReason;
        }

        public ReservationDTO()
        {
        }
    }
}
