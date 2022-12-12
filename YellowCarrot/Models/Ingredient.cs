using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot.Models
{
    class Ingredient
    {
        public int IngredientId { get; set; }
        public string Quantity { get; set; } = null!;
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public string IngredientName { get; set; } = null!;

    }
}
