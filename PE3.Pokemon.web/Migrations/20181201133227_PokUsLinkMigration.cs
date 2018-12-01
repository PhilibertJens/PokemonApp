using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class PokUsLinkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonUsers_Pokemons_PokemonId",
                table: "PokemonUsers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "Catches",
                table: "PokemonUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "MyPokemonId",
                table: "PokemonUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonUsers_MyPokemonId",
                table: "PokemonUsers",
                column: "MyPokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonUsers_Pokemons_MyPokemonId",
                table: "PokemonUsers",
                column: "MyPokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonUsers_Pokemons_MyPokemonId",
                table: "PokemonUsers");

            migrationBuilder.DropIndex(
                name: "IX_PokemonUsers_MyPokemonId",
                table: "PokemonUsers");

            migrationBuilder.DropColumn(
                name: "Catches",
                table: "PokemonUsers");

            migrationBuilder.DropColumn(
                name: "MyPokemonId",
                table: "PokemonUsers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new Guid("00000000-1000-0000-0000-000000000000"), "jan", "lul", "azert1234", "jan" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonUsers_Pokemons_PokemonId",
                table: "PokemonUsers",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
