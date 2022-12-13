using Microsoft.EntityFrameworkCore;
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


        }

        private void btnAddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddNewRecipe();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new();
            recipeWindow.Show();
            Close();
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            string newRecipe = txtNewRecipe.Text;
            string newIngredient = txtNewIngredient.Text;
            string newTag = txtNewTag.Text;
            string newQuantity = txtNewQuantity.Text;

            using (AppDbContext context = new())
            {
                new RecipeRepository(context).AddRecipe(new Recipe()
                {
                    RecipeName = newRecipe
                });
                new IngredientRepository(context).AddIngredient(new Ingredient()
                {
                    IngredientName = newIngredient,
                    Quantity = newQuantity,
                });

                context.SaveChanges();

            }
        }

        public void AddNewRecipe()
        {
            string newRecipe = txtNewRecipe.Text.Trim();
            string newIngredient = txtNewIngredient.Text.Trim();
            string newTag = txtNewTag.Text.Trim();
            string newQuantity = txtNewQuantity.Text.Trim();

            txtNewRecipe.Clear();
            txtNewQuantity.Clear();
            txtNewIngredient.Clear();
            txtNewTag.Clear();

            lvAllRecipes.Items.Add(newRecipe);
            lvAllRecipes.Items.Add($"{newIngredient} |  {newQuantity}");

        }
    }
}
