namespace BookingApp.Core
{
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
                this.hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.Select(hotelName) != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);
            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> orderHotels = (List<IHotel>)this.hotels.All();
            orderHotels.OrderBy(h => h.FullName);
            List<IRoom> rooms = new List<IRoom>();
            List<IHotel> hotels = new List<IHotel>();

            foreach (var hotel in orderHotels)
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        rooms.Add(room);
                        hotels.Add(hotel);
                    }
                }
            }

            List<IRoom> orderRooms = rooms.OrderBy(r => r.BedCapacity).ToList();
            if (orderRooms.Count == 0)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            IRoom roomSelect = null;
            foreach (var room in orderRooms)
            {
                if (room.BedCapacity >= adults + children)
                {
                    roomSelect = room;
                    break;
                }
            }

            if (roomSelect == null)
            {
                return String.Format(OutputMessages.RoomNotAppropriate);
            }


            IHotel hotelSelect = null;
            foreach (var hotel in hotels)
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.GetType().Name == roomSelect.GetType().Name && room.PricePerNight == roomSelect.PricePerNight)
                    {
                        hotelSelect = hotel;
                        break;
                    }
                }
            }

            int bookNumber = hotelSelect.Bookings.All().Count + 1;
            IBooking booking = new Booking(roomSelect, duration, adults, children, bookNumber);
            hotelSelect.Bookings.AddNew(booking);
            return String.Format(OutputMessages.BookingSuccessful, bookNumber, hotelSelect.FullName);
        }

        public string HotelReport(string hotelName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = this.hotels.Select(hotelName);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Hotel name: {hotel.FullName}");
            stringBuilder.AppendLine($"--{hotel.Category} star hotel");
            stringBuilder.AppendLine($"--Turnover: {hotel.Turnover:f2} $");

            if (hotel.Bookings.All().Count == 0)
            {
                stringBuilder.AppendLine($"--Bookings:");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"none");
            }
            else
            {
                stringBuilder.AppendLine($"--Bookings:");
                stringBuilder.AppendLine();

                foreach (var booking in hotel.Bookings.All())
                {
                    stringBuilder.AppendLine(booking.BookingSummary());
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString().TrimEnd();

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = this.hotels.Select(hotelName);
            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" && roomTypeName != "Apartment")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RoomTypeIncorrect));
            }


            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return String.Format(OutputMessages.RoomTypeNotCreated);
            }


            //List<IRoom> roomsSet = hotel.Rooms.All().Where(r=>r.GetType().Name == roomTypeName).ToList();

            //foreach (var room in roomsSet)
            //{
            //    if (room.PricePerNight == 0)
            //    {
            //        room.SetPrice(price);
            //    }
            //    else
            //    {
            //        throw new InvalidOperationException(String.Format(ExceptionMessages.PriceAlreadySet));
            //    }
            //}

            IRoom roomSearch = hotel.Rooms.Select(roomTypeName);
            if (roomSearch.PricePerNight != 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PriceAlreadySet));
            }

            roomSearch.SetPrice(price);
            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;
            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();

            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RoomTypeIncorrect));
            }


            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
