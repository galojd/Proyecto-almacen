using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class IdentityCoreInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecharegistro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "DatosEscaneo",
                columns: table => new
                {
                    DatosEscaneoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NuevoStock = table.Column<int>(type: "int", nullable: true),
                    AnteriorStock = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEscaneo", x => x.DatosEscaneoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoMetodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "PrecioWeb",
                columns: table => new
                {
                    PrecioWebId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioWeb", x => x.PrecioWebId);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preciocompra = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Preciounitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => x.ProductoProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "CompraPago",
                columns: table => new
                {
                    CompraPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MontoPago = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MetodoPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraPago", x => x.CompraPagoId);
                    table.ForeignKey(
                        name: "FK_CompraPago_MetodoPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoId");
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecharegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedor_ProductoProveedor_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedor",
                        principalColumn: "ProductoProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "PrecioWebProducto",
                columns: table => new
                {
                    PrecioWebProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnteriorPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NuevoPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrecioWebId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioWebProducto", x => x.PrecioWebProductoId);
                    table.ForeignKey(
                        name: "FK_PrecioWebProducto_PrecioWeb_PrecioWebId",
                        column: x => x.PrecioWebId,
                        principalTable: "PrecioWeb",
                        principalColumn: "PrecioWebId");
                    table.ForeignKey(
                        name: "FK_PrecioWebProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    DetallePedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.DetallePedidoId);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_DetallePedido_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadProducto = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventario_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "Devolucion",
                columns: table => new
                {
                    DevolucionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallePedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucion", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK_Devolucion_DetallePedido_DetallePedidoId",
                        column: x => x.DetallePedidoId,
                        principalTable: "DetallePedido",
                        principalColumn: "DetallePedidoId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleInventario",
                columns: table => new
                {
                    DetalleInventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockAnterior = table.Column<int>(type: "int", nullable: true),
                    StockIngreso = table.Column<int>(type: "int", nullable: true),
                    StockTotal = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleInventario", x => x.DetalleInventarioId);
                    table.ForeignKey(
                        name: "FK_DetalleInventario_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "InventarioId");
                    table.ForeignKey(
                        name: "FK_DetalleInventario_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "InventarioProducto",
                columns: table => new
                {
                    InventarioProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fechaentrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioProducto", x => x.InventarioProductoId);
                    table.ForeignKey(
                        name: "FK_InventarioProducto_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "InventarioId");
                    table.ForeignKey(
                        name: "FK_InventarioProducto_ProductoProveedor_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedor",
                        principalColumn: "ProductoProveedorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompraPago_MetodoPagoId",
                table: "CompraPago",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInventario_InventarioId",
                table: "DetalleInventario",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInventario_ProductoId",
                table: "DetalleInventario",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoId",
                table: "DetallePedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_VentaId",
                table: "DetallePedido",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucion_DetallePedidoId",
                table: "Devolucion",
                column: "DetallePedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProveedorId",
                table: "Inventario",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_InventarioId",
                table: "InventarioProducto",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_ProductoProveedorId",
                table: "InventarioProducto",
                column: "ProductoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioWebProducto_PrecioWebId",
                table: "PrecioWebProducto",
                column: "PrecioWebId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioWebProducto_ProductoId",
                table: "PrecioWebProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_ProductoProveedorId",
                table: "Proveedor",
                column: "ProductoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompraPago");

            migrationBuilder.DropTable(
                name: "DatosEscaneo");

            migrationBuilder.DropTable(
                name: "DetalleInventario");

            migrationBuilder.DropTable(
                name: "Devolucion");

            migrationBuilder.DropTable(
                name: "InventarioProducto");

            migrationBuilder.DropTable(
                name: "PrecioWebProducto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "PrecioWeb");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProductoProveedor");
        }
    }
}
