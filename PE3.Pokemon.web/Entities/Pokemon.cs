using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class Pokemon
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasAllolanForm { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<PokemonType> PokemonTypes { get; set; }
        public ICollection<PokemonUser> PokemonUsers { get; set; }

    }
}
