using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RadioComponents.Domain.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Не получен клиентом")]
        NotGiven = 0,

        [Display(Name = "Получен клиентом")]
        Given = 1,  

        [Display(Name = "Просрочен")]
        Expired = 2
    }
}
