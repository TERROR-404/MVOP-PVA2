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

namespace Databáze_kuchyňských_receptů
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Grid newRecipe = new Grid();
            newRecipe.Background = new SolidColorBrush(Color.FromRgb(201, 213, 255));
            newRecipe.Margin = new Thickness(0, 10, 0, 0);
            newRecipe.Width = 500;
            newRecipe.Height = 282;
            newRecipe.HorizontalAlignment = HorizontalAlignment.Center;
            newRecipe.VerticalAlignment = VerticalAlignment.Center;
            //newRecipe.ShowGridLines = true; // redundantní
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
            rowDef6.Height = new GridLength(8, GridUnitType.Star);
            RowDefinition rowDef7 = new RowDefinition();
            rowDef7.Height = new GridLength(0.2, GridUnitType.Star);
            newRecipe.RowDefinitions.Add(rowDef1);
            newRecipe.RowDefinitions.Add(rowDef2);
            newRecipe.RowDefinitions.Add(rowDef3);
            newRecipe.RowDefinitions.Add(rowDef4);
            newRecipe.RowDefinitions.Add(rowDef5);
            newRecipe.RowDefinitions.Add(rowDef6);
            newRecipe.RowDefinitions.Add(rowDef7);
            Label title = new Label();
            Grid.SetColumn(title, 1);
            Grid.SetRow(title, 1);
            title.FontWeight = FontWeights.Bold;
            title.Content = "Recept";
            newRecipe.Children.Add(title);
            Label author = new Label();
            Grid.SetColumn(author, 4);
            Grid.SetColumnSpan(author, 2);
            Grid.SetRow(author, 1);
            author.Content = "Autor:";
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
            ingredients.BorderBrush = Brushes.Black;
            ingredients.BorderThickness = new Thickness(1);
            ingredients.Content = "idk";
            newRecipe.Children.Add(ingredients);
            Label process = new Label();
            Grid.SetColumn(process, 3);
            Grid.SetRow(process, 5);
            process.BorderBrush = Brushes.Black;
            process.BorderThickness = new Thickness(1);
            process.Content = "idk";
            newRecipe.Children.Add(process);
            Button change = new Button();
            change.Height = 30;
            change.Width = 100;
            change.VerticalAlignment = VerticalAlignment.Bottom;
            change.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(change, 5);
            Grid.SetRow(change, 5);
            change.FontWeight = FontWeights.Bold;
            change.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
            change.Background = new SolidColorBrush(Color.FromRgb(39, 38, 67));
            change.Content = "Upravit";
            newRecipe.Children.Add(change);
            this.Recipes.Children.Add(newRecipe);
        }
    }
}
