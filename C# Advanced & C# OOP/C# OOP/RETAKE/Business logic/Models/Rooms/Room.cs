namespace BookingApp.Models.Rooms
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;


        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get
            {
                return this.pricePerNight;
            }
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.PricePerNightNegative));
                }

                this.pricePerNight = value;
            }
        }

        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }
        public void SetPrice(double price)
        {
           this.PricePerNight = price;  
        }
    }
}
