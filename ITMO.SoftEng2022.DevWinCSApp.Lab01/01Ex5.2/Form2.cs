using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab._1._5._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

// Сделайте так, чтобы при запуске стартовая форма разворачивалась до максимальных размеров
// Для этого свойство "Window State" установил на "Maximize"

// https://www.cyberforum.ru/windows-forms/thread76872.html