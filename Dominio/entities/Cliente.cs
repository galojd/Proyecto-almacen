using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class Cliente
    {
        public Guid ClienteId{get;set;}  
        public string? DNI{get;set;}
        public string? RUC{get;set;}   
        public string? Nombres{get;set;}
        public string? Telefono{get;set;}
        public string? Email{get;set;}
        public string? Direccion{get;set;}
        public DateTime? Fecharegistro{get;set;}
        public ICollection<Venta>? Ventalista{get;set;}
        
    }
} 