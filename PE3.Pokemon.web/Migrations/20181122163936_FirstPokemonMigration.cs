using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class FirstPokemonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0430a2a0-efe5-41ac-8564-b04876f08728"), "Normal" },
                    { new Guid("ff3e6c5c-d2d4-470f-bf0b-0811240acdb0"), "Dragon" },
                    { new Guid("a8e26784-056c-4720-a412-f6de0f2ab3db"), "Ice" },
                    { new Guid("af547cd3-1ddf-4e04-9f34-76bfe2e725ec"), "Psychic" },
                    { new Guid("7ce365ac-9862-4c36-ad44-c80be50c1beb"), "Electric" },
                    { new Guid("6e2fe5f7-7665-44a3-a137-576d209965ad"), "Grass" },
                    { new Guid("ece96743-d4c6-4775-8b0a-7649f7cb9491"), "Water" },
                    { new Guid("11b6dcbb-14d2-4de8-9519-415dee8e3b6f"), "Fire" },
                    { new Guid("850f62d6-6907-44a3-8a95-455063adcfc4"), "Steel" },
                    { new Guid("e9970647-e3c4-40ae-98ad-aa752a4f6e22"), "Ghost" },
                    { new Guid("6003ed6c-dad3-4f0a-905a-b4d9c4898dab"), "Bug" },
                    { new Guid("f3e915dd-4be9-4211-b62e-d7b79ffd26c7"), "Rock" },
                    { new Guid("60c95187-9605-46b4-b214-8b4663bc8a2c"), "Ground" },
                    { new Guid("30899c17-15be-45ef-9730-511b6ce2ec16"), "Poison" },
                    { new Guid("b6ae7c2a-c7b3-4a19-a1d2-4183195cc56c"), "Flying" },
                    { new Guid("c56cd56d-3642-4961-a8c6-8582e9676e1f"), "Fighting" },
                    { new Guid("e056d750-fbbd-435b-b3f2-7a9a12314030"), "Dark" },
                    { new Guid("9993daeb-790c-4a28-be9e-28d96b53b68e"), "Fairy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("0430a2a0-efe5-41ac-8564-b04876f08728"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("11b6dcbb-14d2-4de8-9519-415dee8e3b6f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("30899c17-15be-45ef-9730-511b6ce2ec16"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("6003ed6c-dad3-4f0a-905a-b4d9c4898dab"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("60c95187-9605-46b4-b214-8b4663bc8a2c"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("6e2fe5f7-7665-44a3-a137-576d209965ad"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("7ce365ac-9862-4c36-ad44-c80be50c1beb"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("850f62d6-6907-44a3-8a95-455063adcfc4"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("9993daeb-790c-4a28-be9e-28d96b53b68e"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a8e26784-056c-4720-a412-f6de0f2ab3db"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("af547cd3-1ddf-4e04-9f34-76bfe2e725ec"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("b6ae7c2a-c7b3-4a19-a1d2-4183195cc56c"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("c56cd56d-3642-4961-a8c6-8582e9676e1f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("e056d750-fbbd-435b-b3f2-7a9a12314030"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("e9970647-e3c4-40ae-98ad-aa752a4f6e22"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ece96743-d4c6-4775-8b0a-7649f7cb9491"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("f3e915dd-4be9-4211-b62e-d7b79ffd26c7"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ff3e6c5c-d2d4-470f-bf0b-0811240acdb0"));

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
    }
}
