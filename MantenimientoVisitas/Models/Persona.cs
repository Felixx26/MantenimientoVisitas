using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoVisitas.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}