using System;
using System.Collections.Generic;
using System.Text;

namespace E07.RawData
{
    public class Tires
    {
        public int Age { get; set; }

        public double Pressure { get; set; }

        public Tires(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
