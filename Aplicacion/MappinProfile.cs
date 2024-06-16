using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;
using Dominio.entities;
using AutoMapper;
using Dominio;

namespace Aplicacion
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<Inventario,InventarioDTO>()
            .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.DetalleInventariolista.Select(d => d.Producto).ToList()));
            CreateMap<DetalleInventario,DetalleInventarioDTO>();
            CreateMap<Producto, ProductoDTO>();
           
        }
    }
}