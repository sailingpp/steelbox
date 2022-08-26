using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class SectionBox
    {
        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double tw;

        public double Tw
        {
            get { return tw; }
            set { tw = value; }
        }

        private double area;

        public double Area
        {
            get   
            {
                return this.Width*this.Height-(this.Width-2*this.Tw)*(this.Height-2*this.Tw);
            }
        }
        private double inertiaX;

        public double InertiaX
        {
            get 
            {
                return (this.Width *Math.Pow(this.Height,3) - (this.Width - 2 * this.Tw) * Math.Pow((this.Height - 2 * this.Tw),3))/12; 
            }
        }
        private double inertiaY;

        public double InertiaY
        {
            get
            {
               return (this.Height *Math.Pow(this.Width,3) - (this.Height - 2 * this.Tw) * Math.Pow((this.Width - 2 * this.Tw),3))/12;
            }
        }
        private double ix;

        public double Ix
        {
            get 
            { 
                return Math.Sqrt(this.InertiaX/this.Area);
            }
        }
        private double iy;

        public double Iy
        {
            get
            {
                return Math.Sqrt(this.InertiaY / this.Area);
            }
        }

        public SectionBox(double height,double width,double tw)
        {
            this.Height = height;
            this.Width = width;
            this.Tw = tw;
        }
        public SectionBox() { ;}
        private double flangeWidthThicknessRaio;

        public double FlangeWidthThicknessRaio
        {
            get
            {
                return (this.Width - 2*this.Tw) / (this.Tw);
            }
        }
        private double webWidthThicknessRaio;

        public double WebWidthThicknessRaio
        {
            get 
            {
                return (this.Height - 2 * this.Tw) / (this.Tw);
            }
        }
    }
}
