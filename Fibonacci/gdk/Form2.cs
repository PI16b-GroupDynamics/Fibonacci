using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonacci
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox4.Text == "")
            {
                label7.Text = "Заполните все поля!";
                if (textBox1.Text == "")
                {
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    label1.ForeColor = Color.Black;
                }
                if (textBox2.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                else
                {
                    label2.ForeColor = Color.Black;
                }
                if (textBox3.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                else
                {
                    label3.ForeColor = Color.Black;
                }
                if (textBox5.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                else
                {
                    label4.ForeColor = Color.Black;
                }
                if (textBox6.Text == "")
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.Black;
                }
                if (textBox4.Text == "")
                {
                    label8.ForeColor = Color.Red;
                }
                else
                {
                    label8.ForeColor = Color.Black;
                }
                return;
            }
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            if (textBox6.Text != textBox4.Text)
            {
                label7.Text = "Пароли не совпадают!";
                label8.ForeColor = Color.Red;
                textBox4.Text = "";
                return;
            }
            else
            {
                label8.ForeColor = Color.Black;
            }
            OleDbConnection connection = new OleDbConnection("Provider=VFPOLEDB.1;" + "Data Source=C:\\Users\\igory\\Desktop\\gdk_db\\data1.dbc;");
            OleDbCommand command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "Insert into table1 (login, password, f, i, o, pol, admin) VALUES (?, ?, ?, ?, ?, ?, .F.)";
            command.Parameters.AddWithValue("@login", textBox5.Text);
            command.Parameters.AddWithValue("@password", textBox6.Text);
            command.Parameters.AddWithValue("@f", textBox1.Text);
            command.Parameters.AddWithValue("@i", textBox2.Text);
            command.Parameters.AddWithValue("@o", textBox3.Text);
            if (radioButton1.Checked)
            {
                command.Parameters.AddWithValue("@pol", true);
            }
            if (radioButton2.Checked)
            {
                command.Parameters.AddWithValue("@pol", false);
            }
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Регистрация прошла успешно!");
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
