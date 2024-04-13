using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Databáze_kuchyňských_receptů
{
    /// <summary>
    /// Interakční logika pro Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Registered_users.txt";
        public Login()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Application.Current.MainWindow = main;
            main.logged = false;
            main.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string name = LogName.Text;
            string password = LogPassword.Text;
            if (name != "" && password != "")
            {
                using (StreamReader reader = new StreamReader(filePath, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        UserClass userClass = JsonSerializer.Deserialize<UserClass>(line);
                        if (userClass.Name == name)
                        {
                            Error.Content = "Toto přihlašovací jméno je již zaregistrováno";
                            return;
                        }
                    }
                }
                UserClass u = new UserClass
                {
                    Name = name,
                    Password = password
                };
                string jsonString = JsonSerializer.Serialize(u);
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(jsonString);
                }
                MainWindow main = new MainWindow();
                Application.Current.MainWindow = main;
                main.logged = true;
                main.author = name;
                main.Show();
                this.Close();
            }
            else
            {
                Error.Content = "Prosím vyplňte všechna textová pole";
            }
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            string name = LogName.Text;
            string password = LogPassword.Text;
            if (name != "" && password != "")
            {
                using (StreamReader reader = new StreamReader(filePath, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        UserClass userClass = JsonSerializer.Deserialize<UserClass>(line);
                        if (userClass.Name == name && userClass.Password == password)
                        {
                            MainWindow main = new MainWindow();
                            Application.Current.MainWindow = main;
                            main.logged = true;
                            main.author = name;
                            main.Show();
                            this.Close();
                        }
                    }
                }
                Error.Content = "Chybně zadané uživatelské jméno, nebo heslo";
            }
            else
            {
                Error.Content = "Prosím vyplňte všechna textová pole";
            }
        }
    }
}
