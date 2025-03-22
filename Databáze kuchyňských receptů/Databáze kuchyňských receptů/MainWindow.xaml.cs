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
        public string recipesFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\recipes.txt";
        public List<RecipesClass> recipes = new List<RecipesClass>();
        public int highestID = 1;
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
            using (StreamReader reader = new StreamReader(recipesFilePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    Recipe recipe = new Recipe();
                    if (recipesClass.ID > highestID){ highestID = recipesClass.ID+1; }
                    recipes.Add(recipesClass);
                    recipe.Add_Recipe(recipesClass.ID, recipesClass.Title, recipesClass.Ingredients, recipesClass.Process, recipesClass.Author, author, recipesClass.Vegetarian, recipesClass.Time, true);
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
            Searching();
        }
        public void Searching()
        {
            Vegan.IsChecked = false;
            string searching = Find.Text;
            Recipes.Children.Clear();
            if (searching == "")
            {
                foreach (var item in recipes)
                {
                    Recipe recipe = new Recipe();
                    recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                }
            }
            else
            {
                foreach (var item in recipes)
                {
                    if (item.Title == searching || item.Author == searching)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                    }
                }
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DependencyObject parentObject = VisualTreeHelper.GetParent(button);
            Grid parentGrid = (Grid)parentObject;
            Recipes.Children.Remove(parentGrid);

            List<string> recipesString = new List<string>();
            using (StreamReader reader = new StreamReader(recipesFilePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    if (Convert.ToString(recipesClass.ID) != parentGrid.Name.Replace("_",""))
                    {
                        recipesString.Add(line);
                    }
                    else
                    {
                        foreach (var item in recipes)
                        {
                            if (item.ID == recipesClass.ID)
                            {
                                recipes.Remove(item);
                                break;
                            }
                        }
                        continue;
                    }
                }
            }
            File.WriteAllLines(recipesFilePath, recipesString);
        }
        public void Change_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DependencyObject parentObject = VisualTreeHelper.GetParent(button);
            Grid parentGrid = (Grid)parentObject;
            Recipe R = new Recipe();
            R.changeRecipe = true;

            using (StreamReader reader = new StreamReader(recipesFilePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    if (Convert.ToString(recipesClass.ID) == parentGrid.Name.Replace("_",""))
                    {
                        R.Title.Text = recipesClass.Title;
                        R.Ingredients.Text = recipesClass.Ingredients;
                        R.Process.Text = recipesClass.Process;
                        R.Vegan.IsChecked = recipesClass.Vegetarian;
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

        private void Vegan_Checked(object sender, RoutedEventArgs e)
        {
            Recipes.Children.Clear();
            string searching = Find.Text;
            if (searching == "")
            {
                foreach (var item in recipes)
                {
                    if (item.Vegetarian)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                    }
                }
            }
            else
            {
                foreach (var item in recipes)
                {
                    if (item.Vegetarian && (item.Title == searching || item.Author == searching))
                    {
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                    }
                }
            }
        }

        private void Vegan_Unchecked(object sender, RoutedEventArgs e)
        {
            Recipes.Children.Clear();
            string searching = Find.Text;
            if (searching == "")
            {
                foreach (var item in recipes)
                {
                    Recipe recipe = new Recipe();
                    recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                }
            }
            else
            {
                foreach (var item in recipes)
                {
                    if (item.Title == searching || item.Author == searching)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                    }
                }
            }
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort_Recipes();
        }
        public void Sort_Recipes()
        {
            if (Sort.SelectedValue != null)
            {
                string sortBy = Sort.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                switch (sortBy)
                {
                    case "data přidání":
                        recipes = recipes.OrderBy(recipe => recipe.Time).ToList();
                        break;
                    case "názvu abecedně":
                        recipes = recipes.OrderBy(recipe => recipe.Title).ToList();
                        break;
                    case "autorů abecedně":
                        recipes = recipes.OrderBy(recipe => recipe.Author).ToList();
                        break;
                }
                Recipes.Children.Clear();
                string searching = Find.Text;
                if (Vegan.IsChecked == true)
                {
                    foreach (var item in recipes)
                    {
                        if (item.Vegetarian)
                        {
                            Recipe recipe = new Recipe();
                            recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                        }
                    }
                }
                else
                {
                    foreach (var item in recipes)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(item.ID, item.Title, item.Ingredients, item.Process, item.Author, author, item.Vegetarian, item.Time, true);
                    }
                }
                Searching();
            }
        }
    }
}
