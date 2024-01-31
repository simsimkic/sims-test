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
    public class HotelRepository : IHotelRepository
    {
        private List<Hotel> hotels;

        private readonly IDataHandler<Hotel> hotelDataHandler;

        public HotelRepository()
        {
            hotelDataHandler = new HotelDataHandler();
            hotels = hotelDataHandler.GetAll().ToList();
        }

        public List<Hotel> GetAll()
        {
            hotels = hotelDataHandler.GetAll().ToList();

            return hotels;
        }

        public List<Hotel> GetByOwnerJmbg(string ownerJmbg)
        {
            hotels = hotelDataHandler.GetAll().ToList();

            return hotels.Where(h => h.OwnerJmbg.Equals(ownerJmbg)).ToList();
        }

        public Hotel GetById(int id)
        {
            hotels = hotelDataHandler.GetAll().ToList();

            return hotels.SingleOrDefault(h => h.Id == id);
        }

        public Hotel Save(Hotel hotel)
        {
            return hotelDataHandler.SaveOneEntity(hotel);
        }

        public void Update(Hotel hotel) 
        {
            hotelDataHandler.Update(hotel);
        }

    }
}
