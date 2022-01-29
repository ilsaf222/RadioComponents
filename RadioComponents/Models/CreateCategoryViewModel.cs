using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models
{
    public class CreateCategoryViewModel<TConfiguration>
    {
        [Display(Name = "Фото")]
        public string Image { get; set; }

        public IFormFile UploadedFile { get; set; } 

        [Display(Name = "Тип элемента")]
        public Domain.Models.ComponType Type { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public TConfiguration Configuration { get; set; }
    }
}
