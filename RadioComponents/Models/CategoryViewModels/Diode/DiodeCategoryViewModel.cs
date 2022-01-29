using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.CategoryViewModels.Diode
{
    public class DiodeCategoryViewModel
    {
        [Display(Name = "Кол-во диодов в корпусе")]
        public int NumberDiodesCase { get; set; }

        [Display(Name = "Конфигурация диода")]
        public string DiodeConfiguration { get; set; }

        [Display(Name = "Максимальное постоянное обратное напряжение, Vr (Вольт)")]
        public int MaxDCReverseVolt { get; set; }

        [Display(Name = "Максимальный (средний) прямой ток на диод, If(AV) (A)")]
        public int MaximumForwardCurrent { get; set; }

        [Display(Name = "Максимальное прямое напряжение при Tj=25 °C, Vf при If")]
        public string MaxForwardVoltAt25 { get; set; }

        [Display(Name = "Максимальный обратный ток при Tj=25 °C, Ir при Vr")]
        public string MaxReverseCurrentAt25 { get; set; }

        [Display(Name = "Емкость при Vr, F")]
        public string CapacityAtVr { get; set; }

        [Display(Name = "Рабочая температура PN-прехода")]
        public string OperatingTempPNJunction { get; set; }

        [Display(Name = "Корпус")]
        public string Case { get; set; }

        [Display(Name = "Вес, г")]
        public string Weight { get; set; }

    }
}
