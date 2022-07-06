using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Упражнение 2.8. Проверка вводимых значений. События KeyPress и Validating.
// Элемент управления ErrorProvider

namespace RegistrationForm_Lab2._7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(16, 96);
                lbl.Size = new System.Drawing.Size(32, 23);
                lbl.Name = "labelll";
                lbl.TabIndex = 2;
                lbl.Text = "PIN2";
                groupBox1.Controls.Add(lbl);
                TextBox txt = new TextBox();
                txt.Location = new System.Drawing.Point(96, 96);
                txt.Size = new System.Drawing.Size(184, 20);
                txt.Name = "textboxx";
                txt.TabIndex = 1;
                txt.Text = "";
                groupBox1.Controls.Add(txt);
                // Здесь был долгирй затык. Долго думал куда вставлять код:
                txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress); // KeyPress 
            }
            else
            {
                int lcv;
                lcv = groupBox1.Controls.Count;
                while (lcv > 4)
                {
                    groupBox1.Controls.RemoveAt(lcv - 1);
                    lcv -= 1;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // KeyPress
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле Name не может содержать цифры");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // KeyPress
        {
            //// Эту часть коментируем для реализации события Validating
            //if (!char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Поле PIN не может содержать буквы");
            //}
        }
        // KeyPress НЕ позволяет внести недопутимые символы в строки,
        // сразу говорит об этом

        private void textBox2_Validating(object sender, CancelEventArgs e) // Validating
        {
            /// Эту часть коментируем для реализации события KeyPress
            if (textBox2.Text == "")
            {
                e.Cancel = false;
            }
            else
            {
                try
                {
                    double.Parse(textBox2.Text);
                    e.Cancel = false;
                }
                catch
                {
                    e.Cancel = true;
                    MessageBox.Show("Поле PIN не может содержать буквы");
                }
            }
            // Validating позволяет внести недопутимые символы в строки, 
            // но говорит об этом при нажатии на кнопку Регистрация
        }
    }
}