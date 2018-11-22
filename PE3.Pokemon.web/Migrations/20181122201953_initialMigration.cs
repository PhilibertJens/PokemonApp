using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HasAllolanForm = table.Column<bool>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    PokemonId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => new { x.PokemonId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_PokemonTypes_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PokemonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonUsers", x => new { x.PokemonId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PokemonUsers_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Description", "HasAllolanForm", "ImgUrl", "Location", "Name" },
                values: new object[] { new Guid("7701a5d6-4061-462d-a58b-01d4525be9db"), "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. ", false, "Bulbasaur.png", "Starter", "Bulbasaur" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("efabba4e-8370-4b82-8182-5adc1a4ef425"), "Dragon" },
                    { new Guid("a9171c57-6fcd-47a1-9218-abd0463bb708"), "Ice" },
                    { new Guid("f0627b7c-7762-4a59-9c2b-9c410d644704"), "Psychic" },
                    { new Guid("e85e1859-e6e4-4164-9621-d5eaae2cbc81"), "Electric" },
                    { new Guid("9634ab72-d1af-40a3-a2d6-402d022ece4a"), "Grass" },
                    { new Guid("ae36aef2-d2c6-481a-8a01-59bc706ea6b7"), "Water" },
                    { new Guid("66464263-90ac-46d7-865d-eb9f1e421a94"), "Fire" },
                    { new Guid("dceac1d0-33a3-4b9f-9600-8ed194860182"), "Dark" },
                    { new Guid("0cfebb47-72ec-43b9-982b-d6bb2ce280c9"), "Steel" },
                    { new Guid("631bbd2b-4761-4eaf-85ae-87b3663a41d3"), "Bug" },
                    { new Guid("3a237e62-b579-405a-a3e4-de23314b3f64"), "Rock" },
                    { new Guid("ceea9f21-0b66-4ba3-82de-c777372ab9b6"), "Ground" },
                    { new Guid("78be2b62-89de-4da7-81e8-c02b819e2396"), "Poison" },
                    { new Guid("f29503b4-f30f-4182-af2a-c157a48147f9"), "Flying" },
                    { new Guid("3d0bb554-c111-4e1a-b9bd-e77b1181c17c"), "Fighting" },
                    { new Guid("2da2aeb6-3594-45ae-b0d8-0bdc22a01201"), "Normal" },
                    { new Guid("3f72c904-1abb-4fe8-8991-a7af3100455c"), "Ghost" },
                    { new Guid("ba4df992-4327-4e39-a8f5-0238f724f456"), "Fairy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_TypeId",
                table: "PokemonTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonUsers_UserId",
                table: "PokemonUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "PokemonUsers");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
