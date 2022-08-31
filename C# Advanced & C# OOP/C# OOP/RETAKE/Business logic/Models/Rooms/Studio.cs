namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int bedCapacityRoom = 4;
        public Studio() 
            : base(bedCapacityRoom)
        {
        }
    }
}
