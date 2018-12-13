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
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Normal", Colour = "#A8A878" },//mag niet volledig 0 zijn
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Fighting", Colour = "#C03028" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Flying", Colour = "#A890F0" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Poison", Colour = "#A040A0" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Ground", Colour = "#E0C068" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Rock", Colour = "#B8A038" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Bug", Colour = "#A8B820" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "Ghost", Colour = "#705898" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "Steel", Colour = "#B8B8D0" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000A"), Name = "Fire", Colour = "#F08030" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000B"), Name = "Water", Colour = "#6890F0" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000C"), Name = "Grass", Colour = "#78C850" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000D"), Name = "Electric", Colour = "#F8D030" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000E"), Name = "Psychic", Colour = "#F85888" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-00000000000F"), Name = "Ice", Colour = "#98D8D8" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "Dragon", Colour = "#7038F8" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000011"), Name = "Dark", Colour = "#705848" },
                new Entities.Type { Id = new Guid("00000000-0000-0000-0000-000000000012"), Name = "Fairy", Colour = "#EE99AC" }

                );

            modelBuilder.Entity<PokemonType>().HasData(//enkele koppelingen toegevoegd om de join te testen.
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000001"),//bulbasaur
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000002"),//ivysaur
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000003"),//venusaur
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000C")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000004"),//charmander
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000005"),//charmeleon
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000006"),//charizard
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000A")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000007"),//squirtle
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000008"),//wartortle
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000009"),//blastoise
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000010"),//caterpie
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000011"),//metapod
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000012"),//butterfree
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000013"),//weedle
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000014"),//kakuna
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000015"),//beedrill
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000007")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000019"),//rattata
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")//normal
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000106"),//hitmonlee
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000002")//fighting
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000016"),//pidgey
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000003")//flying
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000109"),//koffing
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")//poison
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000050"),//diglett
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000005")//ground
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000095"),//onix
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000006")//rock
                },
                 new PokemonType
                 {
                     PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000095"),
                     TypeId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                 },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000092"),//gastly
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000008")//ghost
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000092"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000025"),//pikachu
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000D")//electric
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000150"),//mewtwo
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000E")//psychic
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000087"),//dewgong
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000F")//ice
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000087"),
                    TypeId = Guid.Parse("00000000-0000-0000-0000-00000000000B")
                },
                new PokemonType
                {
                    PokemonId = Guid.Parse("00000000-0000-0000-0000-000000000147"),//dratini
                    TypeId = Guid.Parse("00000000-0000-0000-0000-000000000010")//dragon
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

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000019"),
                        Name = "Rattata",
                        HasAllolanForm = true,
                        ImgUrl = "Rattata.png",
                        Location = "Somewhere",
                        Description = "Is a small, quadruped rodent Pokémon. Its most notable feature is its large teeth."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000106"),
                        Name = "Hitmonlee",
                        HasAllolanForm = false,
                        ImgUrl = "Hitmonlee.png",
                        Location = "Somewhere",
                        Description = "Is a humanoid Pokémon with an ovoid body. Hitmonlee's legs freely contract and stretch similar to a coiled spring."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000016"),
                        Name = "Pidgey",
                        HasAllolanForm = false,
                        ImgUrl = "Pidgey.png",
                        Location = "Somewhere",
                        Description = "Has an extremely sharp sense of direction and homing instincts."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000109"),
                        Name = "Koffing",
                        HasAllolanForm = false,
                        ImgUrl = "Koffing.png",
                        Location = "Somewhere",
                        Description = "Creates gases within its body by mixing toxins with garbage, and produces more gas in higher temperatures."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000050"),
                        Name = "Diglett",
                        HasAllolanForm = true,
                        ImgUrl = "Diglett.png",
                        Location = "Somewhere",
                        Description = "Is a tiny, brown Pokémon that seems to be perpetually buried within the earth, leaving only its head visible."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000095"),
                        Name = "Onix",
                        HasAllolanForm = false,
                        ImgUrl = "Onix.png",
                        Location = "Somewhere",
                        Description = "Resembles a giant chain of gray boulders that become smaller towards the tail."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000092"),
                        Name = "Gastly",
                        HasAllolanForm = false,
                        ImgUrl = "Gastly.png",
                        Location = "Somewhere",
                        Description = "Has no true form, due to 95% of its body being poisonous gas."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000025"),
                        Name = "Pikachu",
                        HasAllolanForm = true,
                        ImgUrl = "Pikachu.png",
                        Location = "Somewhere",
                        Description = "Is covered in yellow fur with two horizontal brown stripes on its back."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000150"),
                        Name = "Mewtwo",
                        HasAllolanForm = false,
                        ImgUrl = "Mewtwo.png",
                        Location = "Somewhere",
                        Description = "Is a Pokémon created by science. It is a bipedal, humanoid creature with some feline features."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000087"),
                        Name = "Dewgong",
                        HasAllolanForm = false,
                        ImgUrl = "Dewgong.png",
                        Location = "Somewhere",
                        Description = "Has a snowy white, furry body, which renders it virtually invisible in snowy conditions."

                    },
                    new Entities.MyPokemon
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000147"),
                        Name = "Dratini",
                        HasAllolanForm = false,
                        ImgUrl = "Dratini.png",
                        Location = "Somewhere",
                        Description = "is filled with life energy. Dratini is constantly growing, and can thus reach lengths of over six feet."

                    }
                );
        }
    }
}
