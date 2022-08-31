namespace BookingApp.Repositories
{
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class HotelRepository : IRepository<IHotel>
    {
        private readonly IList<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public IReadOnlyCollection<IHotel> Hotels => (List<IHotel>)this.hotels;
        public void AddNew(IHotel model) => this.hotels.Add(model);

        public IReadOnlyCollection<IHotel> All() => (IReadOnlyCollection<IHotel>)this.hotels;    
        public IHotel Select(string criteria)
        {
            IHotel hotel = this.hotels.FirstOrDefault(h => h.FullName == criteria);
            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }
    }
}
