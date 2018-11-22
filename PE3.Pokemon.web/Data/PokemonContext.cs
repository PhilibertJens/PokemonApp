using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PE3.Pokemon.web.Entities;

namespace PE3.Pokemon.web.Data
{
    public class PokemonContext: DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }

        public DbSet<Entities.Pokemon> Pokemons { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<PokemonUser> PokemonUsers { get; set; }

    }
}
