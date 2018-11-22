using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class Type
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonType> PokemonTypes { get; set; }

    }
}
