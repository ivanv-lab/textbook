using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace textbook
{
    public partial class Test : Form
    {
        int t = 0;
        int i = 1;
        List<string> lekcii = new List<string> {  };
        public Test()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = false;
            radioButton27.Checked = false;
            radioButton28.Checked = false;
            radioButton29.Checked = false;
            radioButton30.Checked = false;
            lekcii.AddRange(File.ReadAllLines(Environment.CurrentDirectory + "\\Test\\Spisok.txt"));
            string[] lekcii2 = lekcii.ToArray<string>();
            listBox1.Items.AddRange(lekcii2);
            listBox1.Items.RemoveAt(0);
            foreach (string s in File.ReadAllLines(Environment.CurrentDirectory + "\\Test\\Spisok.txt"))
            {
                i++;
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
           // string s = DateTime.Now.ToString();

        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void наГлавнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main f1 = new Main();
            f1.Show();
        }

        private void теорияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teory f2 = new Teory();
            f2.Show();
        }

        private void практикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Practice f3 = new Practice();
            f3.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Help.chm");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Внимание",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question,
             MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes) { Application.Exit(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Ошибка! Введите данные!");
                return;
            }
            panel1.Visible = false;
            tabControl1.Visible = true;
            button2.Visible = true;
            button4.Visible= true;
            button3.Visible = true;
            menuStrip1.Visible = false;
            timer1.Interval=1000;
            timer1.Enabled = true;
            timer1.Start();
            panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {

                tabControl1.SelectedTab = tabPage2;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {

                tabControl1.SelectedTab = tabPage3;
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {

                tabControl1.SelectedTab = tabPage4;
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {

                tabControl1.SelectedTab = tabPage5;
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {

                tabControl1.SelectedTab = tabPage6;
            }
            else if (tabControl1.SelectedTab == tabPage6)
            {

                tabControl1.SelectedTab = tabPage7;
            }
            else if (tabControl1.SelectedTab == tabPage7)
            {

                tabControl1.SelectedTab = tabPage8;
            }
            else if (tabControl1.SelectedTab == tabPage8)
            {

                tabControl1.SelectedTab = tabPage9;
            }
            else if (tabControl1.SelectedTab == tabPage9)
            {

                tabControl1.SelectedTab = tabPage10;
                button2.Visible = false;
                button3.Visible = true;
            }
            else if (tabControl1.SelectedTab == tabPage10)
            {

                button2.Visible = false;
                button3.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label14.Visible = true;
            label17.Visible = true;
            label15.Visible = true;
            label18.Visible = true;
            label19.Visible = true; 
            button6.Visible = true;
            button2.Visible = false;
            timer1.Stop();
            string s = (t%60).ToString();
            string m = (t / 60).ToString();
            label15.Text ="Время, затраченное на тестирование: "+ m+":"+s;
            string s11 = "Время, затраченное на тестирование: " + m+":"+s;
            string s12 = "Имя: " + textBox1.Text;
            string s13 = "Фамилия : " + textBox2.Text;
            DateTime dat = DateTime.Now;
            dat.ToShortDateString();
            string s14 = "Дата и время тестирования: " + dat.ToString();
            string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;
            int a = 0;
            int b = 0;
            tabControl1.Visible = false;
            button3.Visible = false;
            menuStrip1.Visible = true;
            button4.Visible = false;
            if (radioButton3.Checked && !radioButton1.Checked && !radioButton2.Checked)
            {
                a++;
                s1 = "1. Был выбран верный ответ";
            }
            else
            {
                s1 = "1. Был выбран неверный ответ";
                b++;
            }
            if (radioButton6.Checked && !radioButton4.Checked && !radioButton5.Checked)
            {
                a++;
                s2 = "2. Был выбран верный ответ";
            }
            else
            {
                s2 = "2. Был выбран неверный ответ";
                b++;
            }
            if (radioButton7.Checked && !radioButton8.Checked && !radioButton9.Checked)
            {
                a++;
                s3 = "3. Был выбран верный ответ";
            }
            else
            {
                s3 = "3. Был выбран неверный ответ";
                b++;
            }
            if (radioButton11.Checked && !radioButton10.Checked && !radioButton12.Checked)
            {
                a++;
                s4 = "4. Был выбран верный ответ";
            }
            else
            {
                s4 = "4. Был выбран неверный ответ";
                b++;
            }
            if (radioButton15.Checked && !radioButton13.Checked && !radioButton14.Checked)
            {
                a++;
                s5 = "5. Был выбран верный ответ";
            }
            else
            {
                s5 = "5. Был выбран неверный ответ";
                b++;
            }
            if (radioButton16.Checked && !radioButton17.Checked && !radioButton18.Checked)
            {
                a++;
                s6 = "6. Был выбран верный ответ";
            }
            else
            {
                s6 = "6. Был выбран неверный ответ";
                b++;
            }
            if (radioButton21.Checked && !radioButton19.Checked && !radioButton20.Checked)
            {
                a++;
                s7 = "7. Был выбран верный ответ";
            }
            else
            {
                s7 = "7. Был выбран неверный ответ";
                b++;
            }
            if (radioButton23.Checked && !radioButton22.Checked && !radioButton24.Checked)
            {
                a++;
                s8 = "8. Был выбран верный ответ";
            }
            else
            {
                s8 = "8. Был выбран неверный ответ";
                b++;
            }
            if (radioButton25.Checked && !radioButton26.Checked && !radioButton27.Checked)
            {
                a++;
                s9 = "9. Был выбран верный ответ";
            }
            else
            {
                s9 = "9. Был выбран неверный ответ";
                b++;
            }
            if (radioButton28.Checked && !radioButton29.Checked && !radioButton30.Checked)
            {
                a++;
                s10 = "10. Был выбран верный ответ";
            }
            else
            {
                s10 = "10. Был выбран неверный ответ";
                b++;
            }
            if (a >= 9)
            {
                label14.Text = "Правильных ответов: " + a.ToString()+Environment.NewLine+ "Неправильных ответов:"+b.ToString();
                label17.Text = "Ваша оценка 5";
              
            }
            if (a >= 7 && a < 9)
            {
                label14.Text = "Правильных ответов: " + a.ToString() + Environment.NewLine + "Неправильных ответов:" + b.ToString();
                label17.Text = "Ваша оценка 4";
               
            }
            if (a > 3 && a < 7)
            {
                label14.Text = "Правильных ответов: " + a.ToString() + Environment.NewLine + "Неправильных ответов:" + b.ToString();
                label17.Text = "Ваша оценка 3";
                
            }
            if (a <= 3)
            {
                label14.Text = "Правильных ответов: " + a.ToString() + Environment.NewLine + "Неправильных ответов:" + b.ToString();
                label17.Text = "Ваша оценка 2";
               
            }
            switch(a)
            {
                case 0: label19.Text = "Тест выполнен на 0%"; break;
                case 1: label19.Text = "Тест выполнен на 10%"; break;
                case 2: label19.Text = "Тест выполнен на 20%"; break;
                case 3: label19.Text = "Тест выполнен на 30%"; break;
                case 4: label19.Text = "Тест выполнен на 40%"; break;
                case 5: label19.Text = "Тест выполнен на 50%"; break;
                case 6: label19.Text = "Тест выполнен на 60%"; break;
                case 7: label19.Text = "Тест выполнен на 70%"; break;
                case 8: label19.Text = "Тест выполнен на 80%"; break;
                case 9: label19.Text = "Тест выполнен на 90%"; break;
                case 10: label19.Text = "Тест выполнен на 100%"; break;

            }
            string[] mas1 = { s12, s13, s14, s11, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            File.WriteAllLines(Environment.CurrentDirectory + "\\Test\\Попытка " + i.ToString() + ".txt", mas1);
            File.AppendAllText(Environment.CurrentDirectory + "\\Test\\Spisok.txt", "Попытка " + i.ToString()+Environment.NewLine);
            lekcii.Add("Попытка " + i.ToString());
            i++;

        }




        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s=File.ReadAllText(Environment.CurrentDirectory+"\\Test\\"+listBox1.SelectedItem.ToString()+".txt");
            MessageBox.Show(s);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти из тестирования?", "Внимание",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) 
            {
                tabControl1.SelectedTab = tabPage1;
                tabControl1.Visible = false;
                menuStrip1.Visible = true;
                button2.Visible= false;
                button3.Visible = false;
                panel1.Visible = true;
                panel4.Visible = true;
                button4.Visible = false;
                radioButton1.Checked= false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.Visible = true;
            menuStrip1.Visible = false;
            label18.Visible = false;
            button6.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;
            label19.Visible = false;
            button4.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = false;
            radioButton27.Checked = false;
            radioButton28.Checked = false;
            radioButton29.Checked = false;
            radioButton30.Checked = false;
        }
    }
    }

