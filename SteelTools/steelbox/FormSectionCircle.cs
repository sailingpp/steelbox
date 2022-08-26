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
    public delegate void PassSectionCHandler(SectionCircle sectionc);  //定义委托
    public partial class FormSectionCircle : Form
    {
        public FormSectionCircle()
        {
            InitializeComponent();
        }
        public event PassSectionCHandler PassSectionC;  //定义事件
        double diameter;
        double tw;
        SectionCircle circle = new SectionCircle();
        private void buttonSectionCircle_Click(object sender, EventArgs e)
        {
            diameter = Convert.ToDouble(textBoxCD.Text);
            tw = Convert.ToDouble(textBoxCt.Text);
            circle = new SectionCircle(diameter, tw);
            labelCircleArea.Text = circle.Area.ToString();
            labelCInertiaX.Text = circle.InertiaX.ToString();
            labelCix.Text = circle.Ix.ToString();
        }

        private void buttonSCO_Click(object sender, EventArgs e)
        {
            if (PassSectionC != null)//判断事件是否为空
            {
                PassSectionC(circle);//执行委托实例  
                this.Close();
            }         
        }
    }
}
