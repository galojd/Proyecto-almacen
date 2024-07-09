using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Aplicacion.Reportes;
using Dominio.entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Net;

namespace Aplicacion.Productos
{
    public class Consulta_producto_stock
    {
        public class Ejecuta: IRequest<ReporteStockBajo>{
            public String Nombre{get;set;}
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, ReporteStockBajo>
        {
            private readonly AlmacenOnlineContext _contexto;
            public Manejador(AlmacenOnlineContext contexto){
                _contexto = contexto;
            }
            public async Task<ReporteStockBajo> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.Producto
                                    .Where(p => p.Nombre == request.Nombre)
                                    .Include(p => p.Categoria)
                                    .Include(p => p.DetalleInventariolista)
                                        .ThenInclude(di => di.Inventario)
                                        //.Where(p => p.NombreProducto == request.Nombre)
                                        .Select(p => new ReporteStockBajo
                                        {
                                            Id = p.ProductoId,
                                            NombreProducto = p.Nombre,
                                            StockMinimo = p.StockMinimo,
                                            Stocktotal = p.DetalleInventariolista.FirstOrDefault().StockTotal,
                                            Descripcion = p.Descripcion,
                                            Comentario = (p.DetalleInventariolista.FirstOrDefault().StockTotal ?? 0) < (p.StockMinimo ?? 0)
                                                            ? "El stock del producto es bajo, es necesario reponer"
                                                            : "Stock suficiente"
                                        })
                                        .FirstOrDefaultAsync(cancellationToken);
                /*if(producto == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el registro"});
                    
                }  */                  
                return producto;
            }
        }
    }
}