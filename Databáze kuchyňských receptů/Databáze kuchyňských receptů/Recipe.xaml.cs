using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace Databáze_kuchyňských_receptů
{
    /// <summary>
    /// Interakční logika pro Recipe.xaml
    /// </summary>
    public partial class Recipe : Window
    {
        public bool changeRecipe;
        public Grid changeGrid;
        public string authorName;
        public string recipesFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\recipes.txt";
        public Recipe()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "")
            {
                Error.Content = "Prosím napište jméno receptu!";
            }
            else
            {
                if (Application.Current.MainWindow is MainWindow main)
                {
                    if (changeRecipe)
                    {
                        main.Recipes.Children.Remove(changeGrid);
                        List<string> recipesString = new List<string>();
                        using (StreamReader reader = new StreamReader(recipesFilePath, true))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                RecipesClass recipesClass = JsonSerializer.Deserialize<RecipesClass>(line);
                                if (Convert.ToString(recipesClass.ID) != changeGrid.Name.Replace("_",""))
                                {
                                    recipesString.Add(line);
                                }
                                else
                                {
                                    foreach (var item in main.recipes)
                                    {
                                        if (item.ID == recipesClass.ID)
                                        {
                                            main.recipes.Remove(item);
                                            break;
                                        }
                                    }
                                    continue;
                                }
                            }
                        }
                        File.WriteAllLines(recipesFilePath, recipesString);
                    }
                    bool vege = false;
                    if (Vegan.IsChecked == true)
                    {
                        vege = true;
                    }
                    DateTime time = DateTime.Now;
                    RecipesClass r = new RecipesClass
                    {
                        ID = main.highestID,
                        Title = Title.Text,
                        Ingredients = Ingredients.Text,
                        Process = Process.Text,
                        Author = authorName,
                        Vegetarian = vege,
                        Time = time
                    };
                    main.recipes.Add(r);
                    string jsonString = JsonSerializer.Serialize(r);
                    using (StreamWriter writer = new StreamWriter(recipesFilePath, true))
                    {
                        writer.WriteLine(jsonString);
                    }
                    Add_Recipe(main.highestID,Title.Text, Ingredients.Text, Process.Text, authorName, authorName, vege, time, false);
                    main.highestID++;
                    if (main.Sort.SelectedValue != null)
                    {
                        main.Sort_Recipes();
                    }
                }
                else
                {
                    throw new Exception("Unexpected application window.");
                }
            }
        }
        public void Add_Recipe(int id,string titleText, string ingredientsText, string processText, string authorText, string loggedAuthor, bool vegan, DateTime date, bool loading)
        {
            try
            {
                Grid newRecipe = new Grid();
                newRecipe.Background = new SolidColorBrush(Color.FromRgb(201, 213, 255));
                newRecipe.Margin = new Thickness(0, 10, 0, 0);
                newRecipe.Width = 500;
                newRecipe.Height = 282;
                newRecipe.HorizontalAlignment = HorizontalAlignment.Center;
                newRecipe.VerticalAlignment = VerticalAlignment.Center;
                ColumnDefinition colDef1 = new ColumnDefinition();
                colDef1.Width = new GridLength(0.5, GridUnitType.Star);
                ColumnDefinition colDef2 = new ColumnDefinition();
                colDef2.Width = new GridLength(8, GridUnitType.Star);
                ColumnDefinition colDef3 = new ColumnDefinition();
                colDef3.Width = new GridLength(2, GridUnitType.Star);
                ColumnDefinition colDef4 = new ColumnDefinition();
                colDef4.Width = new GridLength(10, GridUnitType.Star);
                ColumnDefinition colDef5 = new ColumnDefinition();
                colDef5.Width = new GridLength(1, GridUnitType.Star);
                ColumnDefinition colDef6 = new ColumnDefinition();
                colDef6.Width = new GridLength(3, GridUnitType.Star);
                ColumnDefinition colDef7 = new ColumnDefinition();
                colDef7.Width = new GridLength(0.5, GridUnitType.Star);
                newRecipe.ColumnDefinitions.Add(colDef1);
                newRecipe.ColumnDefinitions.Add(colDef2);
                newRecipe.ColumnDefinitions.Add(colDef3);
                newRecipe.ColumnDefinitions.Add(colDef4);
                newRecipe.ColumnDefinitions.Add(colDef5);
                newRecipe.ColumnDefinitions.Add(colDef6);
                newRecipe.ColumnDefinitions.Add(colDef7);
                RowDefinition rowDef1 = new RowDefinition();
                rowDef1.Height = new GridLength(0.2, GridUnitType.Star);
                RowDefinition rowDef2 = new RowDefinition();
                rowDef2.Height = new GridLength(1, GridUnitType.Star);
                RowDefinition rowDef3 = new RowDefinition();
                rowDef3.Height = new GridLength(0.2, GridUnitType.Star);
                RowDefinition rowDef4 = new RowDefinition();
                rowDef4.Height = new GridLength(1, GridUnitType.Star);
                RowDefinition rowDef5 = new RowDefinition();
                rowDef5.Height = new GridLength(0.2, GridUnitType.Star);
                RowDefinition rowDef6 = new RowDefinition();
                rowDef6.Height = new GridLength(4, GridUnitType.Star);
                RowDefinition rowDef7 = new RowDefinition();
                rowDef7.Height = new GridLength(4, GridUnitType.Star);
                RowDefinition rowDef8 = new RowDefinition();
                rowDef8.Height = new GridLength(0.2, GridUnitType.Star);
                newRecipe.RowDefinitions.Add(rowDef1);
                newRecipe.RowDefinitions.Add(rowDef2);
                newRecipe.RowDefinitions.Add(rowDef3);
                newRecipe.RowDefinitions.Add(rowDef4);
                newRecipe.RowDefinitions.Add(rowDef5);
                newRecipe.RowDefinitions.Add(rowDef6);
                newRecipe.RowDefinitions.Add(rowDef7);
                newRecipe.RowDefinitions.Add(rowDef8);
                Label title = new Label();
                Grid.SetColumn(title, 1);
                Grid.SetRow(title, 1);
                title.FontWeight = FontWeights.Bold;
                title.Content = titleText;
                newRecipe.Children.Add(title);
                Label author = new Label();
                Grid.SetColumn(author, 4);
                Grid.SetColumnSpan(author, 2);
                Grid.SetRow(author, 1);
                author.Content = authorText;
                newRecipe.Children.Add(author);
                Label titleIngredients = new Label();
                Grid.SetColumn(titleIngredients, 1);
                Grid.SetRow(titleIngredients, 3);
                titleIngredients.Content = "Ingredience:";
                newRecipe.Children.Add(titleIngredients);
                Label titleProcess = new Label();
                Grid.SetColumn(titleProcess, 3);
                Grid.SetRow(titleProcess, 3);
                titleProcess.Content = "Postup:";
                newRecipe.Children.Add(titleProcess);
                Label ingredients = new Label();
                Grid.SetColumn(ingredients, 1);
                Grid.SetRow(ingredients, 5);
                Grid.SetRowSpan(ingredients, 2);
                ingredients.BorderBrush = Brushes.Black;
                ingredients.BorderThickness = new Thickness(1);
                ingredients.Content = ingredientsText;
                newRecipe.Children.Add(ingredients);
                Label process = new Label();
                Grid.SetColumn(process, 3);
                Grid.SetRow(process, 5);
                Grid.SetRowSpan(process, 2);
                process.BorderBrush = Brushes.Black;
                process.BorderThickness = new Thickness(1);
                process.Content = processText;
                newRecipe.Children.Add(process);
                Button delete = new Button();
                delete.Height = 30;
                delete.Width = 100;
                delete.VerticalAlignment = VerticalAlignment.Bottom;
                delete.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(delete, 5);
                Grid.SetRow(delete, 5);
                delete.FontWeight = FontWeights.Bold;
                delete.Content = "Smazat";
                Button change = new Button();
                change.Height = 30;
                change.Width = 100;
                change.VerticalAlignment = VerticalAlignment.Center;
                change.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(change, 5);
                Grid.SetRow(change, 6);
                change.FontWeight = FontWeights.Bold;
                change.Content = "Upravit";
                newRecipe.Name = $"_{id}";

                if (Application.Current.MainWindow is MainWindow main)
                {
                    if (main.logged)
                    {
                        if (authorText == loggedAuthor)
                        {
                            delete.Click += new RoutedEventHandler(main.Delete_Click);
                            change.Click += new RoutedEventHandler(main.Change_Click);
                            delete.IsEnabled = true;
                            change.IsEnabled = true;
                        }
                        else
                        {
                            delete.IsEnabled = false;
                            change.IsEnabled = false;
                        }
                    }
                    else
                    {
                        delete.IsEnabled = false;
                        change.IsEnabled = false;
                    }

                    newRecipe.Children.Add(delete);
                    newRecipe.Children.Add(change);
                    main.Sort.SelectedValue = null;
                    if (loading)
                    {
                        main.Recipes.Children.Add(newRecipe);
                    }
                    else
                    {
                        main.Searching();
                    }
                    main.IsEnabled = true;
                    this.Close();
                }
                else
                {
                    throw new Exception("Unexpected application window.");
                }
            }
            catch (Exception)
            {
                Error.Content = "Toto jméno receptu není validní!";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
            {
                main.IsEnabled = true;
                this.Close();
            }
            else
            {
                throw new Exception("Unexpected application window.");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow main)
            {
                main.IsEnabled = true;
                this.Close();
            }
            else
            {
                throw new Exception("Unexpected application window.");
            }
        }
    }
}
