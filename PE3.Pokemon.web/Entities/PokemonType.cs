using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class PokemonType
    {
        public Guid PokemonId { get; set; }
        public Guid TypeId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Type Type { get; set; }
    }   
}
