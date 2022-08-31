using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea(double length, double width, double height)
        {
            double resultSurfaceArea = (2 * (this.Length * this.Width)) + (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return resultSurfaceArea;
        }

        public double LateralSurfaceArea(double length, double width, double height)
        {
            double resultLateralArea = (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return resultLateralArea;
        }

        public double Volume(double length, double width, double height)
        { 
            double resultVolume = this.Length * this.Width * this.Height;
            return resultVolume;    
        }
    }
}
