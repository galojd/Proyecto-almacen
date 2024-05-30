using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class CompraPago
    {
        public Guid CompraPagoId{ get; set; }
        public DateTime? FechaPago{ get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public Decimal? MontoPago{ get; set; }
        public Guid? MetodoPagoId{get; set; }
        public MetodoPago? MetodoPago{ get; set; }

    }//Ya esta
}