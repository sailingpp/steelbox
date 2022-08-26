using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steelbox
{

    public class SectionClass
    {
        enum SectionGrade
        {
            S1, S2, S3, S4, S5
        };

        private SteelGrade steelGrade;

        public SteelGrade SteelGrade
        {
            get { return steelGrade; }
            set { steelGrade = value; }
        }
        private StressGradient stressGradient;

        public StressGradient StressGradient
        {
            get { return stressGradient; }
            set { stressGradient = value; }
        }
        private SectionH sectionH;

        public SectionH SectionH
        {
            get { return sectionH; }
            set { sectionH = value; }
        }
        private SectionBox sectionBox;

        public SectionBox SectionBox
        {
            get { return sectionBox; }
            set { sectionBox = value; }
        }
        private SectionCircle sectionCircle;

        public SectionCircle SectionCircle
        {
            get { return sectionCircle; }
            set { sectionCircle = value; }
        }
        public SectionClass() { ;}
        public SectionClass(SectionH sectionH)
        {
            this.SectionH=sectionH;
        }
        public SectionClass(SectionBox sectionBox)
        {
            this.SectionBox = SectionBox;
        }
        public SectionClass(SectionCircle sectionCircle)
        {
            this.SectionCircle=sectionCircle;
        }
        public string JudgeHFlangeSectionClass(double ek, double ThicknessRatio)
        {
            if (ThicknessRatio <= 9 * ek)
            {
                return "s1";
            }
            else if (ThicknessRatio <= 11 * ek)
            {
                return "s2";
            }
            else if (ThicknessRatio <= 13 * ek)
            {
                return "s3";
            }
            else if (ThicknessRatio <= 15 * ek)
            {
                return "s4";
            }
            else if (ThicknessRatio <= 20)
            {
                return "s5";
            }
            else
            {
                return "超过s5";
            }



        }
        public string JudgeHWebSectionClass(string forceType, double ek, double stressGra, double ThicknessRatio)
        {
            if (forceType == "受弯构件")
            {
                if (ThicknessRatio <= 65 * ek)
                {
                    return "s1";
                }
                else if (ThicknessRatio <= 72 * ek)
                {
                    return "s2";
                }
                else if (ThicknessRatio <= 93 * ek)
                {
                    return "s3";
                }
                else if (ThicknessRatio <= 124 * ek)
                {
                    return "s4";
                }
                else if (ThicknessRatio <= 250)
                {
                    return "s5";
                }
                else
                {
                    return "超过s5";
                }
            }
            else
            {
                if (ThicknessRatio <= (33 + 13 * Math.Pow(stressGra, 1.3)) * ek)
                {
                    return "s1";
                }
                else if (ThicknessRatio <= (38 + 13 * Math.Pow(stressGra, 1.39)) * ek)
                {
                    return "s2";
                }
                else if (ThicknessRatio <= (40 + 18 * Math.Pow(stressGra, 1.5)) * ek)
                {
                    return "s3";
                }
                else if (ThicknessRatio <= (45 + 25 * Math.Pow(stressGra, 1.66)) * ek)
                {
                    return "s4";
                }
                else if (ThicknessRatio <= 250)
                {
                    return "s5";
                }
                else
                {
                    return "超过s5";
                }
            }

        }
        public string JudgeBoxSectionClass(string forceType, double ek, double stressGra, double ThicknessRatio)
        {
            if (forceType == "受弯构件")
            {
                if (ThicknessRatio <= 25 * ek)
                {
                    return "s1";
                }
                else if (ThicknessRatio <= 32 * ek)
                {
                    return "s2";
                }
                else if (ThicknessRatio <= 37 * ek)
                {
                    return "s3";
                }
                else if (ThicknessRatio <= 42 * ek)
                {
                    return "s4";
                }
                else
                {
                    return "s5";
                }
            }
            else
            {
                if (ThicknessRatio <= 30 * ek)
                {
                    return "s1";
                }
                else if (ThicknessRatio <= 35 * ek)
                {
                    return "s2";
                }
                else if (ThicknessRatio <= 40 * ek)
                {
                    return "s3";
                }
                else if (ThicknessRatio <= 45 * ek)
                {
                    return "s4";
                }
                else
                {
                    return "s5";
                }
            }
        }
        public string JudgeCircleSectionClass(string forceType, double ek, double stressGra, double ThicknessRatio)
        {
            if (ThicknessRatio <= 50 * ek * ek)
            {
                return "s1";
            }
            else if (ThicknessRatio <= 70 * ek * ek)
            {
                return "s2";
            }
            else if (ThicknessRatio <= 90 * ek * ek)
            {
                return "s3";
            }
            else if (ThicknessRatio <= 100 * ek * ek)
            {
                return "s4";
            }
            else
            {
                return "s5";
            }
        }

    }
}
