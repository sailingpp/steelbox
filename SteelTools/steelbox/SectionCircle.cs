using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class SectionCircle
    {
        private double diameter;

        public double Diameter
        {
            get { return diameter; }
            set { diameter = value; }
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
                return 3.14 * (this.Diameter * this.Diameter - (this.Diameter - 2 * this.Tw) * (this.Diameter - 2 * this.Tw)) / 4;
            }
        }
        private double inertiaX;

        public double InertiaX
        {
            get 
            {
                return 3.14 * (Math.Pow(this.Diameter,4) - Math.Pow((this.Diameter - 2 * this.Tw),4)) / 64;
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
        public SectionCircle(double diameter, double tw)
        {
            this.Diameter = diameter;
            this.Tw = tw;
        }
        private double diameterThicknessRatio;

        public double DiameterThicknessRatio
        {
            get
            {
                return (this.Diameter) / (this.Tw);
            }
           
        }
        public SectionCircle() { ;}
    }
}
