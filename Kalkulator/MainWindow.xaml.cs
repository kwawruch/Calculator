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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<float> historyNumbers = new List<float>();
        public char lastOperation = '0';
        public bool resultsVisible = false;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (resultsVisible)
            {
                TextBlockResult.Text = "";
                resultsVisible = false;
            }
            Button button = sender as Button;
            if (TextBlockResult.Text == "0") TextBlockResult.Text = "";
            TextBlockResult.Text += button.Content;
        }

        private void DragBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (resultsVisible)
            {
                TextBlockResult.Text = "0";
                resultsVisible = false;
            }
            TextBlockResult.Text = TextBlockResult.Text.Remove(TextBlockResult.Text.Length - 1);
            if (TextBlockResult.Text == "") TextBlockResult.Text = "0";
            Operation.SetFalse();
        }
        
        
        private void ButtonCount_Click(object sender, RoutedEventArgs e)
        {
            Operation.SetFalse();
            if (lastOperation == '+')
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockResult.Text = (historyNumbers[historyNumbers.Count - 1] + historyNumbers[historyNumbers.Count - 2]).ToString();
            }
            else if (lastOperation == '-')
            {
                TextBlockResult.Text = (int.Parse(TextBlockMemory.Text) - int.Parse(TextBlockResult.Text)).ToString();
            }

            resultsVisible = true;
        }

        
        private void ButtonAddition_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.addiction==false)
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockMemory.Text = TextBlockResult.Text;
                TextBlockResult.Text = "0";
                lastOperation = '+';
                Operation.addiction = true;
            }
            else Operation.SetFalse(add:true);
            
        }

        private void ButtonSubstraction_Click(object sender, RoutedEventArgs e)
        {
            if(Operation.substration==false)
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockMemory.Text = TextBlockResult.Text;
                TextBlockResult.Text = "0";
                lastOperation = '-';
                Operation.substration = true;
            }
            else Operation.SetFalse(sub: true);
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            TextBlockResult.Text = (float.Parse(TextBlockResult.Text) / 100).ToString("0,00 %");
        }

        //Multiplication, Division
    }
}
