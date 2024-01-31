using SimsProjekat.Applications.Services;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Controllers
{
    public class LoginController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public User Login(string email, string password)
        {
            return _loginService.Login(new DTOs.UserDTO(email, password));
        }

        public bool Logout()
        {
            return _loginService.Logout();
        }
    }
}
