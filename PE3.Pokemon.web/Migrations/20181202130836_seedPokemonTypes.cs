using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class seedPokemonTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "PokemonId", "TypeId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000007") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000c") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000000a") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-00000000000b") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "PokemonTypes",
                keyColumns: new[] { "PokemonId", "TypeId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000007") });
        }
    }
}
