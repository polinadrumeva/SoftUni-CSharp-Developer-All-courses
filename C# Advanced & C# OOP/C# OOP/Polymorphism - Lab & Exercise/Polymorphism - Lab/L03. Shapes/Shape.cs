using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        //        Create a class hierarchy, starting with abstract class Shape :
        //•	Abstract methods:
        //o CalculatePerimeter(): double
        //o   CalculateArea() : double
        //•	Virtual methods:
        //o Draw(): string


        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Drawing ";
        }
       
    }
}
