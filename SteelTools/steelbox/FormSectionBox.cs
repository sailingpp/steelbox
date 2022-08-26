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
    public delegate void PassSectionBHandler(SectionBox sectionb);  //定义委托
    public partial class FormSectionBox : Form
    {
        public FormSectionBox()
        {
            InitializeComponent();
        }
        public event PassSectionBHandler PassSectionBox;  //定义事件
        double height;
        double width;
        double twidth;
        SectionBox box = new SectionBox();
        private void buttonSectionRec_Click(object sender, EventArgs e)
        {
            height = Convert.ToDouble(textBoxSRH.Text);
            width = Convert.ToDouble(textBoxSRW.Text);
            twidth = Convert.ToDouble(textBoxSRTw.Text);
            box = new SectionBox(height, width, twidth);
            labelBoxArea.Text = box.Area.ToString();
            labelBoxInertiaX.Text = box.InertiaX.ToString();
            labelBoxInertiaY.Text = box.InertiaY.ToString();
            labelBoxix.Text = box.Ix.ToString();
            labelBoxiy.Text = box.Iy.ToString();
        }

        private void buttonSBO_Click(object sender, EventArgs e)
        {
            if (PassSectionBox != null)//判断事件是否为空
            {
                PassSectionBox(box);//执行委托实例  
                this.Close();
            }         
        }
    }
}
