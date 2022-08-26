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
    public delegate void ChangeTextHandler(string str);  //定义委托
    public partial class FormStressGradient : Form
    {
        public FormStressGradient()
        {
            InitializeComponent();
        }
        public event ChangeTextHandler ChangeText;  //定义事件
        /// <summary>
        /// 计算应力梯度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double stressMax = Convert.ToDouble(textBoxStressMax.Text);
            double stressMin = Convert.ToDouble(textBoxStressMin.Text);
            StressGradient stressGradient = new StressGradient(stressMax, stressMin);
            labelStressGro.Text = stressGradient.StressGra.ToString();
            
        }
        /// <summary>
        /// 关闭并传递应力梯度的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
             if (ChangeText != null)//判断事件是否为空
             {
                 ChangeText(labelStressGro.Text);//执行委托实例  
                 this.Close();
           }         
        }
    }
}
