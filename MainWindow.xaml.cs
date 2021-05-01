using System;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainGrid.Children) {
                if (el is Button) {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = (string)((Button)e.OriginalSource).Content;
                if (str == "AC")
                    textOutput.Text = "";
                else if (str == "C" && textOutput.Text.Length > 0)
                {
                    textOutput.Text = textOutput.Text.Substring(0, textOutput.Text.Length - 1);
                }
                else if (str == "=")
                {
                    string value = new DataTable().Compute(textOutput.Text, null).ToString();
                    textOutput.Text = value;
                }
                else
                    textOutput.Text += str;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
