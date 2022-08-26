using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class SectionH
    {
        //H400x200x8x12
        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        private double tFlange;

        public double TFlange
        {
            get { return tFlange; }
            set { tFlange = value; }
        }
        private double tWidth;

        public double TWidth
        {
            get { return tWidth; }
            set { tWidth = value; }
        }

        public SectionH(double height, double width, double tflange, double twidth)
        {
            this.Height = height;
            this.Width = width;
            this.TFlange = tflange;
            this.TWidth = twidth;
        }
        public SectionH() { ;}
        private double inertiaX;

        public double InertiaX
        {
            get
            {
                return (this.Width * Math.Pow(this.Height, 3) - (this.Width - this.TWidth) * Math.Pow((this.Height - 2 * this.tFlange), 3)) / 12;
            }
        }

        private double interiaY;

        public double InteriaY
        {
            get
            {
                return 2 * this.TFlange * Math.Pow(this.Width, 3) / 12;
            }

        }
        private double area;

        public double Area
        {
            get
            {
                return this.Width * this.Height - (this.Width - this.TWidth) * (this.Height - 2 * this.tFlange);
            }
        }
        private double ix;

        public double Ix
        {
            get
            {
                return Math.Sqrt(this.InertiaX / this.Area);
            }
        }
        private double iy;

        public double Iy
        {
            get
            {
                return Math.Sqrt(this.InteriaY / this.Area);
            }
        }

        private double flangeWidthThicknessRaio;

        public double FlangeWidthThicknessRaio
        {
            get 
            { 
                return (this.Width-this.TWidth)/(2*this.TFlange);
            }
        }
        private double webWidthThicknessRaio;

        public double WebWidthThicknessRaio
        {
            get 
            {
                return (this.Height-2*this.TFlange)/this.TWidth; 
            }
        }
    }
}
