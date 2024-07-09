using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class DatosEscaneo
    {
        public Guid DatosEscaneoId{ get; set; }
        public int? NuevoStock{ get; set; }
        public int? AnteriorStock{ get; set; }
        public Guid? ProductoId{ get; set; }
        public DateTime? FechaActualizacion{ get; set; }
    }
}