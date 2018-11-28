using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Areas.Admin.Models
{
    public class AssignedTypeDataVm
    {
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public bool Assigned { get; set; }
    }
}
