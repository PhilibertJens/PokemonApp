using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class PokemonUser
    {
        public Guid UserId { get; set; }
        public Guid PokemonId { get; set; }
        public User User { get; set; }
        public MyPokemon Pokemon { get; set; }
    }
}
