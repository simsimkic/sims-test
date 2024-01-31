using SimsProjekat.Applications.DTOs;
using SimsProjekat.Applications.Services;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Applications.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserDisplayDTO> GetAll(string userType, string adminJmbg)
        {
            return _userService.GetUsers(userType, adminJmbg);
        }

        public void BlockUnblockUser(string jmbg)
        {
            _userService.BlockUnblockUser(jmbg);
        }

        public bool CreateOwner(CreateUserDTO newUser)
        {
            return _userService.SaveUser(newUser);
        }
    }
}
