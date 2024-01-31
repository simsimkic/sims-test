using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;

        private readonly IDataHandler<User> userDataHandler;

        public UserRepository()
        {
            userDataHandler = new UserDataHandler();
            users = userDataHandler.GetAll().ToList();
        }
        public List<User> GetAll()
        {
            users = userDataHandler.GetAll().ToList();
            return users;
        }

        public User GetByJmbg(string jmbg)
        {
            return users.FirstOrDefault(user => user.EqualsJmbg(jmbg));
        }

        public User GetByEmail(string email)
        {
            return users.FirstOrDefault(user => user.EqualsEmail(email));
        }

        public User GetByPassword(string Password)
        {
            return users.FirstOrDefault(user => user.EqualsPassword(Password));
        }

        public void Update(User user)
        {
            userDataHandler.Update(user);
        }

        public User Save(User user)
        {
            return userDataHandler.SaveOneEntity(user);
        }

    }
}
