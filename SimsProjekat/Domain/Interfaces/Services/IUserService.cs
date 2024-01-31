using SimsProjekat.Applications.DTOs;
using SimsProjekat.Domain.Models;
using SimsProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public User GetByJmbg(string jmbg);

        public List<UserDisplayDTO> GetUsers(string userType, string adminJmbg);

        public void BlockUnblockUser(string jmbg);

        public bool SaveUser(CreateUserDTO user);
      
    }
}
