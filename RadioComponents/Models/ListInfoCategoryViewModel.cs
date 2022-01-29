using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models
{
    public class ListInfoCategoryViewModel<TConfiguration>
    {
        [Display(Name = "Тип элемента")]
        public Domain.Models.ComponType Type { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public TConfiguration Configuration { get; set; }
    }
}
