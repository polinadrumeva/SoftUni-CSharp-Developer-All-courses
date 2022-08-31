namespace BookingApp.Repositories
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class RoomRepository : IRepository<IRoom>
    {
        private readonly IList<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public IReadOnlyCollection<IRoom> Rooms => (List<IRoom>)this.rooms;

        public void AddNew(IRoom model) => this.rooms.Add(model);

        public IReadOnlyCollection<IRoom> All() => (IReadOnlyCollection<IRoom>)this.rooms;

        public IRoom Select(string criteria)
        {
            IRoom room = this.rooms.FirstOrDefault(r => r.GetType().Name == criteria);
            if (room != null)
            { 
                return room;
            }

            return null;
        }
    }
}
