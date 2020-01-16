using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace Lab_1_ISIS
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64195/");
                HttpResponseMessage response = client.GetAsync("api/products").Result;
                var settingg = response.Content.ReadAsAsync<IEnumerable<Setting1>>().Result;
                serviceGrid.DataSource = settingg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AddProduct(textBox2.Text, textBox3.Text);
                MessageBox.Show("Настройка добавлена");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AddProduct(string name, string val)
        {
            Setting1 s = new Setting1();
            s.Name = name;
            s.Value = val;
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(s);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:64195/api/products", content);
            };
        }

        private async void DeleteProduct(int delid)
        {
            using (var client = new HttpClient())
            {
                var result = await client.DeleteAsync(String.Format("{0}/{1}", "http://localhost:64195/api/products", delid));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteProduct(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("Настройка удалена");
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ini inif = new ini("settings.ini");
            int formWidth = Convert.ToInt32(inif.Read("FormWidth"));
            int formHeight = Convert.ToInt32(inif.Read("FormHeight"));
            int label3Width = Convert.ToInt32(inif.Read("Label3Width"));
            int label3Height = Convert.ToInt32(inif.Read("Label3Height"));
            int label3MaximumWeidht = Convert.ToInt32(inif.Read("Label3MaximumWeidht"));
            int label3MaximumHeight = Convert.ToInt32(inif.Read("Label3MaximumHeight"));
            //int autoSize = Convert.ToInt32(ini.Read("AutoSize"));
            //string poiskText = ini.Read("PoiskText");
            //string zamenaText = ini.Read("ZamenaText");
            //string pathtext = ini.Read("Pathtext");
            AddProduct("FormWidth", Convert.ToString(formWidth));
            AddProduct("FormHeight", Convert.ToString(formHeight));
            AddProduct("Label3Width", Convert.ToString(label3Width));
            AddProduct("Label3Height", Convert.ToString(label3Height));
            AddProduct("Label3MaximumWeidht", Convert.ToString(label3MaximumWeidht));
            AddProduct("Label3MaximumHeight", Convert.ToString(label3MaximumHeight));
           //AddProduct("AutoSize", Convert.ToString(autoSize));
            //AddProduct("PoiskText", Convert.ToString(poiskText));
            //AddProduct("ZamenaText", Convert.ToString(zamenaText));
            //AddProduct("Pathtext", Convert.ToString(pathtext));
        
        }

        
    }
}
