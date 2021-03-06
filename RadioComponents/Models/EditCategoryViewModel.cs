using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models
{
    public class EditCategoryViewModel<TConfig>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public TConfig Configuration { get; set; }
    }
}
