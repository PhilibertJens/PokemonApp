using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class Type
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonType> PokemonTypes { get; set; }
        public string Colour { get; set; }
    }
}
