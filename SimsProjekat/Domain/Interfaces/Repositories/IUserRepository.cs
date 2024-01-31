using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();

        public User GetByJmbg(string jmbg);

        public User GetByEmail(string email);

        public User GetByPassword(string Password);

        public void Update(User user);

        public User Save(User user);
    }
}
