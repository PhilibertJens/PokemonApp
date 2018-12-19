using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Areas.Admin.Models
{
    public class UsersIndexVm
    {
        public IEnumerable<User> Users { get; set; }
    }
}
