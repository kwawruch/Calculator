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
        }

        private void ButtonCount_Click(object sender, RoutedEventArgs e)
        {
            if (lastOperation == '+') TextBlockResult.Text = (int.Parse(TextBlockMemory.Text) + int.Parse(TextBlockResult.Text)).ToString();
            else if (lastOperation == '-') TextBlockResult.Text = (int.Parse(TextBlockMemory.Text) - int.Parse(TextBlockResult.Text)).ToString();

            resultsVisible = true;
        }
        private void ButtonAddition_Click(object sender, RoutedEventArgs e)
        {
            TextBlockMemory.Text = TextBlockResult.Text;
            TextBlockResult.Text = "0";
            if (TextBlockResult.Text != "")
            {
                if (TextBlockMemory.Text == "") TextBlockMemory.Text = "0";
                TextBlockResult.Text = (int.Parse(TextBlockMemory.Text) + int.Parse(TextBlockResult.Text)).ToString();
                TextBlockResult.Text = "0";
            }
            lastOperation = '+';
        }

            private void ButtonSubstraction_Click(object sender, RoutedEventArgs e)
        {
            TextBlockMemory.Text = TextBlockResult.Text;
            TextBlockResult.Text = "0";
            if (TextBlockResult.Text != "")
            {
                if (TextBlockMemory.Text == "") TextBlockMemory.Text = "0";
                TextBlockResult.Text = (int.Parse(TextBlockMemory.Text) - int.Parse(TextBlockResult.Text)).ToString();
                TextBlockResult.Text = "0";
            }
            lastOperation = '-';
        }
        //Multiplication, Division
    }
}
