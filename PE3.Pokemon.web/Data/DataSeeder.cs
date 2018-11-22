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
                }

                );
        }
    }
}
