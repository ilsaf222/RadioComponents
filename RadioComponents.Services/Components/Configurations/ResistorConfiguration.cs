using System;
using System.Collections.Generic;
using System.Text;

namespace RadioComponents.Services.Components.Configurations
{
    public class ResistorConfiguration
    {
        public string ResType { get; set; }
        public int Resistance { get; set; }
        public int Accuracy { get; set; }
        public int Power { get; set; }
        public int MaxVoltage { get; set; } 
        public int MinOperatingTemp { get; set; } 
        public int MaxOperatingTemp { get; set; }
        public int BLength { get; set; }
        public int DiameterB { get; set; }
        public int Weight { get; set; }
    }
}
