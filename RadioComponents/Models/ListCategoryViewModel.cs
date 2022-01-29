using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models
{
    public class ListCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Тип")]
        public Domain.Models.ComponType Type { get; set; }
    }
}
