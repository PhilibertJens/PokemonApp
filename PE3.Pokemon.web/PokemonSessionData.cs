using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class PokemonSessionData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Caught { get; set; }/*blijft false als user vanuit GeneratePokemon of CatchProcesser url naar Gotcha veranderd*/
        public string CheatingWarning { get; set; } /*wordt ingevuld bij Gotcha*/
        public int HP { get; set; }
        public List<string> Moves { get; set; }
        //Er kunnen nog specifieke pokemon kenmerken worden toegevoegd
    }
}
