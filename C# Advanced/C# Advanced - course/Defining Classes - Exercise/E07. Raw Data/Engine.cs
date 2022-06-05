using System;
using System.Collections.Generic;
using System.Text;

namespace E07.RawData
{
    public class Engine
    {
        public double Speed { get; set; }

        public double Power { get; set; }

        public Engine(double speed, double Power)
        {
            this.Power = Power;
            this.Speed = speed;
        }
    }
}
