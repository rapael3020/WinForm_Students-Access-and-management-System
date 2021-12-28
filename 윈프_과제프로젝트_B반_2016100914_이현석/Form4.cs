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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n1 = Convert.ToDouble(textBox1.Text);
            double n2 = Convert.ToDouble(textBox5.Text);
            double n3 = Convert.ToDouble(textBox4.Text);
            double n4 = Convert.ToDouble(textBox3.Text);

            double sum = n1 + n2 + n3 + n4;
            textBox6.Text = sum.ToString("0.0");
            double avg = sum / 4;
            textBox2.Text = avg.ToString("0.0");
        }
    }
}
