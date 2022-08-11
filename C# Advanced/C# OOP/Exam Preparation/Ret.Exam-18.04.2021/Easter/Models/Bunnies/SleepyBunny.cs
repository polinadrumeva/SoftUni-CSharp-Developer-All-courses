namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SleepyBunny : Bunny
    {
        private const int energySleepyBunny = 50;

        public SleepyBunny()
        {
        }

        public SleepyBunny(string name)
            : base(name, energySleepyBunny)
        {
        }

        public override void Work()
        {
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
            this.Energy -= 15;
        }
    }
}
