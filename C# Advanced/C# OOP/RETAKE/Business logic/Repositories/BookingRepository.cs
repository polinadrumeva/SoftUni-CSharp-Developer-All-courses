namespace BookingApp.Repositories
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class BookingRepository : IRepository<IBooking>
    {
        private readonly IList<IBooking> booking;

        public BookingRepository()
        {
            this.booking = new List<IBooking>();
        }

        public IReadOnlyCollection<IBooking> Booking => (List<IBooking>) this.booking;
        public void AddNew(IBooking model) => this.booking.Add(model);

        public IReadOnlyCollection<IBooking> All() => (IReadOnlyCollection<IBooking>)this.booking;

        public IBooking Select(string criteria)
        {
            IBooking booking = this.booking.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
            if (booking != null)
            { 
                return booking;
            }

            return null;
        }
    }
}
