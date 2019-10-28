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
using System.Windows;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Lab_1_ISIS
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (text == "")
            {
                MessageBox.Show("Нет текста чтобы сохранить его");
                
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Текстовый файл (*.txt) | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName,richTextBox1.Text);
                }
                XDocument doc = new XDocument();
                XElement text = new XElement("Result", richTextBox1.Text);
                doc.Add(text);
                doc.Save("result.xml");
                MessageBox.Show("XML файл сохранен");
            }
        }

        public string text = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            openFileDialog1.Title = "Загрузить из...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.FileName;
                text = openFileDialog1.FileName;
                try
                {
                    richTextBox1.LoadFile(text);
                }
                catch { richTextBox1.Text = File.ReadAllText(text); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (text == "")
            {
                MessageBox.Show("Нет текста чтобы сохранить его");

            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Текстовый файл (*.rtf) | *.rtf";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, richTextBox1.Text);
                   
                }
                XDocument doc = new XDocument();
                XElement text = new XElement("Result", richTextBox1.Text);
                doc.Add(text);
                doc.Save("result.xml");
                MessageBox.Show("XML файл сохранен");
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text))
                {
                    richTextBox1.Text = Regex.Replace(richTextBox1.Text, textBox1.Text, textBox2.Text);
                }
            }
        }

        private void Child_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            ini inif = new ini("settings.ini");
            inif.Write("FormWidth", Convert.ToString(this.Size.Width));
            inif.Write("FormHeight", Convert.ToString(this.Size.Height));
            inif.Write("Label3Width", Convert.ToString(label3.Size.Width));
            inif.Write("Label3Height", Convert.ToString(label3.Size.Height));
            inif.Write("Label3MaximumWeidht", Convert.ToString(label3.MaximumSize.Width));
            inif.Write("Label3MaximumHeight", Convert.ToString(label3.MaximumSize.Height));
            inif.Write("AutoSize", Convert.ToString(label3.AutoSize));
            inif.Write("PoiskText", textBox1.Text);
            inif.Write("ZamenaText", textBox2.Text);
            if (text != "")
                inif.Write("Pathtext", text);
        }

        private void Child_Load(object sender, EventArgs e)
        {
            ini inif = new ini("settings.ini");
            try
            {
                Width = Convert.ToInt32(inif.Read("FormWidth"));
                Height = Convert.ToInt32(inif.Read("FormHeight"));
                label3.Text = "Путь к последнему открытому тексту:     " + inif.Read("Pathtext");
            }
            catch { }
        }


    }
}
