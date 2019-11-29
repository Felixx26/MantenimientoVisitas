using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MantenimientoVisitas.Models
{
    public class Visita
    {
        public int VisitaID { get; set; }
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int PersonaID { get; set; }
        public virtual Persona Persona { get; set; }
        public string Motivo { get; set; }



    }
}