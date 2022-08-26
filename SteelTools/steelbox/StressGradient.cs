using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
    public class StressGradient
    {
        private double stressMax;

        public double StressMax
        {
            get { return stressMax; }
            set { stressMax = value; }
        }
        private double stressMin;

        public double StressMin
        {
            get { return stressMin; }
            set { stressMin = value; }
        }
        private double stressGra;

        public double StressGra
        {
            get 
            {
                return (this.StressMax - this.StressMin) / this.StressMax;
            }
            set { stressGra = value; }
        }
        public StressGradient(double stressMax, double stressMin)
        {
            this.StressMax = stressMax;
            this.StressMin = stressMin;
        }
    }
}
