using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class MetodoPago
    {
        public Guid MetodoPagoId{ get; set; }
        public string? TipoMetodo{ get; set; }
    }

    
}