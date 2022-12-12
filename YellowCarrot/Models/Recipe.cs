using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot.Models
{
    class Recipe
    {
        public string RecipeName { get; set; } = null!;
        public int RecipeId { get; set; }
        public int TagId { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
        public Tag Tag { get; set; } = null!;

    }
}
