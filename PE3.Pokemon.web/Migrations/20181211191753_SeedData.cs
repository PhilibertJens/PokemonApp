using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PE3.Pokemon.web.Migrations
{
    public partial class SeedData : Migration
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
                    PokemonId = table.Column<Guid>(nullable: false),
                    Catches = table.Column<byte>(nullable: false)
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
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. ", false, "Bulbasaur.png", "Starter", "Bulbasaur" },
                    { new Guid("00000000-0000-0000-0000-000000000147"), "is filled with life energy. Dratini is constantly growing, and can thus reach lengths of over six feet.", false, "Dratini.png", "Somewhere", "Dratini" },
                    { new Guid("00000000-0000-0000-0000-000000000087"), "Has a snowy white, furry body, which renders it virtually invisible in snowy conditions.", false, "Dewgong.png", "Somewhere", "Dewgong" },
                    { new Guid("00000000-0000-0000-0000-000000000150"), "Is a Pokémon created by science. It is a bipedal, humanoid creature with some feline features.", false, "Mewtwo.png", "Somewhere", "Mewtwo" },
                    { new Guid("00000000-0000-0000-0000-000000000092"), "Has no true form, due to 95% of its body being poisonous gas.", false, "Gastly.png", "Somewhere", "Gastly" },
                    { new Guid("00000000-0000-0000-0000-000000000095"), "Resembles a giant chain of gray boulders that become smaller towards the tail.", false, "Onix.png", "Somewhere", "Onix" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "Is a tiny, brown Pokémon that seems to be perpetually buried within the earth, leaving only its head visible.", true, "Diglett.png", "Somewhere", "Diglett" },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "Creates gases within its body by mixing toxins with garbage, and produces more gas in higher temperatures.", false, "Koffing.png", "Somewhere", "Koffing" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Has an extremely sharp sense of direction and homing instincts.", false, "Pidgey.png", "Somewhere", "Pidgey" },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "Is a humanoid Pokémon with an ovoid body. Hitmonlee's legs freely contract and stretch similar to a coiled spring.", false, "Hitmonlee.png", "Somewhere", "Hitmonlee" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "Is a small, quadruped rodent Pokémon. Its most notable feature is its large teeth.", true, "Rattata.png", "Somewhere", "Rattata" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail.", false, "Beedrill.png", "Evolve Kakuna", "Beedrill" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators.", false, "Kakuna.png", "Routes 24 and 25, Viridian Forest", "Kakuna" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Is covered in yellow fur with two horizontal brown stripes on its back.", true, "Pikachu.png", "Somewhere", "Pikachu" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", false, "Butterfree.png", "Evolve Metapod", "Butterfree" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Often found in forests, eating leaves. It has a sharp venomous stinger on its head.", false, "Weedle.png", "Routes 2, 24, and 25, Viridian Forest", "Weedle" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "When the bulb on its back grows large, it appears to lose the ability to stand on its hind leg", false, "Ivysaur.png", "Evolve Bulbasaur", "Ivysaur" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", false, "Venusaur.png", "Evolve Ivysaur", "Venusaur" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "When it swings its burning tail, it elevates the temperature to unbearably high levels.", false, "Charmeleon.png", "Evolve Charmander", "Charmeleon" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.", false, "Charizard.png", "Evolve Charmeleon", "Charizard" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", false, "Charmander.png", "Starter", "Charmander" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance", false, "Wartortle.png", "Evolve Squirtle", "Wartortle" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", false, "Blastoise.png", "evolve Wartortle", "Blastoise" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", false, "Caterpie.png", "Routes 2, 24 and 25,Viridian Forest", "Caterpie" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body", false, "Metapod.png", "Routes 24 and 25, Viridian Forest or evolve Caterpie", "Metapod" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", false, "Squirtle.png", "Starter", "Squirtle" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Dark" },
                    { new Guid("00000000-0000-0000-0000-00000000000b"), "Water" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Dragon" },
                    { new Guid("00000000-0000-0000-0000-00000000000f"), "Ice" },
                    { new Guid("00000000-0000-0000-0000-00000000000e"), "Psychic" },
                    { new Guid("00000000-0000-0000-0000-00000000000d"), "Electric" },
                    { new Guid("00000000-0000-0000-0000-00000000000c"), "Grass" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "Fire" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Poison" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Ghost" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Bug" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Rock" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Ground" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Flying" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Fighting" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Normal" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Fairy" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Steel" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), "ad", "min", "+Y7d6ZfLIwrzW3xaWPSYYtJogSApg+ANJPTQs/j1YpmAm72t", "admin" });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "PokemonId", "TypeId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-00000000000a") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-00000000000b") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-00000000000c") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-00000000000c") }
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
