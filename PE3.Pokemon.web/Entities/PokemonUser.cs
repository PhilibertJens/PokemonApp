using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class PokemonUser
    {
        public long UserId { get; set; }
        public Guid PokemonId { get; set; }
        public User User { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
