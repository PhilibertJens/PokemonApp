using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PE3.Pokemon.web.Entities;

namespace PE3.Pokemon.web.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Type>().HasData(
                //Guid: Id = Guid.Parse("11111111-1111-1111-1111-111111111111") --> 128 bits getal (32 hexa's, 1 hexa = 4bits)
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Normal" },//mag niet volledig 0 zijn
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Fighting" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Flying" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Poison" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Ground" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Rock" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Bug" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "Ghost" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "Steel" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000A"), Name = "Fire" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000B"), Name = "Water" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000C"), Name = "Grass" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000D"), Name = "Electric" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000E"), Name = "Psychic" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000F"), Name = "Ice" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "Dragon" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000011"), Name = "Dark" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000012"), Name = "Fairy" }

                );

            modelBuilder.Entity<PokemonType>().HasData(//enkele koppelingen toegevoegd om de join te testen.
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000000"),
                    FirstName = "ad",
                    LastName = "min",
                    Username = "admin",
                    Password = "+Y7d6ZfLIwrzW3xaWPSYYtJogSApg+ANJPTQs/j1YpmAm72t" // hashwaarde voor pokemon1234(paswoord voor admin)
                                
                }
                );

            modelBuilder.Entity<Entities.MyPokemon>().HasData(
                new Entities.MyPokemon
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Bulbasaur",
                    
                    HasAllolanForm = false,
                    ImgUrl = "Bulbasaur.png",
                    Location = "Starter",
                    Description = "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. "
                },
                new Entities.MyPokemon
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Ivysaur",
                    HasAllolanForm = false,
                    ImgUrl = "Ivysaur.png",
                    Location = "Evolve Bulbasaur",
                    Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind leg"

                },
                 new Entities.MyPokemon
                 {
                     Id = new Guid("00000000-0000-0000-0000-000000000003"),
                     Name = "Venusaur",
                     HasAllolanForm = false,
                     ImgUrl = "Venusaur.png",
                     Location = "Evolve Ivysaur",
                     Description = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."

                 },
                 new Entities.MyPokemon
                 {
                     Id = new Guid("00000000-0000-0000-0000-000000000004"),
                     Name = "Charmander",
                     HasAllolanForm = false,
                     ImgUrl = "Charmander.png",
                     Location = "Starter",
                     Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail."

                 },
                 new Entities.MyPokemon
                 {
                     Id = new Guid("00000000-0000-0000-0000-000000000005"),
                     Name = "Charmeleon",
                     HasAllolanForm = false,
                     ImgUrl = "Charmeleon.png",
                     Location = "Evolve Charmander",
                     Description = "When it swings its burning tail, it elevates the temperature to unbearably high levels."

                 },
                 new Entities.MyPokemon
                 {
                     Id = new Guid("00000000-0000-0000-0000-000000000006"),
                     Name = "Charizard",
                     HasAllolanForm = false,
                     ImgUrl = "Charizard.png",
                     Location = "Evolve Charmeleon",
                     Description = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally."

                 },
                 new Entities.MyPokemon
                 {
                     Id = new Guid("00000000-0000-0000-0000-000000000007"),
                     Name = "Squirtle",
                     HasAllolanForm = false,
                     ImgUrl = "Squirtle.png",
                     Location = "Starter",
                     Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth."

                 },
                  new Entities.MyPokemon
                  {
                      Id = new Guid("00000000-0000-0000-0000-000000000008"),
                      Name = "Wartortle",
                      HasAllolanForm = false,
                      ImgUrl = "Wartortle.png",
                      Location = "Evolve Squirtle",
                      Description = "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance"

                  },
                   new Entities.MyPokemon
                   {
                       Id = new Guid("00000000-0000-0000-0000-000000000009"),
                       Name = "Blastoise",
                       HasAllolanForm = false,
                       ImgUrl = "Blastoise.png",
                       Location = "evolve Wartortle",
                       Description = "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles."

                   },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000010"),
                        Name = "Caterpie",
                        HasAllolanForm = false,
                        ImgUrl = "Caterpie.png",
                        Location = "Routes 2, 24 and 25,Viridian Forest",
                        Description = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000011"),
                        Name = "Metapod",
                        HasAllolanForm = false,
                        ImgUrl = "Metapod.png",
                        Location = "Routes 24 and 25, Viridian Forest or evolve Caterpie",
                        Description = "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body"

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000012"),
                        Name = "Butterfree",
                        HasAllolanForm = false,
                        ImgUrl = "Butterfree.png",
                        Location = "Evolve Metapod",
                        Description = "In battle, it flaps its wings at high speed to release highly toxic dust into the air."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000013"),
                        Name = "Weedle",
                        HasAllolanForm = false,
                        ImgUrl = "Weedle.png",
                        Location = "Routes 2, 24, and 25, Viridian Forest",
                        Description = "Often found in forests, eating leaves. It has a sharp venomous stinger on its head."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000014"),
                        Name = "Kakuna",
                        HasAllolanForm = false,
                        ImgUrl = "Kakuna.png",
                        Location = "Routes 24 and 25, Viridian Forest",
                        Description = "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000015"),
                        Name = "Beedrill",
                        HasAllolanForm = false,
                        ImgUrl = "Beedrill.png",
                        Location = "Evolve Kakuna",
                        Description = "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail."

                    }
                );
        }
    }
}
