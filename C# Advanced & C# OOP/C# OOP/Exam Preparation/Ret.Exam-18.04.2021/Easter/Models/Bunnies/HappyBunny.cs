namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class HappyBunny : Bunny
    {
        private const int energyHappyBunny = 100;
        public HappyBunny(string name) 
            : base(name, energyHappyBunny)
        {
        }

        public override void Work()
        {
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }

            this.Energy -= 10;
        }
    }
}
