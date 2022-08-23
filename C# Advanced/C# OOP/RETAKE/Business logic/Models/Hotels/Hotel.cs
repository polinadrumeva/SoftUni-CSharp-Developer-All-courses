namespace BookingApp.Models.Hotels
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCategory));
                }

                this.category = value;
            }
        }

        public double Turnover
        {
            get 
            {
                List<IBooking> allBooking = (List<IBooking>)this.bookings.All();
                double total = Math.Round(allBooking.Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);
                return total;
            }
            
        }

        public IRepository<IRoom> Rooms { get => this.rooms; set => this.rooms = value; }
        public IRepository<IBooking> Bookings { get => this.bookings; set => this.bookings = value; }

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }
    }
}
