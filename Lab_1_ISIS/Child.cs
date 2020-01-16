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
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Текстовый файл (*.txt) | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, richTextBox1.Text);
                 
                }
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
                else
                {
                    MessageBox.Show("Нет текста для замены");
                }
            }
            else
            {
                MessageBox.Show("Нет текста для замены");
            }


        }

        private void Child_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    SqlCommand Widthcom = new SqlCommand("update dbo.Setting set FormWidth = @FormWidth where ID_Setting = 1", sqlConnection);
            //    Widthcom.Parameters.AddWithValue("FormWidth", this.Size.Width);
            //    Widthcom.ExecuteScalar();

            //    SqlCommand Heightcom = new SqlCommand("update dbo.Setting set FormHeight = @FormHeight where ID_Setting = 1", sqlConnection);
            //    Heightcom.Parameters.AddWithValue("FormHeight", this.Size.Height);
            //    Heightcom.ExecuteScalar();

            //    SqlCommand Label3Width = new SqlCommand("update dbo.Setting set Label3Width = @Label3Width where ID_Setting = 1", sqlConnection);
            //    Label3Width.Parameters.AddWithValue("Label3Width", label3.Size.Width);
            //    Label3Width.ExecuteScalar();

            //    SqlCommand Label3Height = new SqlCommand("update dbo.Setting set Label3Height = @Label3Height where ID_Setting = 1", sqlConnection);;
            //    Label3Height.Parameters.AddWithValue("Label3Height", label3.Size.Height);
            //    Label3Height.ExecuteScalar();

            //    SqlCommand Label3MaximumWeidht = new SqlCommand("update dbo.Setting set Label3MaximumWeidht = @Label3MaximumWeidht where ID_Setting = 1", sqlConnection);
            //    Label3MaximumWeidht.Parameters.AddWithValue("Label3MaximumWeidht", label3.MaximumSize.Width);
            //    Label3MaximumWeidht.ExecuteScalar();

            //    SqlCommand Label3MaximumHeight = new SqlCommand("update dbo.Setting set Label3MaximumHeight = @Label3MaximumHeight where ID_Setting = 1", sqlConnection);
            //    Label3MaximumHeight.Parameters.AddWithValue("Label3MaximumHeight", label3.MaximumSize.Height);
            //    Label3MaximumHeight.ExecuteScalar();

            //    SqlCommand AutoSize = new SqlCommand("update dbo.Setting set AutoSize = @AutoSize where ID_Setting = 1", sqlConnection);
            //    AutoSize.Parameters.AddWithValue("AutoSize", label3.AutoSize);
            //    AutoSize.ExecuteScalar();

            //    SqlCommand PoiskText = new SqlCommand("update dbo.Setting set PoiskText = @PoiskText where ID_Setting = 1", sqlConnection);
            //    PoiskText.Parameters.AddWithValue("PoiskText", textBox1.Text);
            //    PoiskText.ExecuteScalar();

            //    SqlCommand ZamenaText = new SqlCommand("update dbo.Setting set ZamenaText = @ZamenaText where ID_Setting = 1", sqlConnection);
            //    ZamenaText.Parameters.AddWithValue("ZamenaText", textBox2.Text);
            //    ZamenaText.ExecuteScalar();

            //    if (text != "")
            //    {
            //        SqlCommand Pathtext = new SqlCommand("update dbo.Setting set Pathtext = @Pathtext where ID_Setting = 1", sqlConnection);
            //        Pathtext.Parameters.AddWithValue("Pathtext", text);
            //        Pathtext.ExecuteScalar();
            //    }

            //}
            //catch { }

            //if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            //    sqlConnection.Close();

            ini inif = new ini("settings.ini");
            inif.Write("FormWidth", Convert.ToString(this.Size.Width));
            inif.Write("FormHeight", Convert.ToString(this.Size.Height));
            inif.Write("Label3Width", Convert.ToString(label3.Size.Width));
            inif.Write("Label3Height", Convert.ToString(label3.Size.Height));
            inif.Write("Label3MaximumWeidht", Convert.ToString(label3.MaximumSize.Width));
            inif.Write("Label3MaximumHeight", Convert.ToString(label3.MaximumSize.Height));
            //inif.Write("AutoSize", Convert.ToString(label3.AutoSize));
            inif.Write("PoiskText", textBox1.Text);
            inif.Write("ZamenaText", textBox2.Text);
            if (text != "")
                inif.Write("Pathtext", text);
        }

        private void Child_Load(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Laba3_ISIS;Integrated Security=True";
            //sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            //SqlDataReader sqlReader = null;
            //SqlCommand name = new SqlCommand("select Name from dbo.Book", sqlConnection);
            //try
            //{
            //    sqlReader = name.ExecuteReader();
            //    while (sqlReader.Read())
            //    {
            //        domainUpDown1.Items.Add(Convert.ToString(sqlReader["Name"]));
            //    }
            //}
            //finally
            //{
            //    if (sqlReader != null)
            //        sqlReader.Close();
            //}
            //domainUpDown1.SelectedIndex = 0;
           
            //try
            //{
            //    SqlCommand Widthcom = new SqlCommand("select FormWidth from dbo.Setting where ID_Setting = 1", sqlConnection);
            //    Widthcom.Parameters.AddWithValue("FormWidth", "FormWidth");
            //    Width = Convert.ToInt32(Widthcom.ExecuteScalar());

            //    SqlCommand Heightcom = new SqlCommand("select FormHeight from dbo.Setting where ID_Setting = 1", sqlConnection);
            //    Heightcom.Parameters.AddWithValue("FormHeight", "FormHeight");
            //    Height = Convert.ToInt32(Heightcom.ExecuteScalar());
            //}
            //catch
            //{ }

            ini inif = new ini("settings.ini");
            try
            {
                Width = Convert.ToInt32(inif.Read("FormWidth"));
                Height = Convert.ToInt32(inif.Read("FormHeight"));
                label3.Text = "Путь к последнему открытому тексту:     " + inif.Read("Pathtext");
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form settings = new Settings();
            settings.Show();
        }
    }
}
