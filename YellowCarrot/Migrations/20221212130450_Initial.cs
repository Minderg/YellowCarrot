using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YellowCarrot.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "Name" },
                values: new object[,]
                {
                    { 1, "Vegetariskt" },
                    { 2, "Kött" },
                    { 3, "Fisk" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "RecipeName", "TagId" },
                values: new object[,]
                {
                    { 1, "Tortellini & Pesto", 1 },
                    { 2, "Kött & Potatisgratäng", 2 },
                    { 3, "Lax i Ugn", 3 },
                    { 4, "Bolognese", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "IngredientName", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Tortellini", "120g", 1 },
                    { 2, "Pesto", "80g", 1 },
                    { 3, "Köttfärs", "800g", 2 },
                    { 4, "Pasta", "180g", 2 },
                    { 5, "Tomatpuree", "2 msk", 2 },
                    { 6, "1 Gul lök", "50g", 2 },
                    { 7, "Krossade Tomater", "200g", 2 },
                    { 8, "Grönsak Buljong", "3 msk", 2 },
                    { 9, "Salt", "3 tsk", 2 },
                    { 10, "Peppar", "5 tsk", 2 },
                    { 11, "Chili Flakes", "1 msk", 2 },
                    { 12, "Oxfile", "200g", 3 },
                    { 13, "Potatisgratäng", "450g", 3 },
                    { 14, "Vitlök", "2 tsk", 3 },
                    { 15, "Sparris", "80g", 3 },
                    { 16, "Salt", "3 tsk", 3 },
                    { 17, "Peppar", "3 tsk", 3 },
                    { 18, "Lax", "500g", 4 },
                    { 19, "Kokt Potatis", "200g", 4 },
                    { 20, "Salt", "2 tsk", 4 },
                    { 21, "Peppar", "4 tsk", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
