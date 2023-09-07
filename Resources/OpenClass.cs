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
using textbook;


namespace abc
{

    internal class OpenClass : Teory
    {
        public string filename;
        public string rich;
        public OpenClass(string filename, string rich)
        {
            this.filename = filename;
            this.rich = rich;
        }

        public void Open(ref string rich)
        {
            x = filename.IndexOf(".");
            //q = filename;
            if (filename.Remove(0, x + 1) == "docx" || filename.Remove(0, x + 1) == "doc" || filename.Remove(0, x + 1) == "txt")
            {
                if (filename.Remove(0, x + 1) == "docx")
                {
                    string filename1 = filename.Remove(filename.Length - 4, 4) + "txt";
                    Word.Application appWord = new Word.Application();
                    appWord.Documents.Open(filename);

                    Word.Document doc = appWord.ActiveDocument;
                    doc.ReadOnlyRecommended = false;
                    StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, filename1), true, Encoding.UTF8);

                    for (int i = 1; i <= doc.Paragraphs.Count; i++)
                    {
                        string Paragraph_Text = doc.Paragraphs[i].Range.Text;
                        Paragraph_Text = Paragraph_Text.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                        if (!String.IsNullOrEmpty(Paragraph_Text) || !String.IsNullOrWhiteSpace(Paragraph_Text))
                            writer.WriteLine(Paragraph_Text);
                        rich += Paragraph_Text + Environment.NewLine;
                    }

                    writer.Close();
                    doc.Close();
                    appWord.Quit();
                    File.Delete(filename1);
                }
                if (filename.Remove(0, x + 1) == "doc")
                {
                    string filename1 = filename.Remove(filename.Length - 3, 3) + "txt";
                    Word.Application appWord = new Word.Application();
                    appWord.Documents.Open(filename);
                    Word.Document doc = appWord.ActiveDocument;
                    doc.ReadOnlyRecommended = false;
                    StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, filename1), true, Encoding.UTF8);

                    for (int i = 1; i <= doc.Paragraphs.Count; i++)
                    {
                        string Paragraph_Text = doc.Paragraphs[i].Range.Text;
                        Paragraph_Text = Paragraph_Text.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                        if (!String.IsNullOrEmpty(Paragraph_Text) || !String.IsNullOrWhiteSpace(Paragraph_Text))
                            writer.WriteLine(Paragraph_Text);
                        rich += Paragraph_Text + Environment.NewLine;
                    }

                    writer.Close();
                    doc.Close();
                    appWord.Quit();

                    File.Delete(filename1);
                }
                if (filename.Remove(0, x + 1) == "txt")
                {
                    rich = File.ReadAllText(filename);
                }
            }
            else
                MessageBox.Show("Ошибка!Неподдерживаемый формат файла." +
                    "(Поддерживаемые форматы: .doc, .docx, .txt)");
        }
        public void Save()
        {
            x = filename.IndexOf(".");
            if (filename.Remove(0, x + 1) == "docx" || filename.Remove(0, x + 1) == "doc")
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(filename);
                object missing = System.Reflection.Missing.Value;
                doc.Content.Delete();
                doc.Content.Text += rich;
                app.Visible = false;
                doc.ReadOnlyRecommended = false;
                doc.Save();
                doc.Close();
                app.Quit();
            }
            if (filename.Remove(0, x + 1) == "txt")
            {
                File.WriteAllText(filename, rich);
            }
        }

    }

}
