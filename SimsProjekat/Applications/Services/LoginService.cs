using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Util;
using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Login(UserDTO userDTO)
        {
            var userByEmail = _userRepository.GetByEmail(userDTO.Email);
            var userByPassword = _userRepository.GetByPassword(userDTO.Password);

            if (userByEmail != null && userByPassword != null && userByEmail.Equals(userByPassword))
            {
                UserSession.User = userByEmail;
            }
            else
            {
                return null;
            }

            return userByEmail;
        }

        public bool Logout()
        { 
            if(UserSession.User == null) {
                return false;
            }

            UserSession.User = null;

            return true;
        }

    }
}
