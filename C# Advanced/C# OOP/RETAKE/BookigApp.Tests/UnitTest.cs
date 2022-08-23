using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
       
        [TestCase(0)]
        [TestCase(-5)]
        public void RoomBedCapacityShouldThrowExceptionIfIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(capacity, 200);
            });
        }

        [Test]
        public void RoomBedCapacityShouldReturnCorrectData()
        {
            Room room = new Room(2, 200);
            int actualCapacity = room.BedCapacity;
            int expectedCapacity = 2;

            double actualPrice = room.PricePerNight;
            double expectedPrice = 200;

            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedPrice, actualPrice);

        }

        [TestCase(0)]
        [TestCase(-5)]
        public void RoomPriceShouldThrowExceptionIfIsNegative(double price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, price);
            });
        }

        [Test]
        public void BookingShouldReturnCorrectData()
        {
            Room room = new Room(2, 200);
            Booking booking = new Booking(1, room, 10);

            int actualNumber = booking.BookingNumber;
            int expectedNumber = 1;

            Room actualRoom = booking.Room;

            int actualDuration = booking.ResidenceDuration;
            int expectedDuration = 10;

            Assert.AreEqual(expectedNumber, actualNumber);
            Assert.AreEqual(room, actualRoom);
            Assert.AreEqual(expectedDuration, actualDuration);

        }

        [TestCase("   ")]
        [TestCase(null)]
        public void HotelNameShouldThrowExceptionIfValueIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 3);
            });
        }

        [TestCase(0)]
        [TestCase(6)]
        public void HotelCategoryShouldThrowExceptionIfIsNotInRange(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Maria", category);
            });
        }

        [Test]
        public void AddedRoomShouldReturnCorrectData()
        {
            Hotel hotel = new Hotel("Maria", 5);
            Room room = new Room(2, 200);
            hotel.AddRoom(room);

            int actualData = hotel.Rooms.Count;
            int expecedData = 1;

            Assert.AreEqual(expecedData, actualData);

        }

        [TestCase(-2, 2, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(2, -1, 3)]
        [TestCase(2, 2, 0)]
        public void HotelBookRoomShouldThrowExceptionIfValueIsNegative(int adult, int children, int duration)
        {
            Hotel hotel = new Hotel("Maria", 5);
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(adult, children, duration, 200);
            });
        }

        [Test]
        public void BookingShouldBookRoom()
        {
            Hotel hotel = new Hotel("Maria", 5);
            Room room = new Room(2, 200);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 1, 2, 500);

            int actualCount = hotel.Bookings.Count;
            int expectedCount = 1;

            double actualTurnover = hotel.Turnover;
            double expectedTurnover = 400;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedTurnover, actualTurnover);
        }
    }
}