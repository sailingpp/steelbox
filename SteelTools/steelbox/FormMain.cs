using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace steelbox
{
    public partial class FormMain : Form
    {
        XmlDocument xmlDocBolt = new XmlDocument();
        XmlNodeList boltNameNodeList;
        XmlNodeList fcbList;
        XmlNodeList ftbList;
        XmlNodeList fvbList;
        XmlNodeList steelNameNodeList;
        List<Bolt> boltList = new List<Bolt>();
        Dictionary<string, double> Ae = new Dictionary<string, double>();
       

        public FormMain()
        {
            InitializeComponent();
            xmlDocBolt.Load("BoltSteel.XML");
            boltNameNodeList = xmlDocBolt.GetElementsByTagName("BoltGrade");
            fcbList = xmlDocBolt.GetElementsByTagName("fcb");
            ftbList = xmlDocBolt.GetElementsByTagName("ftb");
            fvbList = xmlDocBolt.GetElementsByTagName("fvb");
            steelNameNodeList = xmlDocBolt.GetElementsByTagName("fcb");

            for (int i = 0; i < boltNameNodeList.Count; i++)
            {
                comboBoxCBolt.Items.Add(boltNameNodeList[i].Attributes["name"].Value);
                Bolt bolt = new Bolt();
                bolt.BoltName = boltNameNodeList[i].Attributes["name"].Value;
                bolt.Fcb = Convert.ToDouble(fcbList[i].InnerText);
                bolt.Ftb = Convert.ToDouble(ftbList[i].InnerText);
                bolt.Fvb = Convert.ToDouble(fvbList[i].InnerText);
                boltList.Add(bolt);

            }

            Ae["M16"] = 157;
            Ae["M20"] = 245;
            Ae["M22"] = 303;
            Ae["M24"] = 353;
            Ae["M27"] = 459;
            Ae["M30"] = 561;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(myH.Area.ToString());
            //MessageBox.Show(myBox.Area.ToString());
            //MessageBox.Show(myCircle.Area.ToString());
            if (comboBoxSectionType.Text == "H型")
            {
                textBoxTfR.Text = myH.FlangeWidthThicknessRaio.ToString();
                textBoxTwR.Text = myH.WebWidthThicknessRaio.ToString();
                SectionClass sc = new SectionClass(myH);
                double ek = Convert.ToDouble(labelek.Text);
                string forceType = comboBoxForceType.Text;
                double stressGra = Convert.ToDouble(textBoxStressGra.Text);
                labelSection.Text = "H" + myH.Height + "x" + myH.Width + "x" + myH.TWidth + "x" + myH.TFlange;
                textBoxGF.Text = sc.JudgeHFlangeSectionClass(ek, myH.FlangeWidthThicknessRaio);
                textBoxGW.Text = sc.JudgeHWebSectionClass(forceType, ek, stressGra, myH.WebWidthThicknessRaio);
                textCircleDR.Text = "";

            }
            else if (comboBoxSectionType.Text == "箱型")
            {
                textBoxTfR.Text = myBox.FlangeWidthThicknessRaio.ToString();
                textBoxTwR.Text = myBox.WebWidthThicknessRaio.ToString();
                SectionClass sc = new SectionClass(myBox);
                double ek = Convert.ToDouble(labelek.Text);
                string forceType = comboBoxForceType.Text;
                double stressGra = Convert.ToDouble(textBoxStressGra.Text);
                labelSection.Text = "口" + myBox.Height + "x" + myBox.Width + "x" + myBox.Tw;
                textBoxTfR.Text = myBox.FlangeWidthThicknessRaio.ToString();
                textBoxTwR.Text = myBox.WebWidthThicknessRaio.ToString();
                textBoxGF.Text = sc.JudgeBoxSectionClass(forceType, ek, stressGra, myBox.FlangeWidthThicknessRaio);
                textBoxGW.Text = sc.JudgeBoxSectionClass(forceType, ek, stressGra, myBox.WebWidthThicknessRaio);
                textCircleDR.Text = "";
            }
            else if (comboBoxSectionType.Text == "圆管型")
            {
                SectionClass sc = new SectionClass(myCircle);
                labelSection.Text = "D" + myCircle.Diameter + "x" + myCircle.Tw;
                textCircleDR.Show();
                textCircleDR.Text = myCircle.DiameterThicknessRatio.ToString();

                double ek = Convert.ToDouble(labelek.Text);
                string forceType = comboBoxForceType.Text;
                double stressGra = Convert.ToDouble(textBoxStressGra.Text);
                textBoxGC.Text = sc.JudgeCircleSectionClass(forceType, ek, stressGra, myCircle.DiameterThicknessRatio);
                textBoxTfR.Text = "";
                textBoxTwR.Text = "";
                textBoxGF.Text = "";
                textBoxGW.Text = "";
            }

        }

        private void comboBoxSectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxSectionType.SelectedItem.ToString();
            if (str == "H型")
            {
                FormSectionH formSectionH = new FormSectionH();
                formSectionH.PassSectionH += new PassSectionHHandler(PassSectionH);
                formSectionH.Show();

            }
            else if (str == "箱型")
            {
                FormSectionBox formSectionBox = new FormSectionBox();
                formSectionBox.PassSectionBox += new PassSectionBHandler(PassSectionBox);
                formSectionBox.Show();

            }
            else if (str == "圆管型")
            {
                FormSectionCircle formSectionCircle = new FormSectionCircle();
                formSectionCircle.PassSectionC += new PassSectionCHandler(PassSectionCircle);
                formSectionCircle.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormStressGradient formStressGradient = new FormStressGradient();
            formStressGradient.ChangeText += new ChangeTextHandler(Change_Text);//将事件和处理方法绑在一起，这句话必须放在f2.ShowDialog();前面
            formStressGradient.Show();
        }
        /// <summary>
        /// 窗体传值
        /// </summary>
        /// <param name="str"></param>
        public void Change_Text(string str)
        {
            textBoxStressGra.Text = str;
        }
        SectionH myH = new SectionH();
        SectionBox myBox = new SectionBox();
        SectionCircle myCircle = new SectionCircle();
        public void PassSectionH(SectionH sectionH)
        {
            myH = sectionH;
        }
        public void PassSectionBox(SectionBox sectionBox)
        {
            myBox = sectionBox;
        }
        public void PassSectionCircle(SectionCircle sectionCircle)
        {
            myCircle = sectionCircle;
        }

        private void comboBoxForceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxForceType.SelectedItem.ToString();
            if (str == "受弯构件")
            {
                textBoxStressGra.Text = 2.0 + "";
                textBoxStressGra.ReadOnly = true;
                button2.Enabled = false;
            }
            else
            {
                textBoxStressGra.Text = "";
                textBoxStressGra.ReadOnly = false;
                button2.Enabled = true;
            }
        }

        private void comboBoxfy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxfy.SelectedItem.ToString();
            double ek = 0;
            if (str == "Q235")
            {
                ek = Math.Sqrt(235 / 235.0);
            }
            else if (str == "Q345")
            {
                ek = Math.Sqrt(345 / 235.0);
            }
            else if (str == "Q390")
            {
                ek = Math.Sqrt(390 / 235.0);
            }
            else if (str == "Q420")
            {
                ek = Math.Sqrt(420 / 235.0);
            }
            else if (str == "Q460")
            {
                ek = Math.Sqrt(460 / 235.0);
            }
            labelek.Text = Math.Round(ek, 3).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double Mx = Convert.ToDouble(textBoxMx.Text);
            double My = Convert.ToDouble(textBoxMy.Text);
            double rx = Convert.ToDouble(comboBoxRx.Text);
            double ry = Convert.ToDouble(comboBoxRy.Text);
            double Wnx = Convert.ToDouble(textBoxWnx.Text);
            double Wny = Convert.ToDouble(textBoxWny.Text);
            double Faib = Convert.ToDouble(textBoxFaib.Text);
            Blending myBlending = new Blending(Mx, rx, My, ry, Wnx, Wny, Faib);
            labelstress.Text = myBlending.CalBlending().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double Mx = Convert.ToDouble(textBoxMx.Text);
            double My = Convert.ToDouble(textBoxMy.Text);
            double rx = Convert.ToDouble(comboBoxRx.Text);
            double ry = Convert.ToDouble(comboBoxRy.Text);
            double Wnx = Convert.ToDouble(textBoxWnx.Text);
            double Wny = Convert.ToDouble(textBoxWny.Text);
            double Faib = Convert.ToDouble(textBoxFaib.Text);
            Blending myBlending = new Blending(Mx, rx, My, ry, Wnx, Wny, Faib);
            labelStability.Text = myBlending.CalStability().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double NForce = Convert.ToDouble(textBoxNForce.Text);
            double lx = Convert.ToDouble(textBoxLx.Text);
            double ly = Convert.ToDouble(textBoxLy.Text);
            double ix = Convert.ToDouble(textBoxix.Text);
            double iy = Convert.ToDouble(textBoxiy.Text);
            string sectionX = comboBoxSectionX.Text;
            string sectionY = comboBoxSectionY.Text;
            string steelType = comboBoxfy.Text;
            double area = Convert.ToDouble(textBoxArea.Text);
            double lamdaX = lx / ix;
            double lamdaY = ly / iy;
            textBoxlamx.Text = Math.Round(lamdaX, 3) + "";
            textBoxlamy.Text = Math.Round(lamdaY, 3) + "";
            AxisForce afx = new AxisForce(sectionX, lamdaX, steelType, lx, area, ix, NForce);
            AxisForce afy = new AxisForce(sectionY, lamdaY, steelType, ly, area, iy, NForce);
            textBoxFaiX.Text = Math.Round(afx.GetFai(), 3) + "";
            textBoxFaiY.Text = Math.Round(afy.GetFai(), 3) + "";
            double stx = NForce * 1000 / afx.GetFai() / area;
            double sty = NForce * 1000 / afy.GetFai() / area;
            textBoxStx.Text = Math.Round(stx, 3) + "";
            textBoxSty.Text = Math.Round(sty, 3) + "";

        }
        //强度
        private void buttonSN_Click(object sender, EventArgs e)
        {
            double Nforce = Convert.ToDouble(textBoxSNf.Text);
            double Mx = Convert.ToDouble(textBoxSMx.Text);
            double My = Convert.ToDouble(textBoxSMy.Text);
            double Wx = Convert.ToDouble(textBoxSWx.Text);
            double Wy = Convert.ToDouble(textBoxSWy.Text);
            double rx = Convert.ToDouble(comboBoxSrx.Text);
            double ry = Convert.ToDouble(comboBoxSry.Text);
            double Area = Convert.ToDouble(textBoxSArea.Text);
            BlendPlusAxisF bp = new BlendPlusAxisF(Nforce * 1000, Mx * 1000000, My * 1000000, Area, Wx, rx, ry, Wy, "强度验算");
            textBoxSFO.Text = Math.Round(bp.GetSF(), 3).ToString();

        }
        //平面内
        private void buttonSI_Click(object sender, EventArgs e)
        {
            double Nforce = Convert.ToDouble(textBoxSNf.Text);
            double Mx = Convert.ToDouble(textBoxSMx.Text);
            double Area = Convert.ToDouble(textBoxSArea.Text);
            double Wx = Convert.ToDouble(textBoxSWx.Text);
            double faiX = Convert.ToDouble(textBoxSfx.Text);
            double rx = Convert.ToDouble(comboBoxSrx.Text);
            double LamdaX = Convert.ToDouble(textBoxSlamx.Text);
            double Bmx = Convert.ToDouble(textBoxSbetamx.Text);
            BlendPlusAxisF bp = new BlendPlusAxisF("平面内", Nforce * 1000, Mx * 1000000, Area, Wx, rx, faiX, Bmx, LamdaX);
            textBoxNexp.Text = Math.Round(bp.Nexp / 1000.0, 3).ToString();
            textBoxSpmn.Text = Math.Round(bp.GetPMN(), 3).ToString();
        }
        //平面外
        private void buttonSW_Click(object sender, EventArgs e)
        {
            double Nforce = Convert.ToDouble(textBoxSNf.Text);
            double Mx = Convert.ToDouble(textBoxSMx.Text);
            double Area = Convert.ToDouble(textBoxSArea.Text);
            double Wx = Convert.ToDouble(textBoxSWx.Text);
            double faiY = Convert.ToDouble(textBoxSfy.Text);
            double faiB = Convert.ToDouble(textBoxSfb.Text);
            double Yita = Convert.ToDouble(textBoxSyita.Text);
            double Btx = Convert.ToDouble(textBoxSbetatx.Text);
            BlendPlusAxisF bp = new BlendPlusAxisF(Nforce * 1000, Mx * 1000000, Area, Wx, faiY, Btx, faiB, Yita);
            textBoxSmpw.Text = Math.Round(bp.GetPMW(), 3).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxBeamSectionType.SelectedItem.ToString();
            SecondaryMoment secondaryMoment = new SecondaryMoment(str);
            textBoxBeamAlfa.Text = secondaryMoment.Coefficients[0].ToString();
            textBoxBeamBeta.Text = secondaryMoment.Coefficients[1].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = comboBoxBeamSectionType.Text;
            double area = Convert.ToDouble(textBoxSA.Text);
            double w = Convert.ToDouble(textBoxSW.Text);
            double wp = Convert.ToDouble(textBoxSWP.Text);
            double n = Convert.ToDouble(textBoxSN.Text);
            double m = Convert.ToDouble(textBoxSM.Text);
            double f = Convert.ToDouble(textBoxSF.Text);
            double a = Convert.ToDouble(textBoxBeamAlfa.Text);
            double b = Convert.ToDouble(textBoxBeamBeta.Text);
            SecondaryMoment secondaryMoment = new SecondaryMoment(area, w, wp, n * 1000, m * 1000000, f);
            textBoxRes.Text = secondaryMoment.CalStress(a, b) + "," + secondaryMoment.Judge(a, b);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string boltname = comboBoxCBolt.Text;
            string steelname = comboBoxSteelGrade.Text;
            double d = Convert.ToDouble(textBoxBoltD.Text);
            int n = Convert.ToInt32(textBoxBoltN.Text);
            double t = Convert.ToDouble(textBoxBoltT.Text);
            double fvb = Convert.ToDouble(textBoxFvb.Text);
            double ftb = Convert.ToDouble(textBoxFtb.Text);
            double fcb = Convert.ToDouble(textBoxFvb.Text);
            Bolt mbolt = new Bolt(boltname, steelname, fcb, ftb, fvb, n, t, d);
            textBoxNcb.Text = (mbolt.Ncb / 1000).ToString();
            textBoxNtb.Text = (mbolt.Ntb / 1000).ToString();
            textBoxNvb.Text = (mbolt.Nvb / 1000).ToString();


        }

        private void comboBoxCBolt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxCBolt.SelectedItem.ToString();
            for (int i = 0; i < boltList.Count; i++)
            {
                if (str == boltList[i].BoltName)
                {
                    textBoxFvb.Text = boltList[i].Fvb.ToString();
                    textBoxFtb.Text = boltList[i].Ftb.ToString();
                    textBoxFcb.Text = boltList[i].Fcb.ToString();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double k = Convert.ToDouble(comboBoxK.Text);
            int nf = Convert.ToInt32(textBoxBoltNf.Text);
            double u = Convert.ToDouble(textBoxBoltPU.Text);
            double p = Convert.ToDouble(textBoxBoltP.Text);
            Bolt bolt = new Bolt(nf, p, k, u);
            textBoxBoltPNvb.Text = bolt.PNvb .ToString();
            textBoxBoltPNtb.Text = bolt.PNtb.ToString();
        }

        private void comboBoxBoltPClear_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*喷硬质石英砂或铸钢棱角砂
             抛丸（喷砂）
            钢丝刷或干净的轧制面*/
            string str = this.comboBoxBoltPClear.SelectedItem.ToString();
            string s = comboBoxBoltPS.Text;
            if (str.Contains("石英砂"))
            {
                textBoxBoltPU.Text = 0.45 + "";
            }
            else if (str.Contains("抛丸"))
            {
                textBoxBoltPU.Text = 0.40 + "";
            }
            else if (str.Contains("钢丝刷") && s == "Q235")
            {
                textBoxBoltPU.Text = 0.30 + "";
            }
            else if (str.Contains("钢丝刷") && s == "Q345")
            {
                textBoxBoltPU.Text = 0.35 + "";
            }
            else
            {
                textBoxBoltPU.Text = "请选择";
            }


        }

        private void comboBoxBoltDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxBoltDe.SelectedItem.ToString();
            textBoxBoltAe.Text = Ae[str].ToString() ;

        }

        private void comboBoxBoltPDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string de = this.comboBoxBoltDe.SelectedItem.ToString();
            string pde = this.comboBoxBoltPDG.SelectedItem.ToString();
            double p=-1;
            if (pde == "8.8级")
            {
                if (de=="M16")
                {
                    p = 80;
                }
                else if (de == "M20")
                {
                    p = 125;
                }
                else if (de == "M22")
                {
                    p = 150;
                }
                else if (de == "M24")
                {
                    p = 175;
                }
                else if (de == "M27")
                {
                    p = 230;
                }
                else if (de == "M30")
                {
                    p = 280;
                }
                else
                {
                    p = -1;
                }
            }
            else if (pde == "10.9级")
            {
                if (de == "M16")
                {
                    p = 100;
                }
                else if (de == "M20")
                {
                    p = 155;
                }
                else if (de == "M22")
                {
                    p = 190;
                }
                else if (de == "M24")
                {
                    p = 225;
                }
                else if (de == "M27")
                {
                    p = 290;
                }
                else if (de == "M30")
                {
                    p = 355;
                }
                else
                {
                    p = -1;
                }
            }
            textBoxBoltP.Text = p.ToString();

        }
    }
}
