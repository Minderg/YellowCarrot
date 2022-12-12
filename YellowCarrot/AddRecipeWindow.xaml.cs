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
        private Recipe? recipe;
        private Tag? tag;
        private Ingredient ingredient;
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

        }

        public void AddNewRecipe()
        {
            string newRecipe = txtNewRecipe.Text.Trim();
            string newIngredient = txtNewIngredient.Text.Trim();
            string newTag = txtNewTag.Text.Trim();
            string newQuantity = txtNewQuantity.Text.Trim();

            if (string.IsNullOrEmpty(newRecipe) || string.IsNullOrEmpty(newIngredient) || string.IsNullOrEmpty(newTag) || string.IsNullOrEmpty(newQuantity))
            {
                MessageBox.Show("Please enter full Recipe Information");
            }
            else
            {
                lvAllRecipes.Items.Add($"Name: {newRecipe} | Ingredient: {newIngredient} | Special: {newTag} | Amount: {newQuantity}");
            }
        }
    }
}
