using SimsProjekat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Resources.DBAccess
{
    public class UserDataHandler : IDataHandler<User>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return dataContext.Users.ToList();
        }

        public void Save(IEnumerable<User> entities)
        {
            dataContext.Users.AddRange(entities);

            dataContext.SaveChanges();
        }

        public User SaveOneEntity(User entity)
        {
            if(entity.UserType == UserType.Admin)
            {
                Admin admin = new Admin(entity);

                dataContext.Admins.Add(admin);
            }

            if(entity.UserType == UserType.Owner)
            {
                Owner owner = new Owner(entity);

                dataContext.Owners.Add(owner);
            }

            if(entity.UserType == UserType.Guest)
            {
                Guest guest = new Guest(entity);

                dataContext.Guests.Add(guest);
            }

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(User entity)
        {
            var existingUser = dataContext.Users.Find(entity.Jmbg);

            if (existingUser != null)
            {
                existingUser.IsBlocked = entity.IsBlocked;

                dataContext.SaveChanges();
            }
        }
    }
}
