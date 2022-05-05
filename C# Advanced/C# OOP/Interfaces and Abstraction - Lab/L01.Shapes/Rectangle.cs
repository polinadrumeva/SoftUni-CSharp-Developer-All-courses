using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01.Shapes
{
    public class Rectangle : IDrawable
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));
            
                for (int j = 0; j < this.Height - 2; j++)
                {
                    Console.WriteLine("*" + new string(' ', this.Width - 2) + "*");
                }

            Console.WriteLine(new string('*', this.Width));
        }

    }
}
