using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PE3.Pokemon.web.Entities;

namespace PE3.Pokemon.web.Areas.Admin.Models
{
    public class PokemonsIndexVm
    {
        public IEnumerable<MyPokemon> Pokemons { get; set; }
    }
}
