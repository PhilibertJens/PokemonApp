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
                new Entities.Type { Id = Guid.NewGuid(), Name = "Normal" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Fighting" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Flying" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Poison" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Ground" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Rock" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Bug" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Ghost" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Steel" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Fire" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Water" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Grass" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Electric" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Psychic" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Ice" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Dragon" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Dark" },
                new Entities.Type { Id = Guid.NewGuid(), Name = "Fairy" }

                );

            modelBuilder.Entity<Entities.Pokemon>().HasData(
                new Entities.Pokemon
                {
                    Id = Guid.NewGuid(),
                    Name = "Bulbasaur",
                    HasAllolanForm = false,
                    ImgUrl = "Bulbasaur.png",
                    Location = "Starter",
                    Description = "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. "
                },
                new Entities.Pokemon
                {
                    Id= Guid.NewGuid(),
                    Name="Ivysaur",
                    HasAllolanForm=false,
                    ImgUrl="Ivysaur.png",
                    Location="Evolve Bulbasaur",
                    Description= "When the bulb on its back grows large, it appears to lose the ability to stand on its hind leg"

                },
                 new Entities.Pokemon
                 {
                     Id = Guid.NewGuid(),
                     Name = "Venusaur",
                     HasAllolanForm = false,
                     ImgUrl = "Venusaur.png",
                     Location = "Evolve Ivysaur",
                     Description = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."

                 },
                 new Entities.Pokemon
                 {
                     Id = Guid.NewGuid(),
                     Name = "Charmander",
                     HasAllolanForm = false,
                     ImgUrl = "Charmander.png",
                     Location = "Starter",
                     Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail."

                 },
                 new Entities.Pokemon
                 {
                     Id = Guid.NewGuid(),
                     Name = "Charmeleon",
                     HasAllolanForm = false,
                     ImgUrl = "Charmeleon.png",
                     Location = "Evolve Charmander",
                     Description = "When it swings its burning tail, it elevates the temperature to unbearably high levels."

                 },
                 new Entities.Pokemon
                 {
                     Id = Guid.NewGuid(),
                     Name = "Charizard",
                     HasAllolanForm = false,
                     ImgUrl = "Charizard.png",
                     Location = "Evolve Charmeleon",
                     Description = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally."

                 },
                 new Entities.Pokemon
                 {
                     Id = Guid.NewGuid(),
                     Name = "Squirtle",
                     HasAllolanForm = false,
                     ImgUrl = "Squirtle.png",
                     Location = "Starter",
                     Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth."

                 },
                  new Entities.Pokemon
                  {
                      Id = Guid.NewGuid(),
                      Name = "Wartortle",
                      HasAllolanForm = false,
                      ImgUrl = "Wartortle.png",
                      Location = "Evolve Squirtle",
                      Description = "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance"

                  },
                   new Entities.Pokemon
                   {
                       Id = Guid.NewGuid(),
                       Name = "Blastoise",
                       HasAllolanForm = false,
                       ImgUrl = "Blastoise.png",
                       Location = "evolve Wartortle",
                       Description = "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles."

                   },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
                        Name = "Caterpie",
                        HasAllolanForm = false,
                        ImgUrl = "Caterpie.png",
                        Location = "Routes 2, 24 and 25,Viridian Forest",
                        Description = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls."

                    },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
                        Name = "Metapod",
                        HasAllolanForm = false,
                        ImgUrl = "Metapod.png",
                        Location = "Routes 24 and 25, Viridian Forest or evolve Caterpie",
                        Description = "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body"

                    },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
                        Name = "Butterfree",
                        HasAllolanForm = false,
                        ImgUrl = "Butterfree.png",
                        Location = "Evolve Metapod",
                        Description = "In battle, it flaps its wings at high speed to release highly toxic dust into the air."

                    },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
                        Name = "Weedle",
                        HasAllolanForm = false,
                        ImgUrl = "Weedle.png",
                        Location = "Routes 2, 24, and 25, Viridian Forest",
                        Description = "Often found in forests, eating leaves. It has a sharp venomous stinger on its head."

                    },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kakuna",
                        HasAllolanForm = false,
                        ImgUrl = "Kakuna.png",
                        Location = "Routes 24 and 25, Viridian Forest",
                        Description = "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators."

                    },
                    new Entities.Pokemon
                    {
                        Id = Guid.NewGuid(),
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
