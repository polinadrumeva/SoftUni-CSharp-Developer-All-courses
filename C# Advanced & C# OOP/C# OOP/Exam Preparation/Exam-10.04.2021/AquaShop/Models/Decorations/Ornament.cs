namespace AquaShop.Models.Decorations
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Ornament : Decoration
    {
        private const int comfortOrnamment = 1;
        private const decimal priceOrnament = 5;
        public Ornament()
            : base(comfortOrnamment, priceOrnament)
        {
        }
    }
}
