namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int bedCapacityRoom = 6;
        public Apartment()
            : base(bedCapacityRoom)
        {
        }
    }
}
