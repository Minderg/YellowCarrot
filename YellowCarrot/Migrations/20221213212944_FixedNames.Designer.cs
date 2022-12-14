﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YellowCarrot.Data;

#nullable disable

namespace YellowCarrot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221213212944_FixedNames")]
    partial class FixedNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YellowCarrot.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            IngredientName = "Tortellini",
                            Quantity = "120g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 2,
                            IngredientName = "Pesto",
                            Quantity = "80g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 3,
                            IngredientName = "Köttfärs",
                            Quantity = "800g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 4,
                            IngredientName = "Pasta",
                            Quantity = "180g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 5,
                            IngredientName = "Tomatpuree",
                            Quantity = "2 msk",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 6,
                            IngredientName = "1 Gul lök",
                            Quantity = "50g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 7,
                            IngredientName = "Krossade Tomater",
                            Quantity = "200g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 8,
                            IngredientName = "Grönsak Buljong",
                            Quantity = "3 msk",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 9,
                            IngredientName = "Salt",
                            Quantity = "3 tsk",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 10,
                            IngredientName = "Peppar",
                            Quantity = "5 tsk",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 11,
                            IngredientName = "Chili Flakes",
                            Quantity = "1 msk",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 12,
                            IngredientName = "Oxfile",
                            Quantity = "200g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 13,
                            IngredientName = "Potatisgratäng",
                            Quantity = "450g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 14,
                            IngredientName = "Vitlök",
                            Quantity = "2 tsk",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 15,
                            IngredientName = "Sparris",
                            Quantity = "80g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 16,
                            IngredientName = "Salt",
                            Quantity = "3 tsk",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 17,
                            IngredientName = "Peppar",
                            Quantity = "3 tsk",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 18,
                            IngredientName = "Lax",
                            Quantity = "500g",
                            RecipeId = 4
                        },
                        new
                        {
                            IngredientId = 19,
                            IngredientName = "Kokt Potatis",
                            Quantity = "200g",
                            RecipeId = 4
                        },
                        new
                        {
                            IngredientId = 20,
                            IngredientName = "Salt",
                            Quantity = "2 tsk",
                            RecipeId = 4
                        },
                        new
                        {
                            IngredientId = 21,
                            IngredientName = "Peppar",
                            Quantity = "4 tsk",
                            RecipeId = 4
                        });
                });

            modelBuilder.Entity("YellowCarrot.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.HasIndex("TagId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            RecipeName = "Tortellini & Pesto",
                            TagId = 1
                        },
                        new
                        {
                            RecipeId = 2,
                            RecipeName = "Bolognese",
                            TagId = 2
                        },
                        new
                        {
                            RecipeId = 3,
                            RecipeName = "Kött & Potatisgratäng",
                            TagId = 3
                        },
                        new
                        {
                            RecipeId = 4,
                            RecipeName = "Lax i Ugn",
                            TagId = 2
                        });
                });

            modelBuilder.Entity("YellowCarrot.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            Name = "Vegetariskt"
                        },
                        new
                        {
                            TagId = 2,
                            Name = "Kött"
                        },
                        new
                        {
                            TagId = 3,
                            Name = "Fisk"
                        });
                });

            modelBuilder.Entity("YellowCarrot.Models.Ingredient", b =>
                {
                    b.HasOne("YellowCarrot.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("YellowCarrot.Models.Recipe", b =>
                {
                    b.HasOne("YellowCarrot.Models.Tag", "Tag")
                        .WithMany("Recipes")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("YellowCarrot.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("YellowCarrot.Models.Tag", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}