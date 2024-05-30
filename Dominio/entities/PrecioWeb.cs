using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.entities
{
    public class PrecioWeb
    {
        public Guid PrecioWebId{ get; set; }
        public string? Url{ get;set; }

        public ICollection<PrecioWebProducto>? PrecioWeblista{get;set;}

        //ya esta
    }
}