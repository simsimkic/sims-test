using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        public User Login(UserDTO userDTO);

        public bool Logout();
    }
}
