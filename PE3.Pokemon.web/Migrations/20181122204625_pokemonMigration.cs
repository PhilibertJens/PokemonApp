using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class pokemonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("7701a5d6-4061-462d-a58b-01d4525be9db"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("0cfebb47-72ec-43b9-982b-d6bb2ce280c9"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("2da2aeb6-3594-45ae-b0d8-0bdc22a01201"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("3a237e62-b579-405a-a3e4-de23314b3f64"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("3d0bb554-c111-4e1a-b9bd-e77b1181c17c"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("3f72c904-1abb-4fe8-8991-a7af3100455c"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("631bbd2b-4761-4eaf-85ae-87b3663a41d3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("66464263-90ac-46d7-865d-eb9f1e421a94"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("78be2b62-89de-4da7-81e8-c02b819e2396"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("9634ab72-d1af-40a3-a2d6-402d022ece4a"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a9171c57-6fcd-47a1-9218-abd0463bb708"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ae36aef2-d2c6-481a-8a01-59bc706ea6b7"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ba4df992-4327-4e39-a8f5-0238f724f456"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ceea9f21-0b66-4ba3-82de-c777372ab9b6"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("dceac1d0-33a3-4b9f-9600-8ed194860182"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("e85e1859-e6e4-4164-9621-d5eaae2cbc81"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("efabba4e-8370-4b82-8182-5adc1a4ef425"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("f0627b7c-7762-4a59-9c2b-9c410d644704"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("f29503b4-f30f-4182-af2a-c157a48147f9"));

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "Description", "HasAllolanForm", "ImgUrl", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("090bd652-7065-4e36-bd55-19845f5f1147"), "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. ", false, "Bulbasaur.png", "Starter", "Bulbasaur" },
                    { new Guid("4288066d-237e-4a7c-8994-00f6a566c32f"), "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail.", false, "Beedrill.png", "Evolve Kakuna", "Beedrill" },
                    { new Guid("77a0bda5-8a01-48d6-b05c-4c867ba54bee"), "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators.", false, "Kakuna.png", "Routes 24 and 25, Viridian Forest", "Kakuna" },
                    { new Guid("450af65a-8068-4856-ae09-b87828590c30"), "Often found in forests, eating leaves. It has a sharp venomous stinger on its head.", false, "Weedle.png", "Routes 2, 24, and 25, Viridian Forest", "Weedle" },
                    { new Guid("0e4a1ed9-90c3-4583-8ef9-88d942cc938a"), "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body", false, "Metapod.png", "Routes 24 and 25, Viridian Forest or evolve Caterpie", "Metapod" },
                    { new Guid("44810325-90ea-406b-b866-3058683d2b67"), "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", false, "Caterpie.png", "Routes 2, 24 and 25,Viridian Forest", "Caterpie" },
                    { new Guid("3f1345c2-7e26-43c2-8543-15d647718a55"), "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", false, "Blastoise.png", "evolve Wartortle", "Blastoise" },
                    { new Guid("bff628c0-da94-4d38-bf03-dfc10eb5c1f8"), "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", false, "Butterfree.png", "Evolve Metapod", "Butterfree" },
                    { new Guid("b8403264-1f89-4ce2-b0c5-d5c0705dca1a"), "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", false, "Squirtle.png", "Starter", "Squirtle" },
                    { new Guid("d37624fe-618a-4c86-8c7e-2692f126a215"), "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.", false, "Charizard.png", "Evolve Charmeleon", "Charizard" },
                    { new Guid("bd6f49d8-b17c-47cc-9e2e-6e73e4510cfd"), "When it swings its burning tail, it elevates the temperature to unbearably high levels.", false, "Charmeleon.png", "Evolve Charmander", "Charmeleon" },
                    { new Guid("f4ad61a1-ea7a-4ef4-85f7-395b94b2cfa1"), "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", false, "Charmander.png", "Starter", "Charmander" },
                    { new Guid("66ae9046-109a-4fdb-aa1b-0c7a4e3c36bd"), "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", false, "Venusaur.png", "Evolve Ivysaur", "Venusaur" },
                    { new Guid("17d13bdb-72f6-4906-9d08-35d60cadf539"), "When the bulb on its back grows large, it appears to lose the ability to stand on its hind leg", false, "Ivysaur.png", "Evolve Bulbasaur", "Ivysaur" },
                    { new Guid("028b2e1c-1ef6-4d22-b0ad-eace29f4f2fe"), "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance", false, "Wartortle.png", "Evolve Squirtle", "Wartortle" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a699c0ff-1fa7-4258-aa2a-f6e5020b3541"), "Fire" },
                    { new Guid("59e53dc8-16a3-4572-8159-d96da5eb9118"), "Dragon" },
                    { new Guid("bbc8c790-86a9-4417-8c34-6dadcfb6e983"), "Ice" },
                    { new Guid("2d2f9559-4501-44c9-9bff-c9d89e8440bc"), "Psychic" },
                    { new Guid("bad9a2c8-0e87-40ef-b16d-340abd2ad3b1"), "Electric" },
                    { new Guid("635174c5-deba-4494-83d8-6305645a6a6f"), "Grass" },
                    { new Guid("8cf35603-1032-451b-be00-f1b26a0abef9"), "Water" },
                    { new Guid("f59db6fe-22d2-4b84-8ffb-16a1e99cf41f"), "Steel" },
                    { new Guid("703bafca-dcf0-49eb-81b1-24705cd60aac"), "Fighting" },
                    { new Guid("2160debb-f9fa-4e21-a0ec-06075827c3d3"), "Bug" },
                    { new Guid("c17baf55-7106-49c0-84e5-9826e6aa3cef"), "Rock" },
                    { new Guid("ac6b8edc-0783-49a7-850b-dde798bdd6cb"), "Ground" },
                    { new Guid("d6927210-9a16-4cd1-a999-5ab0681129c4"), "Poison" },
                    { new Guid("987da79e-9400-4288-8f94-53c846162a3a"), "Flying" },
                    { new Guid("58696251-80d3-4b09-8d45-6f8ccbc0d120"), "Dark" },
                    { new Guid("6d64c320-719c-4dc6-9d00-8100804a7774"), "Normal" },
                    { new Guid("ed6107de-282c-41c2-a229-c5422d8425c2"), "Ghost" },
                    { new Guid("410047ef-7e1f-49ed-bc9f-5222eab13a6d"), "Fairy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("028b2e1c-1ef6-4d22-b0ad-eace29f4f2fe"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("090bd652-7065-4e36-bd55-19845f5f1147"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("0e4a1ed9-90c3-4583-8ef9-88d942cc938a"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("17d13bdb-72f6-4906-9d08-35d60cadf539"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("3f1345c2-7e26-43c2-8543-15d647718a55"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("4288066d-237e-4a7c-8994-00f6a566c32f"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("44810325-90ea-406b-b866-3058683d2b67"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("450af65a-8068-4856-ae09-b87828590c30"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("66ae9046-109a-4fdb-aa1b-0c7a4e3c36bd"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("77a0bda5-8a01-48d6-b05c-4c867ba54bee"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("b8403264-1f89-4ce2-b0c5-d5c0705dca1a"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("bd6f49d8-b17c-47cc-9e2e-6e73e4510cfd"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("bff628c0-da94-4d38-bf03-dfc10eb5c1f8"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("d37624fe-618a-4c86-8c7e-2692f126a215"));

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: new Guid("f4ad61a1-ea7a-4ef4-85f7-395b94b2cfa1"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("2160debb-f9fa-4e21-a0ec-06075827c3d3"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("2d2f9559-4501-44c9-9bff-c9d89e8440bc"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("410047ef-7e1f-49ed-bc9f-5222eab13a6d"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("58696251-80d3-4b09-8d45-6f8ccbc0d120"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("59e53dc8-16a3-4572-8159-d96da5eb9118"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("635174c5-deba-4494-83d8-6305645a6a6f"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("6d64c320-719c-4dc6-9d00-8100804a7774"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("703bafca-dcf0-49eb-81b1-24705cd60aac"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("8cf35603-1032-451b-be00-f1b26a0abef9"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("987da79e-9400-4288-8f94-53c846162a3a"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("a699c0ff-1fa7-4258-aa2a-f6e5020b3541"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ac6b8edc-0783-49a7-850b-dde798bdd6cb"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("bad9a2c8-0e87-40ef-b16d-340abd2ad3b1"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("bbc8c790-86a9-4417-8c34-6dadcfb6e983"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("c17baf55-7106-49c0-84e5-9826e6aa3cef"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("d6927210-9a16-4cd1-a999-5ab0681129c4"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ed6107de-282c-41c2-a229-c5422d8425c2"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("f59db6fe-22d2-4b84-8ffb-16a1e99cf41f"));

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
        }
    }
}
