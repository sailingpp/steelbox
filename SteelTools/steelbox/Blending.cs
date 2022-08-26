using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class Blending
    {
        public string name = "受弯构件";
        public double Mx;
        public double rx;
        public double My;
        public double ry;
        public double Wnx;
        public double Wny;
        public double Faib;
        public SectionH sectionH;
        public SectionBox sectionBox;
        public SectionCircle sectionCircle;
        public Blending(double mx, double rx, double my, double ry, double Wnx, double Wny,double faib)
        {

            this.Mx = mx;
            this.rx = rx;
            this.Wnx = Wnx;
            this.My = my;
            this.ry = ry;
            this.Wny = Wny;
            this.Faib = faib;
        }
        public double CalBlending()
        {
            return Mx * 1000000 / (rx * Wnx) + My * 1000000 / (ry * Wny);
        }
        public double CalStability()
        {
            return Mx * 1000000 / (Faib * Wnx) + My * 1000000 / (ry * Wny);
        }

    }
}
