using System;
using System.Collections.Generic;
using System.Text;

namespace E07.Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }



        public Tuple(TFirst firstelement, TSecond secondelement)
        {
            this.FirstElement = firstelement;
            this.SecondElement = secondelement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}
