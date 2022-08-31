namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> data;

        public MyList()
        {
            this.data = new List<T>();
        }
        public int Used => this.data.Count;

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T toRemove = this.data.FirstOrDefault();
            if (toRemove != null)
            { 
                this.data.Remove(toRemove);
            }

            return toRemove;
        }
    }
}
