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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.IsEnabled = false; // 1.3 п.2 + поменял имя в свойстве Name
            button1.IsEnabled = false; // 1.3 п.2 + поменял имя в свойстве Name
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Users\\Admin\\Desktop\\" +
                    "Практика_Win_CS\\ITMO.SoftEng2022.DevWinCSWpf.Lab1Ex3\\username.txt");
                sw.WriteLine(textBox.Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1.IsEnabled = true; // 1.3 п.5
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("C:\\Users\\Admin\\Desktop\\" +
                    "Практика_Win_CS\\ITMO.SoftEng2022.DevWinCSWpf.Lab1Ex3\\username.txt");
                label.Content = "Приветствую Вас, уважаемый " + sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
        }
    }
}