namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class BoxingGloves : Equipment
    {
        private const double weightBoxing = 227;
        private const decimal priceBoxing = 120;
        public BoxingGloves() 
            : base(weightBoxing, priceBoxing)
        {
            
        }
    }
}
