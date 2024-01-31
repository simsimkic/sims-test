using SimsProjekat.Applications.DTOs;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public User GetByJmbg(string jmbg)
        {
            return _userRepository.GetByJmbg(jmbg);
        }

        public List<UserDisplayDTO> GetUsers(string userType, string adminJmbg)
        {
            List<User> users = new List<User>();

            if (userType.Equals("Guest") || userType.Equals("Owner"))
            {
                UserType type;

                if(Enum.TryParse(userType, true, out type))
                {
                    users = _userRepository.GetAll().Where(user => user.UserType == type).ToList();
                }
            }else
            {
                users = _userRepository.GetAll();
            }
            
            users.Remove(_userRepository.GetByJmbg(adminJmbg));

            return users.Select(user => new UserDisplayDTO(user)).ToList();
        }

        public void BlockUnblockUser(string jmbg)
        {
            User userToBlock = _userRepository.GetByJmbg(jmbg);

            if (userToBlock.IsBlocked)
            {
                userToBlock.IsBlocked = false;
            }
            else
            {
                userToBlock.IsBlocked = true;
            }

            _userRepository.Update(userToBlock);
        }

        public bool SaveUser(CreateUserDTO user)
        {
            var existingJmbgUser = _userRepository.GetByJmbg(user.Jmbg);

            var existingEmailUser = _userRepository.GetByEmail(user.Email);

            if (existingJmbgUser == null && existingEmailUser == null)
            {
                if (Enum.TryParse(user.UserType, true, out UserType type))
                {
                    User newUser = new User(user, type);

                    return _userRepository.Save(newUser) != null;
                }
            }
            
            return false;
        }
    }
}
