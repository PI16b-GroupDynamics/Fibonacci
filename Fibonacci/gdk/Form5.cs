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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Form3.is_rus == true)
            {
                label1.Text = "Для вычисления чисел Фибоначчи необходимо ввести число, до" + Environment.NewLine + "которого будет вычисляться ряд, в текстовое поле. Результат" + Environment.NewLine + "выводится во второе текстовое поле";
                button1.Text = "Закрыть";
                Text = "Инструкция";
            }
            else
            {
                label1.Text = "To compute Fibonacci numbers user have to enter number, that marks" + Environment.NewLine + "end of calculation, in text box. Result will be printed in second text box";
                button1.Text = "Close";
                Text = "Instruction";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
