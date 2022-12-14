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
        private List<Ingredient> selectedItem;
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
                Recipe? recipes = new RecipeRepository(context).GetRecipe(recipeId);

                txtDetatilsName.Text = recipes.RecipeName;
                txtDetailsTag.Text = $"{recipes.Tag.Name}";


                foreach (Ingredient ingredient in recipes.Ingredients)
                {
                    lvAllRecipesDetails.Items.Add($"{ingredient.IngredientName} | {ingredient.Quantity}");
                }
            }
        }
        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            txtDetatilsQuantity.IsEnabled = true;
            txtDetatilsName.IsEnabled = true;
            txtDetailsTag.IsEnabled = true;
            txtDetatilsIngredient.IsEnabled = true;
            btnUpdateRecipe.IsEnabled = true;
            btnAdd.IsEnabled = true;
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
           
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem itemSelected = lvAllRecipesDetails.SelectedItem as ListViewItem;
            Ingredient selectedItem = itemSelected.Tag as Ingredient;

            using (AppDbContext context = new())
            {
                new IngredientRepository(context).RemoveIngredient(selectedItem);
                
            }
        }
    }   
}
