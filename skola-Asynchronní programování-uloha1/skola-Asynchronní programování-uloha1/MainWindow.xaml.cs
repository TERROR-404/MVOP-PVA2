using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace skola_Asynchronní_programování_uloha1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private static CancellationTokenSource cts;
        private CancellationToken ct;

        public event PropertyChangedEventHandler PropertyChanged;
        private string output1;
        public string Output1
        {
            get { return output1; }
            set
            {
                output1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output1"));
            }
        }
        private string output2;
        public string Output2
        {
            get { return output2; }
            set
            {
                output2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output2"));
            }
        }
        private string output3;
        public string Output3
        {
            get { return output3; }
            set
            {
                output3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output3"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
            ct = cts.Token;
            this.DataContext = this;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)textbox1.Text;
            bool outputload = true;
            Task.Run(async () =>
            {
                await Task.Delay(500);
                while (outputload && ct.IsCancellationRequested == false)
                {
                    Output1 = "-";
                    await Task.Delay(500);
                    Output1 = "\\";
                    await Task.Delay(500);
                    Output1 = "|";
                    await Task.Delay(500);
                    Output1 = "/";
                    await Task.Delay(500);
                }
            });
            Task.Run(async () =>
            {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        outputload = false;
                        Output1 = a.ToString();
                        break;
                    }
                    a++;
                }
                outputload = false;
            });
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)textbox2.Text;
            bool outputload = true;

            Task.Run(async () =>
            {
                await Task.Delay(500);
                while (outputload && ct.IsCancellationRequested == false)
                {
                    Output2 = "-";
                    await Task.Delay(500);
                    Output2 = "\\";
                    await Task.Delay(500);
                    Output2 = "|";
                    await Task.Delay(500);
                    Output2 = "/";
                    await Task.Delay(500);
                }
            });
            Task.Run(() => {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        outputload = false;
                        Output2 = a.ToString();
                        break;
                    }
                    a++;
                }
                outputload = false;
            });
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)textbox3.Text;
            bool outputload = true;
            Task.Run(async () =>
            {
                await Task.Delay(500);
                while (outputload && ct.IsCancellationRequested == false)
                {
                    Output3 = "-";
                    await Task.Delay(500);
                    Output3 = "\\";
                    await Task.Delay(500);
                    Output3 = "|";
                    await Task.Delay(500);
                    Output3 = "/";
                    await Task.Delay(500);
                }
            });
            Task.Run(async () =>
            {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        outputload = false;
                        Output3 = a.ToString();
                        break;
                    }
                    a++;
                }
                outputload = false;
            });
        }
        private bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
                if (number % i == 0)
                    return false;
            return true;

        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            ct = cts.Token;
        }
    }
}
