using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("Owner")]
    public class Owner : User
    {
        public virtual ICollection<Hotel> Hotels { get; set; }

        public Owner()
        {
        }

        public Owner(User user) : base(user.Jmbg, user.Email, user.Password, user.FirstName, user.LastName, user.PhoneNumber)
        {
            Hotels = new List<Hotel>();
            UserType = UserType.Owner;
        }
    }
}
