using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot.Data;
using YellowCarrot.Models;

namespace YellowCarrot.Services
{
    internal class IngredientRepository
    {
        private readonly AppDbContext _context;

        public IngredientRepository(AppDbContext context)
        {
            _context = context;
        }

        //public void AddIngredient(Ingredient ingredientToAdd)
        //{
        //    _context.Ingredients.Add(ingredientToAdd);
        //}

        public Ingredient? GetIngredient(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.IngredientId == id);
        }

        
        public void RemoveIngredient(Ingredient ingredientToRemove)
        {
            _context.Ingredients.Remove(ingredientToRemove);
        }

    }
}
