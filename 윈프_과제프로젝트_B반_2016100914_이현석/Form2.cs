using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈프_과제프로젝트_B반_2016100914_이현석
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string school = textBox2.Text;
            string phone = textBox3.Text;
            string adr = textBox4.Text;

            string[] strs = new string[] { name, school, phone, adr };
            ListViewItem lvi = new ListViewItem(strs);
            lvi.Text = name;
            listView1.Items.Add(lvi);
            ClearInputControl();
        }

        private void ClearInputControl()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = listView1.SelectedItems.Count > 0;
            button2.Enabled = button4.Enabled = selected;
            if (selected == false)
            {
                ClearInputControl();
                return;
            }
            ListViewItem lvi = listView1.SelectedItems[0];
            textBox1.Text = lvi.SubItems[0].Text;
            textBox2.Text = lvi.SubItems[1].Text;
            textBox3.Text = lvi.SubItems[2].Text;
            textBox4.Text = lvi.SubItems[3].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool selected = listView1.SelectedItems.Count > 0;
            ListViewItem lvi = listView1.SelectedItems[0];
            listView1.Items.Remove(lvi);
            ClearInputControl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool selected = listView1.SelectedItems.Count > 0;
            ListViewItem lvi = listView1.SelectedItems[0];
            string school = textBox2.Text;
            string phone = textBox3.Text;
            string adr = textBox4.Text;
            lvi.SubItems[1].Text = school;
            lvi.SubItems[2].Text = phone;
            lvi.SubItems[3].Text = adr;
            ClearInputControl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private void SaveFile()
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Title = "텍스트 파일 저장";
            sfd1.FileName = string.Empty;
            sfd1.Filter = "텍스트파일 (*.txt)|*.txt";
            if (sfd1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    SaveData_listView(sfd1.FileName, listView1);
                }
                catch
                {
                    MessageBox.Show("파일 저장중 에러가 발생했습니다.");
                    return;
                }
                MessageBox.Show(Path.GetFileName(sfd1.FileName) + " 파일을 저장했습니다.");
            }

        }

        private void SaveData_listView(string fileName, ListView LV)
        {
            // Text 파일로 데이터 저장
            string delimeter = Environment.NewLine;  // 줄바꿈(개행문자)
            using (TextWriter textExport = new StreamWriter(fileName))
            {
                if (LV.Items.Count == 0)
                {
                    MessageBox.Show("저장할 내용이 없습니다");
                    return;
                }

                foreach (ListViewItem item in LV.Items)
                {
                    for (int i = 0; i < item.SubItems.Count; i++) // SubItems (열)을 전부 순환하는데 마지막은 제외
                    {
                        if (i != 5)  // 출력하고 싶지 않은 열 지정
                        {
                            textExport.Write(item.SubItems[i].Text);
                            textExport.Write("|");
                            //textExport.Write(delimeter);  // 줄바꿈으로 처리하고 싶을 때
                        }
                    }
                    textExport.Write(delimeter);
                }

                textExport.Flush(); // flush from the buffers
                textExport.Close();
            }
        }
    }
}
