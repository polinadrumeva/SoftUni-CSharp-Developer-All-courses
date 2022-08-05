namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class WeightliftingGym : Gym
    {
        private const int weightliftingCapacity = 20;
        public WeightliftingGym(string name) 
            : base(name, weightliftingCapacity)
        {
        }
    }
}
