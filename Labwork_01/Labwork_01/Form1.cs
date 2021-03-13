using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Labwork_01
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        DataSet ds;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danil\source\repos\Labwork_01\Labwork_01\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]",sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Логин"]) + "  " + Convert.ToString(sqlReader["Email"]) + "  " + Convert.ToString(sqlReader["Имя"]) + "  " + Convert.ToString(sqlReader["Фамилия"]) + "  " + Convert.ToString(sqlReader["Телефон"])+" "+ Convert.ToString(sqlReader["Датарождения"]));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 button1 = new Form2();
            button1.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private  void button2_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
