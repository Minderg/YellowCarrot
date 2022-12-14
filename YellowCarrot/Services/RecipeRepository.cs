using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot.Data;
using YellowCarrot.Models;

namespace YellowCarrot.Services
{
    internal class RecipeRepository
    {
        private readonly AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get one by ID
        public Recipe? GetRecipe(int id)
        {
            return _context.Recipes.Include(i => i.Ingredients).Include(t => t.Tag).Where(r => r.RecipeId == id).FirstOrDefault();
        }

        // Get All Recipes
        public List<Recipe> GetRecipes()
        {
            return _context.Recipes.Include(r => r.Ingredients).Include(r => r.Tag).ToList();
        }

        // Create Recipe
        public void AddRecipe(Recipe recipeToAdd)
        {
             _context.Recipes.Add(recipeToAdd);
        }

        // Delete Recipe
        private void RemoveRecipe(Recipe recipeToDelete)
        {
           _context.Recipes.Remove(recipeToDelete);
        }

        public void SaveDb()
        {
            _context.SaveChanges();
        }
    }
}
