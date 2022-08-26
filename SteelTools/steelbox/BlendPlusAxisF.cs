using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class BlendPlusAxisF
    {
        public double Nforce { set; get; }
        public double Mx { set; get; }
        public double My { set; get; }
        public double Area { set; get; }
        public double Wx { set; get; }
        public double Wy { set; get; }
        public double faiX { set; get; }
        public double faiY { set; get; }
        public double faiB { set; get; }
        public double rx { set; get; }
        public double ry { set; get; }
        public double Bmx { set; get; }
        public double Btx { set; get; }
        public double LamdaX { set; get; }
        public double Es
        { 
            get
            {
                return 206000;
            }
        }
        public double Yita { set; get; }
        public double Nexp 
        {
            get
            {
                return 3.14 * 3.14 * this.Es * this.Area / (1.1 * this.LamdaX * this.LamdaX);
            }
        }
        public BlendPlusAxisF(double nforce,double mx,double my,double area,double wx,double faix,double faiy ,double faib,double rx,double lamdax,double yita,double bmx,double btx,double ry,double wy)
        {
            this.Nforce = nforce;
            this.Mx = mx;
            this.My = my;
            this.Area = area;
            this.Wx = wx;
            this.Wy = wy;
            this.faiX = faix;
            this.faiY = faiy;
            this.faiB = faib;
            this.rx = rx;
            this.ry = ry;
            this.LamdaX = lamdax;
            this.Yita = yita;
            this.Bmx = bmx;
            this.Btx = btx;
           
        }
        /// <summary>
        /// 强度
        /// </summary>
        /// <param name="nforce"></param>
        /// <param name="mx"></param>
        /// <param name="my"></param>
        /// <param name="area"></param>
        /// <param name="wx"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="wy"></param>
        /// <param name="n"></param>
        public BlendPlusAxisF(double nforce, double mx, double my, double area, double wx, double rx, double ry, double wy,string str)
        {
            this.Nforce = nforce;
            this.Mx = mx;
            this.My = my;
            this.Area = area;
            this.Wx = wx;
            this.Wy = wy;
            this.rx = rx;
            this.ry = ry;

        }
        /// <summary>
        /// 平面内
        /// </summary>
        /// <param name="nforce"></param>
        /// <param name="mx"></param>
        /// <param name="area"></param>
        /// <param name="wx"></param>
        /// <param name="rx"></param>
        /// <param name="faix"></param>
        /// <param name="bmx"></param>
        public BlendPlusAxisF(string str,double nforce, double mx, double area, double wx, double rx,double faix,double bmx,double lamdax)
        {
            this.Nforce = nforce;
            this.Mx = mx;
            this.Area = area;
            this.Wx = wx;
            this.rx = rx;
            this.faiX = faix;
            this.Bmx = bmx;
            this.LamdaX = lamdax;
        }
        /// <summary>
        /// 平面外
        /// </summary>
        /// <param name="nforce"></param>
        /// <param name="mx"></param>
        /// <param name="area"></param>
        /// <param name="wx"></param>
        /// <param name="faiy"></param>
        /// <param name="btx"></param>
        /// <param name="faib"></param>
        /// <param name="yita"></param>
        public BlendPlusAxisF(double nforce, double mx, double area, double wx, double faiy, double btx,double faib,double yita)
        {
            this.Nforce = nforce;
            this.Mx = mx;
            this.Area = area;
            this.Wx = wx;
            this.faiY = faiy;
            this.Btx = btx;
            this.faiB = faib;
            this.Yita = yita;
        }
        public double GetSF()
        {
            return this.Nforce/this.Area +this.Mx / (this.rx * this.Wx) + this.My / (this.ry * this.Wy);
        }
        public double GetPMN()
        {
            return this.Nforce / (this.faiX * this.Area) + this.Bmx * this.Mx / (this.rx * this.Wx * (1 - 0.8 * this.Nforce / this.Nexp));
        }
        public double GetPMW()
        {
            return this.Nforce / (this.faiY * this.Area) + this.Yita*this.Btx * this.Mx / (this.faiB * this.Wx);
        }
    }
}
