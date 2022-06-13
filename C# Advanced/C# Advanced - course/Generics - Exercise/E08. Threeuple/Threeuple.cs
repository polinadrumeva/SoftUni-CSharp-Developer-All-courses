using System;
using System.Collections.Generic;
using System.Text;

namespace E08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }
        public TThird ThirdElement { get; private set; }


        public Threeuple(TFirst firstelement, TSecond secondelement, TThird thirdelement)
        {
            this.FirstElement = firstelement;
            this.SecondElement = secondelement;
            this.ThirdElement = thirdelement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
