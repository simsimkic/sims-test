using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimsProjekat.Domain.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        public List<Hotel> GetAll();

        public List<Hotel> GetByOwnerJmbg(string ownerJmbg);

        public Hotel GetById(int id);

        public Hotel Save(Hotel hotel);

        public void Update(Hotel hotel);
    }
}
