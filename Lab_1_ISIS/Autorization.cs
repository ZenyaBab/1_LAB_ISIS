using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab_1_ISIS
{
    public partial class Autorization : Form
    {
        SqlConnection sqlConnection;
        public Autorization()
        {
            InitializeComponent();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Laba3_ISIS;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                try
                {
                    SqlCommand vhodcomand = new SqlCommand("select Login from [dbo].[User] where Login=@Login and Password=@Password", sqlConnection);
                    vhodcomand.Parameters.AddWithValue("@Login", textBox1.Text);
                    vhodcomand.Parameters.AddWithValue("@Password", textBox2.Text);
                    Name = (string)vhodcomand.ExecuteScalar();
                    if (Name == textBox1.Text)
                    {
                        Form mdi = new MDI();
                        this.Hide();
                        mdi.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Неправильный логин или пароль", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Autorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }
    }
    
}
