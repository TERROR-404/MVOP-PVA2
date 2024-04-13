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
using System.Xml;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Databáze_kuchyňských_receptů
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool logged;
        public string author;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!logged)
            {
                Add.IsEnabled = false;
            }
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\recipes.txt";
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    Recipe recipe = new Recipe();
                    recipe.Add_Recipe(recipesClass.Title, recipesClass.Ingredients, recipesClass.Process, recipesClass.Author, author);
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Recipe R = new Recipe();
            R.changeRecipe = false;
            R.authorName = author;
            R.Show();
            this.IsEnabled = false;
        }

        private void Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DependencyObject parentObject = VisualTreeHelper.GetParent(button);
            Grid parentGrid = (Grid)parentObject;
            Recipes.Children.Remove(parentGrid);

            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\recipes.txt";
            List<string> recipes = new List<string>();
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    if (recipesClass.Title != parentGrid.Name)
                    {
                        recipes.Add(line);
                    }
                }
            }
            File.WriteAllLines(filePath, recipes);
        }
        public void Change_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DependencyObject parentObject = VisualTreeHelper.GetParent(button);
            Grid parentGrid = (Grid)parentObject;
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\recipes.txt";
            Recipe R = new Recipe();
            R.changeRecipe = true;
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    if (recipesClass.Title == parentGrid.Name)
                    {
                        R.Title.Text = recipesClass.Title;
                        R.Ingredients.Text = recipesClass.Ingredients;
                        R.Process.Text = recipesClass.Process;
                        break;
                    }
                }
            }
            R.changeGrid = parentGrid;
            R.authorName = author;
            R.Show();
            this.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
