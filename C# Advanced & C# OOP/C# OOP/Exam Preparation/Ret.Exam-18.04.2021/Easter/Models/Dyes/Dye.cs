namespace Easter.Models.Dyes
{
    using Easter.Models.Dyes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Dye : IDye
    {
        private int power;
        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                this.power = value;
            }
        }


        public Dye(int power)
        {
            this.Power = power;
        }

        public bool IsFinished()
        {
            if (this.Power == 0)
            {
                return true;
            }

            return false;
        }

        public void Use()
        {
            if (this.Power < 0)
            {
                this.Power = 0;
            }

            this.Power -= 10;
            
        }
    }
}
