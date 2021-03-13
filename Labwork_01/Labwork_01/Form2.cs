using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labwork_01
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;

        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Table] (Логин, Email,Имя,Фамилия,Телефон,Датарождения)VALUES(@Логин, @Email,@Имя,@Фамилия,@Телефон,@Датарождения)", sqlConnection);

            command.Parameters.AddWithValue("Логин", textBox1.Text);

            command.Parameters.AddWithValue("Email", textBox5.Text);
            command.Parameters.AddWithValue("Имя", textBox4.Text);

            command.Parameters.AddWithValue("Фамилия", textBox3.Text);
            command.Parameters.AddWithValue("Телефон", textBox6.Text);
            command.Parameters.AddWithValue("Датарождения", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            await command.ExecuteNonQueryAsync();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danil\source\repos\Labwork_01\Labwork_01\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
