using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class Bolt
    {
        public string BoltName { set; get; }
        public double Fcb { set; get; }
        public double Ftb { set; get; }
        public double Fvb { set; get; }
        public double d { set; get; }
        public int n { set; get; }
        public double t { set; get; }
        public double Area
        {
            get
            {
                return 3.14 * d * d / 4;
            }
        }
        public double Ntb
        {
            get
            {
                return this.Area * this.Ftb;
            }
        }
        public double Nvb
        {
            get
            {

                return this.n * this.Area * this.Fvb;
            }
        }
        public double Ncb
        {
            get
            {

                return this.Fcb * this.t * this.d;
            }
        }
        public string SteelName { set; get; }
        public Bolt()
        {

        }
        public Bolt(string boltname, string steelname, double fcb, double ftb, double fvb, int n, double t, double d)
        {
            this.BoltName = boltname;
            this.SteelName = steelname;
            this.Fcb = fcb;
            this.Ftb = ftb;
            this.Fvb = fvb;
            this.n = n;
            this.t = t;
            this.d = d;
        }
        public double u { set; get; }
        public double Ae { set; get; }

        public double P { set; get; }
        public double K { set; get; }
        public Bolt(int n, double p, double k, double u)
        {
            this.n = n;
            this.P = p;
            this.K = k;
            this.u = u;
        }
        public double PNvb
        {
            get
            {
                return 0.9 * this.K * this.n * this.u * this.P;
            }
        }
        public double PNtb
        {
            get
            {
                return 0.8 * this.P;
            }
        }
    }
}
