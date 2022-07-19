using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        //        •	Fields: 
        //o height and width for Rectangle
        //o   radius for Circle
        //•	Encapsulation for these fields
        //•	A public constructor 
        //•	Concrete methods for calculations(perimeter and area)
        //•	Override methods for drawing
        private double height;
        private double width;   

        public double Height 
        {
            get
            {
                return this.height;
            }
            private set
            { 
                 this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            { 
            this.width = value;
            }
        }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Width + this.Height) * 2;
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
