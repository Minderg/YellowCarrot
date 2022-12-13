﻿using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using YellowCarrot.Data;
using YellowCarrot.Models;
using YellowCarrot.Services;

namespace YellowCarrot
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {

        public RecipeWindow()
        {
            InitializeComponent();


            btnDetails.IsEnabled = false;
            btnDeleteRecipe.IsEnabled = false;

            UpdateUi();

        }

        // Hämtar alla recept som finns i databasen och läggger in dem i ListViewn
        private void UpdateUi()
        {
            using(AppDbContext context = new())
            {
                List<Recipe> recipes = new RecipeRepository(context).GetRecipes();

                foreach (Recipe recipe in recipes)
                    {
                        ListViewItem item = new();

                        item.Content = recipe.RecipeName;
                        item.Tag = recipe;

                        lvAllRecipes.Items.Add(item);
                    }
            }           
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new();
            addRecipe.Show();
            Close();
        }

        // Hämtar mer information om den valda receptet i listviewn
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            using(AppDbContext context = new())
            {
                if (lvAllRecipes.SelectedItem != null)
                {
                    ListViewItem selectedItem = lvAllRecipes.SelectedItem as ListViewItem;

                    Recipe? selectedRecipe = selectedItem.Tag as Recipe;

                    DetailsWindow detailsWindow = new(selectedRecipe.RecipeId);
                    detailsWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please select a recipe, Darling");
                }
            } 
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to delete this recipe?", "Delete a recipe", MessageBoxButton.YesNo); 

            if(dialogResult == MessageBoxResult.Yes)
            {

                ListViewItem itemToRemove = lvAllRecipes.SelectedItem as ListViewItem;
                Recipe selectedRecipe = itemToRemove.Tag as Recipe;

                if (selectedRecipe != null)
                {
                    using (AppDbContext context = new())
                    {
                        context.Recipes.Remove(selectedRecipe);
                        context.SaveChanges();
                    }
                    UpdateUi();
                }
                else
                {
                    MessageBox.Show("Please enter a recipe to delete!");
                }
            }            
        }

        private void lvAllRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDetails.IsEnabled = true;
            btnDeleteRecipe.IsEnabled = true;
        }
    }
}
