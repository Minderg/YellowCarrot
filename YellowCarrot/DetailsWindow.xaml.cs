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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {

        public DetailsWindow(int recipeId)
        {
            InitializeComponent();


            GetRecipeDetail(recipeId);
        }

        private void GetRecipeDetail(int recipeId)
        {
            using(AppDbContext context = new())
            {
                Recipe? recipe = new RecipeRepository(context).GetRecipe(recipeId);

                txtDetatilsName.Text = recipe.RecipeName.ToString();
                txtDetatilsIngredient.Text = recipe.Ingredients.ToString();
                
            }
        }
        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new();
            recipeWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
