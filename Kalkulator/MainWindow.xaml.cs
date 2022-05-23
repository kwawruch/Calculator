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

        public void ResizeResults()
        {
            if (TextBlockResult.Text.Length > 12)
            {
                TextBlockResult.FontSize = 40;
            }
            else TextBlockResult.FontSize = 50;
        }
        public void UpdateResults(char lastOperation)
        {
            if(TextBlockResult.Text != "")
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockMemory.Text = TextBlockResult.Text;
                TextBlockResult.Text = "";
            }
            this.lastOperation = lastOperation;
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
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockResult.Text = (float.Parse(TextBlockMemory.Text) - float.Parse(TextBlockResult.Text)).ToString();
            }
            else if(lastOperation=='*')
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockResult.Text = (float.Parse(TextBlockMemory.Text) * float.Parse(TextBlockResult.Text)).ToString();
            }
            else if(lastOperation=='/')
            {
                historyNumbers.Add(float.Parse(TextBlockResult.Text));
                TextBlockResult.Text = (float.Parse(TextBlockMemory.Text) / float.Parse(TextBlockResult.Text)).ToString();
            }
            resultsVisible = true;
        }

        
        private void ButtonAddition_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.addiction==false)
            {
                UpdateResults('+');
                Operation.addiction = true;
            }
            else Operation.SetFalse(add:true);
        }

        private void ButtonSubstraction_Click(object sender, RoutedEventArgs e)
        {
            if(Operation.substration==false)
            {
                UpdateResults('-');
                Operation.substration = true;
            }
            else Operation.SetFalse(sub: true);
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            if(!resultsVisible)
            {
                TextBlockResult.Text = float.Parse(TextBlockResult.Text).ToString("0.00%");
                resultsVisible = true;
            }
        }

        private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.multiplication == false)
            {
                UpdateResults('*');
                Operation.multiplication = true;
            }
            else Operation.SetFalse(multi: true);
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.division == false)
            {
                UpdateResults('/');
                Operation.division = true;
            }
            else Operation.SetFalse(div: true);
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            Operation.SetFalse();
            historyNumbers.Add(float.Parse(TextBlockResult.Text));
            TextBlockMemory.Text = TextBlockResult.Text;
            TextBlockResult.Text = Math.Sqrt(historyNumbers.Last()).ToString();
            ResizeResults();
        }
    }
}
