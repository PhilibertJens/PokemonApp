using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username{ get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}
