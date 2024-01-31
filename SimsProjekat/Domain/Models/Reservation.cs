using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string GuestJmbg { get; set; }

        [ForeignKey("GuestJmbg")]
        public virtual Guest Guest { get; set; }

        public int ApartmentId { get; set; }

        [ForeignKey("ApartmentId")]
        public virtual Apartment Apartment { get; set; }

        public DateTime ReservationDate { get; set; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public string RejectionReason { get; set; }

        public Reservation()
        {
        }

        public Reservation(Guest guest, Apartment apartment, DateTime reservationDate)
        {
            Guest = guest;
            Apartment = apartment;
            ReservationDate = reservationDate;
            Status = Status.Pending;
            RejectionReason = "";
        }

        public Reservation(string guestJmbg, int apartmentId, DateTime reservationDate)
        {
            GuestJmbg = guestJmbg;
            ApartmentId = apartmentId;
            ReservationDate = reservationDate;
            Status = Status.Pending;
            RejectionReason = "";
        }

        public bool Equals(int id)
        {
            return Id == id;
        }

        public bool EqualsByGuestJmbg(string guestJmbg)
        {
            return GuestJmbg.Equals(guestJmbg);
        }

        public bool EqualsByApartmentId(int apartmentId)
        {
            return ApartmentId == apartmentId;
        }
    }
}
