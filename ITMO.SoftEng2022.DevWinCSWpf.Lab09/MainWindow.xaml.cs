using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel; // 9.1.5
using System.Windows.Data; // 9.1.7
using System.Windows.Media; // 9.1.7
using System.Globalization; // 9.1.7

namespace DataBindingDemo
{
    public class Student // 9.1.1
    {
        public string StudentName { get; set; } // 9.1.3
        public bool IsEnrolled { get; set; } // 9.1.3
    }

    public class StudentList : ObservableCollection<Student> // 9.1.4 (подчеркивает <Student>)
    {

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    [ValueConversion(typeof(bool), typeof(Brush))] // 9.1.8
    public class BoolToBrushConverter: IValueConverter // п.9.1.6 + п.9.1.8
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // 9.1.9
        {
            Brush b = null;
            if (value != null && value.GetType() == typeof(bool))
            {
                b = (bool)value ? Brushes.Green : Brushes.Red;
            }
            return b;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // 9.1.9
        {
            return null;
        }
    }
}

