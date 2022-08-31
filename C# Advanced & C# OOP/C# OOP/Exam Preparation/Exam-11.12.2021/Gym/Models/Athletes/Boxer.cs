namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Boxer : Athlete
    {
        private const int increaseBoxer = 15;
        private const int boxerStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, boxerStamina, numberOfMedals)
        {
           
        }

        public override void Exercise()
        {
            this.Stamina += increaseBoxer;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
