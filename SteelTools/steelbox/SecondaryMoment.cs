using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class SecondaryMoment
    {
        public string SectionType { set; get; }
        public static double alfa;
        public static double beta;
        public double[] coefficients = new double[2] { alfa, beta };
        public double[] Coefficients
        {
            get 
            {
                if (this.SectionType =="H形截面，腹板位于桁架平面内")
                {
                    coefficients[0] = 0.85;
                    coefficients[1] =1.15;
                }
                else if (this.SectionType =="H形截面，腹板垂直于桁架平面")
	            {
                    coefficients[0] = 0.60;
                    coefficients[1] = 1.08;
	            }
                 else if (this.SectionType =="正方箱型截面")
                {
                    coefficients[0] = 0.80;
                    coefficients[1] = 1.13;
                }
                else
                {
                    coefficients[0] = 0;
                    coefficients[1] = 0; 
                 }
                return coefficients;
            }
        }
        public double Area { set; get; }
        public double W{ set; get; }
        public double N { set; get; }
        public double M { set; get; }
        public double Wp { set; get; }
        public double F { set; get; }
        public double e
        {
            get 
            {
                return this.M * this.Area / this.N * this.W;
            }
        }
        public SecondaryMoment(double area,double w,double wp,double n,double m,double f)
        {
            this.Area = area;
            this.W = w;
            this.Wp = wp;
            this.N = n;
            this.M = m;
        }
        public SecondaryMoment(string sectionType)
        {
            this.SectionType = sectionType;
        }
        public double CalStress(double a,double b)
        {
            if (this.e <= 0.2)
            {
                return this.N / this.Area;
            }
            else
            {
                return this.N / this.Area + a * this.M / this.Wp;
            }
        }
        public string Judge(double a, double b)
        {
            if (this.e <= 0.2 )
            {
                if (this.N / this.Area < this.F)
                {
                    return "N/A<f";
                }
                else
                {
                    return "N/A>=f";
                }
              
            }
            else
            {
                if (this.N / this.Area + a * this.M / this.Wp < b * this.F)
                {
                    return "N/A+a*M/Wp<Bf";
                }
                else
                {
                    return "N/A+a*M/Wp>=Bf";
                }
               
            }
        }


    }
}
