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

namespace UserIn2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (FontFamily F in Fonts.SystemFontFamilies) // п.12
            {
                comboBox1.Items.Add(F.ToString());
            }
        }

    private void Button_Click(object sender, RoutedEventArgs e) // п.8 RTB стало подчеркивать...
        {
            RichTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // п.9
        {
            RichTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // п.10
        {
            RichTextBox.Selection.ApplyPropertyValue(FontSizeProperty, Slider1.Value.ToString());
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) // п.11
        {
            RichTextBox.Selection.ApplyPropertyValue(FontFamilyProperty, new FontFamily(comboBox1.Text));
        }
    }
}

// НАЧИНАЕМ С П.13!!!!
