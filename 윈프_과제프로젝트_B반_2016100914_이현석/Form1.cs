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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 긴급및비상알람ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("긴급상황발생");
        }

        private void 종ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnMouseClick(MouseEventArgs e)

        {

            base.OnMouseClick(e);

            // 마우스 우측 버튼이 눌린 경우에 컨텍스트 메뉴 실행

            if (e.Button == System.Windows.Forms.MouseButtons.Right)

            {

                ContextMenu contextMenu = new ContextMenu();



                MenuItem menuItem = new MenuItem("알람 발생");

                menuItem.Click += 긴급및비상알람ToolStripMenuItem_Click;    // 메뉴에서 등록한 알람 이벤트 처리기 등록

                contextMenu.MenuItems.Add(menuItem);



                menuItem = new MenuItem("종료");

                menuItem.Click += 종ToolStripMenuItem_Click;   // 메뉴에서 등록한 종료 이벤트처리기 등록

                contextMenu.MenuItems.Add(menuItem);



                contextMenu.Show(this, e.Location);    // 마우스가 클릭된 지점에서 콘텍스트 메뉴 Show

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.Text);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.Text);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)Owner;
            if (f3.getid != null)
            {
                try
                {
                    label3.Text = "현석학원등하원시스템입니다." + f3.getid + "님 환영합니다.";
                    label4.Text = f3.getpw + "! 모두가 행복한 현석학원입니다!";
                }
                catch(Exception)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Application.Exit();
            }
        }
        
        private void 바로가기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void 바로가기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
