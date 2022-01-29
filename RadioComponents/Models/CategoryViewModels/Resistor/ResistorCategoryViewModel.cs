using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.CategoryViewModels.Resistor
{
    public class ResistorCategoryViewModel
    {
        [Display(Name = "Тип")]
        public string ResType { get; set; }

        [Display(Name = "Сопротивление, Ом")]
        public int Resistance { get; set; }

        [Display(Name = "Точность, %")]
        public int Accuracy { get; set; }

        [Display(Name = "Мощность, С")]
        public int Power { get; set; }

        [Display(Name = "Макс.рабочее напряжение, В")]
        public int MaxVoltage { get; set; }



        [Display(Name = "Минимальная рабочая температура, С")]
        public int MinimumWorkTemp { get; set; }

        [Display(Name = "Максимальная рабочая температура, С")]
        public int MaximumWorkTemp { get; set; }

        [Display(Name = "Диаметр корпуса, мм")]
        public int CaseDiameter { get; set; }

        [Display(Name = "Длина корпуса, мм")]
        public int CaseLength { get; set; }

        [Display(Name = "Вес, г")]
        public int Weight { get; set; }

    }
}
