using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RadioComponents.Domain.Entities
{
    public class Сategory
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public Models.ComponType Type { get; set; }
        public List<Component> Components { get; set; }

        [Column(TypeName = "jsonb")]
        public string ComponentsInfoString { get; set; }
    }
}
