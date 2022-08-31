using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> books { get; set; }

       
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }


        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort();
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
