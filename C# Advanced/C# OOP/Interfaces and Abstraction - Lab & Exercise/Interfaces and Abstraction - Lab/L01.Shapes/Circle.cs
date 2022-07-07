using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public int Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = value;
            }
        }

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public void Draw()
        {
            double rin = this.radius - 0.4;
            double rout = this.radius + 0.4;

            
            for (double i = this.radius; i >= -this.radius; --i)
            {
                for (double j = -this.radius; j < rout; j += 0.5)
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
