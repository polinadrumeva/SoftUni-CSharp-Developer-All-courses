using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01.Shapes
{
    public class Circle : IDrawable
    {
        public int Radius { get; private set; }
       
        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public void Draw()
        {
            double rin = this.Radius - 0.4;
            double rout = this.Radius + 0.4;

            
            for (double i = this.Radius; i >= -this.Radius; --i)
            {
                for (double j = -this.Radius; j < rout; j += 0.5)
                {
                    var distance = (i * i) + (j * j);
                    if (distance >= rin * rin && distance <= rout * rout)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
