using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PE3.Pokemon.web.Entities;

namespace PE3.Pokemon.web.Models
{
    public class PokebagVm
    {
        public ICollection<PokemonUser> MostCaught { get; set; }
        public ICollection<MyPokemon> MostPokemon { get; set; }
        public IDictionary<string, short> PokemonData { get; set; }
    }
}
