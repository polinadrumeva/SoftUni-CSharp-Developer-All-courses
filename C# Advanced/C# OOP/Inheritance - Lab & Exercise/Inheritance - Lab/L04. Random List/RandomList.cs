using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;
        public Random Random { get; set; }

        public RandomList(Random random)
        {
            this.Random = random;
        }

        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
            

    }
}
