using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class HomePokemonVm
    {
        public MyPokemon SelectedPokemon { get; set; }
        public short Catches { get; set; }
        public StringBuilder Sb { get; set; }
        public string[] Colors { get; set; }
    }
}
