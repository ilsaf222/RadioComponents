using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.CategoryViewModels.Capacitor
{
    public class СapacitorCategoryViewModel
    {
        [Display(Name = "Рабочее напряжение, B")]
        public int WorkVolt { get; set; }

        [Display(Name = "Номинальная емкость,мкФ")]
        public int RatedCapacity { get; set; }

        [Display(Name = "Допуск номинальной емкости, %")]
        public int RatedCapacityTolerance { get; set; }

        [Display(Name = "Тангенс угла потерь, %")]
        public int LossTangent { get; set; }

        [Display(Name = "Выводы/корпус")]
        public string ConclusionsAndCase { get; set; }



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
