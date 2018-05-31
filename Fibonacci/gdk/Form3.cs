using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonacci
{
    public partial class Form3 : Form
    {
        public static List<int> l;
        public static bool is_rus;
        public static int o;
        public Form3()
        {
            InitializeComponent();
            l = new List<int>();
            is_rus = true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;           
            Fibonacci(worker, e);
        }
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Text += " " + o.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }
        private void Fibonacci(BackgroundWorker worker, DoWorkEventArgs e)
        {            
            int j = 1;
            for (o = 1; o <= Convert.ToInt32(textBox1.Text) && backgroundWorker1.CancellationPending == false; o += j)
            {
                    backgroundWorker1.ReportProgress(o * 100 / Convert.ToInt32(textBox1.Text));
                    j = o - j;
                    System.Threading.Thread.Sleep(100);
            }       
            if (worker.CancellationPending)
                e.Cancel = true;

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            button2.Enabled = false;
            textBox1.Enabled = true;
            progressBar1.Value = 0;
            backgroundWorker1.DoWork -= new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged -= new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
            button2.Enabled = true;
            textBox1.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_rus == true)
            {
                if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }

        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_rus == true)
            {
                return;
            }
            else
            {
                файлToolStripMenuItem.Text = "Файл";
                сохранитьToolStripMenuItem.Text = "Сохранить";
                справкаToolStripMenuItem.Text = "Справка";
                оПрограммеToolStripMenuItem.Text = "О программе";
                инструкцияToolStripMenuItem.Text = "Инструкция";
                языкToolStripMenuItem.Text = "Язык";
                выходToolStripMenuItem.Text = "Выход";
                label1.Text = "Число, до которого будет вычислен ряд Фибоначчи:";
                label2.Text = "Ряд чисел Фибоначчи:";
                button1.Text = "Ввод";
                is_rus = true;
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_rus == false)
            {
                return;
            }
            else
            {
                файлToolStripMenuItem.Text = "File";
                сохранитьToolStripMenuItem.Text = "Save";
                справкаToolStripMenuItem.Text = "Help";
                оПрограммеToolStripMenuItem.Text = "About program";
                инструкцияToolStripMenuItem.Text = "Instruction";
                языкToolStripMenuItem.Text = "Language";
                выходToolStripMenuItem.Text = "Exit";
                label1.Text = "End number of Fibonacci calculation:";
                label2.Text = "Fibonacci numbers:";
                button1.Text = "Enter";
                is_rus = false;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f5 = new Form5();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            if (is_rus == true)
            {
                textBox2.Text = "Отменено";
            }
            else
            {
                textBox2.Text = "Canceled";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (Form1.adm == true)
            {
                администрированиеToolStripMenuItem.Visible = true;
            }
            else
            {
                администрированиеToolStripMenuItem.Visible = false;
            }
        }

        private void администрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lines = textBox2.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(saveFileDialog.FileName);
                wr.Write(lines);
                wr.Close();
                MessageBox.Show("Файл сохранен");
            }
        }
    }
}
