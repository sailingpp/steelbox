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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "admin" && textBoxPassWord.Text == "123456")
            {
                FormMain formain = new FormMain();
                MessageBox.Show("登录成功！");
                this.Hide();
                formain.Show();            
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入");
            }
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }
    }
}
