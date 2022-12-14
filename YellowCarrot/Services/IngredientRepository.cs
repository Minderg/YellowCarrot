﻿using System;
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

        public void AddIngredient(Ingredient ingredientToAdd)
        {
            _context.Ingredients.Add(ingredientToAdd);
        }
    }
}