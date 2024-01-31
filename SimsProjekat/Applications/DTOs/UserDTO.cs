using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserDTO() { }
    }
}
