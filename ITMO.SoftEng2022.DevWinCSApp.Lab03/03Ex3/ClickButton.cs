using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Упражнение 3.3. Создание расширенных элементов управления

namespace WinButNum_Lab3._3
{
    //internal class ClickButton // п.2 Изменяем класс
    public class ClickButton : System.Windows.Forms.Button
    {
        int mClicks;
        public int Clicks
        {
            get { return mClicks; }
        }
        protected override void OnClick(EventArgs e) //  п.5. Переопределите метод OnClick
        {
            mClicks++;
            base.OnClick(e);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent) // п.6. Переопределите метод OnPaint
        {
            base.OnPaint(pevent);
            System.Drawing.Graphics g = pevent.Graphics;
            System.Drawing.SizeF stringsize;
            stringsize = g.MeasureString(Clicks.ToString(), this.Font,
            this.Width);
            g.DrawString(Clicks.ToString(), this.Font,
            System.Drawing.SystemBrushes.ControlText,
            this.Width - stringsize.Width - 3, this.Height -
            stringsize.Height - 3);
        }
    }
}
