using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoVisitas.Models
{
    public class Area
    {
        public int AreaID { get; set; }
        public string NombreArea { get; set; }
        public Boolean Estado { get; set; }
        public int NumerosVisita { get; set; }
        public virtual ICollection<Visita> Visita { get; set; }

    }
}