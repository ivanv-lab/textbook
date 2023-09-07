using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Core = Microsoft.Office.Core;
using System.Drawing.Printing;
using abc;
using System.Security.Cryptography.X509Certificates;

namespace textbook
{
    public partial class Practice : Form
    {
        public string filename;
        public int x = 0;
        public string rich;
        public string listfile;
        public int lc;
        public bool lic;
        List<string> lekcii = new List<string> { "Лабораторная работа №1" };

        public Practice()
        {
            InitializeComponent();
            lekcii.AddRange(File.ReadAllLines(Environment.CurrentDirectory + "\\Practica\\Spisok.txt"));
            string[] lekcii2 = lekcii.ToArray<string>();
            listBox1.Items.AddRange(lekcii2);
        }

        private void Practice_Load(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
        }

        private void Practice_FormClosing(object sender, FormClosingEventArgs e)
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

        private void тестированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test f3= new Test();
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
            if (result == DialogResult.Yes) { System.Windows.Forms.Application.Exit(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rich = richTextBox1.Text;
            OpenClass obj = new OpenClass(filename, rich);
            obj.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            rich = "";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            openFileDialog1.Filter = "doc files(*.doc)|*.doc|docx files(*.docx)|*.docx|text files(*.txt)|*.txt";
            filename = openFileDialog1.FileName;
            OpenClass obj = new OpenClass(filename, rich);
            obj.Open(ref rich);
            richTextBox1.Text = rich;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Word.Application app = new Word.Application();
                app.Visible = false;
                object missing = Type.Missing;
                Word.Document doc = app.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                doc.Content.Text += richTextBox1.Text;
                doc.Save();
                doc.Close();
                app.Quit();
            }
            catch
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;
            if (printDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            printDialog1.Document = printDocument1;
            printDocument1.Print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num = 0;
            char ch = '\\';
            for (int i = 0; i < filename.Length; i++)
            {
                if (filename[i] == ch)
                    num = i;
                listfile = filename.Remove(0, num + 1);
            }
            listfile = listfile.Remove(listfile.Length - 5, 5);
            lekcii.Add(listfile);
            File.AppendAllText(Environment.CurrentDirectory + "\\Practica\\Spisok.txt", listfile + Environment.NewLine);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items.Contains(listfile) == true)
                    return;
                else
                {
                    File.Move(filename, Environment.CurrentDirectory + "/Practica/" + listfile + ".docx");
                    listBox1.Items.Add(listfile);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            rich = "";
            filename = Environment.CurrentDirectory + "\\Practica\\" + listBox1.SelectedItem + ".docx";
            OpenClass obj = new OpenClass(filename, rich);
            obj.Open(ref rich);
            richTextBox1.Text = rich;
        }
    }
}
