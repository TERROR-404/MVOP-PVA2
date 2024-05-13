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
        private int output1;
        public int Output1
        {
            get { return output1; }
            set
            {
                output1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output1"));
            }
        }
        private int output2;
        public int Output2
        {
            get { return output2; }
            set
            {
                output2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output2"));
            }
        }
        private int output3;
        public int Output3
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
            Task.Run(async () =>
            {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        Output1 = a;
                        break;
                    }
                    a++;
                }
            });
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)textbox2.Text;
            Task.Run(() => {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        Output2 = a;
                        break;
                    }
                    a++;
                }

                return Task.CompletedTask;
            });
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)textbox3.Text;
            Task.Run(async () =>
            {
                int a = 1;
                while (ct.IsCancellationRequested == false)
                {
                    if (isPrime(a) && Convert.ToString(a).Contains(input))
                    {
                        Output3 = a;
                        break;
                    }
                    a++;
                }
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
