using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("Guest")]
    public class Guest : User
    {
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Guest()
        {
        }

        public Guest(User user) : base(user.Jmbg, user.Email, user.Password, user.FirstName, user.LastName, user.PhoneNumber)
        {
            UserType = UserType.Guest;
            Reservations = new List<Reservation>();
        }
    }
}
