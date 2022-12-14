using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private Ingredient selectedItem;
        private Recipe _recipe;

        public DetailsWindow(int recipeId)
        {
            InitializeComponent();

            txtDetailsTag.IsEnabled = false;
            txtDetatilsIngredient.IsEnabled = false;
            txtDetatilsName.IsEnabled = false;
            txtDetatilsQuantity.IsEnabled = false;
            btnAdd.IsEnabled = false;
            btnUpdateRecipe.IsEnabled = false;
            
            GetRecipeDetail(recipeId);
        }

        // Displayar den valda Recipe och tar fram all information om det
        private void GetRecipeDetail(int recipeId)
        {
            using (AppDbContext context = new())
            {
                _recipe = new RecipeRepository(context).GetRecipe(recipeId);

                txtDetatilsName.Text = _recipe.RecipeName;
                txtDetailsTag.Text = $"{_recipe.Tag.Name}";


                foreach (Ingredient ingredient in _recipe.Ingredients)
                {
                    lvAllRecipesDetails.Items.Add($"{ingredient.IngredientName} | {ingredient.Quantity}");
                }
            }
        }
        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            txtDetatilsQuantity.IsEnabled = true;
            txtDetatilsIngredient.IsEnabled = true;
            btnUpdateRecipe.IsEnabled = true;
            btnAdd.IsEnabled = true;
            txtDetatilsName.IsEnabled = true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new();
            recipeWindow.Show();
            Close();
        }


        // Uppdaterar Recipe till det som har lagt till
        private void btnUpdateRecipe_Click(object sender, RoutedEventArgs e)
        {
           using(AppDbContext context = new())
           {
                if(txtDetatilsName.Text != _recipe.RecipeName)
                {
                    _recipe.RecipeName = txtDetatilsName.Text;
                }

                new RecipeRepository(context).UpdateRecipe(_recipe);

                context.SaveChanges();
           }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string newIngredient = txtDetatilsIngredient.Text.Trim();
            string newQuantity = txtDetatilsQuantity.Text.Trim();

            txtDetatilsIngredient.Clear();
            txtDetatilsQuantity.Clear();
            

            ListViewItem item = new();
            item.Content = $"{newIngredient} / {newQuantity}";
            item.Tag = new Ingredient()
            {
                IngredientName = newIngredient,
                Quantity = newQuantity
            };

            lvAllRecipesDetails.Items.Add(item);

            _recipe.Ingredients.Add((Ingredient)item.Tag);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem itemSelected = lvAllRecipesDetails.SelectedItem as ListViewItem;
            //Ingredient selectedItem = itemSelected.Tag as Ingredient;

            //using (AppDbContext context = new())
            //{
            //    new IngredientRepository(context).RemoveIngredient(selectedItem);
                
            //}
        }
    }   
}
