using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonacci
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (Form3.is_rus == true)
            {
                label1.Text = "Программа \"Fibonacci\" предназначена для вычисления числового ряда" + Environment.NewLine + "Фибоначчи до заданного пользователем ограничения.";
                button1.Text = "Закрыть";
                Text = "О программе";
            }
            else
            {
                label1.Text = "Program \"Fibonacci\" is to compute Fibonacci numbers till user's end number.";
                button1.Text = "Close";
                Text = "About porgram";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
