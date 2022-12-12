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

            UpdateUi();

        }

        private void UpdateUi()
        {
            using(AppDbContext context = new())
            {
                List<Recipe> recipes = new RecipeRepository(context).GetRecipes();

                foreach (Recipe recipe in recipes)
                    {
                        ListViewItem item = new();

                        item.Content = recipe.RecipeName;
                        item.Tag = item;

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

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem selectedItem = lvAllRecipes.SelectedItem as ListViewItem;

            if(lvAllRecipes.SelectedItem != null)
            {
                ListViewItem selectedItem = lvAllRecipes.SelectedItem as ListViewItem;

                Recipe? selectedRecipe = selectedItem.Tag as Recipe;

                DetailsWindow detailsWindow = new(selectedRecipe.RecipeId);
                detailsWindow.Show();
                //Close();
            }
            else
            {
                MessageBox.Show("Please enter a recipe, Darling");
            }
           
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
