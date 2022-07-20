namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>

    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T toRemove = this.data.LastOrDefault();
            if (toRemove != null)
            { 
                this.data.Remove(toRemove);
            }

            return toRemove;
        }
    }
}
