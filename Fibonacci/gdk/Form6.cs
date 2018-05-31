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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection("Provider=VFPOLEDB.1;" + "Data Source=C:\\Users\\igory\\Desktop\\gdk_db\\data1.dbc;");
            OleDbCommand command = new OleDbCommand("SELECT id, login, password, f, i, o, pol, admin from table1", connection);
            connection.Open();
            command.Connection = connection;
            OleDbDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetBoolean(7));
            }

            connection.Close();
        }
    }
}
