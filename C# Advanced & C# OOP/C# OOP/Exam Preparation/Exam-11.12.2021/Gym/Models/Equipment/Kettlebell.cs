using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double weightKettlebell = 10000;
        private const decimal priceKettlebell = 80;
        public Kettlebell() 
            : base(weightKettlebell, priceKettlebell)
        {
        }
    }
}
