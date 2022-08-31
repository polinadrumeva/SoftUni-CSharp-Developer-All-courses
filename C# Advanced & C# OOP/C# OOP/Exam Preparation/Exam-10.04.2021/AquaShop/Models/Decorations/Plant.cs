namespace AquaShop.Models.Decorations
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Plant : Decoration
    {
        private const int comfortPlant = 5;
        private const decimal pricePlant = 10;

        public Plant()
            : base(comfortPlant, pricePlant)
        {
        }
    }
}
