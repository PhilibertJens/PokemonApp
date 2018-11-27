using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Areas.Admin.Models
{
    public class PokemonCreateVm
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasAllolanForm { get; set; }

       
        public string ImgUrl { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string location { get; set; }

        
        public IFormFile UploadedImage { get; set; }
    }
}
