using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class AxisForce
    {
        double Nforce;
        double L0;
        double i;
        double Area;
        double fai;
        double lamda;
        string sectionType;
        private double a1;

        public double A1
        {
            get
            { return GetA1(); }
        }
        private double a2;

        public double A2
        {
            get { return GetA2(); }
        }
        private double a3;

        public double A3
        {
            get { return GetA3(); }
        }

        private double lamdaN;

        public double LamdaN
        {
            get { return lamda / 3.14 * Math.Sqrt(this.Fy / Es); }
        }

        private double fy;

        public double Fy
        {
            get
            {
                return GetFy();
            }

        }
        double Es = 206000;
        string steelFy;

        public string SteelFy
        {
            get { return steelFy; }
            set { steelFy = value; }
        }
        public double GetA1()
        {
            if (sectionType == "a类")
            {
                return 0.41;
            }
            else if (sectionType == "b类")
            {
                return 0.65;
            }
            else if (sectionType == "c类")
            {
                return 0.73;
            }
            else
            {
                return 1.35;
            }
        }
        public double GetA2()
        {
            if (sectionType == "a类")
            {
                return 0.986;
            }
            else if (sectionType == "b类")
            {
                return 0.965;
            }
            else if (sectionType == "c类")
            {
                if (lamda <= 1.05)
                {
                    return 0.965;
                }
                else
                {
                    return 1.216;
                }
            }
            else
            {
                if (lamda <= 1.05)
                {
                    return 0.595;
                }
                else
                {
                    return 0.302;
                }
            }
        }
        public double GetA3()
        {
            if (sectionType == "a类")
            {
                return 0.152;
            }
            else if (sectionType == "b类")
            {
                return 0.300;
            }
            else if (sectionType == "c类")
            {
                if (lamda <= 1.05)
                {
                    return 0.595;
                }
                else
                {
                    return 0.302;
                }
            }
            else
            {
                if (lamda <= 1.05)
                {
                    return 0.915;
                }
                else
                {
                    return 0.432;
                }
            }
        }

        public AxisForce(string sectionType, double lamda, string steelfy)
        {
            this.sectionType = sectionType;
            this.lamda = lamda;
            this.SteelFy = steelFy;
        }
        public AxisForce(double l0, double area, double i, double nforce)
        {
            this.L0 = l0;
            this.Area = area;
            this.i = i;
            this.Nforce = nforce;
        }
        public AxisForce(string sectionType, double lamda, string steelfy, double l0, double area, double i, double nforce)
        {
            this.sectionType = sectionType;
            this.lamda = lamda;
            this.SteelFy = steelFy;
            this.L0 = l0;
            this.Area = area;
            this.i = i;
            this.Nforce = nforce;
        }
        public double GetFai()
        {
            if (this.LamdaN <= 0.215)
            {
                return a1 - this.A1 * this.LamdaN * this.LamdaN;
            }
            else
            {
                double temp = this.A2 + this.A3 * this.LamdaN + this.LamdaN * this.LamdaN;
                return ((temp) - Math.Sqrt(temp * temp - 4 * this.LamdaN * this.LamdaN)) / (2 * this.LamdaN * this.LamdaN);
            }
        }
        public double GetFy()
        {
            if (this.SteelFy == "Q460")
            {
                return 460;
            }
            else if (this.SteelFy == "Q345")
            {
                return 345;
            }
            else if (this.SteelFy == "Q390")
            {
                return 390;
            }
            else if (this.SteelFy == "Q420")
            {
                return 420;
            }
            else
            {
                return 235;
            }
        }

        






    }
}
