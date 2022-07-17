using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;                         // п.1.9
using ExcelObj = Microsoft.Office.Interop.Excel; //п.1.9 создается псевдоним пространства имен
                                                 //«Microsoft.Office.Interop.Excel».

namespace MicrosoftExcel_Lab5._1_
{
    public partial class Form1 : Form
    {
        ExcelObj.Application app = new ExcelObj.Application(); // п.3.1
        ExcelObj.Workbook workbook;
        ExcelObj.Worksheet NwSheet;
        ExcelObj.Range ShtRange;

        DataTable dt = new DataTable(); // п.3.2

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // п.1.4. Обр. события кнопки.
        {
            if (ofd.ShowDialog() == DialogResult.OK) // п.3.3
            {
                textBox1.Text = ofd.FileName;

                workbook = app.Workbooks.Open(ofd.FileName); // п.3.4 код следует указывать в теле Оп. выб.
                NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1); // п.3.5 - // -
                ShtRange = NwSheet.UsedRange; // п.3.6 - // -

                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++) // п.3.9
                {
                    dt.Columns.Add(new DataColumn((ShtRange.Cells[1, Cnum] as ExcelObj.Range).Value2.ToString()));
                }
                dt.AcceptChanges();

                string[] columnNames = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnNames[0] = dt.Columns[i].ColumnName;
                }

                for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                {
                    DataRow dr = dt.NewRow();
                    for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                    {
                        if ((ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2 != null)
                        {
                            dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                dataGridView1.DataSource = dt; // п.3.10
                app.Quit();
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл для открытия",
                "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
