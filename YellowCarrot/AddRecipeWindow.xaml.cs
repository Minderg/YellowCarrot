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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        public AddRecipe()
        {
            InitializeComponent();

            GetTags();
        }

        // Klicka här så lägger man till en ny ingredient
        private void btnAddNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddNewIngredient();
        }

        // Kommer till baka till RecipeSidan(Startsidan)
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new();
            recipeWindow.Show();
            Close();
        }

        // Spara det nya recepet som man har skrivit in, till Listviewn och databasen
        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            string newRecipe = txtNewRecipe.Text;
            List<Ingredient> ingredients = GetListViewIngredients();

            using (AppDbContext context = new())
            {
                if(cbTags.SelectedItem!= null)
                {
                    Tag? tag = (Tag)((ComboBoxItem)cbTags.SelectedItem).Tag;

                    // Lägger till ett nytt Recipe med, Namn, ingredient och Tag
                    new RecipeRepository(context).AddRecipe(new Recipe()
                    {
                        RecipeName = newRecipe,
                        Ingredients = ingredients,
                        TagId = tag.TagId
                    });

                    context.SaveChanges();
                    RecipeWindow recipeWindow = new();
                    recipeWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You need to a Recipe to save!");
                }
            }

        }

        // Loppar igenom vad för ingredients och lägger in den i en lista
        private List<Ingredient> GetListViewIngredients()
        {
            List<Ingredient> ingredients = new();

            foreach(ListViewItem lvItem in lvAllIngredients.Items)
            {
                ingredients.Add((Ingredient)lvItem.Tag);
            }

            return ingredients;
        }

        // Lägger till en ny ingredient i Listviewn men sparar inte den till databasen
        public void AddNewIngredient()
        {
            string newRecipe = txtNewRecipe.Text.Trim();
            string newIngredient = txtNewIngredient.Text.Trim();
            string newQuantity = txtNewQuantity.Text.Trim();
            
            if(string.IsNullOrEmpty(newIngredient) || string.IsNullOrEmpty(newQuantity) || string.IsNullOrEmpty(newRecipe)) 
            {
                MessageBox.Show("Need to enter full recipe description!");
            }
            else
            {
                txtNewQuantity.Clear();
                txtNewIngredient.Clear();

                ListViewItem item = new();
                item.Content = $"{newIngredient} / {newQuantity}";
                item.Tag = new Ingredient()
                {
                    IngredientName = newIngredient,
                    Quantity = newQuantity
                };

                lvAllIngredients.Items.Add(item);
            }    
        }

        // Hämtar alla tags o loppar dem och skickar in dem i comboboxen
        private void GetTags()
        {
            using(AppDbContext context = new())
            {
                List<Tag> tags = new TagsRepository(context).GetTags();

                foreach(Tag tag in tags)
                {
                    ComboBoxItem cbItem = new();
                    cbItem.Content = tag.Name;
                    cbItem.Tag = tag;

                    cbTags.Items.Add(cbItem);
                }
            }
        }
    }
}
