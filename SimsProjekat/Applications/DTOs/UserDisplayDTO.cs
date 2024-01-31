using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class UserDisplayDTO
    {
        public string Jmbg { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        public string IsBlocked {  get; set; }

        public UserDisplayDTO(User user) 
        {
            Jmbg = user.Jmbg;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            UserType = user.UserType;
            IsBlocked = (user.IsBlocked == true) ? "Yes" : "No";
        }
    }
}
