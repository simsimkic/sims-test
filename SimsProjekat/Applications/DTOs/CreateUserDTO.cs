using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class CreateUserDTO
    {
        public string Jmbg { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserType { get; set; }

        public CreateUserDTO()
        {
        }

        public CreateUserDTO(string jmbg, string email, string password, string firstName, string lastName, string phoneNumber, string userType)
        {
            Jmbg = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            UserType = userType;
        }
    }
}
