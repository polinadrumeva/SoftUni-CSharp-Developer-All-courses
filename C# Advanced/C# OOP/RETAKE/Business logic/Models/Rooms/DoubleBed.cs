namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int bedCapacityRoom = 2;
        public DoubleBed()
            : base(bedCapacityRoom)
        {
        }
    }
}
