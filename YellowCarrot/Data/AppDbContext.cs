using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot.Models;

namespace YellowCarrot.Data
{
    class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YellowCarrotDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(new Recipe()
            {
                RecipeId = 1,
                RecipeName = "Tortellini & Pesto",
                TagId = 1          
            }, new Recipe()
            {
                RecipeId = 2,
                RecipeName = "Bolognese",
                TagId = 2       
            }, new Recipe()
            {
                RecipeId = 3,
                RecipeName = "Kött & Potatisgratäng",
                TagId = 3
            },new Recipe()
            {
                RecipeId = 4,
                RecipeName = "Lax i Ugn",
                TagId = 2
            });

            modelBuilder.Entity<Tag>().HasData(new Tag()
            {  
                TagId = 1,
                Name = "Vegetariskt"

            }, new Tag()
            {
                TagId = 2,
                Name = "Kött"

            }, new Tag()
            {
                TagId = 3,
                Name = "Fisk"
            });

            modelBuilder.Entity<Ingredient>().HasData(new Ingredient()
            {
                IngredientId = 1,
                IngredientName = "Tortellini",
                Quantity = "120g",
                RecipeId = 1
            }, new Ingredient()
            {
                IngredientId = 2,
                IngredientName = "Pesto",
                Quantity = "80g",
                RecipeId = 1
            }, new Ingredient()
            {
                IngredientId = 3,
                IngredientName = "Köttfärs",
                Quantity = "800g",
                RecipeId = 2,
            }, new Ingredient()
            {
                IngredientId = 4,
                IngredientName = "Pasta",
                Quantity = "180g",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 5,
                IngredientName = "Tomatpuree",
                Quantity = "2 msk",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 6,
                IngredientName = "1 Gul lök",
                Quantity = "50g",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 7,
                IngredientName = "Krossade Tomater",
                Quantity = "200g",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 8,
                IngredientName = "Grönsak Buljong",
                Quantity = "3 msk",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 9,
                IngredientName = "Salt",
                Quantity = "3 tsk",
                RecipeId = 2,
            }, new Ingredient()
            {
                IngredientId = 10,
                IngredientName = "Peppar",
                Quantity = "5 tsk",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 11,
                IngredientName = "Chili Flakes",
                Quantity = "1 msk",
                RecipeId = 2
            }, new Ingredient()
            {
                IngredientId = 12,
                IngredientName = "Oxfile",
                Quantity = "200g",
                RecipeId = 3
            }, new Ingredient()
            {
                IngredientId = 13,
                IngredientName = "Potatisgratäng",
                Quantity = "450g",
                RecipeId = 3
            }, new Ingredient()
            {
                IngredientId = 14,
                IngredientName = "Vitlök",
                Quantity = "2 tsk",
                RecipeId = 3
            }, new Ingredient()
            {
                IngredientId = 15,
                IngredientName = "Sparris",
                Quantity = "80g",
                RecipeId = 3,
            }, new Ingredient()
            {
                IngredientId = 16,
                IngredientName = "Salt",
                Quantity = "3 tsk",
                RecipeId = 3
            }, new Ingredient()
            {
                IngredientId = 17,
                IngredientName = "Peppar",
                Quantity = "3 tsk",
                RecipeId = 3
            }, new Ingredient()
            {
                IngredientId = 18,
                IngredientName = "Lax",
                Quantity = "500g",
                RecipeId = 4
            }, new Ingredient()
            {
                IngredientId = 19,
                IngredientName = "Kokt Potatis",
                Quantity = "200g",
                RecipeId = 4
            }, new Ingredient()
            {
                IngredientId = 20,
                IngredientName = "Salt",
                Quantity = "2 tsk",
                RecipeId = 4
            }, new Ingredient()
            {
                IngredientId = 21,
                IngredientName = "Peppar",
                Quantity = "4 tsk",
                RecipeId = 4
            });
        }
    }
}
