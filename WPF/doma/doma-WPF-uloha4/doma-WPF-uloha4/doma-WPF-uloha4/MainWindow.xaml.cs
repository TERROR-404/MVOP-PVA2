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

namespace doma_WPF_uloha4
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string input = textBox.Text;
            try
            {
                input = input.Replace('.', ',');
                bool loop = true;
                int j = 0;
                while (loop)
                {
                    if (j == input.Length)
                    {
                        loop = false;
                    }
                    else if ((input[j] == '*' || input[j] == '/' || input[j] == '+' || input[j] == '-') && (input[j - 1] != ' ') && (input[j + 1] != ' '))
                    {
                        input = $"{input.Substring(0, j)} {input[j]} {input.Substring(j + 1, input.Length - j - 1)}";
                        j += 2;
                    }
                    j++;
                }
                string multiplyDivide = Operation("*/", input);
                string plusMinus = Operation("+-", multiplyDivide);
                double output = double.Parse(plusMinus);
                label.Content = output;
            }
            catch (Exception)
            {
                throw new Exception("Nebyla zadána platná početní operace!");
            }
        }
        private string Operation(string charracters, string operationInput)
        {
            string operationOutput = operationInput;
            string[] operationOutputElements = operationOutput.Split(' ');
            bool operationLoop = true;
            int i = 0;
            while (operationLoop)
            {
                if (operationOutputElements[i] == charracters[0].ToString())
                {
                    if (charracters[0] == '*')
                    {
                        operationOutput = operationOutput.Replace($"{operationOutputElements[i - 1]} * {operationOutputElements[i + 1]}", (Convert.ToDouble(operationOutputElements[i - 1]) * Convert.ToDouble(operationOutputElements[i + 1])).ToString());
                        operationOutputElements = operationOutput.Split(' ');
                        i = 0;
                    }
                    else
                    {
                        operationOutput = operationOutput.Replace($"{operationOutputElements[i - 1]} + {operationOutputElements[i + 1]}", (Convert.ToDouble(operationOutputElements[i - 1]) + Convert.ToDouble(operationOutputElements[i + 1])).ToString());
                        operationOutputElements = operationOutput.Split(' ');
                        i = 0;
                    }
                }
                else if (operationOutputElements[i] == charracters[1].ToString())
                {
                    if (charracters[1] == '/')
                    {
                        operationOutput = operationOutput.Replace($"{operationOutputElements[i - 1]} / {operationOutputElements[i + 1]}", (Convert.ToDouble(operationOutputElements[i - 1]) / Convert.ToDouble(operationOutputElements[i + 1])).ToString());
                        operationOutputElements = operationOutput.Split(' ');
                        i = 0;
                    }
                    else
                    {
                        operationOutput = operationOutput.Replace($"{operationOutputElements[i - 1]} - {operationOutputElements[i + 1]}", (Convert.ToDouble(operationOutputElements[i - 1]) - Convert.ToDouble(operationOutputElements[i + 1])).ToString());
                        operationOutputElements = operationOutput.Split(' ');
                        i = 0;
                    }
                }
                i++;
                if (i >= operationOutputElements.Length)
                {
                    operationLoop = false;
                }
            }
            return operationOutput;
        }
    }
}
