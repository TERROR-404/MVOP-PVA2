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
        public List<Grid> recipesChildren;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recipesChildren = Recipes.Children.OfType<Grid>().ToList();
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
                    recipe.Add_Recipe(recipesClass.Title, recipesClass.Ingredients, recipesClass.Process, recipesClass.Author, author, recipesClass.Vegetarian, recipesClass.Time, true);
                }
            }
            recipesChildren = Recipes.Children.OfType<Grid>().ToList();
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
                using (StreamReader reader = new StreamReader(recipesFilePath, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                        Recipe recipe = new Recipe();
                        recipe.Add_Recipe(recipesClass.Title, recipesClass.Ingredients, recipesClass.Process, recipesClass.Author, author, recipesClass.Vegetarian, recipesClass.Time, true);
                    }
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(recipesFilePath, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                        if (recipesClass.Title == searching || recipesClass.Author == searching)
                        {
                            Recipe recipe = new Recipe();
                            recipe.Add_Recipe(recipesClass.Title, recipesClass.Ingredients, recipesClass.Process, recipesClass.Author, author, recipesClass.Vegetarian, recipesClass.Time, true);
                        }
                    }
                }
            }
            if (Sort.SelectedValue != null)
            {
                Sort_Recipes();
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DependencyObject parentObject = VisualTreeHelper.GetParent(button);
            Grid parentGrid = (Grid)parentObject;
            Recipes.Children.Remove(parentGrid);
            recipesChildren.Remove(parentGrid);

            List<string> recipes = new List<string>();
            using (StreamReader reader = new StreamReader(recipesFilePath, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                    if ($"{recipesClass.Author}_{recipesClass.Title}_{recipesClass.Time.ToString().Replace(":", "a").Replace(".", "b").Replace(" ", "c")}_{recipesClass.Vegetarian}" != parentGrid.Name)
                    {
                        recipes.Add(line);
                    }
                }
            }
            File.WriteAllLines(recipesFilePath, recipes);
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
                    if ($"{recipesClass.Author}_{recipesClass.Title}_{recipesClass.Time.ToString().Replace(":", "a").Replace(".", "b").Replace(" ", "c")}_{recipesClass.Vegetarian}" == parentGrid.Name)
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
            recipesChildren = Recipes.Children.OfType<Grid>().ToList();
            Recipes.Children.Clear();
            foreach (var grid in recipesChildren)
            {
                if (bool.Parse(grid.Name.Split('_')[3]))
                {
                    Recipes.Children.Add(grid);
                }
            }
        }

        private void Vegan_Unchecked(object sender, RoutedEventArgs e)
        {
            Recipes.Children.Clear();
            foreach (var grid in recipesChildren)
            {
                Recipes.Children.Add(grid);
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
                recipesChildren = Recipes.Children.OfType<Grid>().ToList();

                string sortBy = Sort.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                switch (sortBy)
                {
                    case "data přidání":
                        List<Grid> sortedTimes = recipesChildren.OrderBy(grid => DateTime.Parse(grid.Name.Split('_')[2].Replace("a",":").Replace("b",".").Replace("c"," "))).ToList();
                        Recipes.Children.Clear();
                        foreach (var grid in sortedTimes)
                        {
                            Recipes.Children.Add(grid);
                        }
                        break;
                    case "názvu abecedně":
                        List<Grid> sortedTitles = recipesChildren.OrderBy(grid => grid.Name.Split('_')[1]).ToList();
                        Recipes.Children.Clear();
                        foreach (var grid in sortedTitles)
                        {
                            Recipes.Children.Add(grid);
                        }
                        break;
                    case "autorů abecedně":
                        List<Grid> sortedAuthors = recipesChildren.OrderBy(grid => grid.Name).ToList();
                        Recipes.Children.Clear();
                        foreach (var grid in sortedAuthors)
                        {
                            Recipes.Children.Add(grid);
                        }
                        break;
                }
            }
        }
    }
}
