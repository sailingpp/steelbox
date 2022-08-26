using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{
   public  class SteelGrade
    {
      private  string steelName;

        public string SteelName
        {
            get { return steelName; }
            set { steelName = value; }
        }

        private double fy;

        public double Fy
        {
            get { return fy; }
            set 
            {
                fy = value;
            }
        }

        private double ek;

        public double Ek
        {
            get { return ek; }
            set { ek = value; }
        }



    }

}
