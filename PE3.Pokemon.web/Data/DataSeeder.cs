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
                new Entities.Type { Id = 1, Name = "Normal" },
                new Entities.Type { Id = 2, Name = "Fighting" },
                new Entities.Type { Id = 3, Name = "Flying" },
                new Entities.Type { Id = 4, Name = "Poison" },
                new Entities.Type { Id = 5, Name = "Ground" },
                new Entities.Type { Id = 6, Name = "Rock" },
                new Entities.Type { Id = 7, Name = "Bug" },
                new Entities.Type { Id = 8, Name = "Ghost" },
                new Entities.Type { Id = 9, Name = "Steel" },
                new Entities.Type { Id = 10, Name = "Fire" },
                new Entities.Type { Id = 11, Name = "Water" },
                new Entities.Type { Id = 12, Name = "Grass" },
                new Entities.Type { Id = 13, Name = "Electric" },
                new Entities.Type { Id = 14, Name = "Psychic" },
                new Entities.Type { Id = 15, Name = "Ice" },
                new Entities.Type { Id = 16, Name = "Dragon" },
                new Entities.Type { Id = 17, Name = "Dark" },
                new Entities.Type { Id = 18, Name = "Fairy" }

                );
        }
    }
}
