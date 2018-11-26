using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Areas.Admin.Models
{
    public class PokemonEditVm : PokemonCreateVm
    {
        public Guid Id { get; set; }
    }
}
