namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Weightlifter : Athlete
    {
        private const int increaseWeightlifter = 10;
        private const int weightlifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, weightlifterStamina, numberOfMedals)
        {
           
        }

        public override void Exercise()
        {
            this.Stamina += increaseWeightlifter;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
