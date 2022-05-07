using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03._Shapes
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

        public double Height { get; private set; }

        public double Width { get; private set; }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculatePerimeter()
        {
            return Height + Width;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override string Draw()
        {
            return base.Draw() + " " + "Rectangle";
        }
    }
}
