using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Inventarios;
using Dominio.entities;
using AutoMapper;
using Dominio;
using Aplicacion.Ventas;
using Aplicacion.Devoluciones;

namespace Aplicacion
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<Inventario,InventarioDTO>()
            .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.DetalleInventariolista.Select(d => d.Producto).ToList()));
            CreateMap<DetalleInventario,DetalleInventarioDTO>();
            CreateMap<DetallePedido,DetallePedidoDto>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Venta, VentaDto>()
            .ForMember(d => d.Productos, op => op.MapFrom(src => src.DetallePedidolista.Select(d => d.Producto).ToList()));
        }
    }
}