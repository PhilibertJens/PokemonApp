using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class SeededMorePokemonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "PokemonId", "TypeId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000106"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000095"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000092"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-00000000000d") },
                    { new Guid("00000000-0000-0000-0000-000000000150"), new Guid("00000000-0000-0000-0000-00000000000e") },
                    { new Guid("00000000-0000-0000-0000-000000000087"), new Guid("00000000-0000-0000-0000-00000000000f") },
                    { new Guid("00000000-0000-0000-0000-000000000147"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Description", "HasAllolanForm", "ImgUrl", "Location", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), "Is a small, quadruped rodent Pokémon. Its most notable feature is its large teeth.", true, "Rattata.png", "Somewhere", "Rattata" });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "PokemonId", "TypeId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000001") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-00000000000d") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000087"), new Guid("00000000-0000-0000-0000-00000000000f") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000092"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000095"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000106"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000147"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000150"), new Guid("00000000-0000-0000-0000-00000000000e") });

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Description", "HasAllolanForm", "ImgUrl", "Location", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), "Is a small, quadruped rodent Pokémon. Its most notable feature is its large teeth.", true, "Rattata.png", "Somewhere", "Rattata" });
        }
    }
}
