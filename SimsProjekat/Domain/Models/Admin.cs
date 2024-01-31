using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Models
{
    [Table("Admin")]
    public class Admin : User
    {

        public Admin() { }

        public Admin(User user) : base(user.Jmbg, user.Email, user.Password, user.FirstName, user.LastName, user.PhoneNumber)
        {
            UserType = UserType.Admin;
        }
    }
}
