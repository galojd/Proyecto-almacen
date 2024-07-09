using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.entities
{
    public class Proveedor
    {
        public Guid ProveedorId{get;set;}     
        public string? Nombre{get;set;}
        public string? Contacto{get;set;}
        public string? Telefono{get;set;}
        public string? Direccion{get;set;}
        public string? Email{get;set;}
        public string? RUC{get;set;}
        public DateTime? Fecharegistro{get;set;}
        public Guid? ProductoProveedorId{get;set;}
        public ProductoProveedor? ProductoProveedor{get;set;}
        public ICollection<Inventario>? Inventariolista{get;set;}
        
       
    }//Ya esta
}