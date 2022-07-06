using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Упражнение 3.2. Создание специализированного элемента управления

namespace WinTimer2_Lab3._2
{
    public partial class UserControlTimer2 : Control
    {
        public UserControlTimer2()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe); // п.6 переопределяем метод
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            g.FillRectangle(Brushes.Blue, 0, 0, this.Width, this.Height);

            // п.7 Это код для отображения времени
            pe.Graphics.DrawString(DateTime.Now.ToLongTimeString(), this.Font, new SolidBrush(this.ForeColor), 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
