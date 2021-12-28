using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈프_과제프로젝트_B반_2016100914_이현석
{
    public partial class Form3 : Form
    {
        private string id;
        private string pw;
        public string getid
        {
            get { return id; }
        }
        public string getpw
        {
            get { return pw; }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "LeeHyunseok") && (textBox2.Text == "1234"))
            {
                id = textBox1.Text;
                pw = textBox2.Text;
                Form1 f3 = new Form1();
                f3.Owner = this;
                f3.ShowDialog();
                f3.Close();
            }
            else
            {
                MessageBox.Show("아이디나 패스워드가 틀렸습니다.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }
    }
}
