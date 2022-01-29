using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RadioComponents.Domain.Models
{
    public enum ComponType
    {
        [Display(Name = "Резистор")]
        Resistor = 0,

        [Display(Name = "Конденсатор")]
        Сapacitor = 1,

        [Display(Name = "Диод")]
        Diode = 2,

        [Display(Name = "Микросхема")]
        Microchip = 3,

        [Display(Name = "Предохранитель")]
        Fuse = 4,

        [Display(Name = "Транзистор")]
        Transistor = 5,

        [Display(Name = "Тиристор")]
        Thyristor = 6,

        [Display(Name = "Трансформатор")]
        Transformator = 7,

        [Display(Name = "Реле")]
        Rele = 8
    }
}
