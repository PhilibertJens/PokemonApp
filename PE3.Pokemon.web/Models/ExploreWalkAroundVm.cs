using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class ExploreWalkAroundVm
    {
        [Required]
        [Display(Name = "Select your environment")]
        public int SelectedEnvironmentId { get; set; }
        public List<SelectListItem> Environments { get; set; }

        [Required]
        [Display(Name = "Select your environment")]
        public int SelectedDayTimeId { get; set; }
        public List<SelectListItem> DayTime { get; set; }
    }
}
