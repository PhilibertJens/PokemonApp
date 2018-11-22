using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class TypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37cdfff1-0bd3-4d6e-b386-c7ad255898b1"), "Normal" },
                    { new Guid("a396c59f-23d2-4778-ae99-d44513a2a0db"), "Dragon" },
                    { new Guid("59da137b-5f9c-4bb5-bf64-f86a8b40753f"), "Ice" },
                    { new Guid("5dc048e0-a3b8-48e3-863e-ecc0a0569453"), "Psychic" },
                    { new Guid("e458a0f5-11af-4555-806a-f31c6a0221c3"), "Electric" },
                    { new Guid("f1ac803d-7b9d-45bd-95bd-bcee9e01a09e"), "Grass" },
                    { new Guid("d68ee470-97b6-49b5-a7e2-090f9742604a"), "Water" },
                    { new Guid("7d7c1fa4-b40b-435d-938c-f38653dfd933"), "Fire" },
                    { new Guid("aa54dbd8-7644-448e-92d1-dc0c4896751f"), "Steel" },
                    { new Guid("a44005d3-b8f2-43ac-8da5-eb15ebdfa7c3"), "Ghost" },
                    { new Guid("9bb0d318-db9c-44c4-b33f-0855cd95a6e4"), "Bug" },
                    { new Guid("90bb4532-6a14-4a1c-be97-e180596f24a3"), "Rock" },
                    { new Guid("a797de2a-a2c7-4a1b-8f5a-e035651a09c4"), "Ground" },
                    { new Guid("67d3af1a-1207-492e-b676-f982d2f32df3"), "Poison" },
                    { new Guid("e85e0823-befe-4f8c-9b86-976f53db4100"), "Flying" },
                    { new Guid("14aa4702-c5ac-4a70-95fb-d314ae8ce386"), "Fighting" },
                    { new Guid("330890c6-aa7f-4568-8b30-dac8b4376fda"), "Dark" },
                    { new Guid("01ab37a1-bfe9-4f28-91fa-d2d5d7167710"), "Fairy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("01ab37a1-bfe9-4f28-91fa-d2d5d7167710"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("14aa4702-c5ac-4a70-95fb-d314ae8ce386"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("330890c6-aa7f-4568-8b30-dac8b4376fda"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("37cdfff1-0bd3-4d6e-b386-c7ad255898b1"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("59da137b-5f9c-4bb5-bf64-f86a8b40753f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("5dc048e0-a3b8-48e3-863e-ecc0a0569453"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("67d3af1a-1207-492e-b676-f982d2f32df3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("7d7c1fa4-b40b-435d-938c-f38653dfd933"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("90bb4532-6a14-4a1c-be97-e180596f24a3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("9bb0d318-db9c-44c4-b33f-0855cd95a6e4"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a396c59f-23d2-4778-ae99-d44513a2a0db"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a44005d3-b8f2-43ac-8da5-eb15ebdfa7c3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a797de2a-a2c7-4a1b-8f5a-e035651a09c4"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("aa54dbd8-7644-448e-92d1-dc0c4896751f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("d68ee470-97b6-49b5-a7e2-090f9742604a"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("e458a0f5-11af-4555-806a-f31c6a0221c3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("e85e0823-befe-4f8c-9b86-976f53db4100"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("f1ac803d-7b9d-45bd-95bd-bcee9e01a09e"));
        }
    }
}
