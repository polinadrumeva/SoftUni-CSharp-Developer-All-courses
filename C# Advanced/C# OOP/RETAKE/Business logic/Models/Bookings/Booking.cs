namespace BookingApp.Models.Bookings
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultCount;
        private int childCount;
        private int bookingNUmber;
        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get
            {
                return this.residenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.DurationZeroOrLess));
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.AdultsZeroOrLess));
                }

                this.adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.ChildrenNegative));
                }

                this.childCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.Append($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }

        public double TotalPaid()
        {
            double totalAmount = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
            return totalAmount;
        }
    }
}
