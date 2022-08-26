using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steelbox
{
    public delegate void PassSectionHHandler(SectionH sectionh);  //定义委托
    public partial class FormSectionH : Form
    {
        public FormSectionH()
        {
            InitializeComponent();
        }
        public event PassSectionHHandler PassSectionH;  //定义事件
        double height;
        double width;
        double tflange;
        double twidth;
        SectionH hw = new SectionH();
        private void buttonSectionH_Click(object sender, EventArgs e)
        {
            height = Convert.ToDouble(textBoxSHH.Text);
            width = Convert.ToDouble(textBoxSHW.Text);
            tflange = Convert.ToDouble(textBoxSHtf.Text);
            twidth = Convert.ToDouble(textBoxSHtw.Text);
            hw = new SectionH(height, width, tflange, twidth);
            labelArea.Text = hw.Area.ToString();
            labelInertiaX.Text = hw.InertiaX.ToString();
            labelInertiaY.Text = hw.InteriaY.ToString();
            labelix.Text = hw.Ix.ToString();
            labeliy.Text = hw.Iy.ToString();
        }

        private void buttonSHO_Click(object sender, EventArgs e)
        {
            if (PassSectionH != null)//判断事件是否为空
            {
                PassSectionH(hw);//执行委托实例  
                this.Close();
            }         
        }
    }
}
