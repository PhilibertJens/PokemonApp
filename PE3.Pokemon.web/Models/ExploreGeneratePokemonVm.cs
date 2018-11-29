using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class ExploreGeneratePokemonVm
    {
        public MyPokemon AppearedPokemon { get; set; }
        public int HP;
        public List<string> Moves;
    }
}
